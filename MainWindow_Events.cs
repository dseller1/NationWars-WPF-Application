using HtmlAgilityPack;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media;

namespace NationWars
{
    public partial class MainWindow : Window
    {
        public void FillUserInformation(object sender)
        {
            if (userArmyInfo.Text.Length > 0)
            {
                string str = userArmyInfo.Text;
                Match match;
                Regex stateRgx = new Regex("State Summary");

                match = stateRgx.Match(str);

                if (match.Success)
                {
                    try
                    {
                        userArmyInfo.Visibility = Visibility.Collapsed;
                        blankText.Visibility = Visibility.Visible;

                        string segment;
                        Regex rgx = new Regex("[0-9]+\\.*[0-9]*\\.*[0-9]*");
                        int startChar;
                        double readiness = 0;

                        // Get to the troop info
                        startChar = str.IndexOf("Spies");
                        segment = str.Substring(startChar, (str.Length - startChar));
                        match = rgx.Match(segment);

                        if (tbUserReadiness.Text.Length > 0)
                        {
                            readiness = Convert.ToDouble(tbUserReadiness.Text.Replace("%", "").Trim()) / 100;
                        }
                        else
                        {
                            readiness = 1;
                        }

                        #region Gather User Spies Info
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblSpyCount.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblSpyLvl.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblNaSpyCount.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        #endregion

                        #region Gather User Infantry Info
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblInfCount.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblInfLvl.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblNaInfCount.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        #endregion

                        #region Gather User Tanks Info
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblTankCount.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblTankLvl.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblNaTankCount.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        #endregion

                        #region Gather User Jets Info
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblJetCount.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblJetLvl.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblNaJetCount.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        #endregion

                        #region Gather User Bombers Info
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblBombCount.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblBombLvl.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblNaBombCount.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        #endregion

                        #region Gather User SAMS Info
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblSamCount.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblSamLvl.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblNaSamCount.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        #endregion

                        #region Gather User Ships Info
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblShipCount.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblShipLvl.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblNaShipCount.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        #endregion

                        #region Create User State
                        Spies spy = new Spies(Convert.ToInt32(lblSpyCount.Content.ToString().Replace(",", "")), Convert.ToInt32(lblSpyLvl.Content.ToString().Replace(",", "")), Convert.ToInt32(lblNaSpyCount.Content.ToString().Replace(",", "")));
                        Infantry inf = new Infantry(Convert.ToInt32(lblInfCount.Content.ToString().Replace(",", "")), Convert.ToInt32(lblInfLvl.Content.ToString().Replace(",", "")), Convert.ToInt32(lblNaInfCount.Content.ToString().Replace(",", "")));
                        Tanks tank = new Tanks(Convert.ToInt32(lblTankCount.Content.ToString().Replace(",", "")), Convert.ToInt32(lblTankLvl.Content.ToString().Replace(",", "")), Convert.ToInt32(lblNaTankCount.Content.ToString().Replace(",", "")));
                        Jets jet = new Jets(Convert.ToInt32(lblJetCount.Content.ToString().Replace(",", "")), Convert.ToInt32(lblJetLvl.Content.ToString().Replace(",", "")), Convert.ToInt32(lblNaJetCount.Content.ToString().Replace(",", "")));
                        Bombers bomb = new Bombers(Convert.ToInt32(lblBombCount.Content.ToString().Replace(",", "")), Convert.ToInt32(lblBombLvl.Content.ToString().Replace(",", "")), Convert.ToInt32(lblNaBombCount.Content.ToString().Replace(",", "")));
                        Sams sam = new Sams(Convert.ToInt32(lblSamCount.Content.ToString().Replace(",", "")), Convert.ToInt32(lblSamLvl.Content.ToString().Replace(",", "")), Convert.ToInt32(lblNaSamCount.Content.ToString().Replace(",", "")));
                        Ships ship = new Ships(Convert.ToInt32(lblShipCount.Content.ToString().Replace(",", "")), Convert.ToInt32(lblShipLvl.Content.ToString().Replace(",", "")), Convert.ToInt32(lblNaShipCount.Content.ToString().Replace(",", "")));

                        State userState = new State(spy, inf, tank, jet, bomb, sam, ship);
                        userState.Readiness = readiness;
                        userState.UserAttPwr *= userState.Readiness;
                        if (userState.Readiness == 0)
                        {
                            tbUserReadiness.Text = "0%";
                        }
                        else
                        {
                            tbUserReadiness.Text = userState.Readiness.ToString("###%");
                        }

                        state = userState;
                        #endregion
                        if (userState.UserAttPwr == 0)
                        {
                            lblUserAttPwr.Content = "0";
                        }
                        else
                        {
                            lblUserAttPwr.Content = userState.UserAttPwr.ToString("###,###,###,###");
                        }

                        lblUserGbProtect.Content = userState.GbProtection;

                        if (userArmyInfo.Text.Length > 0 && defArmyInfo.Text.Length > 0 && recalc == false)
                        {
                            calcAttPwr();
                            if (Convert.ToDouble(lblAttStr.Content) > 100)
                            {
                                calcRecTroops();
                                displayTroops();
                            }
                        }
                    }
                    catch
                    {
                        clearUserInfo();
                        MessageBox.Show("Wrong info dumbass. \nEnter PM military info.");
                    }
                }
                else
                {
                    clearUserInfo();
                    MessageBox.Show("Wrong info dumbass. \nEnter PM military info.");
                }
            }
        }

        public void FillEnemyInformation(object sender)
        {
            if (defArmyInfo.Text.Length > 0)
            {
                string str = defArmyInfo.Text;
                Regex espRgx = new Regex("Espionage");
                Match match;

                match = espRgx.Match(str);
                if (match.Success)
                {
                    try
                    {
                        defArmyInfo.Visibility = Visibility.Collapsed;
                        defBlankText.Visibility = Visibility.Visible;


                        string segment;
                        Regex rgx = new Regex("[0-9]+\\.*[0-9]*\\.*[0-9]*");

                        int startChar;
                        int endChar;
                        double readiness = 0;

                        // Find State Name and Cut String
                        string stateStr = "State: ";
                        startChar = str.IndexOf(stateStr);
                        string readyStr = "Readiness";
                        endChar = str.IndexOf(readyStr);
                        lblStateName.Content = str.Substring(startChar + stateStr.Length, endChar).Trim();
                        segment = str.Substring(endChar + readyStr.Length, str.Length - (endChar + readyStr.Length));

                        match = rgx.Match(segment);

                        #region Get Readiness
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);

                            if (tbEnemyReadiness.Text.Length > 0)
                            {
                                readiness = Convert.ToDouble(tbEnemyReadiness.Text.Replace("%", "").Trim()) / 100;
                                if (readiness == 0)
                                {
                                    tbEnemyReadiness.Text = "0%";
                                }
                                else
                                {
                                    tbEnemyReadiness.Text = readiness.ToString("###%");
                                }
                            }
                            else
                            {
                                readiness = Convert.ToDouble(match.Value.Replace(".", ",").Trim()) / 100;
                                tbEnemyReadiness.Text = readiness.ToString("###%");
                            }
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        #endregion

                        //Get to the troop info
                        startChar = str.IndexOf("Spies");
                        segment = str.Substring(startChar, (str.Length - startChar));
                        match = rgx.Match(segment);

                        #region Gather Enemy Spies Info
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblDefSpyCount.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblDefNaSpyCount.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblDefSpyLvl.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        #endregion

                        #region Gather Enemy Infantry Info
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblDefInfCount.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblDefNaInfCount.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblDefInfLvl.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        #endregion

                        #region Gather Enemy Tanks Info
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblDefTankCount.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblDefNaTankCount.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblDefTankLvl.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        #endregion

                        #region Gather Enemy Jets Info
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblDefJetCount.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblDefNaJetCount.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblDefJetLvl.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        #endregion

                        #region Gather Enemy Bombers Info
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblDefBombCount.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblDefNaBombCount.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblDefBombLvl.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        #endregion

                        #region Gather Enemy SAMS Info
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblDefSamCount.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblDefNaSamCount.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblDefSamLvl.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        #endregion

                        #region Gather Enemy Ships Info
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblDefShipCount.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblDefNaShipCount.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        if (match.Success)
                        {
                            startChar = segment.IndexOf(match.Value);
                            lblDefShipLvl.Content = match.Value.Replace(".", ",").Trim();
                            segment = segment.Substring(startChar + match.Value.Length);
                            match = rgx.Match(segment);
                        }
                        #endregion

                        #region Create Enemy State
                        Spies spy = new Spies(Convert.ToInt32(lblDefSpyCount.Content.ToString().Replace(",", "")), Convert.ToInt32(lblDefSpyLvl.Content.ToString().Replace(",", "")), Convert.ToInt32(lblDefNaSpyCount.Content.ToString().Replace(",", "")));
                        Infantry inf = new Infantry(Convert.ToInt32(lblDefInfCount.Content.ToString().Replace(",", "")), Convert.ToInt32(lblDefInfLvl.Content.ToString().Replace(",", "")), Convert.ToInt32(lblDefNaInfCount.Content.ToString().Replace(",", "")));
                        Tanks tank = new Tanks(Convert.ToInt32(lblDefTankCount.Content.ToString().Replace(",", "")), Convert.ToInt32(lblDefTankLvl.Content.ToString().Replace(",", "")), Convert.ToInt32(lblDefNaTankCount.Content.ToString().Replace(",", "")));
                        Jets jet = new Jets(Convert.ToInt32(lblDefJetCount.Content.ToString().Replace(",", "")), Convert.ToInt32(lblDefJetLvl.Content.ToString().Replace(",", "")), Convert.ToInt32(lblDefNaJetCount.Content.ToString().Replace(",", "")));
                        Bombers bomb = new Bombers(Convert.ToInt32(lblDefBombCount.Content.ToString().Replace(",", "")), Convert.ToInt32(lblDefBombLvl.Content.ToString().Replace(",", "")), Convert.ToInt32(lblDefNaBombCount.Content.ToString().Replace(",", "")));
                        Sams sam = new Sams(Convert.ToInt32(lblDefSamCount.Content.ToString().Replace(",", "")), Convert.ToInt32(lblDefSamLvl.Content.ToString().Replace(",", "")), Convert.ToInt32(lblDefNaSamCount.Content.ToString().Replace(",", "")));
                        Ships ship = new Ships(Convert.ToInt32(lblDefShipCount.Content.ToString().Replace(",", "")), Convert.ToInt32(lblDefShipLvl.Content.ToString().Replace(",", "")), Convert.ToInt32(lblDefNaShipCount.Content.ToString().Replace(",", "")));

                        State enemyState = new State(spy, inf, tank, jet, bomb, sam, ship);
                        enemyState.Readiness = readiness;
                        enemyState.UserDefPwr *= enemyState.Readiness;

                        #endregion

                        if (enemyState.UserDefPwr == 0)
                        {
                            lblEnemyDefPwr.Content = "0";
                        }
                        else
                        {
                            lblEnemyDefPwr.Content = enemyState.UserDefPwr.ToString("###,###,###,###");
                        }
                        lblEnemyGbProtect.Content = enemyState.GbProtection;

                        if (userArmyInfo.Text.Length > 0 && defArmyInfo.Text.Length > 0 && recalc == false)
                        {
                            calcAttPwr();
                            if (Convert.ToDouble(lblAttStr.Content) > 100)
                            {
                                calcRecTroops();
                                displayTroops();
                            }
                        }
                    }
                    catch
                    {
                        clearEnemyInfo();
                        MessageBox.Show("Wrong info dumbass. \nEnter Espionage info from Saved Intels.");
                    }
                }
                else
                {
                    clearEnemyInfo();
                    MessageBox.Show("Wrong info dumbass. \nEnter Espionage info from Saved Intels.");
                }
            }
        }

        public void calcRecTroops()
        {
            lblRecInf.Visibility = Visibility.Collapsed;
            lblRecTanks.Visibility = Visibility.Collapsed;
            lblRecJets.Visibility = Visibility.Collapsed;
            lblRecShips.Visibility = Visibility.Collapsed;
            double tempEnemyPwr = Math.Round(Convert.ToInt64(lblEnemyDefPwr.Content.ToString().Replace(",", "")) * 1.11, 2);

            if (tempEnemyPwr == 0)
            {
                lblRecInf.Content = "Infantry: 1";
            }

            if (tempEnemyPwr > state.Inf.InfAttPwr && state.Inf.InfCount > 0)
            {
                lblRecInf.Content = "Infantry: " + state.Inf.InfCount.ToString("###,###,###,###");
                tempEnemyPwr -= (state.Inf.InfAttPwr);
            }
            else if (tempEnemyPwr > 0 && state.Inf.InfCount > 0)
            {
                double recInf = 0;
                if (state.Inf.InfCount <= state.Inf.NaInfCount)
                {
                    recInf = Math.Ceiling((tempEnemyPwr / state.Inf.InfUserPwr) / 1.5);
                }
                else
                {
                    if (Math.Ceiling((tempEnemyPwr / state.Inf.InfUserPwr) / 1.5) < state.Inf.InfCount)
                    {
                        recInf = Math.Ceiling((tempEnemyPwr / state.Inf.InfUserPwr) / 1.5);
                    }
                    else
                    {
                        recInf = Math.Ceiling((tempEnemyPwr - state.Inf.NaInfPwr) / state.Inf.InfUserPwr);
                    }
                }
                lblRecInf.Content = "Infantry: " + recInf.ToString("###,###,###,###");
                tempEnemyPwr = 0;
            }
            if (tempEnemyPwr > state.Tank.TankAttPwr && state.Tank.TankCount > 0)
            {
                lblRecTanks.Content = "Tanks: " + state.Tank.TankCount.ToString("###,###,###,###");
                tempEnemyPwr -= (state.Tank.TankAttPwr);
            }
            else if (tempEnemyPwr > 0 && state.Tank.TankCount > 0)
            {
                double recTank = 0;
                if (state.Tank.TankCount <= state.Tank.NaTankCount)
                {
                    recTank = Math.Ceiling((tempEnemyPwr / state.Tank.TankUserPwr) / 1.5);
                }
                else
                {
                    if (tempEnemyPwr < state.Tank.NaTankPwr)
                    {
                        recTank = Math.Ceiling((tempEnemyPwr / state.Tank.TankUserPwr) / 1.5);
                    }
                    else
                    {
                        recTank = Math.Ceiling((tempEnemyPwr - state.Tank.NaTankPwr) / state.Tank.TankUserPwr);
                    }
                }
                lblRecTanks.Content = "Tanks: " + recTank.ToString("###,###,###,###");
                tempEnemyPwr = 0;
            }
            if (tempEnemyPwr > state.Jet.JetAttPwr && state.Jet.JetCount > 0)
            {
                lblRecJets.Content = "Jets: " + state.Jet.JetCount.ToString("###,###,###,###");
                tempEnemyPwr -= (state.Jet.JetAttPwr);
            }
            else if (tempEnemyPwr > 0 && state.Jet.JetCount > 0)
            {
                double recJet = 0;
                if (state.Jet.JetCount <= state.Jet.NaJetCount)
                {
                    recJet = Math.Ceiling((tempEnemyPwr / state.Jet.JetUserPwr) / 1.5);
                }
                else
                {
                    if (tempEnemyPwr < state.Jet.NaJetPwr)
                    {
                        recJet = Math.Ceiling((tempEnemyPwr / state.Jet.JetUserPwr) / 1.5);
                    }
                    else
                    {
                        recJet = Math.Ceiling((tempEnemyPwr - state.Jet.NaJetPwr) / state.Jet.JetUserPwr);
                    }
                }
                lblRecJets.Content = "Jets: " + recJet.ToString("###,###,###,###");
                tempEnemyPwr = 0;
            }
            if (tempEnemyPwr > state.Ship.ShipAttPwr && state.Ship.ShipCount > 0)
            {
                lblRecShips.Content = "Ships: " + state.Ship.ShipCount.ToString("###,###,###,###");
                tempEnemyPwr -= (state.Ship.ShipAttPwr);
            }
            else if (tempEnemyPwr > 0 && state.Ship.ShipCount > 0)
            {
                double recShip = 0;
                if (state.Ship.ShipCount <= state.Ship.NaShipCount)
                {
                    recShip = Math.Ceiling((tempEnemyPwr / state.Ship.ShipUserPwr) / 1.5);
                }
                else
                {
                    if (tempEnemyPwr < state.Ship.NaShipPwr)
                    {
                        recShip = Math.Ceiling((tempEnemyPwr / state.Ship.ShipUserPwr) / 1.5);
                    }
                    else
                    {
                        recShip = Math.Ceiling((tempEnemyPwr - state.Ship.NaShipPwr) / state.Ship.ShipUserPwr);
                    }

                }
                lblRecShips.Content = "Ships: " + recShip.ToString("###,###,###,###");
                tempEnemyPwr = 0;
            }
        }

        public void displayTroops()
        {
            if (lblRecInf.Content != null)
            {
                lblRecInf.Visibility = Visibility.Visible;
            }
            if (lblRecTanks.Content != null)
            {
                lblRecTanks.Visibility = Visibility.Visible;
            }
            if (lblRecJets.Content != null)
            {
                lblRecJets.Visibility = Visibility.Visible;
            }
            if (lblRecShips.Content != null)
            {
                lblRecShips.Visibility = Visibility.Visible;
            }
        }

        public void calcAttPwr()
        {
            if (Properties.Settings.Default.DisplayName.Length == 0)
            {
                Properties.Settings.Default.DisplayName = "Noob";
                Properties.Settings.Default.Save();
            }
            
            double attStr = Math.Round((Convert.ToDouble(lblUserAttPwr.Content) / Convert.ToDouble(lblEnemyDefPwr.Content) * 100), 2);
            if (attStr < 100)
            {
                spTroops.Visibility = Visibility.Collapsed;
                lblAttStr.Foreground = Brushes.Red;
                lblAttStatus.Content = "The Force is weak with you Padawan " + Properties.Settings.Default.DisplayName + ".";
            }
            else if (attStr < 111)
            {
                spTroops.Visibility = Visibility.Visible;
                lblAttStr.Foreground = Brushes.Orange;
                lblAttStatus.Content = "Be careful Apprentice " + Properties.Settings.Default.DisplayName + ", they have the high ground.";
            }
            else
            {
                spTroops.Visibility = Visibility.Visible;
                lblAttStr.Foreground = Brushes.Green;
                lblAttStatus.Content = "The Force is strong with you Darth " + Properties.Settings.Default.DisplayName + ".";
            }

            lblAttStr.Content = attStr.ToString("##.##");
            spRecTroop.Visibility = Visibility.Visible;
        }

        public void getGrabCount(string stateNum, int grabAmount)
        {
            if (Properties.Settings.Default.Username.Length != 0 && Properties.Settings.Default.Password.Length != 0)
            {
                try
                {
                    Times curTime = new Times("", "", "", "", "", "");
                    curTime.stripCurTime(DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm:ss"));

                    string loginUrl = "http://game.nation-wars.com/login.php";
                    string eventsUrl = "http://game.nation-wars.com/events.php?action=search&search%5Btimefrom%5D=36&search%5Btimeto%5D=0&search%5Bstateids%5D=&search%5Btags%5D=&search%5Battacktype%5D=1&search%5Bdisplaylimit%5D=800";
                    string scoresUrl = "http://game.nation-wars.com/scores-all.php";

                    string username = Properties.Settings.Default.Username;
                    string password = Properties.Settings.Default.Password;
                    List<string> pages = GetSubsequentLoginPages(loginUrl, eventsUrl, scoresUrl, username, password);

                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(pages[0]);

                    HtmlNode docNode = doc.DocumentNode;
                    HtmlNode table = docNode.SelectSingleNode("//table[@width='95%']");
                    HtmlNodeCollection tableRows = table.SelectNodes(".//tr");
                    List<string> attackers = new List<string>();
                    List<string> defenders = new List<string>();
                    List<Times> times = new List<Times>();
                    string attackStatus = "";
                    int startRow = 0;
                    double stateLand = 0;
                    foreach (HtmlNode row in tableRows)
                    {
                        if (startRow > 0)
                        {
                            HtmlNodeCollection cells = row.SelectNodes(".//td");
                            if (cells.Count == 5)
                            {
                                attackers.Add(cells[1].InnerText);
                                attackStatus = cells[3].InnerText.Substring(0, 6);
                                if (attackStatus != "Defeat")
                                {
                                    string tempNum = cells[2].InnerText.Substring(cells[2].InnerText.IndexOf("#") + 1, cells[2].InnerText.IndexOf(")") - cells[2].InnerText.IndexOf("#") - 1);
                                    defenders.Add(tempNum);
                                    string tempHour = cells[4].InnerText.Substring(0, 2);
                                    string tempMin = cells[4].InnerText.Substring(3, 2);
                                    string tempSec = cells[4].InnerText.Substring(6, 2);
                                    string tempMonth = cells[4].InnerText.Substring(9, 2);
                                    string tempDay = cells[4].InnerText.Substring(12, 2);
                                    Times tempState = new Times(tempNum, tempHour, tempMin, tempSec, tempMonth, tempDay);
                                    tempState.makeTime();
                                    times.Add(tempState);
                                }
                            }
                        }
                        startRow = 1;
                    }
                    Dictionary<string, int> defenderDict = new Dictionary<string, int>();
                    foreach (string i in defenders)
                    {
                        if (!defenderDict.ContainsKey(i))
                        {
                            defenderDict.Add(i, 0);
                        }
                    }
                    foreach (string i in defenders)
                    {
                        defenderDict[i] += 1;
                    }
                    times.Reverse();

                    doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(pages[1]);

                    docNode = doc.DocumentNode;
                    HtmlNodeCollection tables = docNode.SelectNodes("//table[@bordercolor='#111111']");
                    table = tables[1];
                    tableRows = table.SelectNodes(".//tr");
                    startRow = 0;
                    string nation = "";
                    long networth = 0;
                    int GDN = -2;

                    List<GrabState> statesList = new List<GrabState>();
                    foreach (HtmlNode row in tableRows)
                    {
                        if (nation == "")
                        {
                            if (startRow > 0)
                            {
                                HtmlNodeCollection cells = row.SelectNodes(".//td");
                                if (cells.Count == 7)
                                {
                                    string tempNation = "";
                                    string tempState = cells[2].InnerText + cells[3].InnerText;
                                    if (tempState.IndexOf("[") != -1)
                                    {
                                        tempNation = tempState.Substring(tempState.IndexOf("[") + 1, tempState.IndexOf("]") - tempState.IndexOf("[") - 1);
                                    }
                                    string tempNum = tempState.Substring(tempState.IndexOf("#") + 1, tempState.IndexOf(")") - tempState.IndexOf("#") - 1);
                                    if (stateNum == tempNum)
                                    {
                                        networth = Convert.ToInt64(cells[5].InnerText.Replace("$", "").Replace(".", ""));
                                        nation = tempNation;
                                        GDN = cells[6].InnerText.IndexOf("G");
                                    }
                                }
                            }
                            startRow = 1;
                        }
                    }
                    double multiplier = 0;
                    if (networth < 250000)
                    {
                        multiplier = 10;
                    }
                    else if (networth < 500000)
                    {
                        multiplier = 3;
                    }
                    else if (networth < 3000000)
                    {
                        multiplier = 2.5;
                    }
                    else
                    {
                        multiplier = 2;
                    }

                    startRow = 0;

                    foreach (HtmlNode row in tableRows)
                    {
                        if (startRow > 0)
                        {
                            HtmlNodeCollection cells = row.SelectNodes(".//td");
                            Nullable<int> styles = null;

                            if (cells.Count == 7)
                            {
                                if (cells[2].OuterHtml.IndexOf("background") != -1)
                                    styles = 1;
                                GrabState x = new GrabState("", "", 0, 0, "", 0);
                                x.State = cells[2].InnerText;
                                x.Nation = cells[3].InnerText;
                                if (x.Nation == "&nbsp;")
                                {
                                    x.Nation = "";
                                }
                                x.Land = cells[4].InnerText;
                                string tempNation = "";
                                string tempNum = x.State.Substring(x.State.IndexOf("#") + 1, x.State.IndexOf(")") - x.State.IndexOf("#") - 1);
                                if (x.Nation.IndexOf("[") != -1)
                                {
                                    tempNation = x.Nation.Substring(x.Nation.IndexOf("[") + 1, x.Nation.IndexOf("]") - x.Nation.IndexOf("[") - 1);
                                }
                                if (stateNum == tempNum)
                                {
                                    stateLand = Convert.ToDouble(x.Land.Replace(".", ""));
                                }
                                x.Networth = Convert.ToInt64(cells[5].InnerText.Replace("$", "").Replace(".", ""));
                                x.GDN = cells[6].InnerText.IndexOf("G");
                                x.Protection = cells[6].InnerText.IndexOf("P");
                                long tempNet = x.Networth;
                                if (defenderDict.ContainsKey(tempNum))
                                {
                                    foreach (string i in defenders)
                                    {
                                        if (i == tempNum)
                                        {
                                            int count = 0;
                                            foreach (string j in defenders)
                                            {
                                                if (i == j)
                                                {
                                                    count += 1;
                                                }
                                            }
                                            x.Attacks = count;
                                        }
                                    }
                                }
                                foreach (Times i in times)
                                {
                                    if (i.State == tempNum)
                                    {
                                        i.addHours();
                                        i.makeTime();
                                        x.expireTimes.Add(i);
                                    }
                                }
                                if (stateNum != tempNum && nation != tempNation && tempNet <= networth * multiplier && styles == null && x.Protection == -1)
                                {
                                    if (GDN != -1 && networth / 2 <= tempNet && tempNet <= networth * 2)
                                    {
                                        statesList.Add(x);
                                    }
                                    else if (GDN == -1)
                                    {
                                        if (x.GDN != -1 && networth <= tempNet * 2)
                                        {
                                            statesList.Add(x);
                                        }
                                        else if (x.GDN == -1)
                                        {
                                            statesList.Add(x);
                                        }
                                    }
                                }
                            }
                        }
                        startRow = 1;
                    }

                    foreach (GrabState state in statesList)
                    {
                        double land = Convert.ToDouble(state.Land.Replace(".", ""));
                        double attacks = Convert.ToDouble(state.Attacks);
                        if (state.Attacks != 0)
                        {
                            state.EstGrab = Convert.ToInt32((land / stateLand) * (land * .13) * (Math.Pow(.7, attacks)));
                        }
                        else
                        {
                            state.EstGrab = Convert.ToInt32((land / stateLand) * (land * .13));
                        }
                    }
                    statesList.Sort(delegate (GrabState x, GrabState y)
                    {
                        return y.EstGrab.CompareTo(x.EstGrab);
                    });

                    Process[] processes;
                    string procName = "Excel";
                    processes = Process.GetProcessesByName(procName);
                    foreach (Process proc in processes)
                    {
                        proc.CloseMainWindow();
                        proc.WaitForExit();
                    }

                    FileInfo newFile = new FileInfo(@"grabs.xlsx");
                    if (newFile.Exists)
                    {
                        newFile.Delete();  // ensures we create a new workbook
                        newFile = new FileInfo(@"grabs.xlsx");
                    }
                    using (ExcelPackage xlPackage = new ExcelPackage(newFile))
                    {
                        ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets.Add("Grabs");
                        worksheet.View.ShowGridLines = false;
                        createStyles(worksheet);
                        worksheet.Cells["A1"].Value = "State";
                        worksheet.Cells["B1"].Value = "Attacks";
                        worksheet.Cells["D1"].Value = "Land";
                        worksheet.Cells["F1"].Value = "Networth";
                        worksheet.Cells["H1"].Value = "Est Grab";
                        worksheet.Cells["J1"].Value = "CST";
                        int row = 3;
                        foreach (GrabState state in statesList)
                        {
                            int i = 1;
                            if (state.EstGrab > grabAmount)
                            {
                                worksheet.Cells["A" + row.ToString()].Value = state.State + state.Nation.Trim();
                                worksheet.Cells["B" + row.ToString()].Value = state.Attacks;
                                worksheet.Cells["B" + row.ToString()].StyleName = "numStyle";
                                worksheet.Cells["D" + row.ToString()].Value = Convert.ToInt32(state.Land.Replace(".", ""));
                                worksheet.Cells["D" + row.ToString()].StyleName = "numStyle";
                                worksheet.Cells["D" + row.ToString()].Style.Numberformat.Format = "###,###";
                                worksheet.Cells["F" + row.ToString()].Value = state.Networth;
                                worksheet.Cells["F" + row.ToString()].StyleName = "numStyle";
                                worksheet.Cells["F" + row.ToString()].Style.Numberformat.Format = "$###,###,###";
                                worksheet.Cells["H" + row.ToString()].Value = state.EstGrab;
                                worksheet.Cells["H" + row.ToString()].StyleName = "numStyle";
                                worksheet.Cells["H" + row.ToString()].Style.Numberformat.Format = "###,###";
                                worksheet.Row(row - 1).StyleName = "stateStyle";
                                row += 2;

                                foreach (Times grab in state.expireTimes)
                                {
                                    if (i >= 1)
                                    {
                                        grab.Grab = GrabState.calcGrab(state, i, stateLand);
                                        worksheet.Cells["B" + row.ToString()].Value = "Grab " + i.ToString() + ": ";
                                        worksheet.Cells["C" + row.ToString()].Value = grab.Time.ToString();
                                        worksheet.Cells["E" + row.ToString()].Value = "Est Grab: ";
                                        worksheet.Cells["F" + row.ToString()].Value = grab.Grab;
                                        worksheet.Cells["F" + row.ToString()].Style.Numberformat.Format = "###,###";
                                        worksheet.Cells["F" + row.ToString()].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                                        worksheet.Cells["G" + row.ToString()].Value = "Time Until: ";
                                        worksheet.Cells["H" + row.ToString()].Value = (Times.timeDif(grab.Time, curTime)).ToString();
                                        worksheet.Cells["J" + row.ToString()].Formula = "MOD(" + "C" + row.ToString() + "-TIME(6,0,0),1)";
                                        worksheet.Cells["J" + row.ToString()].Style.Numberformat.Format = "h:mm:ss AM/PM";
                                        row += 2;
                                    }
                                    i += 1;
                                }
                                row += 1;
                            }
                        }
                        xlPackage.Save();
                    }
                    System.Diagnostics.Process.Start("grabs.xlsx");
                }
                catch
                {
                    MessageBox.Show("Username and/or Password is incorrect. \nPlease go to Settings and update.");
                }
            }
            else
            {
                MessageBox.Show("Username and Password are required. \nPlease go to Settings and update.");
            }
        }

        public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public List<string> GetSubsequentLoginPages(string loginUrl, string eventsUrl, string scoresUrl, string username, string password, string cookieName = null)
        {
            // Create a request using a URL that can receive a post. 
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(loginUrl);
            // Set the Method property of the request to POST.
            request.Method = "POST";

            CookieContainer container = new CookieContainer();

            if (cookieName != null)
                container.Add(new Cookie(cookieName, username, "/", new Uri(loginUrl).Host));

            request.CookieContainer = container;

            // Create POST data and convert it to a byte array.  Modify this line accordingly
            string postData = String.Format("username={0}&password={1}", username, password);

            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            WebResponse response = request.GetResponse();
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.

            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();

            request = (HttpWebRequest)WebRequest.Create(eventsUrl);
            request.CookieContainer = container;

            response = request.GetResponse();
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            reader = new StreamReader(dataStream);
            // Read the content.
            string events = reader.ReadToEnd();

            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();

            request = (HttpWebRequest)WebRequest.Create(scoresUrl);
            request.CookieContainer = container;

            response = request.GetResponse();
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            reader = new StreamReader(dataStream);
            // Read the content.
            string scores = reader.ReadToEnd();

            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();

            return new List<string>() { events, scores };
        }

        public ExcelWorksheet createStyles(ExcelWorksheet worksheet)
        {
            var headerStyle = worksheet.Workbook.Styles.CreateNamedStyle("headerStyle");
            headerStyle.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            headerStyle.Style.Font.Bold = true;

            var stateStyle = worksheet.Workbook.Styles.CreateNamedStyle("stateStyle");
            stateStyle.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            var numStyle = worksheet.Workbook.Styles.CreateNamedStyle("numStyle");
            numStyle.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            worksheet.Column(1).Width = 33.25;
            worksheet.Column(2).Width = 7;
            worksheet.Column(6).Width = 12.11;
            worksheet.Column(7).Width = 10.25;
            worksheet.Column(9).Width = 1.5;
            worksheet.Column(10).Width = 11.5;
            worksheet.Row(1).StyleName = "headerStyle";

            return worksheet;
        }

        public void getGaAttacks(double population)
        {
            double count = 0;
            double pop = 0;
            double popTaken = 0;
            if (population > 106538073)
            {
                count = Math.Round(32.83101874 * Math.Log(population / 35357), 0);
            }
            else
            {
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(Pages.Population);
                HtmlNode docNode = doc.DocumentNode;
                HtmlNode table = docNode.SelectSingleNode("//table[@width='95%']");
                HtmlNodeCollection tableRows = table.SelectNodes(".//tr");

                string attackStatus = "";
                int startRow = 0;
                foreach (HtmlNode row in tableRows)
                {
                    if (startRow > 0)
                    {
                        HtmlNodeCollection cells = row.SelectNodes(".//td");
                        if (cells.Count == 5)
                        {
                            if (population >= 0)
                            {
                                attackStatus = cells[3].InnerText;
                                if (attackStatus != "Defeat / ")
                                {
                                    pop = Convert.ToInt32(attackStatus.Substring(attackStatus.IndexOf(",") + 1, attackStatus.IndexOf("C") - attackStatus.IndexOf(",") - 1).Replace(".", ""));
                                    popTaken += pop;
                                    population -= pop;
                                    count += 1;
                                }
                            }
                        }
                    }
                    startRow = 1;
                }
            }
            lblGaAttacks.Content = count.ToString();
            spGaAttacks.Visibility = Visibility.Visible;
        }

        public void getArAttacks(double totalLand)
        {
            double count = 0;
            double land = 0;
            double landTaken = 0;
            if (totalLand > 36485)
            {
                count = Math.Round(70.33832735 * Math.Log(0.00159865 * totalLand), 0);
            }
            else
            {
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(Pages.Land);

                HtmlNode docNode = doc.DocumentNode;
                HtmlNode table = docNode.SelectSingleNode("//table[@width='95%']");
                HtmlNodeCollection tableRows = table.SelectNodes(".//tr");

                string attackStatus = "";
                int startRow = 0;
                foreach (HtmlNode row in tableRows)
                {
                    if (startRow > 0)
                    {
                        HtmlNodeCollection cells = row.SelectNodes(".//td");
                        if (cells.Count == 5)
                        {
                            if (totalLand >= 0)
                            {
                                attackStatus = cells[3].InnerText;
                                if (attackStatus != "Defeat / ")
                                {
                                    land = Convert.ToInt32(attackStatus.Substring(0, attackStatus.IndexOf("L") - 1).Replace(".", ""));
                                    landTaken += land;
                                    totalLand -= land;
                                    count += 1;
                                }
                            }
                        }
                    }
                    startRow = 1;
                }
            }
            lblArAttacks.Content = count.ToString();
            spArAttacks.Visibility = Visibility.Visible;
        }

        public void calcLandGrab(double userLand, double targetLand, int attacks)
        {
            double estGrab;

            estGrab = Math.Round((targetLand / userLand) * (targetLand * .13) * Math.Pow(.7, attacks), 0);

            lblEstGrab.Content = estGrab.ToString();
        }

        public void clearUserLabels()
        {
            lblSpyCount.Content = "";
            lblNaSpyCount.Content = "";
            lblSpyLvl.Content = "";
            lblInfCount.Content = "";
            lblNaInfCount.Content = "";
            lblInfLvl.Content = "";
            lblTankCount.Content = "";
            lblNaTankCount.Content = "";
            lblTankLvl.Content = "";
            lblJetCount.Content = "";
            lblNaJetCount.Content = "";
            lblJetLvl.Content = "";
            lblBombCount.Content = "";
            lblNaBombCount.Content = "";
            lblBombLvl.Content = "";
            lblSamCount.Content = "";
            lblNaSamCount.Content = "";
            lblSamLvl.Content = "";
            lblShipCount.Content = "";
            lblNaShipCount.Content = "";
            lblShipLvl.Content = "";
            tbUserReadiness.Text = "";
            lblRecInf.Content = null;
            lblRecTanks.Content = null;
            lblRecJets.Content = null;
            lblRecShips.Content = null;
            lblUserAttPwr.Content = "";
            lblUserGbProtect.Content = "";
            lblAttStr.Content = "";
        }

        public void clearUserInfo()
        {
            userArmyInfo.Text = "";
            userArmyInfo.Visibility = Visibility.Visible;
            blankText.Visibility = Visibility.Collapsed;
            spRecTroop.Visibility = Visibility.Collapsed;
        }

        public void clearEnemyLabels()
        {
            lblStateName.Content = "";
            lblDefSpyCount.Content = "";
            lblDefNaSpyCount.Content = "";
            lblDefSpyLvl.Content = "";
            lblDefInfCount.Content = "";
            lblDefNaInfCount.Content = "";
            lblDefInfLvl.Content = "";
            lblDefTankCount.Content = "";
            lblDefNaTankCount.Content = "";
            lblDefTankLvl.Content = "";
            lblDefJetCount.Content = "";
            lblDefNaJetCount.Content = "";
            lblDefJetLvl.Content = "";
            lblDefBombCount.Content = "";
            lblDefNaBombCount.Content = "";
            lblDefBombLvl.Content = "";
            lblDefSamCount.Content = "";
            lblDefNaSamCount.Content = "";
            lblDefSamLvl.Content = "";
            lblDefShipCount.Content = "";
            lblDefNaShipCount.Content = "";
            lblDefShipLvl.Content = "";
            tbEnemyReadiness.Text = "";
            lblRecInf.Content = null;
            lblRecTanks.Content = null;
            lblRecJets.Content = null;
            lblRecShips.Content = null;
            lblEnemyDefPwr.Content = "";
            lblEnemyGbProtect.Content = "";
            lblAttStr.Content = "";
        }

        public void clearEnemyInfo()
        {
            defArmyInfo.Text = "";
            defArmyInfo.Visibility = Visibility.Visible;
            defBlankText.Visibility = Visibility.Collapsed;
            spRecTroop.Visibility = Visibility.Collapsed;
        }

        public void errorMessage(int errorCode)
        {
            switch (errorCode)
            {
                case 1:
                    MessageBox.Show("All inputs must be valid numbers");
                    break;
                case 2:
                    MessageBox.Show("All inputs are required.");
                    break;
            }
        }

        public void loadStats()
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            string curDir = Directory.GetCurrentDirectory();
            string path = String.Format("{0}/Pages/MyAttacks.htm", curDir);
            string html = File.ReadAllText(path);
            doc.LoadHtml(html);

            HtmlNode docNode = doc.DocumentNode;
            HtmlNode table = docNode.SelectSingleNode("//table[@width='95%']");
            HtmlNodeCollection tableRows = table.SelectNodes(".//tr");
            int startRow = 0;
            double landTaken = 0;
            double averageGrab = 0;
            int numGrabs = 0;
            string stateNum = "33";
            foreach (HtmlNode row in tableRows)
            {
                if (startRow > 0)
                {
                    HtmlNodeCollection cells = row.SelectNodes(".//td");
                    if (cells.Count == 5)
                    {
                        if (cells[1].InnerText.Substring(cells[1].InnerText.IndexOf("#") + 1, 2) == stateNum)
                        {
                            if (cells[3].InnerText != "Defeat / ")
                            {
                                string tempLand = cells[3].InnerText.Replace(".", "");
                                numGrabs += 1;
                                landTaken += Convert.ToDouble(tempLand.Substring(0, tempLand.IndexOf("L") - 1));
                            }
                        }
                    }
                }
                startRow = 1;
            }
            lblGrabCount.Content = numGrabs.ToString();
            lblLandGrabbed.Content = landTaken.ToString("###,###");
            averageGrab = Math.Round(landTaken / numGrabs, 0);
            lblAverageGrab.Content = averageGrab.ToString("###,###");

        }

        public void calcNumbers()
        {
            string html = File.ReadAllText("C:\\Users\\Derek\\Documents\\Visual Studio 2015\\Projects\\NationWarsProject\\NationWars\\Pages\\Hogwarts Extreme.htm");
            int sum = 0;
            int maxNumbers = 64;
            int num1 = Regex.Matches(html, "number1").Count;
            int num2 = Regex.Matches(html, "number2").Count;
            int num3 = maxNumbers - num1 - num2;

            sum = (3 * num3) + (2 * num2) + num1;

            lblSum.Content = sum.ToString();
        }
    }
}
