using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroAlumnos_CelestePerezJosaelZurita
{
    internal class CRUD
    {


        private Conexion cn = new Conexion();

        public void InsertarAlumno(TextBox textNombre, TextBox textCedu, TextBox textCon,
            TextBox textCon2, ComboBox combo1, ComboBox combo2,
            RadioButton rbtMat, RadioButton rbtVis, CheckBox check2, TextBox textUser)
        {
            try
            {
                SqlConnection conn = cn.Abrir();

                string sql = @"INSERT INTO Alumnos
                               (Nombre, Cedula, Carrera, Semestre, Jornada, Usuario, Contrasena, RecibirNotificaciones)
                               VALUES (@Nombre, @Cedula, @Carrera, @Semestre, @Jornada, @Usuario, @Contrasena, @Noti)";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Nombre", textNombre.Text.Trim());
                cmd.Parameters.AddWithValue("@Cedula", textCedu.Text.Trim());
                cmd.Parameters.AddWithValue("@Carrera", combo1.Text);
                cmd.Parameters.AddWithValue("@Semestre", combo2.Text);

                string jornada = rbtMat.Checked ? "Matutina" : "Vespertina";
                cmd.Parameters.AddWithValue("@Jornada", jornada);

                cmd.Parameters.AddWithValue("@Usuario", textUser.Text.Trim());
                cmd.Parameters.AddWithValue("@Contrasena", textCon.Text.Trim());
                cmd.Parameters.AddWithValue("@Noti", check2.Checked);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Alumno guardado exitosamente ✔️",
                    "INSERT", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cn.Cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error INSERT ❌\n" + ex.Message);
            }
        }



        // UPDATE
        public void ActualizarAlumnoPorID(int id, TextBox textNombre, TextBox textCedu, TextBox textCon, TextBox textCon2,
                                          ComboBox combo1, ComboBox combo2, RadioButton rbtMat, RadioButton rbtVis,
                                          CheckBox check2, TextBox textUser)
        {
            try
            {
                SqlConnection conn = cn.Abrir();

                string sql = @"UPDATE Alumnos SET
                        Nombre=@Nombre,
                        Cedula=@Cedula,
                        Carrera=@Carrera,
                        Semestre=@Semestre,
                        Jornada=@Jornada,
                        Usuario=@Usuario,
                        Contrasena=@Contrasena,
                        RecibirNotificaciones=@Noti
                        WHERE ID=@ID";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Nombre", textNombre.Text.Trim());
                cmd.Parameters.AddWithValue("@Cedula", textCedu.Text.Trim());
                cmd.Parameters.AddWithValue("@Carrera", combo1.Text);
                cmd.Parameters.AddWithValue("@Semestre", combo2.Text);

                string jornada = rbtMat.Checked ? "Matutina" : "Vespertina";
                cmd.Parameters.AddWithValue("@Jornada", jornada);

                cmd.Parameters.AddWithValue("@Usuario", textUser.Text.Trim());
                cmd.Parameters.AddWithValue("@Contrasena", textCon.Text.Trim());
                cmd.Parameters.AddWithValue("@Noti", check2.Checked);
                cmd.Parameters.AddWithValue("@ID", id);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Alumno actualizado correctamente ✔️", "UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cn.Cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error UPDATE ❌\n" + ex.Message);
            }
        }

        // DELETE
        public bool EliminarAlumnoPorID(int id)
        {
            
            try
            {
                SqlConnection conn = cn.Abrir();
                string sql = "DELETE FROM Alumnos WHERE ID=@ID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", id);

                int filas = cmd.ExecuteNonQuery();
                cn.Cerrar();

                if (filas > 0)
                {
                    MessageBox.Show("Alumno eliminado correctamente ✔️", "DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("No se encontró el alumno a eliminar.", "DELETE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error DELETE ❌\n" + ex.Message);
                return false;
            }
        }


        public void BuscarPorCedula(TextBox cedula,
            TextBox textNombre, TextBox textCedu, ComboBox combo1, ComboBox combo2,
            RadioButton rbtMat, RadioButton rbtVis, CheckBox check2, TextBox textUser, TextBox textCon)
        {
            try
            {
                SqlConnection conn = cn.Abrir();

                string sql = "SELECT * FROM Alumnos WHERE Cedula=@Cedula";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Cedula", cedula.Text.Trim());

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    textNombre.Text = dr["Nombre"].ToString();
                    textCedu.Text = dr["Cedula"].ToString();
                    combo1.Text = dr["Carrera"].ToString();
                    combo2.Text = dr["Semestre"].ToString();
                    textUser.Text = dr["Usuario"].ToString();
                    textCon.Text = dr["Contrasena"].ToString();

                    string j = dr["Jornada"].ToString();
                    rbtMat.Checked = j == "Matutina";
                    rbtVis.Checked = j == "Vespertina";

                    check2.Checked = Convert.ToBoolean(dr["RecibirNotificaciones"]);
                }
                else
                {
                    MessageBox.Show("No existe esa cédula ❌");
                }

                dr.Close();
                cn.Cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error BUSCAR ❌\n" + ex.Message);
            }
        }



    }
}
