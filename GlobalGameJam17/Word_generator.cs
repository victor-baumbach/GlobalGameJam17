using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Object;
using System.Random;

namespace GlobalGameJam17
{
    class Word_generator
    {
        const Random random = new Random();

        char GenerateChar()
        {
            int randomNumber = random.Next(0, 9);
            char[] words = {'G', 'T', 'P', 'M', 'S', 'F', 'H', 'E', 'A', 'D'};
            Console.WriteLine("The Letter is ", words[randomNumber]);
            return words[randomNumber];
        }
    }
}
