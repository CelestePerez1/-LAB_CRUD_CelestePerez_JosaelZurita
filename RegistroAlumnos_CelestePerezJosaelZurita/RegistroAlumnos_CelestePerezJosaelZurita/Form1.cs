using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RegistroAlumnos_CelestePerezJosaelZurita
{
    public partial class Form1 : Form
    {
        // Lista para almacenar los estudiantes registrados
        private List<string> estudiantesRegistrados = new List<string>();

        public Form1()
        {
            InitializeComponent();
            //centrar la ventana
            this.StartPosition = FormStartPosition.CenterScreen;
            ActualizarContador();
        }

        private void btnNuevo2_Click(object sender, EventArgs e)
        {
            //Botón para limpiar 
            textNombre.Clear();
            textCedu.Clear();
            combo1.SelectedIndex = -1;
            combo2.SelectedIndex = -1;
            textUser.Clear();
            textCon.Clear();
            textCon2.Clear();
            rbtMat.Checked = false;
            rbtVis.Checked = false;
            check1.Checked = false;
            check2.Checked = false;
        }

        private void btnGua1_Click(object sender, EventArgs e)
        {
            //valida datos y despues debe mostrar esos datos en el listBox
            Validar v = new Validar();
            if (v.ValidarCampos(textNombre, textCedu, textCon,
                                textCon2, check1,
                                combo1, combo2,
                                rbtMat, rbtVis, check2))
            {
                // Agregar el nombre del estudiante a la lista
                string nombreEstudiante = textNombre.Text.Trim();
                estudiantesRegistrados.Add(nombreEstudiante);

                // Actualizar el ListBox con la lista completa
                listBox1.DataSource = null;
                listBox1.DataSource = estudiantesRegistrados;

                // Actualizar el contador
                ActualizarContador();

                MessageBox.Show("Estudiante registrado exitosamente.",
                               "Éxito",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
            }
        }

        //Salir del formulario
        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Close();
        }

        //configuracion del botón 2 de guardar, guarda los datos como tal!!!
        private void btnGua2_Click(object sender, EventArgs e)
        {
            Validar v = new Validar();
            if (v.ValidarCampos(textNombre, textCedu, textCon,
                                textCon2, check1,
                                combo1, combo2,
                                rbtMat, rbtVis, check2))
            {
                // Agregar el nombre del estudiante a la lista
                string nombreEstudiante = textNombre.Text.Trim();
                estudiantesRegistrados.Add(nombreEstudiante);

                // Actualizar el ListBox con la lista completa
                listBox1.DataSource = null;
                listBox1.DataSource = estudiantesRegistrados;

                // Actualizar el contador
                ActualizarContador();

                MessageBox.Show("Estudiante registrado exitosamente.",
                               "Éxito",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);

                // Limpiar los campos después de guardar
                btnNuevo2.PerformClick();
            }
        }

        // Método para actualizar el contador de estudiantes
        private void ActualizarContador()
        {
            txtContAlumno.Text = estudiantesRegistrados.Count.ToString();
        }

        //Botón de ayuda
        private void btnAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aplicación: Registro de Alumnos\n" +
                   "Versión: 1.0\n" +
                   "Autor: Celeste Pérez y Josael Zurita \n",
                   "Ayuda",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
        }

        //Configurar atajos(limpiar y guardar)
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Ctrl + S: guardar
            if (e.Control && e.KeyCode == Keys.S)
            {
                btnGua2.PerformClick();
            }
            // ESC: limpiar
            if (e.KeyCode == Keys.Escape)
            {
                btnNuevo2.PerformClick();
            }
        }

        private void txtContAlumno_TextChanged(object sender, EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        private void textNombre_TextChanged_1(object sender, EventArgs e)
        {
            GenerarUsuario();
        }

         private void textCedu_TextChanged(object sender, EventArgs e)
        {
            GenerarUsuario();
        }

        private void GenerarUsuario()
        {
            string nombre = textNombre.Text.Trim();
            string cedula = textCedu.Text.Trim();

            if (!string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(cedula))
            {
                // primera letra del nombre + cédula
                string usuario = nombre[0].ToString().ToLower() + cedula;
                textUser.Text = usuario;
            }
            else
            {
                textUser.Clear();
            }
        }

       
    }//fin
}