using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacesLibrary
{
    public class LPoint
    {
        public int Key { get; set; } 
        public Place Value { get; set; }     
        public LPoint Next { get; set; }   

        public LPoint(Place place)
        {
            Value = place;
            Key = GetCustomHashCode(place.Name);
            Next = null;
        }

        public override string ToString()
        {
            if (Value is City city)
                return $"{Key}:({city.Name}, Нас: {city.Population})";

            return $"{Key}:({Value.Name})";
        }

        public static int GetCustomHashCode(string name)
        {
            int code = 0;
            foreach (char c in name)
                code += (int)c;
            return code;
        }
    }
}
