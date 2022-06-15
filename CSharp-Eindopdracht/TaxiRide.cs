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
            return 0;
        }
    }
}
