using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    class Dealer
    {
        public Dealer()
        {
            _History = new List<Cards>();
           
        }

        public Cards GetCard()
        {
            _card = new Cards();
            bool ok = true;
            int newCardID;
            do
            {
                ok = true;
                newCardID = Randomizer.GetCardID();
                if (_History.Count == 0)
                {
                    ok = true;
                    continue;

                }
                foreach (var card in _History)
                {
                    if (newCardID == card.CardID)
                    {
                        ok = false;
                    }

                }

            } while (!ok);

            _card = cardAction.GetNewCard(newCardID);

           
            _History.Add(_card);

            return _card;
        }


        ICardAction cardAction = new Validator();
      
        Cards _card;
        private List<Cards> _History;
        

    }
}
