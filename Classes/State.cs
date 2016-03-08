using System.Windows;

namespace NationWars
{
    public partial class MainWindow : Window
    {
        class State
        {
            public State(Spies spy, Infantry inf, Tanks tank, Jets jet, Bombers bomb, Sams sam, Ships ship)
            {
                this.Spy = spy;
                this.Inf = inf;
                this.Tank = tank;
                this.Jet = jet;
                this.Bomb = bomb;
                this.Sam = sam;
                this.Ship = ship;
                this.UserAttPwr = this.Inf.InfAttPwr + this.Tank.TankAttPwr + this.Jet.JetAttPwr + this.Ship.ShipAttPwr;
                this.UserDefPwr = this.Inf.InfAttPwr + this.Tank.TankAttPwr + this.Sam.SamAttPwr + this.Ship.ShipAttPwr;
                this.UserGbAttPwr = (this.Spy.SpyUserPwr * this.Spy.SpyCount) + (this.Jet.JetUserPwr * this.Jet.JetCount) + (this.Bomb.BombUserPwr * this.Bomb.BombCount);
                this.userGbDefPwr = (this.Inf.InfUserPwr * this.Inf.InfCount) + (this.Tank.TankUserPwr * this.Tank.TankCount) + (this.Sam.SamUserPwr * this.Sam.SamCount) + (this.Ship.ShipUserPwr * this.Ship.ShipCount);
                if (this.UserGbAttPwr > this.userGbDefPwr)
                    this.GbProtection = "No";
                else
                    this.GbProtection = "Yes";
                this.Readiness = 0;
            }

            public Spies Spy { get; set; }
            public Infantry Inf { get; set; }
            public Tanks Tank { get; set; }
            public Jets Jet { get; set; }
            public Bombers Bomb { get; set; }
            public Sams Sam { get; set; }
            public Ships Ship { get; set; }
            public double UserAttPwr { get; set; }
            public double UserDefPwr { get; set; }
            public double UserGbAttPwr { get; set; }
            public double userGbDefPwr { get; set; }
            public double Readiness { get; set; }
            public string GbProtection { get; set; }
        }
    }
}
