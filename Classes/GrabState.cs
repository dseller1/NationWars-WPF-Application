using System;
using System.Collections.Generic;
using System.Windows;

namespace NationWars
{
    public partial class MainWindow : Window
    {
        class GrabState
        {
            public GrabState(string state, string nation, int attacks, long networth, string land, int estGrab)
            {
                this.State = state;
                this.Nation = nation;
                this.Attacks = attacks;
                this.Networth = networth;
                this.Land = land;
                this.EstGrab = estGrab;
                this.GDN = 0;
                this.Protection = 0;
                this.expireTimes = new List<Times>();
            }

            public string State { get; set; }
            public string Nation { get; set; }
            public int Attacks { get; set; }
            public long Networth { get; set; }
            public string Land { get; set; }
            public int EstGrab { get; set; }
            public int GDN { get; set; }
            public int Protection { get; set; }
            public List<Times> expireTimes { get; set; }

            public static int calcGrab(GrabState state, int i, double stateLand)
            {
                double land = Convert.ToDouble(state.Land.Replace(".", ""));
                double attacks = Convert.ToInt32(state.Attacks - i);
                double estGrab;
                if (state.Attacks != 0)
                {
                    estGrab = (land / stateLand) * (land * .13) * (Math.Pow(.7, attacks));
                }
                else
                {
                    estGrab = (land / stateLand) * (land * .13);
                }

                return Convert.ToInt32(estGrab);
            }
        }
    }
}
