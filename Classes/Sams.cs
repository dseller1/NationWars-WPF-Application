using System;
using System.Windows;

namespace NationWars
{
    public partial class MainWindow : Window
    {
        class Sams
        {
            public Sams(int samCount, int samLvl, int naSamCount)
            {
                this.SamCount = samCount;
                this.SamLvl = samLvl;
                this.SamBasePwr = 3.35;
                this.SamUserPwr = Math.Round(this.SamBasePwr + (this.SamBasePwr / 10 * (this.SamLvl - 1)), 3);
                this.NaSamCount = naSamCount;
                if (this.SamCount <= this.NaSamCount)
                {
                    this.NaSamPwr = Math.Round((this.SamCount / 2) * this.SamUserPwr, 2);
                }
                else
                {
                    this.NaSamPwr = Math.Round((this.NaSamCount / 2) * this.SamUserPwr, 2);
                }
                this.SamAttPwr = Math.Round(this.SamCount * this.SamUserPwr + this.NaSamPwr, 2);

            }

            public int SamCount { get; set; }
            public int SamLvl { get; set; }
            public double SamBasePwr { get; set; }
            public double SamUserPwr { get; set; }
            public double SamAttPwr { get; set; }
            public int NaSamCount { get; set; }
            public double NaSamPwr { get; set; }
        }
    }
}
