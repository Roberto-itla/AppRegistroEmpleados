using CapaDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDiseño
{
    public partial class Form1 : Form
    {

        //Creacion de instancia de la clase Procedures

        Procedures pr = new Procedures();
        private string id = null;
        private bool edit = false;


        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        public void ShowData()
        {
            Procedures obj = new Procedures();
            dataGridView1.DataSource = obj.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                id = dataGridView1.CurrentRow.Cells["Id_empleados"].Value.ToString();
                pr.Delete(Convert.ToInt32(id));
                MessageBox.Show("El registro fue eliminado exitosamente!");
                ShowData();
            }
            else
            {
                MessageBox.Show("Error al intentar Eliminar el registro");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (edit == false)
            {
                try
                {
                    pr.Insert(textName.Text, textLastNames.Text, textPosition.Text);
                    MessageBox.Show("Los campos se agregaron correctamente!");
                    ShowData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"ERROR al Ingresar los datos :c {ex}");
                }
            }
            if (edit == true)
            {
                try
                {
                    pr.Update(Convert.ToInt32(id), textName.Text, textLastNames.Text, textPosition.Text);
                    MessageBox.Show("Los campos se actualizaron correctamente!");
                    ShowData();
                    edit = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"ERROR al Ingresar los datos :c {ex}");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                edit = true;
                id = dataGridView1.CurrentRow.Cells["Id_empleados"].Value.ToString();
                textName.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                textLastNames.Text = dataGridView1.CurrentRow.Cells["Apellidos"].Value.ToString();
                textPosition.Text = dataGridView1.CurrentRow.Cells["Cargo"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione un registo");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textName.Clear();
            textLastNames.Clear();
            textPosition.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowData();
        }
    }
}
