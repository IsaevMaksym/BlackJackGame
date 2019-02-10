using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BlackJack
{
    using Abstract;
    using BL;

    public partial class MainMenu : Form
    {
        string PLayerName;
        FGame game;
        fRules rules;
        Istatistics stats;

        public MainMenu(string PLayerName)
        {
            this.PLayerName = PLayerName;
            InitializeComponent();
        }

        private void btn_NewGame_Click(object sender, EventArgs e)
        {
            game = new FGame(PLayerName);
            game.Show();
            this.Hide();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            lbl_PlayerNick.Text = PLayerName;

            GetStats();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Rules_Click(object sender, EventArgs e)
        {
            rules = new fRules();

            rules.ShowDialog();
        }

        void GetStats()
        {
            stats = new Validator();
            double winrate;

            lbl_GamesPlayed.Text = stats.playerStats(PLayerName, out winrate).ToString();
            Lbl_WinRate.Text = winrate.ToString("#.##") + "%";
        }

    }
}
