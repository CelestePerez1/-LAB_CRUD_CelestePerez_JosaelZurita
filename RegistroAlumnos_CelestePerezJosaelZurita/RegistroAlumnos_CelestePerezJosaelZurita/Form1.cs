using Microsoft.Reporting.NETCore;
using System.Data.SqlClient;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace RegistroAlumnos_CelestePerezJosaelZurita
{
    public partial class Form1 : Form
    {
        // Lista para almacenar los estudiantes registrados
        private List<string> estudiantesRegistrados = new List<string>();
        private List<int> idsRegistrados = new List<int>(); // Guardamos IDs para referencia
        private int idActual = -1;
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
            txtBuscar.Clear();
            rbtMat.Checked = false;
            rbtVis.Checked = false;
            check1.Checked = false;
            check2.Checked = false;
        }

        private void btnGua1_Click(object sender, EventArgs e)
        {
            Validar v = new Validar();
            if (!v.ValidarCampos(textNombre, textCedu, textCon,
                                 textCon2, check1,
                                 combo1, combo2,
                                 rbtMat, rbtVis, check2))
            {
                return; // Si falla validación, no continuar
            }

            // Validar que la cédula no esté duplicada en SQL
            using (SqlConnection conn = new Conexion().Abrir())
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Alumnos WHERE Cedula=@Cedula", conn);
                cmd.Parameters.AddWithValue("@Cedula", textCedu.Text.Trim());
                int existe = Convert.ToInt32(cmd.ExecuteScalar());
                if (existe > 0)
                {
                    MessageBox.Show("La cédula ya está registrada. No se puede duplicar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            MessageBox.Show("Validación correcta ✔️", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (!v.ValidarCampos(textNombre, textCedu, textCon, textCon2,
                                 check1, combo1, combo2, rbtMat, rbtVis, check2))
            {
                return; // Si falla validación, no insertar
            }

            if (CedulaExiste(textCedu.Text.Trim()))
            {
                MessageBox.Show("La cédula ya está registrada. Usa otra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Guardar en SQL
            crud.InsertarAlumno(textNombre, textCedu, textCon, textCon2,
                                combo1, combo2, rbtMat, rbtVis, check2, textUser);

            // Recargar lista desde SQL
            CargarListBox();

            // Limpiar campos
            btnNuevo2.PerformClick();
        }


        private bool CedulaExiste(string cedula)
        {
            try
            {
                using (SqlConnection conn = new Conexion().Abrir())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Alumnos WHERE Cedula=@Cedula", conn);
                    cmd.Parameters.AddWithValue("@Cedula", cedula);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        private void CargarListBox()
        {
            estudiantesRegistrados.Clear();
            idsRegistrados.Clear();

            try
            {
                using (SqlConnection conn = new Conexion().Abrir())
                {
                    SqlCommand cmd = new SqlCommand("SELECT ID, Nombre, Carrera, Jornada FROM Alumnos ORDER BY Nombre", conn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        int id = Convert.ToInt32(dr["ID"]);
                        string item = $"{id} — {dr["Nombre"]} — {dr["Carrera"]} — {dr["Jornada"]}";
                        estudiantesRegistrados.Add(item);
                        idsRegistrados.Add(id);
                    }

                    dr.Close();
                }

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
            if (!estaEditando || idActual == -1)
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

            // Validar cédula duplicada (excepto este mismo alumno)
            if (CedulaExiste(textCedu.Text.Trim(), idActual))
            {
                MessageBox.Show("La cédula ya está registrada en otro alumno.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Deseas actualizar este alumno?", "Editar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                crud.ActualizarAlumnoPorID(idActual, textNombre, textCedu, textCon, textCon2,
                                           combo1, combo2, rbtMat, rbtVis, check2, textUser);

                CargarListBox();
                btnNuevo2.PerformClick();
                estaEditando = false;
                idActual = -1;
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

            int idAEliminar = idsRegistrados[listBox1.SelectedIndex];

            if (crud.EliminarAlumnoPorID(idAEliminar))
            {
                CargarListBox();
                btnNuevo2.PerformClick();
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
                idActual = idsRegistrados[listBox1.SelectedIndex]; // tomamos el ID

                try
                {
                    using (SqlConnection conn = new Conexion().Abrir())
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Alumnos WHERE ID=@ID", conn);
                        cmd.Parameters.AddWithValue("@ID", idActual);
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
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error cargando alumno: " + ex.Message);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string cedulaBuscada = txtBuscar.Text.Trim();
            if (string.IsNullOrEmpty(cedulaBuscada))
            {
                MessageBox.Show("Ingresa una cédula para buscar.");
                return;
            }

            try
            {
                using (SqlConnection conn = new Conexion().Abrir())
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Alumnos WHERE Cedula=@Cedula", conn);
                    cmd.Parameters.AddWithValue("@Cedula", cedulaBuscada);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        idActual = Convert.ToInt32(dr["ID"]);
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
                    else
                    {
                        MessageBox.Show("No existe un alumno con esa cédula.", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar alumno: " + ex.Message);
            }
        }


        private bool CedulaExiste(string cedula, int idExcluir)
        {
            try
            {
                using (SqlConnection conn = new Conexion().Abrir())
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Alumnos WHERE Cedula=@Cedula AND ID<>@ID", conn);
                    cmd.Parameters.AddWithValue("@Cedula", cedula);
                    cmd.Parameters.AddWithValue("@ID", idExcluir);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        private void RepGeneral_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear instancias del DataSet y TableAdapter
                DBAlumnosDataSet ds = new DBAlumnosDataSet();
                DBAlumnosDataSetTableAdapters.AlumnosTableAdapter adapter =
                    new DBAlumnosDataSetTableAdapters.AlumnosTableAdapter();

                // Llenar la tabla Alumnos del DataSet
                adapter.Fill(ds.Alumnos);

                // Verificar si hay datos
                if (ds.Alumnos.Count == 0)
                {
                    MessageBox.Show("No hay alumnos registrados para mostrar en el reporte.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Obtener la ruta completa del archivo RDLC
                string reportPath = System.IO.Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "ReportAlumnos.rdlc"
                );

                // Verificar que el archivo existe
                if (!System.IO.File.Exists(reportPath))
                {
                    MessageBox.Show($"No se encontró el archivo de reporte en:\n{reportPath}\n\n" +
                        "Asegúrate de que ReportAlumnos.rdlc esté configurado como 'Copiar siempre'.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Crear formulario para mostrar el reporte
                Form reportForm = new Form();
                reportForm.Text = "Reporte General de Alumnos";
                reportForm.Size = new Size(1200, 800);
                reportForm.StartPosition = FormStartPosition.CenterScreen;
                reportForm.WindowState = FormWindowState.Maximized;

                // Crear el LocalReport
                LocalReport localReport = new LocalReport();
                localReport.ReportPath = reportPath;

                // Crear el ReportDataSource
                ReportDataSource rds = new ReportDataSource("DBAlumnosDataSet", ds.Alumnos.DefaultView);

                // Agregar la fuente de datos
                localReport.DataSources.Clear();
                localReport.DataSources.Add(rds);

                // Renderizar el reporte como PDF y mostrarlo
                byte[] reportBytes = localReport.Render("PDF");

                // Guardar temporalmente el PDF
                string tempPdfPath = System.IO.Path.Combine(
                    System.IO.Path.GetTempPath(),
                    $"ReporteAlumnos_{DateTime.Now:yyyyMMddHHmmss}.pdf"
                );

                System.IO.File.WriteAllBytes(tempPdfPath, reportBytes);

                // Abrir el PDF con el visor predeterminado del sistema
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = tempPdfPath,
                    UseShellExecute = true
                });

                MessageBox.Show("Reporte generado exitosamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte:\n{ex.Message}\n\n" +
                    $"Tipo de error: {ex.GetType().Name}\n\n" +
                    $"Detalles:\n{ex.StackTrace}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RepCarrera_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. OBTENER EL VALOR DE FILTRO DE LA CARRERA SELECCIONADA
                // --------------------------------------------------------------------------------------
                // *** ESTA LÍNEA DEBE ENLAZARSE AL CONTROL DE TU FORMULARIO (Ej. ComboBox o TextBox). ***
                //
                // Si tienes un ComboBox para Carreras llamado 'cmbCarreras':
                // string carreraSeleccionada = cmbCarreras.Text; 
                // 
                // Si usas el valor del ComboBox:
                // string carreraSeleccionada = cmbCarreras.SelectedValue.ToString();
                //
                // Sustituye la siguiente línea con la que aplique a tu control:
                string carreraSeleccionada = "Ingeniería de Sistemas"; // << EJEMPLO

                // --- Validación ---
                if (string.IsNullOrEmpty(carreraSeleccionada))
                {
                    MessageBox.Show("Debe seleccionar una carrera para generar este reporte.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. PREPARAR DATOS
                DBAlumnosDataSet ds = new DBAlumnosDataSet();
                DBAlumnosDataSetTableAdapters.AlumnosTableAdapter adapter =
                    new DBAlumnosDataSetTableAdapters.AlumnosTableAdapter();

                // Llenar el DataSet completo (el filtro se hace en el RDLC con el parámetro).
                adapter.Fill(ds.Alumnos);

                // 3. CONFIGURAR REPORTE LOCAL
                string reportFileName = "ReportCarrera.rdlc"; // Usar el reporte con filtro
                string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, reportFileName);

                if (!File.Exists(reportPath))
                {
                    MessageBox.Show($"No se encontró el archivo de reporte: {reportFileName}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                LocalReport localReport = new LocalReport();
                localReport.ReportPath = reportPath;

                // 4. AGREGAR DATASET AL REPORTE
                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("DBAlumnosDataSet", ds.Alumnos.DefaultView));

                // 5. CRÍTICO: PASAR EL PARÁMETRO "Carrera"
                // Esto le dice al RDLC qué carrera usar para filtrar y para el título.
                ReportParameter[] parameters = new ReportParameter[1];
                parameters[0] = new ReportParameter("Carrera", carreraSeleccionada);
                localReport.SetParameters(parameters);

                // 6. RENDERIZAR A PDF
                byte[] reportBytes = localReport.Render("PDF");

                // 7. GUARDAR Y ABRIR PDF temporal
                string tempPdfPath = Path.Combine(
                    Path.GetTempPath(),
                    $"Reporte_{carreraSeleccionada}_{DateTime.Now:yyyyMMddHHmmss}.pdf"
                );
                File.WriteAllBytes(tempPdfPath, reportBytes);

                // Abrir el PDF
                Process.Start(new ProcessStartInfo
                {
                    FileName = tempPdfPath,
                    UseShellExecute = true
                });

                MessageBox.Show($"Reporte por carrera generado exitosamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (LocalProcessingException lpe)
            {
                MessageBox.Show($"Error de reporte. Verifique:\n1. Que ReportCarrera.rdlc esté configurado como 'Copiar siempre' en las propiedades.\n2. Que el parámetro 'Carrera' exista en el RDLC.\nDetalle: {lpe.InnerException?.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error general al generar el reporte:\n{ex.Message}", "Error General", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//fin

        private void RepMatutino_Click(object sender, EventArgs e)
        {
            string jornadaSeleccionada = "";

            
                jornadaSeleccionada = "Matutina";
           

            try
            {
                // 2. PREPARAR Y CARGAR DATOS (¡FILTRADO!)
                DBAlumnosDataSet ds = new DBAlumnosDataSet();
                DBAlumnosDataSetTableAdapters.AlumnosTableAdapter adapter =
                    new DBAlumnosDataSetTableAdapters.AlumnosTableAdapter();

                // *** CAMBIO CRÍTICO: Carga solo los datos de la Matutina ***
                //
                // NOTA: Recuerda que el método 'FillByJornada' debe existir en tu TableAdapter
                //       y usar la consulta SQL filtrada (WHERE Jornada = @Jornada).
                //
                adapter.FillByJornada(ds.Alumnos, jornadaSeleccionada);

                // -------------------------------------------------------------------------

                // 3. CONFIGURAR Y ENVIAR PARÁMETROS (para el TÍTULO)
                string reportFileName = "ReportJornada.rdlc";
                string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, reportFileName);

                LocalReport localReport = new LocalReport();
                localReport.ReportPath = reportPath;
                localReport.DataSources.Clear();

                // El reporte ahora recibe la fuente de datos que *YA ESTÁ FILTRADA*
                localReport.DataSources.Add(new ReportDataSource("DBAlumnosDataSet", ds.Alumnos.DefaultView));

                // Pasamos el parámetro para que el título diga: REPORTE DE ALUMNOS: JORNADA MATUTINA
                ReportParameter[] parameters = new ReportParameter[1];
                parameters[0] = new ReportParameter("Jornada", jornadaSeleccionada);
                localReport.SetParameters(parameters);

                // 4. Renderizar y Abrir PDF
                byte[] reportBytes = localReport.Render("PDF");
                string tempPdfPath = Path.Combine(Path.GetTempPath(), $"Reporte_{jornadaSeleccionada}_{DateTime.Now:yyyyMMddHHmmss}.pdf");
                File.WriteAllBytes(tempPdfPath, reportBytes);

                Process.Start(new ProcessStartInfo
                {
                    FileName = tempPdfPath,
                    UseShellExecute = true
                });

                MessageBox.Show($"Reporte de la jornada '{jornadaSeleccionada}' generado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte:\n{ex.Message}", "Error General", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RepVespertino_Click(object sender, EventArgs e)
        {
            // Usamos el RadioButton rbtVis, renombrado aquí como rbtVespertina para claridad.
            // **Asegúrate de que este nombre (rbtVespertina) coincida con el nombre real de tu control.**

            string jornadaSeleccionada = "";

            // 1. OBTENER EL VALOR DE FILTRO
            
                jornadaSeleccionada = "Vespertina";
           

            try
            {
                // 2. PREPARAR Y CARGAR DATOS (¡EL CAMBIO CRÍTICO!)
                DBAlumnosDataSet ds = new DBAlumnosDataSet();
                DBAlumnosDataSetTableAdapters.AlumnosTableAdapter adapter =
                    new DBAlumnosDataSetTableAdapters.AlumnosTableAdapter();

                // *** LÍNEA CORREGIDA: Usamos un método FillBy para cargar SOLO los alumnos filtrados. ***
                //
                // NOTA: Si el método 'FillByJornada' no existe, debes crearlo en tu diseñador de DataSet
                //       (DBAlumnosDataSet.xsd) con la consulta: SELECT * FROM Alumnos WHERE Jornada = @Jornada
                //
                adapter.FillByJornada(ds.Alumnos, jornadaSeleccionada);

                // ------------------------------------------------------------------------------------------

                // 3. CONFIGURAR Y ENVIAR PARÁMETROS (para el TÍTULO del reporte)
                string reportFileName = "ReportJornada.rdlc";
                string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, reportFileName);

                LocalReport localReport = new LocalReport();
                localReport.ReportPath = reportPath;
                localReport.DataSources.Clear();

                // El reporte ahora recibe la fuente de datos (ds.Alumnos) que *YA ESTÁ FILTRADA*
                localReport.DataSources.Add(new ReportDataSource("DBAlumnosDataSet", ds.Alumnos.DefaultView));

                // Pasamos el parámetro solo para que el título se actualice: REPORTE DE ALUMNOS: JORNADA VESPERTINA
                ReportParameter[] parameters = new ReportParameter[1];
                parameters[0] = new ReportParameter("Jornada", jornadaSeleccionada);
                localReport.SetParameters(parameters);

                // 4. Renderizar y Abrir PDF
                byte[] reportBytes = localReport.Render("PDF");
                string tempPdfPath = Path.Combine(Path.GetTempPath(), $"Reporte_{jornadaSeleccionada}_{DateTime.Now:yyyyMMddHHmmss}.pdf");
                File.WriteAllBytes(tempPdfPath, reportBytes);

                Process.Start(new ProcessStartInfo
                {
                    FileName = tempPdfPath,
                    UseShellExecute = true
                });

                MessageBox.Show($"Reporte de la jornada '{jornadaSeleccionada}' generado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte:\n{ex.Message}", "Error General", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}