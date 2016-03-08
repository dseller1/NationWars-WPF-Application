using System;
using System.Windows;

namespace NationWars
{
    public partial class MainWindow : Window
    {
        class Times
        {
            public Times(string state, string hour, string minute, string second, string month, string day)
            {
                this.State = state;
                this.Hour = hour;
                this.Minute = minute;
                this.Second = second;
                this.Month = month;
                this.Day = day;
                this.Time = "";
                this.Grab = 0;
            }

            public string State { get; set; }
            public string Hour { get; set; }
            public string Minute { get; set; }
            public string Second { get; set; }
            public string Month { get; set; }
            public string Day { get; set; }
            public string Time { get; set; }
            public int Grab { get; set; }

            public void makeTime()
            {
                this.Time = this.Hour + ":" + this.Minute + ":" + this.Second + "-" + this.Month + "/" + this.Day;
            }

            public string getTime()
            {
                return this.Time;
            }

            public void stripCurTime(string curTime)
            {
                this.Hour = curTime.Substring(11, 2);
                this.Minute = curTime.Substring(14, 2);
                this.Second = curTime.Substring(17, 2);
                this.Month = curTime.Substring(0, 2);
                this.Day = curTime.Substring(3, 2);
                this.makeTime();
            }

            public void stripTime(string curTime)
            {
                this.Hour = curTime.Substring(0, 2);
                this.Minute = curTime.Substring(3, 2);
                this.Second = curTime.Substring(6, 2);
                this.Month = curTime.Substring(9, 2);
                this.Day = curTime.Substring(12, 2);
                this.makeTime();
            }

            public void addHours()
            {
                DateTime expTime = new DateTime(2016, Convert.ToInt32(this.Month), Convert.ToInt32(this.Day), Convert.ToInt32(this.Hour), Convert.ToInt32(this.Minute), Convert.ToInt32(this.Second));

                expTime = expTime.AddHours(36.0);

                if (expTime.Hour < 10)
                    this.Hour = ("0" + expTime.Hour).ToString();
                else
                    this.Hour = expTime.Hour.ToString();

                if (expTime.Minute < 10)
                    this.Minute = ("0" + expTime.Minute).ToString();
                else
                    this.Minute = expTime.Minute.ToString();

                if (expTime.Second < 10)
                    this.Second = ("0" + expTime.Second).ToString();
                else
                    this.Second = expTime.Second.ToString();

                if (expTime.Month < 10)
                    this.Month = ("0" + expTime.Month).ToString();
                else
                    this.Month = expTime.Month.ToString();

                if (expTime.Day < 10)
                    this.Day = ("0" + expTime.Day).ToString();
                else
                    this.Day = expTime.Day.ToString();
            }

            public static int timeCompare(string expTime, string curTime)
            {
                int expTimeInt = Convert.ToInt32(expTime.Replace(":", "").Replace("-", "").Replace("/", ""));
                int curTimeInt = Convert.ToInt32(curTime.Replace(":", "").Replace("-", "").Replace("/", ""));
                return expTimeInt - curTimeInt;
            }

            public static string timeDif(string time, Times curTime)
            {
                string diff = "";
                TimeSpan difference = new TimeSpan();
                Times expireTime = new Times("", "", "", "", "", "");
                expireTime.stripTime(time);
                Times timeDif = new Times("", "", "", "", "", "");

                DateTime expTime = new DateTime(2016, Convert.ToInt32(expireTime.Month), Convert.ToInt32(expireTime.Day), Convert.ToInt32(expireTime.Hour), Convert.ToInt32(expireTime.Minute), Convert.ToInt32(expireTime.Second));

                DateTime currentTime = new DateTime(2016, Convert.ToInt32(curTime.Month), Convert.ToInt32(curTime.Day), Convert.ToInt32(curTime.Hour), Convert.ToInt32(curTime.Minute), Convert.ToInt32(curTime.Second));

                difference = expTime.Subtract(currentTime);

                if (difference.Hours < 10)
                    timeDif.Hour = "0" + difference.Hours.ToString();
                else
                    timeDif.Hour = difference.Hours.ToString();

                if (difference.Minutes < 10)
                    timeDif.Minute = "0" + difference.Minutes.ToString();
                else
                    timeDif.Minute = difference.Minutes.ToString();

                if (difference.Seconds < 10)
                    timeDif.Second = "0" + difference.Seconds.ToString();
                else
                    timeDif.Second = difference.Seconds.ToString();

                if (difference.Days > 0)
                {
                    timeDif.Hour = (difference.Hours + (difference.Days * 24)).ToString();
                }
                diff = (timeDif.Hour + ":" + timeDif.Minute + ":" + timeDif.Second).ToString();

                return diff;
            }
        }
    }
}
