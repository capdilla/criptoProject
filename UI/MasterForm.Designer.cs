namespace UI
{
    partial class MasterForm
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
            this.label8 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.LabelPublicKeySlave = new System.Windows.Forms.Label();
            this.LabelTdesKey = new System.Windows.Forms.Label();
            this.LabelTdes1Encrypted = new System.Windows.Forms.Label();
            this.LabelEncryptedText = new System.Windows.Forms.Label();
            this.LabelDecryptedText = new System.Windows.Forms.Label();
            this.TextBoxRsaPublicKey = new System.Windows.Forms.TextBox();
            this.TextBoxRsaPrivateKey = new System.Windows.Forms.TextBox();
            this.LabelTdes2Encrypted = new System.Windows.Forms.Label();
            this.LabelTdes3Encrypted = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(201, 556);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 41;
            this.label8.Text = "Texto";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(88, 544);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(90, 37);
            this.button6.TabIndex = 40;
            this.button6.Text = "Desencriptar Texto";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(197, 493);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Texto encriptado del XML";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(85, 477);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(93, 44);
            this.button5.TabIndex = 38;
            this.button5.Text = "Importar mensaje de xml";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(201, 379);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "TDES encriptadas";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(85, 363);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(93, 44);
            this.button4.TabIndex = 36;
            this.button4.Text = "Encriptar claves TDES ";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(201, 322);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Clave TDES ";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(85, 309);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 38);
            this.button3.TabIndex = 34;
            this.button3.Text = "Generar Claves TDES";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(197, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Valor Clave publica esclavo";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(85, 244);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 51);
            this.button2.TabIndex = 32;
            this.button2.Text = "Importar clave publica RSA esclavo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(242, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 25);
            this.label3.TabIndex = 31;
            this.label3.Text = "Soy Maestro";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Clave Privada";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(198, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Clave Publica";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(85, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 44);
            this.button1.TabIndex = 28;
            this.button1.Text = "Generar Clave RSA";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // LabelPublicKeySlave
            // 
            this.LabelPublicKeySlave.AutoSize = true;
            this.LabelPublicKeySlave.Location = new System.Drawing.Point(341, 263);
            this.LabelPublicKeySlave.Name = "LabelPublicKeySlave";
            this.LabelPublicKeySlave.Size = new System.Drawing.Size(35, 13);
            this.LabelPublicKeySlave.TabIndex = 44;
            this.LabelPublicKeySlave.Text = "label9";
            // 
            // LabelTdesKey
            // 
            this.LabelTdesKey.AutoSize = true;
            this.LabelTdesKey.Location = new System.Drawing.Point(284, 322);
            this.LabelTdesKey.Name = "LabelTdesKey";
            this.LabelTdesKey.Size = new System.Drawing.Size(35, 13);
            this.LabelTdesKey.TabIndex = 45;
            this.LabelTdesKey.Text = "label9";
            // 
            // LabelTdes1Encrypted
            // 
            this.LabelTdes1Encrypted.AutoSize = true;
            this.LabelTdes1Encrypted.Location = new System.Drawing.Point(330, 354);
            this.LabelTdes1Encrypted.Name = "LabelTdes1Encrypted";
            this.LabelTdes1Encrypted.Size = new System.Drawing.Size(35, 13);
            this.LabelTdes1Encrypted.TabIndex = 46;
            this.LabelTdes1Encrypted.Text = "label9";
            // 
            // LabelEncryptedText
            // 
            this.LabelEncryptedText.AutoSize = true;
            this.LabelEncryptedText.Location = new System.Drawing.Point(350, 492);
            this.LabelEncryptedText.Name = "LabelEncryptedText";
            this.LabelEncryptedText.Size = new System.Drawing.Size(35, 13);
            this.LabelEncryptedText.TabIndex = 47;
            this.LabelEncryptedText.Text = "label9";
            // 
            // LabelDecryptedText
            // 
            this.LabelDecryptedText.AutoSize = true;
            this.LabelDecryptedText.Location = new System.Drawing.Point(260, 557);
            this.LabelDecryptedText.Name = "LabelDecryptedText";
            this.LabelDecryptedText.Size = new System.Drawing.Size(35, 13);
            this.LabelDecryptedText.TabIndex = 48;
            this.LabelDecryptedText.Text = "label9";
            // 
            // TextBoxRsaPublicKey
            // 
            this.TextBoxRsaPublicKey.Location = new System.Drawing.Point(290, 94);
            this.TextBoxRsaPublicKey.Multiline = true;
            this.TextBoxRsaPublicKey.Name = "TextBoxRsaPublicKey";
            this.TextBoxRsaPublicKey.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBoxRsaPublicKey.Size = new System.Drawing.Size(422, 57);
            this.TextBoxRsaPublicKey.TabIndex = 49;
            // 
            // TextBoxRsaPrivateKey
            // 
            this.TextBoxRsaPrivateKey.Enabled = false;
            this.TextBoxRsaPrivateKey.Location = new System.Drawing.Point(293, 176);
            this.TextBoxRsaPrivateKey.Multiline = true;
            this.TextBoxRsaPrivateKey.Name = "TextBoxRsaPrivateKey";
            this.TextBoxRsaPrivateKey.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBoxRsaPrivateKey.Size = new System.Drawing.Size(419, 62);
            this.TextBoxRsaPrivateKey.TabIndex = 50;
            // 
            // LabelTdes2Encrypted
            // 
            this.LabelTdes2Encrypted.AutoSize = true;
            this.LabelTdes2Encrypted.Location = new System.Drawing.Point(330, 381);
            this.LabelTdes2Encrypted.Name = "LabelTdes2Encrypted";
            this.LabelTdes2Encrypted.Size = new System.Drawing.Size(35, 13);
            this.LabelTdes2Encrypted.TabIndex = 51;
            this.LabelTdes2Encrypted.Text = "label9";
            // 
            // LabelTdes3Encrypted
            // 
            this.LabelTdes3Encrypted.AutoSize = true;
            this.LabelTdes3Encrypted.Location = new System.Drawing.Point(329, 405);
            this.LabelTdes3Encrypted.Name = "LabelTdes3Encrypted";
            this.LabelTdes3Encrypted.Size = new System.Drawing.Size(35, 13);
            this.LabelTdes3Encrypted.TabIndex = 52;
            this.LabelTdes3Encrypted.Text = "label9";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(247, 430);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(533, 24);
            this.button7.TabIndex = 53;
            this.button7.Text = "Exportar Claves TDES a xml";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.Button7_Click);
            // 
            // MasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 593);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.LabelTdes3Encrypted);
            this.Controls.Add(this.LabelTdes2Encrypted);
            this.Controls.Add(this.TextBoxRsaPrivateKey);
            this.Controls.Add(this.TextBoxRsaPublicKey);
            this.Controls.Add(this.LabelDecryptedText);
            this.Controls.Add(this.LabelEncryptedText);
            this.Controls.Add(this.LabelTdes1Encrypted);
            this.Controls.Add(this.LabelTdesKey);
            this.Controls.Add(this.LabelPublicKeySlave);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "MasterForm";
            this.Text = "MasterForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MasterForm_FormClosing);            
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label LabelPublicKeySlave;
        private System.Windows.Forms.Label LabelTdesKey;
        private System.Windows.Forms.Label LabelTdes1Encrypted;
        private System.Windows.Forms.Label LabelEncryptedText;
        private System.Windows.Forms.Label LabelDecryptedText;
        private System.Windows.Forms.TextBox TextBoxRsaPublicKey;
        private System.Windows.Forms.TextBox TextBoxRsaPrivateKey;
        private System.Windows.Forms.Label LabelTdes2Encrypted;
        private System.Windows.Forms.Label LabelTdes3Encrypted;
        private System.Windows.Forms.Button button7;
    }
}