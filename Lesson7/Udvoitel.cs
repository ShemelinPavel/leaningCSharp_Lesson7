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
        int winMoveQty;
        Stack<int> history = new Stack<int>();

        public event EventHandler<WinLoseEventArgs> RaiseWinLose;

        private void OnRaiseWinLose(StatusGame status)
        {
            EventHandler<WinLoseEventArgs> handler = RaiseWinLose;

            if(handler != null)
            {

                WinLoseEventArgs e = null;

                if(status == StatusGame.Win)
                {
                    e = new WinLoseEventArgs("Поздравляю! Вы выиграли!", true);
                }
                else
                {
                    e = new WinLoseEventArgs($"Увы! Вы проиграли!\n Все можно сделать за {this.winMoveQty.ToString()} ходов", false);
                }
            
                handler(this, e);
            }
        }

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
            CountWinMoveQty(finish, ref winMoveQty);
            ResetHistory();
        }

        public void Plus()
        {
            SaveMoveToHistory(current);
            current++;

            StatusGame curGameState = CheckWinLose();

            if (curGameState == StatusGame.Win || curGameState == StatusGame.Lose) OnRaiseWinLose(curGameState);
        }

        public void Multi()
        {
            SaveMoveToHistory(current);
            current *= 2;

            StatusGame curGameState = CheckWinLose();

            if (curGameState == StatusGame.Win || curGameState == StatusGame.Lose) OnRaiseWinLose(curGameState);
        }

        public void Reset()
        {
            current = 1;
            ResetHistory();
        }

        private void SaveMoveToHistory(int userMove)
        {
            this.history.Push(userMove);
        }

        private void ResetHistory()
        {
            this.history.Clear();
        }

        public void GetLastMoveFromHistory()
        {
            this.current = (this.history.Count ==0) ? 1 : this.history.Pop();
        }

        private int CountWinMoveQty(int currNumber, ref int moveCounter)
        {
            if(currNumber == 1) return currNumber;

            if(currNumber % 2 == 0){ currNumber /= 2; }
            else{ currNumber -= 1; }

            moveCounter++;

            return CountWinMoveQty(currNumber, ref moveCounter);
        }

        private StatusGame CheckWinLose()
        {
            if (this.current == this.finish && this.winMoveQty == this.history.Count) return StatusGame.Win;
            else if (this.current >= this.finish || this.winMoveQty <= this.history.Count) return StatusGame.Lose;
            else return StatusGame.Game;
        }
    }
}
