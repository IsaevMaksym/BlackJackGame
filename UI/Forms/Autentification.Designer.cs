namespace BlackJack
{
    partial class Autentification
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Autentification));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_login = new System.Windows.Forms.Button();
            this.btn_register = new System.Windows.Forms.Button();
            this.tBx_NickName = new System.Windows.Forms.TextBox();
            this.tBx_password = new System.Windows.Forms.TextBox();
            this.btn_guest = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pbx_main = new System.Windows.Forms.PictureBox();
            this.lbl_Hello = new System.Windows.Forms.Label();
            this.lbl_error = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_main)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nick name";
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(12, 209);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(120, 40);
            this.btn_login.TabIndex = 1;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // btn_register
            // 
            this.btn_register.Location = new System.Drawing.Point(138, 209);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(120, 40);
            this.btn_register.TabIndex = 2;
            this.btn_register.Text = "Create player";
            this.btn_register.UseVisualStyleBackColor = true;
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
            // 
            // tBx_NickName
            // 
            this.tBx_NickName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tBx_NickName.Location = new System.Drawing.Point(16, 111);
            this.tBx_NickName.Name = "tBx_NickName";
            this.tBx_NickName.Size = new System.Drawing.Size(200, 31);
            this.tBx_NickName.TabIndex = 3;
            // 
            // tBx_password
            // 
            this.tBx_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tBx_password.Location = new System.Drawing.Point(16, 172);
            this.tBx_password.Name = "tBx_password";
            this.tBx_password.PasswordChar = '*';
            this.tBx_password.Size = new System.Drawing.Size(200, 31);
            this.tBx_password.TabIndex = 4;
            // 
            // btn_guest
            // 
            this.btn_guest.Location = new System.Drawing.Point(264, 209);
            this.btn_guest.Name = "btn_guest";
            this.btn_guest.Size = new System.Drawing.Size(120, 40);
            this.btn_guest.TabIndex = 5;
            this.btn_guest.Text = "Guest";
            this.btn_guest.UseVisualStyleBackColor = true;
            this.btn_guest.Click += new System.EventHandler(this.btn_guest_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Password";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pbx_main
            // 
            this.pbx_main.BackColor = System.Drawing.Color.Transparent;
            this.pbx_main.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pbx_main.ErrorImage")));
            this.pbx_main.Image = ((System.Drawing.Image)(resources.GetObject("pbx_main.Image")));
            this.pbx_main.Location = new System.Drawing.Point(222, 17);
            this.pbx_main.Name = "pbx_main";
            this.pbx_main.Size = new System.Drawing.Size(162, 186);
            this.pbx_main.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbx_main.TabIndex = 6;
            this.pbx_main.TabStop = false;
            // 
            // lbl_Hello
            // 
            this.lbl_Hello.AutoSize = true;
            this.lbl_Hello.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Hello.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(204)));
            this.lbl_Hello.ForeColor = System.Drawing.Color.White;
            this.lbl_Hello.Location = new System.Drawing.Point(12, 9);
            this.lbl_Hello.Name = "lbl_Hello";
            this.lbl_Hello.Size = new System.Drawing.Size(204, 24);
            this.lbl_Hello.TabIndex = 0;
            this.lbl_Hello.Text = "Welcome to Black Jack";
            // 
            // lbl_error
            // 
            this.lbl_error.AutoSize = true;
            this.lbl_error.BackColor = System.Drawing.Color.Transparent;
            this.lbl_error.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_error.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_error.Location = new System.Drawing.Point(12, 34);
            this.lbl_error.Name = "lbl_error";
            this.lbl_error.Size = new System.Drawing.Size(180, 50);
            this.lbl_error.TabIndex = 0;
            this.lbl_error.Text = "Неверное введено\r\nNickname/password\r\n";
            this.lbl_error.Visible = false;
            // 
            // Autentification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(392, 255);
            this.Controls.Add(this.pbx_main);
            this.Controls.Add(this.btn_guest);
            this.Controls.Add(this.tBx_password);
            this.Controls.Add(this.tBx_NickName);
            this.Controls.Add(this.btn_register);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_error);
            this.Controls.Add(this.lbl_Hello);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Autentification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BlackJack";
            this.Load += new System.EventHandler(this.Autentification_Load);
            this.Click += new System.EventHandler(this.Autentification_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pbx_main)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Button btn_register;
        private System.Windows.Forms.TextBox tBx_NickName;
        private System.Windows.Forms.TextBox tBx_password;
        private System.Windows.Forms.Button btn_guest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbx_main;
        private System.Windows.Forms.Label lbl_Hello;
        private System.Windows.Forms.Label lbl_error;
    }
}

