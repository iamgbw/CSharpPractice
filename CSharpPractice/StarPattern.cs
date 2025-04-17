using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    internal class StarPattern
    {
        public static void StarPatternVerticalDamaru() 
        {
            for (int row = 0; row <= 6; row++)
            {
                for (int col = 0; col <= 6; col++)
                {
                    if (row == 0 || row == 6 || (row + col == 6) || row == col)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                
                }

                Console.WriteLine();
            
            }
        }

        public static void StarPatternHorizontalDamaru() 
        {
            for(int row = 0; row <= 6; row++)
            {
                for (int col = 0; col <= 6; col++)
                {
                    if(col == 0 || col == 6 || (row == col) || (row + col == 6))
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        public static void HollowDiamond()
        {
            for (int row = 0; row <= 8; row++)
            {
                for (int col = 0; col <= 8; col++)
                {
                    if ((row + col == 4) || (col - row == 4) || (row - col == 4) || (col + row == 4) || (row + col == 12))
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        public static void ButterFlyPattern()
        {
            Console.WriteLine("ButterFlyPattern");
            for (int row = 0; row <= 9; row++)
            {
                for (int col = 0; col <= 9; col++)
                {
                    if ((row == 0) || (row == 9) || (row == col) || (row + col == 9) || ((row + col > 0) && (row + col <= 9)))
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        
        }
    }
}
