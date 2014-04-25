using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTestRebtel.Data.AuxiliaryMethod
{
    public static class AuxiliaryMethods
    {
        public static bool Determine2Power(int num)
        {
            return (num != 0) && ((num & (num - 1)) == 0);
        }

        public static string ReverseString(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new InvalidOperationException("The string you trying to reverse is null or empty");
            }
            
            return new string(str.Reverse().ToArray());
        }

        public static string ReplicateString(string str, int count)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new InvalidOperationException("The string you trying to Replicate is null or empty");
            }

            if (count <= 0)
            {
                throw new InvalidOperationException("Is not posible to replicate the string, because the count is less than or equal zero");
            }
            
            var returnValue = string.Empty;

            for (var i = 0; i < count; i++)
            {
                returnValue += str;
            }

            return returnValue;
        }

        public static string OddNumbers(int startNum , int endNUm)
        {
            if (startNum > endNUm)
            {
                throw  new InvalidOperationException("Start number cannot be greater than end number");
            }
            
            var oddNumbers = new List<int>();

            for (var i = startNum; i < endNUm; i++)
            {
                var num = i%2;

                if (num == 0)
                {
                    oddNumbers.Add(i);
                }
             }

            return string.Join(" ", oddNumbers.ToArray());
        }
    }
}
