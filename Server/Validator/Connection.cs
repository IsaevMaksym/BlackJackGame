using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

using System.IO;


namespace Server
{
    using Abstract;
    using ServerABstract;

    class Connection : IDeck
    {
        const int DECK_SIZE = 52;
        public bool CheckPlayer(string nick)
        {
            using (var db = new BJContext())
            {
                bool exist = false;
                var query = from s in db.PLAYERS
                            where s.NickName == nick
                            select s;

                foreach (var student in query)
                {
                    if (student.PlayerID != 0)
                    {
                        exist = true;
                    }
                }

                return exist;
            }
        }

        public bool CheckPlayerPass(string nick, string pass)
        {
            using (var db = new BJContext())
            {
                bool exist = false;
                var query = from s in db.PLAYERS
                            where s.NickName == nick
                            where s.Password == pass
                            select s;

                foreach (var student in query)
                {
                    if (student.PlayerID != 0)
                    {
                        exist = true;
                    }
                }

                return exist;
            }
        }

        public Cards GetCardPicture(int id)
        {

            Cards c = new Cards();
            using (var db = new BJContext())
            {
                var query = from C in db.Cards
                            where C.CardID == id
                            select C;



                foreach (var Card in query)
                {
                    c = Card;
                }
                return c;
            }
        }


        List<Cards> IDeck.GetDeck(int size = 1)
        {

            List<Cards> deck = new List<Cards>();

            using (var db = new BJContext())
            {
                var query = from C in db.Cards
                            where C.CardID <= DECK_SIZE * size
                            select C;

                foreach (var card in query)
                {
                    deck.Add(card);
                }
            }
            return deck;
        }

        public void SaveGame(int playerID, int winner, string log)
        {
            Games g = new Games();

            g.Date = DateTime.Now;
            g.WINNER = winner;
            g.GameLog = log;
            g.Player_1_ID = playerID;


            bJContext.Games.Add(g);
            bJContext.SaveChanges();
        }

        public void CreatePlayer(string nick, string pass)
        {

            PLAYERS pl = new PLAYERS();
            pl.NickName = nick;
            pl.Password = pass;
            pl.Coins = 1000;


            bJContext.PLAYERS.Add(pl);
            bJContext.SaveChanges();

        }

        public int GetPLayerID(string NIck)
        {

            using (var db = new BJContext())
            {
                int id = 0;
                var query = from s in db.PLAYERS
                            where s.NickName == NIck
                            select s;

                foreach (var student in query)
                {
                    if (student.PlayerID != 0)
                    {
                        id = student.PlayerID;
                    }
                }
                return id;
            }
        }


        private PLAYERS GetPLAYERS(int playerID)
        {
            PLAYERS pl = new PLAYERS();

            using (var db = new BJContext())
            {
                
                var query = from s in db.PLAYERS
                            where s.PlayerID == playerID
                            select s;

                foreach (var student in query)
                {
                    if (student.PlayerID != 0)
                    {
                        pl = student;

                    }
                }
               
            }
            return pl;
        }

        public void UpdatePlayer(int playerID, int WinnerID)
        {

            PLAYERS pl = GetPLAYERS(playerID);
            pl.GamesCount++;

            if (playerID== WinnerID)
            {
                pl.WinCount++;                
            }


            bJContext.PLAYERS.Attach(pl);
            bJContext.Entry(pl).State = System.Data.Entity.EntityState.Modified;
            bJContext.SaveChanges();

        }

        void InserCard()
        {
            Cards cards = new Cards();


            string suit = "Diamonds";
            string value = "";

            for (int i = 0; i < 4; i++)
            {
                string path = "E:\\C#\\BlackJack\\Resourses\\Deck\\";


                if (i == 1)
                {
                    suit = "Hearts";
                }
                if (i == 2)
                {
                    suit = "Spades";
                }
                if (i == 3)
                {
                    suit = "Clubs";

                }

                for (int j = 2; j < 15; j++)
                {


                    if (j <= 10)
                    {
                        value = j.ToString();
                    }

                    if (j == 11)
                    {
                        value = "Jack";
                    }
                    if (j == 12)
                    {
                        value = "Queen";
                    }
                    if (j == 13)
                    {
                        value = "King";
                    }
                    if (j == 14)
                    {
                        value = "Ace";
                    }

                    FileStream fs = new FileStream(path + suit + "\\" + value + ".png", FileMode.Open);
                    cards.CardName = value;
                    cards.CardSuit = suit;
                    cards.Image = imageToByteArray(System.Drawing.Image.FromStream(fs));

                    bJContext.Cards.Add(cards);
                    bJContext.SaveChanges();
                }

            }

        }

        private byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            System.IO.MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }


        BJContext bJContext = new BJContext();

    }
}
