using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalExam_Part2
{
    public class IO
    {
        

        #region Constants

        const int xTop = 2;
        const int yLeft = 2;
        const int xBott = 22;
        const int yRight = 22;
        const int ValueTableTop = 4;
        const int ValueTableLeft = 65;


        #region Constants for setting positions of statistic fields
        const int Move_3 = 3;
        const int Move_8 = 8;
        const int Move_10 = 10;
        const int Move_13 = 13;
        const int Move_18 = 18;
        const int Move_30 = 30;
        #endregion

        #endregion


        #region Card Drawing
        public void DrawTheCard(Card card, int shafle = 0,int compShaffle=0)
        {
            char suitChar;
            ConsoleColor k;
            string valueSymb;          
              

            GetSuitAndValueChar(card, out suitChar, out k, out valueSymb);

            int xTop = 2;
            int yLeft = 2;
            int xBott = 8;
            int yRight = 9;                                               //Стандартные размеры карты.

            
            ChangeBackgroungColor(k);
            ChangeForegroundColor(ConsoleColor.White);

            for (int c = yLeft; c < yRight; c++)                            //область под карту
            {
                Console.SetCursorPosition(xTop + shafle, c + compShaffle);
                for (int v = yLeft; v < yRight; v++)
                {
                    Console.Write("*");
                }

            }

            for (int i = yLeft + shafle; i < yRight + shafle; i++)
            {
                Console.SetCursorPosition(i, xTop + compShaffle);
                Console.Write("=");
                Console.SetCursorPosition(i, xBott + compShaffle);
                Console.Write("=");
            }

            for (int j = xTop + compShaffle; j <= xBott + compShaffle; j++)
            {
                Console.SetCursorPosition(yLeft + shafle, j);
                Console.Write("║");
                Console.SetCursorPosition(yRight + shafle, j);
                Console.Write("║");
            }

            Console.SetCursorPosition(xTop + shafle, yLeft + compShaffle);
            Console.Write("╔");
            Console.SetCursorPosition(yLeft + shafle, xBott + compShaffle);
            Console.Write("╚");
            Console.SetCursorPosition(yRight + shafle, xTop + compShaffle);
            Console.Write("╗");
            Console.SetCursorPosition(xBott + 1 + shafle, -1 + yRight + compShaffle);
            Console.Write("╝");

            
                Console.SetCursorPosition((xBott / 2) + 1 + shafle, (yRight  / 2) + 1+ compShaffle);
            ChangeForegroundColor(ConsoleColor.Black);
            Console.Write("{0}{1}", suitChar, valueSymb);
            ChangeForegroundColor(ConsoleColor.White);
            Console.BackgroundColor = ConsoleColor.Black;
            

           
        }       //Отрисовка карты на игрововом поле

	    #endregion


        #region Functions

        public void ChangeForegroundColor(ConsoleColor c)
        {
            Console.ForegroundColor=c;
        }            //Изменяет цвет шрифта

        public void ChangeBackgroungColor(ConsoleColor c)
        {
            Console.BackgroundColor = c;
        }            //Изменяет цвет фона

        public ConsoleColor SetForegroundColor(ConsoleColor c)
        {            
            return c;
        }       //задаёт цвет карты

        public void GetSuitAndValueChar(Card c, out char suitChar, out ConsoleColor k, out  string valueSymb)
        {
            suitChar = '*';
            k = ConsoleColor.White;
            valueSymb = "!";

            switch (c.suitOfCard)
            {
                case CardSuit.Spades:
                    suitChar = '♠';
                    k = SetForegroundColor(ConsoleColor.DarkGray);
                    break;
                case CardSuit.Clubs:
                    suitChar = '♦';
                    k = SetForegroundColor(ConsoleColor.Red);
                    break;
                case CardSuit.Hearts:
                    suitChar = '♥';
                    k = SetForegroundColor(ConsoleColor.DarkRed);
                    break;
                case CardSuit.Diamonds:
                    suitChar = '♣';
                    k = SetForegroundColor(ConsoleColor.Gray);
                    break;
            }

            if ((int)c.valueOfCard >= 2 && (int)c.valueOfCard <= 10)
            {
                int temp = (int)c.valueOfCard;
                valueSymb = string.Format("{0}", temp);
            }
            else
            {
                switch (c.valueOfCard)
                {

                    case CardValue.Jack:
                        valueSymb = "J";
                        break;
                    case CardValue.Queen:
                        valueSymb = "Q";
                        break;
                    case CardValue.King:
                        valueSymb = "K";
                        break;
                    case CardValue.Ace:
                        valueSymb = "A";
                        break;

                }
            }

        }

        public void ShowTheValue(Player pl)
        {
            Console.SetCursorPosition(ValueTableLeft, ValueTableTop);       
            Console.WriteLine("╔============================╗");
            Console.SetCursorPosition(ValueTableLeft, ValueTableTop + 1);
            Console.WriteLine("║ Колличество очков в руке:{0}║", pl.value);
            Console.SetCursorPosition(ValueTableLeft, ValueTableTop + 2);
            Console.WriteLine("╚============================╝");


        }       //Табличка для отобращения колличества очков игрока
        #endregion
       

        #region GameMenu

        public string GameStart()
        {
            ChangeBackgroungColor(ConsoleColor.Black);
            ChangeForegroundColor(ConsoleColor.Gray);

            Console.Title = "♠♥♣♦ Blackjack Game by Maks Isaiev";            
            Console.WriteLine("Добро пожаловать в игру!");
            Console.Write("Введите пожалуйста ваше имя: ");
             
            string playerName = Console.ReadLine();
           
            return playerName;

        }                      //Начальная меню с вводом имени
        
        public ConsoleKey Menu(string playerName)
        {
            ConsoleKey key;
            ChangeForegroundColor(ConsoleColor.Gray);
            do
            {

                Console.Clear();
                Console.WriteLine("Здравствуй {0}!", playerName);
                Console.WriteLine("Выбери один из пунктов меню:");
                Console.WriteLine("1 - Правила игры.");
                Console.WriteLine("2 - Начать игру.");
                Console.WriteLine("3 - Статистика.");
                Console.WriteLine("Esc - Выход."); 
     
                key = Console.ReadKey().Key;
            } while ((key != ConsoleKey.Escape) && (key != ConsoleKey.D1) && (key != ConsoleKey.D2) && (key != ConsoleKey.D3));

            return key;
        }      //Вывод основного Меню игры

        public void Rules()
        {
            Console.Clear();
            ChangeForegroundColor(ConsoleColor.Yellow);
            Console.WriteLine("========================Правила игры=============================");
            Console.WriteLine("В начале игры вы получаете 2 Карты. Каждая карта имеет свою \"цену\".");
            Console.WriteLine("Вы можете брать карты, пока сумма очков не будет равна или будет больше 21");
            Console.WriteLine("В случае, если у вас больше 21, то вы проигрываете.");
            Console.WriteLine("Когда вы закончили набирать карты, их набирает компьютер. ");
            Console.WriteLine("После того, как компьютер возьмёт карты, сравниваются очки.");
            Console.WriteLine("Побеждает тот, у кого сумма ближе к 21");
            Console.WriteLine("========================Приятной Игры=============================");
            Console.Write("Нажмите любую клавишу...");
            Console.ReadKey();
        }                            //Правила игры

        public void Winner(int num) 
                    
        {
            Console.SetCursorPosition(1, 25);
            switch (num)
            {
                case 1:
                    ChangeForegroundColor(ConsoleColor.Yellow);                    
                    Console.WriteLine("Поздравляю вы выиграли!!!");
                    break;
                case 2:
                    ChangeForegroundColor(ConsoleColor.Gray);
                    Console.WriteLine("Ничья! Тоже неплохо.");
                    break;
                case 3:
                    ChangeForegroundColor(ConsoleColor.Red);
                    Console.WriteLine("Продул! В другой раз повезёт");
                    break;
                
            }
        }                   //Вывод результатов партии

        public void Statistic(User player)  
        {
            Console.Clear();
            
            int size=50;           
            double percent;

            if (player.winCount==0)
            {
                percent = 0;
            }
            else
            {
                percent = (100.0 * player.winCount / player.gamesCount);
            }

            if (player.name.Length>10)
            {
                size = player.name.Length;
            }
            ChangeBackgroungColor(ConsoleColor.Blue);
            ChangeForegroundColor(ConsoleColor.White);
            Console.SetCursorPosition(9, 1);
            Console.WriteLine("Вот твоя статистика за этот сеанс");

            #region Draw statistics Fiels
            for (int c = yLeft; c < xBott; c++)                            //область под карту
            {
                Console.SetCursorPosition(xTop , c );
                for (int v = yLeft; v < size; v++)
                {
                    Console.Write(" ");
                }

            }

            for (int i = yLeft; i < size; i++)
            {                
                    Console.SetCursorPosition(i, xTop);
                    Console.Write("=");
                    Console.SetCursorPosition(i, xTop + 6);
                    Console.Write("=");  
                    Console.SetCursorPosition(i, xTop+11);
                    Console.Write("=");
                    Console.SetCursorPosition(i, xTop + 16);
                    Console.Write("=");     
                    Console.SetCursorPosition(i, xBott);
                    Console.Write("=");                
                
            }

            for (int j = xTop; j <= xBott; j++)
            {
                Console.SetCursorPosition(yLeft, j);
                Console.Write("║");
                Console.SetCursorPosition((size - yLeft)/2+2, j);
                Console.Write("║");
                Console.SetCursorPosition(size, j);
                Console.Write("║");
            }

            Console.SetCursorPosition((size - yLeft) / 2 + 2, xTop);
            Console.Write("┬");
            Console.SetCursorPosition((size - yLeft) / 2 + 2, xBott);
            Console.Write("┴");
            Console.SetCursorPosition(xTop, yLeft);
            Console.Write("╔");
            Console.SetCursorPosition(yLeft, xBott);
            Console.Write("╚");
            Console.SetCursorPosition(size, xTop);
            Console.Write("╗");
            Console.SetCursorPosition(size ,  yRight);
            Console.Write("╝");
            #endregion

            Console.SetCursorPosition(yLeft + Move_10, xTop + Move_3);
            Console.Write("Игрок: ");
            Console.SetCursorPosition(yLeft + Move_30, xTop + Move_3);
            Console.Write("{0}",player.name);

            Console.SetCursorPosition(yLeft + Move_10, xTop + Move_8);
            Console.Write("Сыграл: ");
            Console.SetCursorPosition(yLeft + Move_30, xTop + Move_8);
            Console.Write("{0} партий", player.gamesCount);

            Console.SetCursorPosition(yLeft + Move_10, xTop + Move_13);
            Console.Write("Выиграл: ");
            Console.SetCursorPosition(yLeft + Move_30, xTop + Move_13);
            Console.Write("{0} партий", player.winCount);

            Console.SetCursorPosition(yLeft + Move_10, xTop + Move_18);
            Console.Write("Результат: ");
            Console.SetCursorPosition(yLeft + Move_30, xTop + Move_18);
            Console.Write("{0}% Побед", percent );

            Console.SetCursorPosition(yLeft , xTop + 21);
            Console.Write("Press any key... ");

            Console.ReadKey();
            Console.Clear();
            ChangeBackgroungColor(ConsoleColor.Black);


        }             //Отрисовка таблички с результатами.  
            

        #endregion

       
    }
}
