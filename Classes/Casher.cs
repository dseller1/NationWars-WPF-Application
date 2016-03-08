using System;
using System.Windows;

namespace NationWars
{
    public partial class MainWindow : Window
    {
        class Casher
        {
            public Casher(double land, double cs, double comm, double res)
            {
                this.TotalLand = land;
                this.CS = cs;
                this.BPT = Math.Round(this.CS / 3, 0) + 5;
                this.CurrentComm = comm;
                this.CurrentRes = res;
                this.TargetComm = Math.Round((this.TotalLand - this.CS) * this.CommPct, 0);
                this.TargetRes = Math.Round((this.TotalLand - this.CS) * this.ResPct, 0);
                this.CommToBuild = (Math.Floor((this.TargetComm - this.CurrentComm) / this.BPT)) * this.BPT;
                this.ResToBuild = (Math.Floor((this.TargetRes - this.CurrentRes) / this.BPT)) * this.BPT;
                this.ExtraLand = this.TotalLand - this.CS - this.CurrentComm - this.CurrentRes - this.CommToBuild - this.ResToBuild;
                calcExtraLandToBuild();
                checkNumbers();
            }

            private void calcExtraLandToBuild()
            {
                this.CommToBuild += Math.Round(Math.Floor(this.ExtraLand / this.BPT) * this.BPT * this.CommPct, 0);
                this.ResToBuild += Math.Round(Math.Floor(this.ExtraLand / this.BPT) * this.BPT * this.ResPct, 0);
            }

            private void checkNumbers()
            {
                if (this.CurrentComm + this.CommToBuild > this.TargetComm)
                {
                    this.CommToBuild = this.TargetComm - this.CurrentComm;
                    this.ResToBuild = Math.Floor((this.TotalLand - this.CS - this.CurrentComm - this.CurrentRes) / this.BPT) * this.BPT - this.CommToBuild;
                }

                if (this.CurrentRes + this.ResToBuild > this.TargetRes)
                {
                    this.ResToBuild = this.TargetRes - this.CurrentRes;
                    this.CommToBuild = Math.Floor((this.TotalLand - this.CS - this.CurrentComm - this.CurrentRes) / this.BPT) * this.BPT - this.ResToBuild;
                }
            }
            public double TotalLand { get; set; }
            public double CS { get; set; }
            public double BPT { get; set; }
            public double CurrentComm { get; set; }
            public double CurrentRes { get; set; }
            public double TargetComm { get; set; }
            public double TargetRes { get; set; }
            public double CommToBuild { get; set; }
            public double ResToBuild { get; set; }
            public double CommPct = .4;
            public double ResPct = .6;
            public double ExtraLand { get; set; }
        }
    }
}
