using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace BlackJack
{
    using Abstract;
    using Controller;

    public partial class FGame : Form
    {
        public FGame(string nick)
        {

            this._PlayerNick = nick;
            InitializeComponent();
        }

        private void FGame_Load(object sender, EventArgs e)
        {

            btn_getCard.Visible = false;
            btn_enought.Visible = false;
            _BJController = new GameCOntroller(_PlayerNick);
            
            createPBList();
            
        }

        private void Btn_newGame_Click(object sender, EventArgs e)
        {

            this.NewGame();
        }

        private void btn_getCard_Click(object sender, EventArgs e)
        {

            if (_BJController.PlayerNeedCard())
            {
                int pbx_index = FoundEmptyPbox(_playerHand_PBx);
                _playerHand_PBx[pbx_index].Image = GetImage(_BJController.GetCard());

            }

            else
            {
                btn_getCard.Hide();
                PCplay();

                _PCHand_PBx[0].Image = GetImage(_BJController.GetHiddenCard());

                GetGinner();
            }

        }

        private void btn_enought_Click(object sender, EventArgs e)
        {
            btn_getCard.Hide();

            PCplay();
                       
            _PCHand_PBx[0].Image = GetImage(_BJController.GetHiddenCard());

            GetGinner();
            
        }

        private void GetGinner()
        {
           int isplayer = _BJController.GetWinner();

            if (isplayer==0)
            {
                lbl_playerWin.Show();
            }
            else if (isplayer == 1)
            {
                lbl_playerWin.Show();
                lbl_pcWin.Show();
            }
            else
            {
                lbl_pcWin.Show();
            }
            btn_MainMenu.Show();
            Btn_newGame.Show();
        }

        private void PCplay()
        {
             while (_BJController.PCNeedCard())
            {               
                int index = FoundEmptyPbox(_PCHand_PBx);
                _PCHand_PBx[index].Image = this.GetImage(_BJController.GetPCCard());
                _PCHand_PBx[index].Refresh();
            }


        }

        private int FoundEmptyPbox(List<PictureBox> boxes)
        {
            int temp = 0;
            foreach (var item in boxes)
            {
                if (item.Image != null)
                {
                    temp++;
                }
                else
                {
                    break;
                }

            }
            return temp;
        }

        private void btn_MainMenu_Click(object sender, EventArgs e)
        {
            mainMenu= new MainMenu(_PlayerNick);
            mainMenu.Show();
            this.Dispose();
        }
        private void createPBList()
        {
            _playerHand_PBx.Add(pbx_player_1);
            _playerHand_PBx.Add(pbx_player_2);
            _playerHand_PBx.Add(pbx_player_3);
            _playerHand_PBx.Add(pbx_player_4);
            _playerHand_PBx.Add(pbx_player_5);
            _playerHand_PBx.Add(pbx_player_6);
            _playerHand_PBx.Add(pbx_player_7);
            _playerHand_PBx.Add(pbx_player_8);
            _PCHand_PBx.Add(pbx_PC_1);
            _PCHand_PBx.Add(pbx_PC_2);
            _PCHand_PBx.Add(pbx_PC_3);
            _PCHand_PBx.Add(pbx_PC_4);
            _PCHand_PBx.Add(pbx_PC_5);
            _PCHand_PBx.Add(pbx_PC_6);
            _PCHand_PBx.Add(pbx_PC_7);
            _PCHand_PBx.Add(pbx_PC_8);
        }

        private void NewGame()
        {
            btn_getCard.Show();
            btn_enought.Show();
            lbl_playerWin.Hide();
            lbl_pcWin.Hide();
            btn_MainMenu.Hide();
            Btn_newGame.Hide();

            if (_playerHand_PBx.Count == 0 || _PCHand_PBx.Count == 0)
            {
                createPBList();
            }

            else
            {
                for (int i = 0; i < _playerHand_PBx.Count; i++)
                {
                    _playerHand_PBx[i].Image = null;
                    _PCHand_PBx[i].Image = null;
                }
            }


            _BJController.StartNewGame();
            
            int pbx_index = FoundEmptyPbox(_playerHand_PBx);
            _playerHand_PBx[pbx_index].Image = GetImage(_BJController.GetCard());

            _BJController.GetPCCard();
            pbx_index = FoundEmptyPbox(_PCHand_PBx);
            using (FileStream fs = new FileStream(@"E:\\C#\\BlackJack\\Resourses\\Deck\\shirt.png", FileMode.Open))
            {
                _PCHand_PBx[pbx_index].Image = System.Drawing.Image.FromStream(fs);
                
            }
           
        }

        private Image GetImage(byte[] picture)
        {
            Image returnImage = null;
            if (picture != null)
            {
                MemoryStream ms = new MemoryStream(picture);
                returnImage = Image.FromStream(ms);

            }

            return returnImage;
        }




        IGamelogic _BJController;
        MainMenu mainMenu;
        List<PictureBox> _playerHand_PBx = new List<PictureBox>(8);
        List<PictureBox> _PCHand_PBx = new List<PictureBox>(8);

        string _PlayerNick;

        
    }
}
