using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    internal class Program
    {
        public static Cell[] CA = new Cell[81];

        static void Main(string[] args)
        {
            //check args is a 81 number array
            //if (checkArgs(new string[] { "0,1,0, 0,7,0, 5,0,0,", "6,0,0, 0,1,0, 0,3,2,", "0,0,7, 5,9,0, 0,0,0,", "0,0,0, 0,0,7, 0,8,0,", "0,2,0, 4,0,3, 0,1,0,", "0,8,0, 1,0,0, 0,0,0,", "0,0,0, 0,3,5, 1,0,0,", "3,9,0, 0,4,0, 0,0,5,", "0,0,5, 0,6,0, 4,0,0" }))
            //if(checkArgs(new string[] {"0,1,0,0,7,0,5,0,0,6,0,0,0,1,0,0,3,2,0,0,7,5,9,0,0,0,0,0,0,0,0,0,7,0,8,0,0,2,0,4,0,3,0,1,0,0,8,0,1,0,0,0,0,0,0,0,0,0,3,5,1,0,0,3,9,0,0,4,0,0,0,5,0,0,5,0,6,0,0,4,0"}))
            if(checkArgs(args))
            {
                //checkArgs(args);

                foreach(Cell C in CA)
                {
                    C.calculatepossible(CA);
                }

                int checkingIndex = -1;

                bool cont = true;
                string next = "NG";
                while(cont)
                {
                    switch (next)
                    {
                        case "NG":
                            checkingIndex++;
                            if(checkingIndex == 81)
                            {
                                Console.WriteLine("SOLVED");
                                PrintGrid(CA);
                                cont = false;
                                break;
                            }
                            if (!CA[checkingIndex].known)
                            {
                                next = CA[checkingIndex].nextGuess(CA);
                                //PrintGrid(CA);
                            }
                            break;

                        case "RB":
                            checkingIndex--;
                            if(checkingIndex == -1)
                            {
                                Console.WriteLine("COULD NOT SOLVE GRID");
                                cont = false;
                                break;
                            }
                            if (!CA[checkingIndex].known)
                            {
                                next = CA[checkingIndex].nextGuess(CA);
                                //PrintGrid(CA);
                            }
                            break;
                        default:
                            cont = false;
                            break;

                    }
                    //if (!CA[checkingIndex].known)
                    //{
                        //CA[checkingIndex].nextGuess(CA);
                    //}
                    
                }

                //For each cell,
                //  loop:
                //  move the possible on one,
                //  if at the end of the list,
                // set guess index to zero and move back a cell
                //  check validity of the table?
                //
                //
                // IF at the end of the cells, print table
                // IF at index -1 report the grid cannot be solved


                //Console.WriteLine("SOLVED");
                //PrintGrid(CA);
            } else
            {
                Console.Write("Could not solve");
            }
            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }

        public static void PrintGrid(Cell[] CA)
        {
            Console.WriteLine("┌─────┬─────┬─────┐");
            Console.WriteLine($"│{CA[0].value},{CA[1].value},{CA[2].value}│{CA[3].value},{CA[4].value},{CA[5].value}│{CA[6].value},{CA[7].value},{CA[8].value}│");
            Console.WriteLine($"│{CA[9].value},{CA[10].value},{CA[11].value}│{CA[12].value},{CA[13].value},{CA[14].value}│{CA[15].value},{CA[16].value},{CA[17].value}│");
            Console.WriteLine($"│{CA[18].value},{CA[19].value},{CA[20].value}│{CA[21].value},{CA[22].value},{CA[23].value}│{CA[24].value},{CA[25].value},{CA[26].value}│");
            Console.WriteLine("├─────┼─────┼─────┤");
            Console.WriteLine($"│{CA[27].value},{CA[28].value},{CA[29].value}│{CA[30].value},{CA[31].value},{CA[32].value}│{CA[33].value},{CA[34].value},{CA[35].value}│");
            Console.WriteLine($"│{CA[36].value},{CA[37].value},{CA[38].value}│{CA[39].value},{CA[40].value},{CA[41].value}│{CA[42].value},{CA[43].value},{CA[44].value}│");
            Console.WriteLine($"│{CA[45].value},{CA[46].value},{CA[47].value}│{CA[48].value},{CA[49].value},{CA[50].value}│{CA[51].value},{CA[52].value},{CA[53].value}│");
            Console.WriteLine("├─────┼─────┼─────┤");
            Console.WriteLine($"│{CA[54].value},{CA[55].value},{CA[56].value}│{CA[57].value},{CA[58].value},{CA[59].value}│{CA[60].value},{CA[61].value},{CA[62].value}│");
            Console.WriteLine($"│{CA[63].value},{CA[64].value},{CA[65].value}│{CA[66].value},{CA[67].value},{CA[68].value}│{CA[69].value},{CA[70].value},{CA[71].value}│");
            Console.WriteLine($"│{CA[72].value},{CA[73].value},{CA[74].value}│{CA[75].value},{CA[76].value},{CA[77].value}│{CA[78].value},{CA[79].value},{CA[80].value}│");
            Console.WriteLine("└─────┴─────┴─────┘");
        }

        static bool checkArgs(string[] args)
        {
             List<int> cells = new List<int>();
            try
            {
                foreach(string str in args)
                {
                    int[] ia = str.Split(',').Where(s => !string.IsNullOrWhiteSpace(s)).Select(n => Convert.ToInt32(n)).Where(x => x>=0&&x<=9).ToArray();
                    foreach(int i in ia)
                    {
                        cells.Add(i);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Could not convert arguments to int array, try again");
                return false;
            }

            if(cells.Count == 81)
            {
                Console.WriteLine("Arguments are OK");
                GenerateCellArray(cells.ToArray());
                return true;
            } else
            {
                Console.WriteLine($"Not enough numbers in the starting array : {cells.Count}");
            }

            return false;
        }

        static void GenerateCellArray(int[] values)
        {
            for(int i=0; i<81; i++)
            {
                int group = 0;
                switch (i)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 9:
                    case 10:
                    case 11:
                    case 18:
                    case 19:
                    case 20:
                        group = 0;
                        break;
                    case 3:
                    case 4:
                    case 5:
                    case 12:
                    case 13:
                    case 14:
                    case 21:
                    case 22:
                    case 23:
                        group = 1;
                        break;
                    case 6:
                    case 7:
                    case 8:
                    case 15:
                    case 16:
                    case 17:
                    case 24:
                    case 25:
                    case 26:
                        group = 2;
                        break;
                    case 27:
                    case 28:
                    case 29:
                    case 36:
                    case 37:
                    case 38:
                    case 45:
                    case 46:
                    case 47:
                        group = 3;
                        break;
                    case 30:
                    case 31:
                    case 32:
                    case 39:
                    case 40:
                    case 41:
                    case 48:
                    case 49:
                    case 50:
                        group = 4;
                        break;
                    case 33:
                    case 34:
                    case 35:
                    case 42:
                    case 43:
                    case 44:
                    case 51:
                    case 52:
                    case 53:
                        group = 5;
                        break;
                    case 54:
                    case 55:
                    case 56:
                    case 63:
                    case 64:
                    case 65:
                    case 72:
                    case 73:
                    case 74:
                        group = 6;
                        break;
                    case 57:
                    case 58:
                    case 59:
                    case 66:
                    case 67:
                    case 68:
                    case 75:
                    case 76:
                    case 77:
                        group = 7;
                        break;
                    case 60:
                    case 61:
                    case 62:
                    case 69:
                    case 70:
                    case 71:
                    case 78:
                    case 79:
                    case 80:
                        group = 8;
                        break;
                }

                CA[i] = new Cell(values[i], (i/9), (i % 9), group);
                //CA[i] = new Cell(value, row, col, group);
            }
        }
    }
}
