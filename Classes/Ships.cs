using System;
using System.Windows;

namespace NationWars
{
    public partial class MainWindow : Window
    {
        class Ships
        {
            public Ships(int shipCount, int shipLvl, int naShipCount)
            {
                this.ShipCount = shipCount;
                this.ShipLvl = shipLvl;
                this.ShipBasePwr = 7;
                this.ShipUserPwr = Math.Round(this.ShipBasePwr + (this.ShipBasePwr / 10 * (this.ShipLvl - 1)), 3);
                this.NaShipCount = naShipCount;
                if (this.ShipCount  <= this.NaShipCount)
                {
                    this.NaShipPwr = Math.Round((this.ShipCount / 2) * this.ShipUserPwr, 2);
                }
                else
                {
                    this.NaShipPwr = Math.Round((this.NaShipCount / 2) * this.ShipUserPwr, 2);
                }
                this.ShipAttPwr = Math.Round(this.ShipCount * this.ShipUserPwr + this.NaShipPwr, 2);

            }

            public int ShipCount { get; set; }
            public int ShipLvl { get; set; }
            public double ShipBasePwr { get; set; }
            public double ShipUserPwr { get; set; }
            public double ShipAttPwr { get; set; }
            public int NaShipCount { get; set; }
            public double NaShipPwr { get; set; }
        }
    }
}
