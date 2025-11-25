using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace RegistroAlumnos_CelestePerezJosaelZurita
{
    public partial class Form1 : Form
    {
        // Lista para almacenar los estudiantes registrados
        private List<string> estudiantesRegistrados = new List<string>();
        private CRUD crud = new CRUD();
        public Form1()
        {
            InitializeComponent();
            //centrar la ventana
            this.StartPosition = FormStartPosition.CenterScreen;
            ActualizarContador();
            CargarListBox();
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
            Validar v = new Validar();
            if (v.ValidarCampos(textNombre, textCedu, textCon,
                                textCon2, check1,
                                combo1, combo2,
                                rbtMat, rbtVis, check2))
            {
                MessageBox.Show("Validación correcta ✔️", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Salir del formulario
        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Close();
        }

        private void ActualizarListBox()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = estudiantesRegistrados;
            txtContAlumno.Text = estudiantesRegistrados.Count.ToString();
        }


        //configuracion del botón 2 de guardar, guarda los datos como tal!!!
        private void btnGua2_Click(object sender, EventArgs e)
        {
            Validar v = new Validar();
            if (!v.ValidarCampos(textNombre, textCedu, textCon,
                                 textCon2, check1,
                                 combo1, combo2,
                                 rbtMat, rbtVis, check2))
            {
                return; // Si falla validación, no insertar
            }

            // Guardar en SQL
            crud.InsertarAlumno(textNombre, textCedu, textCon, textCon2,
                                combo1, combo2, rbtMat, rbtVis, check2, textUser);

            // Solo actualizar lista de nombres (ListBox), sin tocar campos
            CargarListBox();

            // Limpiar los campos solo si quieres preparar para un nuevo registro
            btnNuevo2.PerformClick();
        }


        private void CargarListBox()
        {
            estudiantesRegistrados.Clear(); // limpiar lista local

            try
            {
                using (SqlConnection conn = new Conexion().Abrir())
                {
                    SqlCommand cmd = new SqlCommand("SELECT Nombre FROM Alumnos ORDER BY Nombre", conn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        estudiantesRegistrados.Add(dr["Nombre"].ToString());
                    }

                    dr.Close();
                }

                // Actualizar ListBox
                listBox1.DataSource = null;
                listBox1.DataSource = estudiantesRegistrados;
                txtContAlumno.Text = estudiantesRegistrados.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando la lista: " + ex.Message);
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
                   "Versión: 2.0\n" +
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

            if (e.Control && e.KeyCode == Keys.D)
            {
                btnEliminar.PerformClick();
            }

            if (e.Control && e.KeyCode == Keys.E)
            {
                btnEditar.PerformClick();
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

        //botón para comprobar la conexion correcta o posibles errores en su trascurso 
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Conexion cn = new Conexion();
                cn.Abrir();

                MessageBox.Show("Conexión exitosa", "SQL", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cn.Cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión\n" + ex.Message, "SQL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!estaEditando)
            {
                MessageBox.Show("Haz doble click sobre un alumno para editar.", "Aviso");
                return;
            }

            Validar v = new Validar();
            if (!v.ValidarCampos(textNombre, textCedu, textCon, textCon2,
                                 check1, combo1, combo2, rbtMat, rbtVis, check2))
            {
                return;
            }

            if (MessageBox.Show("¿Deseas actualizar este alumno?", "Editar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                crud.ActualizarAlumno(textNombre, textCedu, textCon, textCon2,
                                      combo1, combo2, rbtMat, rbtVis, check2, textUser);

                // Recargar lista desde SQL
                CargarListBox();

                // Limpiar campos y desactivar edición
                btnNuevo2.PerformClick();
                estaEditando = false;
            }

        }

        //Botón para eliminar un estudiante
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Selecciona un estudiante para eliminar.");
                return;
            }

            string nombreEliminar = listBox1.SelectedItem.ToString();
            string cedulaEliminar = textCedu.Text.Trim();

            if (crud.EliminarAlumnoPorCedula(cedulaEliminar)) 
            {
                estudiantesRegistrados.Remove(nombreEliminar);
                ActualizarListBox();
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
           
        }

        //Logica para listBox al doble click se puede editar o eliminar 
        private bool estaEditando = false;
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                string nombreSeleccionado = listBox1.SelectedItem.ToString();
                SqlConnection conn = new Conexion().Abrir();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Alumnos WHERE Nombre=@Nombre", conn);
                cmd.Parameters.AddWithValue("@Nombre", nombreSeleccionado);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    estaEditando = true;
                    textNombre.Text = dr["Nombre"].ToString();
                    textCedu.Text = dr["Cedula"].ToString();
                    combo1.Text = dr["Carrera"].ToString();
                    combo2.Text = dr["Semestre"].ToString();
                    rbtMat.Checked = dr["Jornada"].ToString() == "Matutina";
                    rbtVis.Checked = dr["Jornada"].ToString() == "Vespertina";
                    check2.Checked = Convert.ToBoolean(dr["RecibirNotificaciones"]);
                    textUser.Text = dr["Usuario"].ToString();
                    textCon.Text = dr["Contrasena"].ToString();
                }

                dr.Close();
                new Conexion().Cerrar();
            }
        }


    }//fin
}