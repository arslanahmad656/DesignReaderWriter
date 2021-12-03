using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;
using System.Data.SqlClient;

namespace DesignReaderWriter
{
    public partial class mainForm : Form
    {
        private string connectionString;
        private string designType;
        private int designId;

        private const string dataFileName = "store.json";

        public mainForm()
        {
            InitializeComponent();
        }

        private void ValidateParams()
        {
            var connectionString = txt_ConnectionString.Text;
            var designType = cmb_DesignType.SelectedItem as string;
            var canDesignIdBeParsed = int.TryParse(txt_DesignID.Text, out var designId);

            if (string.IsNullOrWhiteSpace(connectionString)) throw new InvalidOperationException($"Connection string is required.");
            if (string.IsNullOrWhiteSpace(designType)) throw new InvalidOperationException($"Design type is required.");
            if (!canDesignIdBeParsed) throw new InvalidOperationException($"Please provide a valid ID in design type.");

            this.connectionString = connectionString;
            this.designType = designType;
            this.designId = designId;
        }

        private void SaveParams()
        {
            try
            {
                var obj = new DTO
                {
                    ConnectionString = connectionString,
                    DesignId = designId,
                    DesignType = designType,
                };

                var serialized = JsonSerializer.Serialize(obj);
                File.WriteAllText(dataFileName, serialized);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error saving the params", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadParams()
        {
            try
            {
                var serialized = File.ReadAllText(dataFileName);
                var dto = JsonSerializer.Deserialize<DTO>(serialized);

                txt_ConnectionString.Text = dto.ConnectionString;
                cmb_DesignType.SelectedItem = dto.DesignType;
                txt_DesignID.Text = dto.DesignId.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading the params", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            LoadParams();
        }



        private (string idColumn, string table, string selectionColumn) GetParams()
        {
            ValidateParams();
            var idColumnName = designType.Equals("Design", StringComparison.InvariantCultureIgnoreCase)
                ? "ID" : designType.Equals("Template", StringComparison.InvariantCultureIgnoreCase) ? "TemplateID"
                : throw new InvalidOperationException($"Invalid design type. Please select valid value from the dropdown.");
            var tableName = designType.Equals("Design", StringComparison.InvariantCultureIgnoreCase)
                ? "SSPR.PortalDesigns" : designType.Equals("Template", StringComparison.InvariantCultureIgnoreCase) ? "SSPR.PortalDesignTemplates"
                : throw new InvalidOperationException($"Invalid design type. Please select valid value from the dropdown.");
            var selectionColumnName = designType.Equals("Design", StringComparison.InvariantCultureIgnoreCase)
                ? "Design" : designType.Equals("Template", StringComparison.InvariantCultureIgnoreCase) ? "Template"
                : throw new InvalidOperationException($"Invalid design type. Please select valid value from the dropdown.");

            return (idColumnName, tableName, selectionColumnName);
        }

        private void btn_Read_Click(object sender, EventArgs e)
        {
            try
            {
                var (idColumn, table, selectionColumn) = GetParams();
                using var connection = new SqlConnection(connectionString);
                connection.Open();

                var idParam = "@@__ID__";

                var query = $"SELECT {selectionColumn} FROM {table} WHERE {idColumn} = {idParam}";
                using var command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter(idParam, designId));

                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var design = reader.GetString(0);
                    txt_Design.Text = design;

                    SaveParams();
                }
                else
                {
                    throw new Exception($"Could not find a design with the given parameters.");
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error reading design", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Write_Click(object sender, EventArgs e)
        {
            try
            {
                var (idColumn, table, selectionColumn) = GetParams();
                var design = txt_Design.Text;
                if (string.IsNullOrWhiteSpace(design))
                {
                    throw new InvalidOperationException($"Design cannot be empty for this operation.");
                }

                using var connection = new SqlConnection(connectionString);
                connection.Open();

                var designParam = "@@__DESIGN__";
                var idParam = "@@__ID__";

                var query = $"UPDATE {table} SET {selectionColumn} = {designParam} WHERE {idColumn} = {idParam}";
                using var command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter(designParam, design));
                command.Parameters.Add(new SqlParameter(idParam, designId));

                var rowAffectedCount = command.ExecuteNonQuery();
                if (rowAffectedCount > 0)
                {
                    MessageBox.Show($"Design has been changed. {rowAffectedCount} {(rowAffectedCount > 1 ? "rows were" : "row was")} updated.");
                    SaveParams();
                }
                else
                {
                    MessageBox.Show($"Could not update the design. Query returned number of affected rows: {rowAffectedCount}.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error saving design", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
