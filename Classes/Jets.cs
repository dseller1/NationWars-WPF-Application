using System;
using System.Windows;

namespace NationWars
{
    public partial class MainWindow : Window
    {
        class Jets
        {
            public Jets(int jetCount, int jetLvl, int naJetCount)
            {
                this.JetCount = jetCount;
                this.JetLvl = jetLvl;
                this.JetBasePwr = 2.6;
                this.JetUserPwr = Math.Round(this.JetBasePwr + (this.JetBasePwr / 10 * (this.JetLvl - 1)), 3);
                this.NaJetCount = naJetCount;
                if (this.JetCount <= this.NaJetCount)
                {
                    this.NaJetPwr = Math.Round((this.JetCount / 2) * this.JetUserPwr, 2);
                }
                else
                {
                    this.NaJetPwr = Math.Round((this.NaJetCount / 2) * this.JetUserPwr, 2);
                }
                this.JetAttPwr = Math.Round(this.JetCount * this.JetUserPwr + this.NaJetPwr, 2);

            }

            public int JetCount { get; set; }
            public int JetLvl { get; set; }
            public double JetBasePwr { get; set; }
            public double JetUserPwr { get; set; }
            public double JetAttPwr { get; set; }
            public int NaJetCount { get; set; }
            public double NaJetPwr { get; set; }
        }
    }
}
