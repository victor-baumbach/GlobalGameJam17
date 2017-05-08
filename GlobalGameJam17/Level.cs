using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace GlobalGameJam17
{
    class Level
    {
        public List<LevelCharacter> mexicans = new List<LevelCharacter>();
        List<char> solution;

        public int getLength()
        {
            return mexicans.Count;
        }

        public Level(List<char> problem, List<char> _solution)
        {
            solution = _solution;
            foreach(char key in problem)
            {
                LevelCharacter newMexican = new LevelCharacter(key);
                mexicans.Add(newMexican);
            }
        }

        public bool isSolution(List<char> answer)
        {
            bool isEqual = true;
            if(answer.Count == solution.Count)
            {
                if(solution.Equals(answer))
                {
                    isEqual = true;
                }
                else
                {
                    for (int i = 0; i < solution.Count; i++)
                    {
                        if (solution[i] != answer[i])
                        {
                            isEqual = false;
                        }
                    }
                }
            }
            else
            {
                isEqual = false;
            }
            return isEqual;
        }

        public List<Vector2> positionCalculator(float screenWidth, float screenHeight, float xOffset = 0, float yOffset = 0)
        {
            List<Vector2> positions = new List<Vector2>();
            float offsetForEach = (screenWidth - 2 * xOffset) / (mexicans.Count + 1);
            float verticleOffset = (screenHeight - 2 * yOffset) / 2;
            for (int i = 0; i < mexicans.Count; i++)
            {
                Vector2 newPosition = new Vector2();
                newPosition.X = xOffset + offsetForEach * (i + 1);
                newPosition.Y = yOffset + verticleOffset;
                positions.Add(newPosition);
            }

            return positions; 
        }
    }
}
