
namespace Klijent
{
    partial class FrmKlijent
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
            this.gbLogin = new System.Windows.Forms.GroupBox();
            this.gbSlanjeSvima = new System.Windows.Forms.GroupBox();
            this.gbSlanjeOdredjenom = new System.Windows.Forms.GroupBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSifra = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvPoruke = new System.Windows.Forms.DataGridView();
            this.rtbSlanjeSvima = new System.Windows.Forms.RichTextBox();
            this.btnSaljiSvima = new System.Windows.Forms.Button();
            this.btnSaljiOdredjenom = new System.Windows.Forms.Button();
            this.rtbSlanjeOdredjenom = new System.Windows.Forms.RichTextBox();
            this.cbKorisnici = new System.Windows.Forms.ComboBox();
            this.gbLogin.SuspendLayout();
            this.gbSlanjeSvima.SuspendLayout();
            this.gbSlanjeOdredjenom.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoruke)).BeginInit();
            this.SuspendLayout();
            // 
            // gbLogin
            // 
            this.gbLogin.Controls.Add(this.btnLogin);
            this.gbLogin.Controls.Add(this.label2);
            this.gbLogin.Controls.Add(this.label1);
            this.gbLogin.Controls.Add(this.txtSifra);
            this.gbLogin.Controls.Add(this.txtEmail);
            this.gbLogin.Location = new System.Drawing.Point(37, 32);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Size = new System.Drawing.Size(382, 135);
            this.gbLogin.TabIndex = 0;
            this.gbLogin.TabStop = false;
            this.gbLogin.Text = "Logovanje";
            // 
            // gbSlanjeSvima
            // 
            this.gbSlanjeSvima.Controls.Add(this.btnSaljiSvima);
            this.gbSlanjeSvima.Controls.Add(this.rtbSlanjeSvima);
            this.gbSlanjeSvima.Location = new System.Drawing.Point(37, 196);
            this.gbSlanjeSvima.Name = "gbSlanjeSvima";
            this.gbSlanjeSvima.Size = new System.Drawing.Size(382, 135);
            this.gbSlanjeSvima.TabIndex = 1;
            this.gbSlanjeSvima.TabStop = false;
            this.gbSlanjeSvima.Text = "Slanje svima";
            // 
            // gbSlanjeOdredjenom
            // 
            this.gbSlanjeOdredjenom.Controls.Add(this.cbKorisnici);
            this.gbSlanjeOdredjenom.Controls.Add(this.btnSaljiOdredjenom);
            this.gbSlanjeOdredjenom.Controls.Add(this.rtbSlanjeOdredjenom);
            this.gbSlanjeOdredjenom.Location = new System.Drawing.Point(37, 370);
            this.gbSlanjeOdredjenom.Name = "gbSlanjeOdredjenom";
            this.gbSlanjeOdredjenom.Size = new System.Drawing.Size(649, 135);
            this.gbSlanjeOdredjenom.TabIndex = 2;
            this.gbSlanjeOdredjenom.TabStop = false;
            this.gbSlanjeOdredjenom.Text = "Slanje odredjenom";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(113, 37);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(151, 22);
            this.txtEmail.TabIndex = 0;
            // 
            // txtSifra
            // 
            this.txtSifra.Location = new System.Drawing.Point(113, 77);
            this.txtSifra.Name = "txtSifra";
            this.txtSifra.Size = new System.Drawing.Size(151, 22);
            this.txtSifra.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sifra";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(270, 37);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(93, 62);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvPoruke);
            this.groupBox1.Location = new System.Drawing.Point(37, 535);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(704, 297);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sve poruke";
            // 
            // dgvPoruke
            // 
            this.dgvPoruke.AllowUserToAddRows = false;
            this.dgvPoruke.AllowUserToDeleteRows = false;
            this.dgvPoruke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPoruke.Location = new System.Drawing.Point(15, 33);
            this.dgvPoruke.Name = "dgvPoruke";
            this.dgvPoruke.ReadOnly = true;
            this.dgvPoruke.RowHeadersWidth = 51;
            this.dgvPoruke.RowTemplate.Height = 24;
            this.dgvPoruke.Size = new System.Drawing.Size(661, 241);
            this.dgvPoruke.TabIndex = 0;
            // 
            // rtbSlanjeSvima
            // 
            this.rtbSlanjeSvima.Location = new System.Drawing.Point(15, 30);
            this.rtbSlanjeSvima.MaxLength = 200;
            this.rtbSlanjeSvima.Name = "rtbSlanjeSvima";
            this.rtbSlanjeSvima.Size = new System.Drawing.Size(249, 83);
            this.rtbSlanjeSvima.TabIndex = 0;
            this.rtbSlanjeSvima.Text = "";
            // 
            // btnSaljiSvima
            // 
            this.btnSaljiSvima.Location = new System.Drawing.Point(270, 30);
            this.btnSaljiSvima.Name = "btnSaljiSvima";
            this.btnSaljiSvima.Size = new System.Drawing.Size(93, 62);
            this.btnSaljiSvima.TabIndex = 5;
            this.btnSaljiSvima.Text = "Posalji poruku";
            this.btnSaljiSvima.UseVisualStyleBackColor = true;
            this.btnSaljiSvima.Click += new System.EventHandler(this.btnSaljiSvima_Click);
            // 
            // btnSaljiOdredjenom
            // 
            this.btnSaljiOdredjenom.Location = new System.Drawing.Point(272, 26);
            this.btnSaljiOdredjenom.Name = "btnSaljiOdredjenom";
            this.btnSaljiOdredjenom.Size = new System.Drawing.Size(93, 62);
            this.btnSaljiOdredjenom.TabIndex = 7;
            this.btnSaljiOdredjenom.Text = "Posalji poruku";
            this.btnSaljiOdredjenom.UseVisualStyleBackColor = true;
            this.btnSaljiOdredjenom.Click += new System.EventHandler(this.btnSaljiOdredjenom_Click);
            // 
            // rtbSlanjeOdredjenom
            // 
            this.rtbSlanjeOdredjenom.Location = new System.Drawing.Point(17, 26);
            this.rtbSlanjeOdredjenom.MaxLength = 200;
            this.rtbSlanjeOdredjenom.Name = "rtbSlanjeOdredjenom";
            this.rtbSlanjeOdredjenom.Size = new System.Drawing.Size(249, 83);
            this.rtbSlanjeOdredjenom.TabIndex = 6;
            this.rtbSlanjeOdredjenom.Text = "";
            // 
            // cbKorisnici
            // 
            this.cbKorisnici.FormattingEnabled = true;
            this.cbKorisnici.Location = new System.Drawing.Point(400, 26);
            this.cbKorisnici.Name = "cbKorisnici";
            this.cbKorisnici.Size = new System.Drawing.Size(121, 24);
            this.cbKorisnici.TabIndex = 8;
            // 
            // FrmKlijent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 893);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbSlanjeOdredjenom);
            this.Controls.Add(this.gbSlanjeSvima);
            this.Controls.Add(this.gbLogin);
            this.Name = "FrmKlijent";
            this.Text = "Form1";
            this.gbLogin.ResumeLayout(false);
            this.gbLogin.PerformLayout();
            this.gbSlanjeSvima.ResumeLayout(false);
            this.gbSlanjeOdredjenom.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoruke)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLogin;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSifra;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.GroupBox gbSlanjeSvima;
        private System.Windows.Forms.GroupBox gbSlanjeOdredjenom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvPoruke;
        private System.Windows.Forms.Button btnSaljiSvima;
        private System.Windows.Forms.RichTextBox rtbSlanjeSvima;
        private System.Windows.Forms.ComboBox cbKorisnici;
        private System.Windows.Forms.Button btnSaljiOdredjenom;
        private System.Windows.Forms.RichTextBox rtbSlanjeOdredjenom;
    }
}

