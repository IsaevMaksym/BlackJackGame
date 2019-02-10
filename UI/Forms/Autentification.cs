using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity.Migrations;


namespace BlackJack
{
   
    using Abstract;
    using BL;
    public partial class Autentification : Form
    {
        private IAutentification _validator= new Validator();
        private MainMenu mainMenu;

        public Autentification()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (_validator.checkPlayerNickPass(tBx_NickName.Text, tBx_password.Text))
            {
                mainMenu = new MainMenu(tBx_NickName.Text);
                mainMenu.Show();
                this.Hide();
            }
            else
            {
                lbl_error.Visible = true;
                tBx_password.Clear();
            }

        }

        private void btn_register_Click(object sender, EventArgs e)
        {
           
            if (_validator.CheckPlayerNick(tBx_NickName.Text) || (String.IsNullOrWhiteSpace(tBx_NickName.Text)))
            {
                tBx_password.Clear();
                MessageBox.Show("Такой пользователь уже существует!");
            }
            else if (String.IsNullOrWhiteSpace(tBx_password.Text) || (tBx_password.Text.Length<6))
            {
                MessageBox.Show("Пароль должен быть более 6 символов");
            }
            else
            {
                _validator.CreatePlayer(tBx_NickName.Text, tBx_password.Text);
                MessageBox.Show("Пользователь создан!");
            }
        }

        private void btn_guest_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu("Guest");
            mm.Show();
            this.Hide();
        }

        private void Autentification_Click(object sender, EventArgs e)
        {
            if (sender is ConsoleKey)
            {
                if ((ConsoleKey)sender == ConsoleKey.Enter)
                {
                    btn_login_Click(sender, e);
                }
            }
        }

        private void Autentification_Load(object sender, EventArgs e)
        {
            if (!_validator.CheckPlayerNick("player") )
            {
                _validator.CreatePlayer("player", "password");

            }
            
        }
    }
}
