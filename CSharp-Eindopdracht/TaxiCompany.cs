using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Eindopdracht2
{
    internal class TaxiCompany
    {
        public string companyName { get; set; }
        public IDictionary<int, Taxi> taxis { get; }

        //Temp, will be replaced when DB connection is added.
        //public int highestID = 0;
        public TaxiCompany()
        {
            //TODO
            this.companyName = "Placeholder";
            this.taxis = new Dictionary<int, Taxi>();
        }

        public void addTaxi(int taxiID, Taxi taxi)
        {
            taxis[taxiID] = taxi;
        }

        public void removeTaxi(int taxiID)
        {
            taxis.Remove(taxiID);
        }
    }
}
