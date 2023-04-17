using System;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace ExportarDataGridViewExcel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonExportar_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear un objeto de conexión a Excel
                OleDbConnection conn = new OleDbConnection();
                conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=tabla.xlsx;Extended Properties='Excel 12.0 Xml;HDR=YES';";

                // Abrir la conexión
                conn.Open();

                // Crear un objeto de comando SQL para crear una nueva hoja de Excel
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                cmd.CommandText = "CREATE TABLE [Tabla1] ([Columna1] TEXT, [Columna2] TEXT, [Columna3] TEXT)";

                // Ejecutar el comando SQL
                cmd.ExecuteNonQuery();

                // Insertar los datos del DataGridView en la nueva hoja de Excel
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    cmd.CommandText = "INSERT INTO [Tabla1] ([Columna1], [Columna2], [Columna3]) VALUES ('" + row.Cells[0].Value.ToString() + "', '" + row.Cells[1].Value.ToString() + "', '" + row.Cells[2].Value.ToString() + "')";
                    cmd.ExecuteNonQuery();
                }

                // Cerrar la conexión
                conn.Close();

                MessageBox.Show("Los datos se han exportado correctamente a Excel.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error al exportar los datos a Excel: " + ex.Message);
            }
        }
    }
}
