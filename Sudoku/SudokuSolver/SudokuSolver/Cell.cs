using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    internal class Cell
    {
        public int value;
        public bool known;
        public int row;
        public int col;
        public int group;
        public int guessindex;

        public List<int> possibles;

        public Cell(int value, int row, int col, int group)
        {
            this.value = value;
            this.row = row;
            this.col = col;
            this.group = group;
            this.known = (value != 0) ? true : false;
            this.guessindex = 0;

        }

        public void calculatepossible(Cell[] CA)
        {
            List<int> present = new List<int>();
            List<int> temp = new List<int>();
            foreach(Cell c in CA)
            {
                if(c.row == this.row || c.col == this.col || c.group == this.group)
                {
                    present.Add(c.value);
                }
            }
            for(int i = 1; i<10; i++)
            {
                if (!present.Contains(i))
                {
                    temp.Add(i);
                }
            }

            possibles = temp;
        }

        public bool checkValidity(Cell[] CA)
        {
            foreach(Cell c in CA)
            {
                if(c!=this && (c.row == this.row || c.col == this.col || c.group == this.group))
                {
                    if(c.value == this.value)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public string nextGuess(Cell[] CA)
        {
            if (this.guessindex >= this.possibles.Count)
            {
                this.guessindex = 0;
                this.value = 0;
                return "RB";
            } else
            {
                this.value = this.possibles[this.guessindex];
                this.guessindex++;

                if (this.checkValidity(CA))
                {
                    return "NG";
                }
                else
                {
                    return this.nextGuess(CA);
                };
            }
        }
    }
}
