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

        public string getCompanyName()
        {
            String companyName = "placeholder";

            SqlConnection connection = new SqlConnection(connectionString);
            
            connection.Open();
            String sql = "SELECT value FROM [AppSettings] WHERE [option] = @option";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.Add("@option", SqlDbType.VarChar).Value = "company";

            SqlDataReader dataReader = command.ExecuteReader();
                
            if (dataReader.Read())
            {
               companyName = dataReader.GetString(
               dataReader.GetOrdinal("value"));
            }
            else
            {
               this.createCompany();
            }
            
            return companyName;
        }

        public List<Taxi> getData()
        {
            List<Taxi> taxiList = new List<Taxi>();

            SqlConnection connection = new SqlConnection(connectionString);
           
            connection.Open();
            String sql = "SELECT * FROM [Taxi]";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader dataReader = command.ExecuteReader();
                
            while (dataReader.Read())
            {
             int taxiID = (int)dataReader.GetValue(
                  dataReader.GetOrdinal("id"));

            taxiList.Add(new Taxi(taxiID));
            }

            connection.Close();
            connection.Open();
            
         foreach (Taxi taxi in taxiList)
         {
          List<TaxiRide> rideList = new List<TaxiRide>();

          String rideQuery = "SELECT tr.ride_id, r.* " +
             "FROM taxi_rides tr LEFT JOIN Ride r ON tr.ride_id = r.id " +
              "WHERE tr.taxi_id = " + taxi.taxiID;

          SqlCommand rideCmd = new SqlCommand(rideQuery, connection);

          SqlDataReader r = rideCmd.ExecuteReader();
          while (r.Read())
          {
              TaxiRide ride = new TaxiRide(
                            r.GetDouble(r.GetOrdinal("distance")),
                            r.GetDateTime(r.GetOrdinal("starttime")),
                            r.GetDateTime(r.GetOrdinal("endtime")),
                            r.GetInt32(r.GetOrdinal("weekday")),
                            r.GetInt32(r.GetOrdinal("ride_id")));
              taxi.addRide(ride);
          }
              
        }
        return taxiList;
        }

        public int addTaxi()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string insertStatement = "INSERT INTO [Taxi] DEFAULT VALUES SELECT SCOPE_IDENTITY()";

            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
            int taxiID = Convert.ToInt32(insertCommand.ExecuteScalar());
            Console.WriteLine("User created with id: " + taxiID);
            connection.Close();
            return taxiID;
            
        }

        public void setCompany(string value)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string insertStatement = "UPDATE [AppSettings] SET [value] = @value" +
                                            " WHERE [option] = 'company'";
            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.Add("@value", SqlDbType.VarChar).Value = value;
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }

        public void createCompany()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string insertStatement = "INSERT INTO [AppSettings] "
                                            + "([option], [value]) "
                                            + "VALUES (@option, @value)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.Add("@option", SqlDbType.VarChar).Value = "company";
            insertCommand.Parameters.Add("@value", SqlDbType.VarChar).Value = "placeholder";
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }

        public int addRide(int taxiID, TaxiRide ride)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string insertStatement = "INSERT INTO [Ride] "
                                            + "(distance, weekday, starttime, endtime) "
                                            + "VALUES (@distance, @day, @starttime, @endtime) "
                                            + "SELECT SCOPE_IDENTITY()";
            int rideID = -1;

            using (SqlCommand insertCommand = new SqlCommand(insertStatement, connection))
            {
                insertCommand.Parameters.Add("@distance", SqlDbType.Float).Value = (float) ride.distance;
                insertCommand.Parameters.Add("@day", SqlDbType.Int).Value = ride.day;
                insertCommand.Parameters.Add("@starttime", SqlDbType.DateTime).Value = ride.startTime;
                insertCommand.Parameters.Add("@endtime", SqlDbType.DateTime).Value = ride.endTime;

                rideID = Convert.ToInt32(insertCommand.ExecuteScalar());
                Console.WriteLine("Ride created with id: " + rideID);
            }

            insertStatement = "INSERT INTO [taxi_rides] "
                                + "(taxi_id, ride_id) "
                                + "VALUES (@taxiID, @rideID)";

            using (SqlCommand insertCommand = new SqlCommand(insertStatement, connection))
            {
                insertCommand.Parameters.Add("@taxiID", SqlDbType.Int).Value = taxiID;
                insertCommand.Parameters.Add("@rideID", SqlDbType.Int).Value = rideID;
                insertCommand.ExecuteNonQuery();
            }
            connection.Close();
            return rideID;
        }

        public void deleteTaxi(int taxiID)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            //Get all ids of Rides associated with the Taxi.
            string sql = "Select ride_id from [taxi_rides] where taxi_id=" + taxiID;

            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                //Get the ID of the Ride so we know what Ride can be deleted.
                int rideID = (int)dataReader.GetValue(dataReader.GetOrdinal("ride_id"));

                Console.WriteLine("Deleting Taxi: " + taxiID + ", Ride: " + rideID);

                //Delete all taxi_ride entries where taxi_id is the ID of the Taxi..
                String delSQL = "Delete from [taxi_rides] where taxi_id=@id";

                using (SqlCommand deleteCommand = new SqlCommand(delSQL, connection))
                {
                    deleteCommand.Parameters.Add("@id", SqlDbType.Int).Value = taxiID;
                    deleteCommand.ExecuteNonQuery();
                }


                delSQL = "Delete from [Ride] where id=@id";

                using (SqlCommand insertCommand = new SqlCommand(sql, connection))
                {
                    insertCommand.Parameters.Add("@id", SqlDbType.Int).Value = rideID;
                    insertCommand.ExecuteNonQuery();
                }
            }
            connection.Close();
            connection.Open();

            string delSql = "DELETE FROM [Taxi] WHERE [id] = " + taxiID;
            Console.WriteLine(delSql);
            SqlCommand cmd = new SqlCommand(delSql, connection);


            cmd.ExecuteNonQuery();

            connection.Close();
        }
    }
}
