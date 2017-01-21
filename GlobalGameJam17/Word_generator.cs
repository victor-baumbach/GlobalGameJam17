using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Object;
//using System.Random;

namespace GlobalGameJam17
{
    class Word_generator
    {
        public static char GenerateChar()
        {
            Random random = new Random();
            int randomNumber = random.Next(9);
            char[] words = {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
            Console.WriteLine("The Letter is ", words[randomNumber]);
            return words[randomNumber];
        }
    }
}
