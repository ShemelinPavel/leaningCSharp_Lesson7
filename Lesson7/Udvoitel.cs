using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7
{
    class Udvoitel
    {
        int current;
        int finish;
        Stack<int> history = new Stack<int>();
        StatusGame statusGame;

        enum StatusGame
        {
            Game, Win, Lose
        }

        public int Current
        {
            get { return current; }
        }

        public int Finish
        {
            get { return finish; }
        }

        public Udvoitel(int finish)
        {
            this.finish = finish;
            current = 1;
        }

        public void Plus()
        {
            current++;
        }

        public void Multi()
        {
            current *= 2;
        }

        public void Reset()
        {
            current = 1;
        }

    }
}
