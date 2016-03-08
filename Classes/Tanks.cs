using System;
using System.Windows;

namespace NationWars
{
    public partial class MainWindow : Window
    {
        class Tanks
        {
            public Tanks(int tankCount, int tankLvl, int naTankCount)
            {
                this.TankCount = tankCount;
                this.TankLvl = tankLvl;
                this.TankBasePwr = 5;
                this.TankUserPwr = Math.Round(this.TankBasePwr + (this.TankBasePwr / 10 * (this.TankLvl - 1)), 3);
                this.NaTankCount = naTankCount;
                if (this.TankCount <= this.NaTankCount)
                {
                    this.NaTankPwr = Math.Round((this.TankCount / 2) * this.TankUserPwr, 2);
                }
                else
                {
                    this.NaTankPwr = Math.Round((this.NaTankCount / 2) * this.TankUserPwr, 2);
                }
                this.TankAttPwr = Math.Round(this.TankCount * this.TankUserPwr + this.NaTankPwr, 2);

            }

            public int TankCount { get; set; }
            public int TankLvl { get; set; }
            public double TankBasePwr { get; set; }
            public double TankUserPwr { get; set; }
            public double TankAttPwr { get; set; }
            public int NaTankCount { get; set; }
            public double NaTankPwr { get; set; }
        }
    }
}
