namespace RegistroAlumnos_CelestePerezJosaelZurita
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            textCodigo = new TextBox();
            btnIngresar = new Button();
            btnSalir = new Button();
            lblMensaje = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(163, 26);
            label1.Name = "label1";
            label1.Size = new Size(243, 38);
            label1.TabIndex = 0;
            label1.Text = "Acceso al Sistema";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(177, 91);
            label2.Name = "label2";
            label2.Size = new Size(205, 20);
            label2.TabIndex = 1;
            label2.Text = "Ingrese el código de profesor";
            // 
            // textCodigo
            // 
            textCodigo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textCodigo.Location = new Point(139, 143);
            textCodigo.Name = "textCodigo";
            textCodigo.Size = new Size(286, 34);
            textCodigo.TabIndex = 2;
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(139, 195);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(113, 39);
            btnIngresar.TabIndex = 3;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(312, 196);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(113, 39);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click_1;
            // 
            // lblMensaje
            // 
            lblMensaje.AutoSize = true;
            lblMensaje.Location = new Point(276, 253);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(0, 20);
            lblMensaje.TabIndex = 5;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(192, 192, 255);
            ClientSize = new Size(547, 284);
            Controls.Add(lblMensaje);
            Controls.Add(btnSalir);
            Controls.Add(btnIngresar);
            Controls.Add(textCodigo);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textCodigo;
        private Button btnIngresar;
        private Button btnSalir;
        private Label lblMensaje;
    }
}