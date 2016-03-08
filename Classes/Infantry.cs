using System;
using System.Windows;

namespace NationWars
{
    public partial class MainWindow : Window
    {
        class Infantry
        {
            public Infantry(int infCount, int infLvl, int naInfCount)
            {
                this.InfCount = infCount;
                this.InfLvl = infLvl;
                this.InfBasePwr = 0.85;
                this.InfUserPwr = Math.Round(this.InfBasePwr + (this.InfBasePwr / 10 * (this.InfLvl - 1)), 3);
                this.NaInfCount = naInfCount;
                if (this.InfCount <= this.NaInfCount)
                {
                    this.NaInfPwr = Math.Round((this.InfCount / 2) * this.InfUserPwr, 2);
                }
                else
                {
                    this.NaInfPwr = Math.Round((this.NaInfCount / 2) * this.InfUserPwr, 2);
                }
                this.InfAttPwr = Math.Round(this.InfCount * this.InfUserPwr + this.NaInfPwr, 2);

            }

            public int InfCount { get; set; }
            public int InfLvl { get; set; }
            public double InfBasePwr { get; set; }
            public double InfUserPwr { get; set; }
            public double InfAttPwr { get;set; }
            public int NaInfCount { get; set; }
            public double NaInfPwr { get; set; }
        }
    }
}
