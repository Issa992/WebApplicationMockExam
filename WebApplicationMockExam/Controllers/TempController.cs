using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMockExam.Model;

namespace WebApplicationMockExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TempController : ControllerBase
    {
        private string connectionString = ConnectionString.connectionString;
  ///////////////////////      //for test
        //public static List<Temp> _temps;
        //private static int _nextId;


        //public void ReInitialize()
        //{
        //    Initialize();
        //}

        //private static void Initialize()
        //{
        //    _temps = new List<Temp>();
        //    Temp t1 = new Temp { Id = 1, Humidity = 22, Pressure = 11, Temperatur = 21, };
        //    Temp t2 = new Temp { Id = 2, Humidity = 33, Pressure = 10, Temperatur = 22, };

        //    _temps.Add(t1);
        //    _temps.Add(t2);
        //    _nextId = 3;
        //}
       //////////////////// //testDone//

        // GET: api/Temp
        [HttpGet]
        public IEnumerable<Temp> Get()
        {


            string selectString = "SELECT * FROM dbo.Temp";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(selectString, conn))
                {


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Temp> result = new List<Temp>();
                        while (reader.Read())
                        {
                            Temp temp = ReadTemp(reader);
                            result.Add(temp);
                        }

                        return result;
                    }
                }
            }

            //return _temp for test static list commint the code above to test the method 
            return null;
        }

        private Temp ReadTemp(SqlDataReader reader)
        {
            int id = reader.GetInt32(0);
            decimal humidity = reader.GetDecimal(1);
            decimal temperature = reader.GetDecimal(2);
            decimal pressure = reader.GetDecimal(3);
            DateTime timeStamp = reader.GetDateTime(4);
            Temp temp = new Temp { Id = id,  Humidity = humidity, Temperatur = temperature, Pressure = pressure, TimeStamp = timeStamp };
            return temp;
        }

        // GET: api/Temp/5
        [HttpGet("{id}", Name = "Get")]
        public Temp Get(int id)
        {
            /////////   //for test
            //return _temps.FirstOrDefault(temp => temp.Id == id);
            ////////done test



            string selectString = "SELECT * FROM dbo.Temp WHERE Id =@id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(selectString, conn))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            return ReadTemp(reader);

                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }

            return null;
        }

        // POST: api/Temp
        [HttpPost]

        public int Post([FromBody] Temp value) //change int to Temp when you run the test
        {

            ////////////    //test with static
            //value.Id = _nextId;
            //_nextId++;
            //_temps.Add(value);
            //return value;

            ///////////// //end with test

            const string insertString = "INSERT dbo.Temp(Pressure,Humidity,Temp,TimeStamp)VALUES(@Pressure, @Humidity, @Temp,@Date)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(insertString, conn))
                {
                    command.Parameters.AddWithValue("@Pressure", value.Pressure);
                    command.Parameters.AddWithValue("@Humidity", value.Humidity);
                    command.Parameters.AddWithValue("@Temp", value.Temperatur);
                    command.Parameters.AddWithValue("@Date", value.TimeStamp);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }

            }
        }

        // PUT: api/Temp/5
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] Temp value)
        {
            //UPDATE dbo.Temp SET Pressure=10,Humidity=10,Temp=10 WHERE Id=2




            const string updateUser =
                "UPDATE dbo.Temp SET Pressure=@pressure,Humidity=@humidity,Temp=@temp WHERE Id=@id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(updateUser, conn))
                {
                    command.Parameters.AddWithValue("@pressure", value.Pressure);
                    command.Parameters.AddWithValue("@humidity", value.Humidity);
                    command.Parameters.AddWithValue("@temp", value.Temperatur);
                    command.Parameters.AddWithValue("@id", value.Id);


                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }
            }







            //////////    //test with static
            //Temp te = _temps.FirstOrDefault(temps => temps.Id == id);
            //if (te == null) return null;
            //te.Pressure = value.Pressure;
            //te.Humidity = value.Humidity;
            //te.Temperatur = value.Temperatur;
            //te.TimeStamp = value.TimeStamp;
            //return te;
            //////// //end of test with static
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            ////////   //for test
            //int howMany = _temps.RemoveAll(temp => temp.Id == id);
            //return howMany;
            /////////  //done test

            const string deleteStatement = "delete from dbo.Temp where id=@id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(deleteStatement, conn))
                {
                    command.Parameters.AddWithValue("@id", id);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }
    }
}
