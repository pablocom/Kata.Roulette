using System.Collections.Generic;

namespace RouletteSimulator
{
    public class ColourByNumberMapper
    {
        public static readonly Dictionary<Colour, HashSet<int>> numbersByColours = new()
        {
            {Colour.Black, new HashSet<int> { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 }},
            {Colour.Red, new HashSet<int> { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 }},
        }; 
        
        public static Colour GetColourByNumber(int number)
        {
            if (number == 0)
                return Colour.Green;

            foreach (var numbersByColour in numbersByColours)
            {
                if (numbersByColour.Value.Contains(number))
                    return numbersByColour.Key;
            }
            
            return Colour.Black;
        }
    }
}