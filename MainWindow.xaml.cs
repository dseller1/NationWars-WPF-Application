using System;
using System.Windows;
using System.Windows.Controls;

namespace NationWars
{
    public partial class MainWindow : Window
    {
        static State state;
        bool recalc;

        public MainWindow()
        {
            InitializeComponent();
            loadStats();
            Console.Write(Pages.Land.Length);
            //if (Properties.Settings.Default.DisplayName.Length == 0)
            if (Properties.Settings.Default.DisplayName.Length == 0 || Properties.Settings.Default.Username.Length == 0 || Properties.Settings.Default.Password.Length == 0)
            {
                if (Properties.Settings.Default.DisplayName.Length != 0)
                    tbDisplayName.Text = Properties.Settings.Default.DisplayName;
                if (Properties.Settings.Default.Username.Length != 0)
                    tbUsername.Text = Properties.Settings.Default.Username;
                if (Properties.Settings.Default.Password.Length != 0)
                    tbPassword.Password = Properties.Settings.Default.Password;
                tabItems.Visibility = Visibility.Collapsed;
                spDisplayName.Visibility = Visibility.Visible;
            }
            else
            {
                spDisplayName.Visibility = Visibility.Collapsed;
                tabItems.Visibility = Visibility.Visible;
                tbSaveDisplay.Text = Properties.Settings.Default.DisplayName;
                tbSaveUsername.Text = Properties.Settings.Default.Username;
                tbSavePassword.Password = Properties.Settings.Default.Password;
            }
        }

        public void userArmy_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillUserInformation(sender);
        }

        private void clearUserBtn_Click(object sender, RoutedEventArgs e)
        {
            clearUserInfo();
            clearUserLabels();
        }

        public void defArmyInfo_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillEnemyInformation(sender);
        }

        private void tbLandGrab_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblEstGrab.Content = "";
            if (tbAttacks.Text.Length > 0)
            {
                if (!Validation.validateNumber(tbAttacks.Text))
                {
                    errorMessage(1);
                }
            }
            if (tbUserLand.Text.Length > 0 && tbTargetLand.Text.Length > 0)
            {
                if (Validation.validateNumber(tbUserLand.Text) && Validation.validateNumber(tbTargetLand.Text))
                {
                    int attacks = 0;
                    if (tbAttacks.Text.Length > 0)
                    {
                        if (Validation.validateNumber(tbAttacks.Text))
                        {
                            attacks = Convert.ToInt32(tbAttacks.Text);
                        }
                    }
                    calcLandGrab(Convert.ToDouble(tbUserLand.Text), Convert.ToDouble(tbTargetLand.Text), attacks);
                }
                else
                {
                    errorMessage(1);
                }
            }
        }

        public void tbCasher_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblBPT.Content = "";
            lblTargetComm.Content = "";
            lblTargetRes.Content = "";
            lblCommToBuild.Content = "";
            lblResToBuild.Content = "";

            if (tbTotalLand.Text.Length > 0 && tbCS.Text.Length > 0 && tbCurrentComm.Text.Length > 0 && tbCurrentRes.Text.Length > 0)
            {
                if (Validation.validateNumber(tbTotalLand.Text) && Validation.validateNumber(tbCS.Text) && Validation.validateNumber(tbCurrentComm.Text) && Validation.validateNumber(tbCurrentRes.Text))
                {
                    Casher cash = new Casher(Convert.ToDouble(tbTotalLand.Text), Convert.ToDouble(tbCS.Text), Convert.ToDouble(tbCurrentComm.Text), Convert.ToDouble(tbCurrentRes.Text));
                    lblBPT.Content = cash.BPT.ToString();
                    lblTargetComm.Content = cash.TargetComm.ToString();
                    lblTargetRes.Content = cash.TargetRes.ToString();
                    lblCommToBuild.Content = cash.CommToBuild.ToString();
                    lblResToBuild.Content = cash.ResToBuild.ToString();
                }
                else
                {
                    errorMessage(1);
                }
            }
        }

        private void defClearBtn_Click(object sender, RoutedEventArgs e)
        {
            clearEnemyInfo();
            clearEnemyLabels();
        }

        private void btnRecalculate_Click(object sender, RoutedEventArgs e)
        {
            if (Validation.validatePercent(tbUserReadiness.Text) && Validation.validatePercent(tbEnemyReadiness.Text))
            {
                recalc = true;
                lblRecInf.Content = null;
                lblRecTanks.Content = null;
                lblRecJets.Content = null;
                lblRecShips.Content = null;
                lblUserAttPwr.Content = null;
                lblEnemyDefPwr.Content = null;
                FillUserInformation(sender);
                recalc = false;
                FillEnemyInformation(sender);
            }
            else
            {
                errorMessage(1);
            }
        }

        private void btnInitialDisplay_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.DisplayName = tbDisplayName.Text;
            Properties.Settings.Default.Username = tbUsername.Text;
            Properties.Settings.Default.Password = tbPassword.Password;
            Properties.Settings.Default.Save();
            //if (Properties.Settings.Default.DisplayName.Length != 0)
            if (Properties.Settings.Default.DisplayName.Length != 0 && Properties.Settings.Default.Username.Length != 0 && Properties.Settings.Default.Password.Length != 0)
            {
                spDisplayName.Visibility = Visibility.Collapsed;
                tabItems.Visibility = Visibility.Visible;
                tbSaveDisplay.Text = Properties.Settings.Default.DisplayName;
                tbSaveUsername.Text = Properties.Settings.Default.Username;
                tbSavePassword.Password = Properties.Settings.Default.Password;
            }
            else
            {
                MessageBox.Show("All fields required.");
            }
        }

        private void btnSaveSettings_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.DisplayName = tbSaveDisplay.Text;
            Properties.Settings.Default.Username = tbSaveUsername.Text;
            Properties.Settings.Default.Password = tbSavePassword.Password;
            Properties.Settings.Default.Save();
        }

        private void btnGaCalc_Click(object sender, RoutedEventArgs e)
        {
            if (tbPopulation.Text.Length > 0)
            {
                if (Validation.validateNumber(tbPopulation.Text))
                {
                    getGaAttacks(Convert.ToDouble(tbPopulation.Text));
                    //createGaExcel(Convert.ToInt64(tbPopulation.Text));
                }
                else
                {
                    errorMessage(1);
                }
            }
            else
            {
                errorMessage(2);
            }
        }

        private void btnArCalc_Click(object sender, RoutedEventArgs e)
        {
            if (tbLand.Text.Length > 0)
            {
                if (Validation.validateNumber(tbLand.Text))
                {
                    getArAttacks(Convert.ToDouble(tbLand.Text));
                }
                else
                {
                    errorMessage(1);
                }
            }
            else
            {
                errorMessage(2);
            }        
        }

        private void btnGrabCalc_Click(object sender, RoutedEventArgs e)
        {
            if (tbState.Text.Length > 0 && tbGrabLand.Text.Length > 0)
            {
                if (Validation.validateNumber(tbState.Text) && Validation.validateNumber(tbGrabLand.Text))
                {
                    getGrabCount(tbState.Text, Convert.ToInt32(tbGrabLand.Text));
                }
                else
                {
                    errorMessage(1);
                }
            }
            else
            {
                errorMessage(2);
            }
        }

        private void tbPopulation_TextChanged(object sender, TextChangedEventArgs e)
        {
            spGaAttacks.Visibility = Visibility.Hidden;
        }

        private void tbLand_TextChanged(object sender, TextChangedEventArgs e)
        {
            spArAttacks.Visibility = Visibility.Hidden;
        }

        private void btnCalcNumbers_Click(object sender, RoutedEventArgs e)
        {
            calcNumbers();
        }
    }
}
