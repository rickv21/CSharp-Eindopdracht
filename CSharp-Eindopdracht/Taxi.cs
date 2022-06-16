using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Eindopdracht2
{
    internal class Taxi
    {
        public List<TaxiRide> rides { get; }
        public int taxiID { get; }

        public Taxi(int taxiID)
        {
            this.rides = new List<TaxiRide>();
            this.taxiID = taxiID;
        }

        public void addRide(TaxiRide ride)
        {
            this.rides.Add(ride);
        }

        public void removeRide(TaxiRide ride)
        {
            this.rides.Remove(ride);
        }


        public double getTotalIncome()
        {
            double totalIncome = 0;
            foreach (TaxiRide ride in rides)
            {
                totalIncome += ride.getDueMoney();
            }
            return totalIncome;
        }

        public double getAverageDistance()
        {
            double avg = 0;
            double[] distances = new double[rides.Count];
            int count = 0;
            foreach(TaxiRide ride in rides)
            {
                distances[count] = ride.distance;
                count++;
            }
            if(distances.Length > 0)
            { 
                avg = Queryable.Average(distances.AsQueryable());
            }
            return avg;
        }

        public double getLongestRideDistance()
        {
            double distance = 0;
            foreach(TaxiRide ride in rides)
            {
                if(distance < ride.distance)
                {
                    distance = ride.distance;
                }
            }
            return distance;
        }
        public override string ToString()
        {
            return taxiID.ToString();
        }
    }
}
