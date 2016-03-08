using System;
using System.Windows;

namespace NationWars
{
    public partial class MainWindow : Window
    {
        class Spies
        {
            public Spies(int spyCount, int spyLvl, int naSpyCount)
            {
                this.SpyCount = spyCount;
                this.SpyLvl = spyLvl;
                this.SpyBasePwr = 5;
                this.SpyUserPwr = Math.Round(this.SpyBasePwr + (this.SpyBasePwr / 10 * (this.SpyLvl - 1)), 3);
                this.NaSpyCount = naSpyCount;
                if (this.SpyCount <= this.NaSpyCount)
                {
                    this.NaSpyPwr = Math.Round((this.SpyCount / 2) * this.SpyUserPwr, 2);
                }
                else
                {
                    this.NaSpyPwr = Math.Round((this.NaSpyCount / 2) * this.SpyUserPwr, 2);
                }
                this.SpyAttPwr = Math.Round(this.SpyCount * this.SpyUserPwr + this.NaSpyPwr, 2);
            }

            public int SpyCount { get; set; }
            public int SpyLvl { get; set; }
            public double SpyBasePwr { get; set; }
            public double SpyUserPwr { get; set; }
            public double SpyAttPwr { get; set; }
            public int NaSpyCount { get; set; }
            public double NaSpyPwr { get; set; }
        }
    }
}
