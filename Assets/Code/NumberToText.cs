using System;
using System.Collections.Generic;

using UnityEngine;

namespace Asteroids
{
    public static class NumberToText
    {
        static List<Entry> entries;

        static NumberToText()
        {
            entries = new List<Entry>();
            entries.Add(new Entry(9, "B"));
            entries.Add(new Entry(6, "M"));
            entries.Add(new Entry(3, "K"));
        }

        public static string ToText<T>(this T number) where T: struct
        {
            float _number = 0f;

            if(number is int number2)
                _number = number2;
            else if(number is uint number3)
                _number = number3;
            else if(number is long number4)
                _number = number4;
            else if(number is ulong number5)
                _number = number5;
            else
                return String.Empty;
            
            return ToText2(_number);
        }

        public static string ToText2(float number)
        {
            string result = String.Empty;
            bool done = false;

            foreach(var entry in entries)
            {
                if( (number / entry.multiplier) < 1.0 )
                    continue;
                result = ((int)(number / entry.multiplier)).ToString() + entry.suffix;
                done = true;
                break;
            }
            if(!done)
                result = number.ToString();

            return result;
        }

        private class Entry
        {
            public int multiplier;
            public string suffix;

            public Entry(int power, string _suffix)
            {
                multiplier = (int)Math.Pow(10, power);
                suffix = _suffix;
            }
        }
    }
}
