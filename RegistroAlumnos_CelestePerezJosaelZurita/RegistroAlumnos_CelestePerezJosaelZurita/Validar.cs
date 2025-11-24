using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroAlumnos_CelestePerezJosaelZurita
{
    internal class Validar
    {
        public bool ValidarCampos(TextBox textNombre, TextBox textCedu, TextBox textCon,
            TextBox textCon2, CheckBox check1, ComboBox combo1,
            ComboBox combo2, RadioButton rbtMat, RadioButton rbtVis, CheckBox check2)
        {
            // Validar que los campos estén completos
            if (textNombre.Text.Trim() == "" || textCedu.Text.Trim() == "" ||
                combo1.SelectedIndex == -1 || combo2.SelectedIndex == -1 ||
                (!rbtMat.Checked && !rbtVis.Checked) || textCon.Text.Trim() == "" ||
                textCon2.Text.Trim() == "" || check1.Checked == false || check2.Checked == false)
            {
                MessageBox.Show("Se necesita llenar todos los campos.",
                    "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar nombre solo letras
            if (!SoloLetras(textNombre.Text))
            {
                MessageBox.Show("El nombre solo permite letras.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textNombre.Focus();
                return false;
            }

            // ========= NUEVO: VALIDACIÓN REAL DE CÉDULA =========
            if (!CedulaPanameniaValida(textCedu.Text.Trim()))
            {
                MessageBox.Show("La cédula no es válida. Debe tener el formato: 8-1017-808",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                textCedu.Focus();
                return false;
            }

            // Validar confirmación de contraseña
            if (textCon.Text != textCon2.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }// fin ValidarCampos

        private bool SoloLetras(string texto)
        {
            foreach (char c in texto)
            {
                if (!char.IsLetter(c) && c != ' ')
                    return false;
            }
            return true;
        }

        // Ya NO usamos SoloNumeros() para cédula, así que lo dejo por si te sirve en otra cosa
        private bool SoloNumeros(string texto)
        {
            foreach (char c in texto)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

        //VALIDACIÓN DEL FORMATO DE CÉDULA PANAMEÑA 
        private bool CedulaPanameniaValida(string cedula)
        {
            // Provincias 1–13 | Tomo 1–4 dígitos | Asiento 1–4 dígitos
            string patron = @"^(1[0-3]|[1-9])-[0-9]{1,4}-[0-9]{1,4}$";
            return Regex.IsMatch(cedula, patron);
        }

    }// fin clase
}
