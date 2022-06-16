using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Eindopdracht2
{
    internal class TaxiRide
    {

        public double distance { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public int day { get; set; }
        public int rideID { get; }

        public TaxiRide(double distance, DateTime startTime, DateTime endTime, int day, int rideID)
        {
            this.distance = distance;
            this.startTime = startTime;
            this.endTime = endTime;
            this.day = day;
            this.rideID = rideID;
        }

        public double getDueMoney()
        {
            double wholeNumber = Math.Truncate(this.distance);
            double dueMoney = (wholeNumber * 0.50);
            TimeSpan ts = this.endTime - this.startTime;
            Console.WriteLine("Minutes: " + ts.TotalMinutes);
            dueMoney += (ts.Minutes * 0.17);

            if ((this.day == 4 && this.startTime.Hour >= 22) ||
                this.day >= 5 ||
                (this.day == 0 && this.startTime.Hour <= 7))
            {
                Console.WriteLine("Match - " + this.day + " - " + this.startTime.Hour);
                dueMoney += (dueMoney / 100 * 15);
            }
            return Math.Round(dueMoney, 2);
        }

        public String getDayName()
        {
            switch (this.day)
            {
                case 0: return "Monday";
                case 1: return "Tuesday";
                case 2: return "Wednesday";
                case 3: return "Thursday";
                case 4: return "Friday";
                case 5: return "Saturday";
                case 6: return "Sunday";
                default: return "Invalid";
            }
        }
    }
}
