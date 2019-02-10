using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL
{
    using Abstract;


    public class Connection : IDeck, IConnection
    {
        private const int DECK_SIZE = 52;
        private const int DEFAULT_CARD_VALUE = 10;
        private const int CARDS_WITHOUT_IMAGE = 10;
        private const int DEFAULT_PLAYER_COINS = 1000;
        private const int CARD_SUITS_COUNT = 4;

        private BJContext _bJContext = new BJContext();

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

        List<Cards> IDeck.GetDeck(int size)
        {
            if (!IsDBCardsetExist())
            {
                InserCardsToDb();
            }

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

            _bJContext.Games.Add(g);
            _bJContext.SaveChanges();
        }

        public void CreatePlayer(string nick, string pass)
        {
            PLAYERS pl = new PLAYERS();
            pl.NickName = nick;
            pl.Password = pass;
            pl.Coins = DEFAULT_PLAYER_COINS;
            pl.GamesCount = 0;
            pl.WinCount = 0;

            _bJContext.PLAYERS.Add(pl);
            _bJContext.SaveChanges();

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

            if (playerID == WinnerID)
            {
                pl.WinCount++;
            }

            _bJContext.PLAYERS.Attach(pl);
            _bJContext.Entry(pl).State = System.Data.Entity.EntityState.Modified;
            _bJContext.SaveChanges();
        }

        public int getStatistic(string NIck, out double winrate)
        {
            int stats = 0;

            winrate = 0.0;
            using (var db = new BJContext())
            {

                var query = from s in db.PLAYERS
                            where s.NickName == NIck
                            select s;

                foreach (var student in query)
                {
                    if (student.PlayerID != 0)
                    {
                        stats = (int)student.GamesCount;
                        winrate = ((double)student.WinCount * 100 / stats);
                    }
                }

            }


            return stats;

        }
               
        private void InserCardsToDb()
        {
            Cards cards = new Cards();
            int cardValue;
            string cardSuit = "Diamonds";
            string cardName = "";
            string path = "E:\\C#\\BlackJack\\Resourses\\Deck\\";

            for (int i = 0; i < CARD_SUITS_COUNT; i++)
            {
                
                if (i == 1)
                {
                    cardSuit = "Hearts";
                }
                if (i == 2)
                {
                    cardSuit = "Spades";
                }
                if (i == 3)
                {
                    cardSuit = "Clubs";
                }

                for (int j = 2; j < 15; j++)
                {
                    cardValue = DEFAULT_CARD_VALUE;
                    
                    switch (j)
                    {
                        case 11:
                            cardName = "Jack";
                            break;
                        case 12:
                            cardName = "Queen";
                            break;
                        case 13:
                            cardName = "King";
                            break;
                        case 14:
                            cardName = "Ace";
                            cardValue = 11;
                            break;

                        default:
                            cardName = j.ToString();
                            cardValue = j;
                            break;
                    }

                    FileStream fs = new FileStream(path + cardSuit + "\\" + cardName + ".png", FileMode.Open);
                    cards.CardName = cardName;
                    cards.CardSuit = cardSuit;
                    cards.Image = imageToByteArray(System.Drawing.Image.FromStream(fs));
                    cards.CardValue = cardValue;

                    _bJContext.Cards.Add(cards);
                    _bJContext.SaveChanges();
                }

            }

        }

        private byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            System.IO.MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        public bool IsDBCardsetExist()
        {
            using (var db = new BJContext())
            {
                bool exist = false;
                var query = from s in db.Cards
                            select s;
                           
                foreach (var cards in query)
                {
                    if (cards.CardID>=0)
                    {
                        exist = true;
                    }
                }

                return exist;
            }
        }

        public void PushDbCardSet()
        {
            if (!IsDBCardsetExist())
            {
                InserCardsToDb();
            }
        }
    }
}
