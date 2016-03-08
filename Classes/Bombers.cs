using System;
using System.Windows;

namespace NationWars
{
    public partial class MainWindow : Window
    {
        class Bombers
        {
            public Bombers(int bombCount, int bombLvl, int naBombCount)
            {
                this.BombCount = bombCount;
                this.BombLvl = bombLvl;
                this.BombBasePwr = 5;
                this.BombUserPwr = Math.Round(this.BombBasePwr + (this.BombBasePwr / 10 * (this.BombLvl - 1)), 3);
                this.NaBombCount = naBombCount;
                if (this.BombCount <= this.NaBombCount)
                {
                    this.NaBombPwr = Math.Round((this.BombCount / 2) * this.BombUserPwr, 2);
                }
                else
                {
                    this.NaBombPwr = Math.Round((this.NaBombCount / 2) * this.BombUserPwr, 2);
                }
                this.BombAttPwr = Math.Round(this.BombCount * this.BombUserPwr + this.NaBombPwr, 2);
            }

            public int BombCount { get; set; }
            public int BombLvl { get; set; }
            public double BombBasePwr { get; set; }
            public double BombUserPwr { get; set; }
            public double BombAttPwr { get; set; }
            public int NaBombCount { get; set; }
            public double NaBombPwr { get; set; }
        }
    }
}
