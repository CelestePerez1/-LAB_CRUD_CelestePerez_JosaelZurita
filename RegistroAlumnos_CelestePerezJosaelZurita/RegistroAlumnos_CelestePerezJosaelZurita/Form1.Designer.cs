namespace RegistroAlumnos_CelestePerezJosaelZurita
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textUser = new TextBox();
            textCon2 = new TextBox();
            label8 = new Label();
            label9 = new Label();
            check1 = new CheckBox();
            btnGua1 = new Button();
            label10 = new Label();
            listBox1 = new ListBox();
            panel1 = new Panel();
            panel4 = new Panel();
            txtContAlumno = new TextBox();
            lblEST = new Label();
            panel2 = new Panel();
            check2 = new CheckBox();
            label7 = new Label();
            label12 = new Label();
            textCon = new TextBox();
            label1 = new Label();
            panel6 = new Panel();
            btnEliminar = new Button();
            btnSalir2 = new Button();
            btnEditar = new Button();
            btnAyuda = new Button();
            btnNuevo2 = new Button();
            btnGua2 = new Button();
            panel5 = new Panel();
            label13 = new Label();
            rbtVis = new RadioButton();
            rbtMat = new RadioButton();
            combo2 = new ComboBox();
            label6 = new Label();
            combo1 = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            textCedu = new TextBox();
            label3 = new Label();
            textNombre = new TextBox();
            label2 = new Label();
            panel3 = new Panel();
            button1 = new Button();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // textUser
            // 
            textUser.Location = new Point(26, 82);
            textUser.Name = "textUser";
            textUser.ReadOnly = true;
            textUser.Size = new Size(248, 27);
            textUser.TabIndex = 12;
            // 
            // textCon2
            // 
            textCon2.Location = new Point(347, 170);
            textCon2.MaxLength = 12;
            textCon2.Name = "textCon2";
            textCon2.Size = new Size(226, 27);
            textCon2.TabIndex = 1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.White;
            label8.Location = new Point(347, 138);
            label8.Name = "label8";
            label8.Size = new Size(160, 20);
            label8.TabIndex = 15;
            label8.Text = "Confirmar contraseña:*";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.White;
            label9.Location = new Point(26, 138);
            label9.Name = "label9";
            label9.Size = new Size(92, 20);
            label9.TabIndex = 13;
            label9.Text = "Contraseña:*";
            // 
            // check1
            // 
            check1.AutoSize = true;
            check1.BackColor = Color.White;
            check1.Location = new Point(26, 234);
            check1.Name = "check1";
            check1.Size = new Size(337, 24);
            check1.TabIndex = 7;
            check1.Text = "Acepto los términos y condiciones del sistema";
            check1.UseVisualStyleBackColor = false;
            // 
            // btnGua1
            // 
            btnGua1.BackColor = Color.FromArgb(255, 255, 128);
            btnGua1.Location = new Point(517, 262);
            btnGua1.Name = "btnGua1";
            btnGua1.Size = new Size(142, 36);
            btnGua1.TabIndex = 4;
            btnGua1.Text = "Guardar";
            btnGua1.UseVisualStyleBackColor = false;
            btnGua1.Click += btnGua1_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.White;
            label10.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(24, 3);
            label10.Name = "label10";
            label10.Size = new Size(189, 25);
            label10.TabIndex = 23;
            label10.Text = "Alumnos Registrados";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(179, 949);
            listBox1.Name = "listBox1";
            listBox1.ScrollAlwaysVisible = true;
            listBox1.Size = new Size(643, 64);
            listBox1.TabIndex = 88;
            listBox1.Click += listBox1_Click;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            listBox1.MouseDoubleClick += listBox1_MouseDoubleClick;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(label10);
            panel1.Location = new Point(155, 842);
            panel1.Name = "panel1";
            panel1.Size = new Size(696, 198);
            panel1.TabIndex = 26;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(txtContAlumno);
            panel4.Controls.Add(lblEST);
            panel4.Location = new Point(24, 43);
            panel4.Name = "panel4";
            panel4.Size = new Size(643, 41);
            panel4.TabIndex = 27;
            // 
            // txtContAlumno
            // 
            txtContAlumno.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtContAlumno.Location = new Point(361, 11);
            txtContAlumno.Name = "txtContAlumno";
            txtContAlumno.ReadOnly = true;
            txtContAlumno.Size = new Size(67, 27);
            txtContAlumno.TabIndex = 29;
            txtContAlumno.TextChanged += txtContAlumno_TextChanged;
            // 
            // lblEST
            // 
            lblEST.AutoSize = true;
            lblEST.Location = new Point(227, 14);
            lblEST.Name = "lblEST";
            lblEST.Size = new Size(128, 20);
            lblEST.TabIndex = 28;
            lblEST.Text = "Total de Alumnos:";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(check2);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(textCon);
            panel2.Controls.Add(textCon2);
            panel2.Controls.Add(btnGua1);
            panel2.Controls.Add(check1);
            panel2.Controls.Add(textUser);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label9);
            panel2.Location = new Point(155, 496);
            panel2.Name = "panel2";
            panel2.Size = new Size(696, 321);
            panel2.TabIndex = 6;
            // 
            // check2
            // 
            check2.AutoSize = true;
            check2.BackColor = Color.White;
            check2.Location = new Point(26, 264);
            check2.Name = "check2";
            check2.Size = new Size(180, 24);
            check2.TabIndex = 3;
            check2.Text = "Recibir Notificaciones ";
            check2.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.White;
            label7.Location = new Point(26, 50);
            label7.Name = "label7";
            label7.Size = new Size(262, 20);
            label7.TabIndex = 66;
            label7.Text = "Usuario (Generado automáticamente):";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.White;
            label12.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(25, 14);
            label12.Name = "label12";
            label12.Size = new Size(117, 25);
            label12.TabIndex = 29;
            label12.Text = "Credenciales";
            // 
            // textCon
            // 
            textCon.Location = new Point(26, 170);
            textCon.MaxLength = 12;
            textCon.Name = "textCon";
            textCon.Size = new Size(226, 27);
            textCon.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(17, 12);
            label1.Name = "label1";
            label1.Size = new Size(541, 46);
            label1.TabIndex = 77;
            label1.Text = "Sistema de Registro de Estudiantes";
            // 
            // panel6
            // 
            panel6.BackColor = Color.White;
            panel6.Controls.Add(btnEliminar);
            panel6.Controls.Add(btnSalir2);
            panel6.Controls.Add(btnEditar);
            panel6.Controls.Add(btnAyuda);
            panel6.Controls.Add(btnNuevo2);
            panel6.Controls.Add(btnGua2);
            panel6.Location = new Point(96, 98);
            panel6.Name = "panel6";
            panel6.Size = new Size(826, 68);
            panel6.TabIndex = 43;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(417, 17);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(126, 36);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnSalir2
            // 
            btnSalir2.Location = new Point(677, 17);
            btnSalir2.Name = "btnSalir2";
            btnSalir2.Size = new Size(126, 36);
            btnSalir2.TabIndex = 1;
            btnSalir2.Text = "Salir";
            btnSalir2.UseVisualStyleBackColor = true;
            btnSalir2.Click += button3_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(285, 17);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(126, 36);
            btnEditar.TabIndex = 3;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnAyuda
            // 
            btnAyuda.Location = new Point(547, 17);
            btnAyuda.Name = "btnAyuda";
            btnAyuda.Size = new Size(126, 36);
            btnAyuda.TabIndex = 0;
            btnAyuda.Text = "Ayuda";
            btnAyuda.UseVisualStyleBackColor = true;
            btnAyuda.Click += btnAyuda_Click;
            // 
            // btnNuevo2
            // 
            btnNuevo2.Location = new Point(153, 17);
            btnNuevo2.Name = "btnNuevo2";
            btnNuevo2.Size = new Size(126, 36);
            btnNuevo2.TabIndex = 2;
            btnNuevo2.Text = "Nuevo";
            btnNuevo2.UseVisualStyleBackColor = true;
            btnNuevo2.Click += btnNuevo2_Click;
            // 
            // btnGua2
            // 
            btnGua2.Location = new Point(23, 17);
            btnGua2.Name = "btnGua2";
            btnGua2.Size = new Size(126, 36);
            btnGua2.TabIndex = 23;
            btnGua2.Text = "Guardar";
            btnGua2.UseVisualStyleBackColor = true;
            btnGua2.Click += btnGua2_Click;
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.Controls.Add(label1);
            panel5.Location = new Point(224, 12);
            panel5.Name = "panel5";
            panel5.Size = new Size(566, 68);
            panel5.TabIndex = 78;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.White;
            label13.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(24, 10);
            label13.Name = "label13";
            label13.Size = new Size(162, 25);
            label13.TabIndex = 0;
            label13.Text = "Datos del Alumno";
            // 
            // rbtVis
            // 
            rbtVis.AutoSize = true;
            rbtVis.BackColor = Color.White;
            rbtVis.Location = new Point(174, 242);
            rbtVis.Name = "rbtVis";
            rbtVis.Size = new Size(99, 24);
            rbtVis.TabIndex = 5;
            rbtVis.TabStop = true;
            rbtVis.Text = "Vespertina";
            rbtVis.UseVisualStyleBackColor = false;
            // 
            // rbtMat
            // 
            rbtMat.AutoSize = true;
            rbtMat.BackColor = Color.White;
            rbtMat.Location = new Point(25, 242);
            rbtMat.Name = "rbtMat";
            rbtMat.Size = new Size(89, 24);
            rbtMat.TabIndex = 4;
            rbtMat.TabStop = true;
            rbtMat.Text = "Matutina";
            rbtMat.UseVisualStyleBackColor = false;
            // 
            // combo2
            // 
            combo2.DropDownStyle = ComboBoxStyle.DropDownList;
            combo2.FormattingEnabled = true;
            combo2.Items.AddRange(new object[] { "- Seleccione -", "Primer Semestre", "Segundo Semestre", "Tercer Semestre", "Cuarto Semestre", "Quinto Semestre", "Sexto Semestre", "Séptimo Semestre", "Octavo Semestre", "Noveno Semestre", "Décimo Semestre" });
            combo2.Location = new Point(385, 162);
            combo2.Name = "combo2";
            combo2.Size = new Size(185, 28);
            combo2.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.White;
            label6.Location = new Point(385, 139);
            label6.Name = "label6";
            label6.Size = new Size(79, 20);
            label6.TabIndex = 37;
            label6.Text = "Semestre:*";
            // 
            // combo1
            // 
            combo1.DropDownStyle = ComboBoxStyle.DropDownList;
            combo1.FormattingEnabled = true;
            combo1.ImeMode = ImeMode.Off;
            combo1.Items.AddRange(new object[] { "- Seleccione -", "Ingienería de Sistemas", "Derecho", "Administración", "Contaduría", "Medicina", "Psicología" });
            combo1.Location = new Point(25, 162);
            combo1.Name = "combo1";
            combo1.Size = new Size(185, 28);
            combo1.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Location = new Point(25, 209);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 35;
            label4.Text = "Jornada:*";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.White;
            label5.Location = new Point(24, 139);
            label5.Name = "label5";
            label5.Size = new Size(66, 20);
            label5.TabIndex = 34;
            label5.Text = "Carrera:*";
            // 
            // textCedu
            // 
            textCedu.Location = new Point(544, 268);
            textCedu.Name = "textCedu";
            textCedu.Size = new Size(226, 27);
            textCedu.TabIndex = 1;
            textCedu.TextChanged += textCedu_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Location = new Point(540, 238);
            label3.Name = "label3";
            label3.Size = new Size(64, 20);
            label3.TabIndex = 32;
            label3.Text = "Cédula:*";
            // 
            // textNombre
            // 
            textNombre.Location = new Point(25, 83);
            textNombre.Name = "textNombre";
            textNombre.Size = new Size(248, 27);
            textNombre.TabIndex = 0;
            textNombre.TextChanged += textNombre_TextChanged_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Location = new Point(25, 53);
            label2.Name = "label2";
            label2.Size = new Size(143, 20);
            label2.TabIndex = 30;
            label2.Text = "Nombre Completo:*";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(label13);
            panel3.Controls.Add(rbtVis);
            panel3.Controls.Add(combo2);
            panel3.Controls.Add(rbtMat);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(textNombre);
            panel3.Controls.Add(combo1);
            panel3.Controls.Add(label5);
            panel3.Location = new Point(155, 185);
            panel3.Name = "panel3";
            panel3.Size = new Size(696, 287);
            panel3.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(2, 12);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "Conexion";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(192, 192, 255);
            ClientSize = new Size(1035, 550);
            Controls.Add(button1);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(textCedu);
            Controls.Add(label3);
            Controls.Add(panel3);
            Controls.Add(listBox1);
            Controls.Add(panel1);
            Controls.Add(panel2);
            KeyPreview = true;
            Name = "Form1";
            FormClosing += Form1_FormClosing;
            KeyDown += Form1_KeyDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel6.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textUser;
        private TextBox textCon2;
        private Label label8;
        private Label label9;
        private CheckBox check1;
        private Button btnGua1;
        private Label label10;
        private ListBox listBox1;
        private Panel panel1;
        private Panel panel2;
        private TextBox textCon;
        private Panel panel4;
        private Label lblEST;
        private Label label12;
        private Label label7;
        private Label label1;
        private Panel panel6;
        private Panel panel5;
        private Label label13;
        private RadioButton rbtVis;
        private RadioButton rbtMat;
        private ComboBox combo2;
        private Label label6;
        private ComboBox combo1;
        private Label label4;
        private Label label5;
        private TextBox textCedu;
        private Label label3;
        private TextBox textNombre;
        private Label label2;
        private Panel panel3;
        private Button btnGua2;
        private Button btnSalir2;
        private Button btnAyuda;
        private Button btnNuevo2;
        private TextBox txtContAlumno;
        private CheckBox check2;
        private Button button1;
        private Button btnEditar;
        private Button btnEliminar;
    }
}
