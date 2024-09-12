namespace IP_Changer
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
            comboBox_Adaptador = new ComboBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            comboBox_Red = new ComboBox();
            groupBox3 = new GroupBox();
            textBox_Gateway = new TextBox();
            label3 = new Label();
            textBox_Mask = new TextBox();
            label2 = new Label();
            textBox_IP = new TextBox();
            label1 = new Label();
            button_Saved = new Button();
            button_Revert = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // comboBox_Adaptador
            // 
            comboBox_Adaptador.Dock = DockStyle.Fill;
            comboBox_Adaptador.FormattingEnabled = true;
            comboBox_Adaptador.Location = new Point(3, 19);
            comboBox_Adaptador.Name = "comboBox_Adaptador";
            comboBox_Adaptador.Size = new Size(326, 23);
            comboBox_Adaptador.TabIndex = 0;
            comboBox_Adaptador.SelectedIndexChanged += comboBox_Adaptador_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboBox_Adaptador);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(332, 57);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Adaptador";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(comboBox_Red);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(0, 57);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(332, 57);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Redes";
            // 
            // comboBox_Red
            // 
            comboBox_Red.Dock = DockStyle.Fill;
            comboBox_Red.Enabled = false;
            comboBox_Red.FormattingEnabled = true;
            comboBox_Red.Location = new Point(3, 19);
            comboBox_Red.Name = "comboBox_Red";
            comboBox_Red.Size = new Size(326, 23);
            comboBox_Red.TabIndex = 0;
            comboBox_Red.SelectedIndexChanged += comboBox_Red_SelectedIndexChanged;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBox_Gateway);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(textBox_Mask);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(textBox_IP);
            groupBox3.Controls.Add(label1);
            groupBox3.Dock = DockStyle.Top;
            groupBox3.Location = new Point(0, 114);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(332, 174);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Direccionamiento";
            // 
            // textBox_Gateway
            // 
            textBox_Gateway.Enabled = false;
            textBox_Gateway.Location = new Point(12, 145);
            textBox_Gateway.Name = "textBox_Gateway";
            textBox_Gateway.Size = new Size(314, 23);
            textBox_Gateway.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 127);
            label3.Name = "label3";
            label3.Size = new Size(59, 15);
            label3.TabIndex = 4;
            label3.Text = "GATEWAY";
            // 
            // textBox_Mask
            // 
            textBox_Mask.Enabled = false;
            textBox_Mask.Location = new Point(12, 91);
            textBox_Mask.Name = "textBox_Mask";
            textBox_Mask.Size = new Size(314, 23);
            textBox_Mask.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 73);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 2;
            label2.Text = "MASK";
            // 
            // textBox_IP
            // 
            textBox_IP.Enabled = false;
            textBox_IP.Location = new Point(12, 37);
            textBox_IP.Name = "textBox_IP";
            textBox_IP.Size = new Size(314, 23);
            textBox_IP.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(17, 15);
            label1.TabIndex = 0;
            label1.Text = "IP";
            // 
            // button_Saved
            // 
            button_Saved.Dock = DockStyle.Left;
            button_Saved.Location = new Point(0, 288);
            button_Saved.Name = "button_Saved";
            button_Saved.Size = new Size(164, 103);
            button_Saved.TabIndex = 4;
            button_Saved.Text = "Salvar";
            button_Saved.UseVisualStyleBackColor = true;
            button_Saved.Click += button_Saved_Click;
            // 
            // button_Revert
            // 
            button_Revert.Dock = DockStyle.Right;
            button_Revert.Location = new Point(170, 288);
            button_Revert.Name = "button_Revert";
            button_Revert.Size = new Size(162, 103);
            button_Revert.TabIndex = 5;
            button_Revert.Text = "Revertir";
            button_Revert.UseVisualStyleBackColor = true;
            button_Revert.Click += button_Revert_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(332, 391);
            Controls.Add(button_Revert);
            Controls.Add(button_Saved);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "IPV4 Changer";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBox_Adaptador;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ComboBox comboBox_Red;
        private GroupBox groupBox3;
        private TextBox textBox_Gateway;
        private Label label3;
        private TextBox textBox_Mask;
        private Label label2;
        private TextBox textBox_IP;
        private Label label1;
        private Button button_Saved;
        private Button button_Revert;
    }
}
