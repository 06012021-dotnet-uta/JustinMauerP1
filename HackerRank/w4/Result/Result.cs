using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace Result
{
    class Result
    {

        /*
        * Complete the 'staircase' function below.
        *
        * The function accepts INTEGER n as parameter.
        */

        public static void staircase(int n)
        {
            char[] space = new char[n - 1];
            string pnd = "#";
            
            for(int i =  0; i < space.Length; i++)
            {
                space[i] = ' ';
            }
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < (space.Length - i); j++)
                {
                    Console.Write(space[j]);
                }
                Console.WriteLine(pnd);
                pnd+="#";
            }
        }

        public static void Main(string[] args)
        {
            System.Console.Write("Enter height of staircase: ");
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            staircase(n);
        }

    }

}
