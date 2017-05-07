using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace GlobalGameJam17
{
    class Level
    {
        List<Mexican> mexicans = new List<Mexican>();
        List<Keys> solution;

        public Level(List<Keys> problem, List<Keys> _solution)
        {
            solution = _solution;
            foreach(Keys key in problem)
            {
                Mexican newMexican = new Mexican(key);
                mexicans.Add(newMexican);
            }
        }
    }
}
