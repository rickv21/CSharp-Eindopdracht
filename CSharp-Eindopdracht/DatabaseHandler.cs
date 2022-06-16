using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_Eindopdracht2
{
    internal class DatabaseHandler
    {
        private string connectionString;

        public DatabaseHandler(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void connect()
        {
            SqlConnection cnn;
            cnn = new SqlConnection(this.connectionString);
            cnn.Open();
            cnn.Close();
        }

        public List<Taxi> getData()
        {
   
            List<Taxi> taxiList = new List<Taxi>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String sql = "SELECT * FROM [Taxi]";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        int taxiID = (int)dataReader.GetValue(
                            dataReader.GetOrdinal("id"));

                        taxiList.Add(new Taxi(taxiID));
                    }
                }
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                foreach (Taxi taxi in taxiList)
                {
                    List<TaxiRide> rideList = new List<TaxiRide>();

                    String rideQuery = "SELECT tr.ride_id, r.* " +
                    "FROM taxi_rides tr LEFT JOIN Ride r ON tr.ride_id = r.id " +
                    "WHERE tr.taxi_id = " + taxi.taxiID;

                    SqlCommand rideCmd = new SqlCommand(rideQuery, connection);

                    SqlDataReader rideReader = rideCmd.ExecuteReader();
                    while (rideReader.Read())
                    {
                        Console.WriteLine(rideReader.GetValue(
                            rideReader.GetOrdinal("distance")));
                    }
                }

            }
            return taxiList;
         
        }

        public int addTaxi()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string insertStatement = "INSERT INTO [Taxi] DEFAULT VALUES SELECT SCOPE_IDENTITY()";

            using (SqlCommand insertCommand = new SqlCommand(insertStatement, connection))
            {
                int taxiID = Convert.ToInt32(insertCommand.ExecuteScalar());
                Console.WriteLine("User created with id: " + taxiID);
                connection.Close();
                return taxiID;
            }
        }

        public int addRide(int taxiID, TaxiRide ride)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string insertStatement = "INSERT INTO [Ride] "
                                            + "(distance, weekday, startime, endtime) "
                                            + "VALUES (@distance, @day, @starttime, @endtime)"
                                            + "SELECT SCOPE_IDENTITY()";
            int rideID;


            using (SqlCommand insertCommand = new SqlCommand(insertStatement, connection))
            {
                insertCommand.Parameters.Add("@distance", SqlDbType.Float).Value = (float) ride.distance;
                insertCommand.Parameters.Add("@day", SqlDbType.Int).Value = ride.day;
                insertCommand.Parameters.Add("@starttime", SqlDbType.DateTime).Value = ride.startTime;
                insertCommand.Parameters.Add("@endtime", SqlDbType.DateTime).Value = ride.endTime;

                rideID = Convert.ToInt32(insertCommand.ExecuteScalar());
                Console.WriteLine("User created with id: " + rideID);
            }

            insertStatement = "INSERT INTO [taxi_rides] "
                                + "(taxi_id, ride_id) "
                                + "VALUES (@taxiID, @rideID)";

            using (SqlCommand insertCommand = new SqlCommand(insertStatement, connection))
            {
                insertCommand.Parameters.Add("@taxiID", SqlDbType.Int).Value = taxiID;
                insertCommand.Parameters.Add("@rideID", SqlDbType.Int).Value = rideID;

                connection.Close();
                return rideID;
            }
        }

        public void deleteTaxi(int taxiID)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string sql = "Select ride_id from [taxi_rides] where taxi_id=" + taxiID;

            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {

                String delSQL = "Delete from [taxi_rides] where id=@id";

                int rideID = (int)dataReader.GetValue(dataReader.GetOrdinal("ride_id"));

                using (SqlCommand deleteCommand = new SqlCommand(delSQL, connection))
                {
                    deleteCommand.Parameters.Add("@id", SqlDbType.Int).Value = taxiID;
                }

                delSQL = "Delete from [Ride] where id=@id";

                using (SqlCommand insertCommand = new SqlCommand(sql, connection))
                {
                    insertCommand.Parameters.Add("@id", SqlDbType.Int).Value = rideID;
                }
            }
            connection.Close();


            connection = new SqlConnection(connectionString);
            connection.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();
            string delSql = "DELETE FROM [Taxi] WHERE [id] = " + taxiID;
            SqlCommand cmd = new SqlCommand(delSql, connection);

            adapter.DeleteCommand = command;
            adapter.DeleteCommand.ExecuteNonQuery();



        
        }
    }
}
