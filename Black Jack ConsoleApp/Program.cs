using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam_Part2
{
    class Program
    {       
       
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            User Gamer = new User();
            Comp AI = new Comp();
            BL Game = new BL();           

            Game.Run(Gamer, AI);            
                      
            
        }
    }
}
