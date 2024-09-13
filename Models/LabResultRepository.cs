using Generic_Medi_Connect.Models.Repositories;
using Medi_Connect.Models.Interfaces;
using Microsoft.Data.SqlClient;

namespace Medi_Connect.Models
{
    public class LabResultRepository : GenericRepository<LabResult>, ILabResultRepository 
    {
        List<LabResult> _labresult = new List<LabResult>();

        IRepository<LabResult> _labresultRepository = new GenericRepository<LabResult>("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True;");

        private readonly string _connString;

        public LabResultRepository(string conn):base(conn)
        {
            _connString = conn;
        }


        public void Upload(LabResult lr)
        {
            try
            {
                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True;";

                SqlConnection connection = new SqlConnection(connectionString);

                connection.Open();

                // Insert the lab result into the database
                string insertQuery = @"INSERT INTO LabResult (PatientId, TestName, ResultFilePath) 
                                           VALUES (@PatientId, @TestName, @ResultFilePath)";
                SqlCommand cmd = new SqlCommand(insertQuery, connection);
                cmd.Parameters.AddWithValue("@PatientId", lr.PatientId);
                cmd.Parameters.AddWithValue("@TestName", lr.TestName);
                cmd.Parameters.AddWithValue("@ResultFilePath", lr.ResultFilePath);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Lab result uploaded successfully!");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error uploading lab result: " + ex.Message);
            }
        }




        //public IEnumerable<LabResult> View()
        //{
        //    return _labresultRepository.GetAll();

        //}

        public IEnumerable<LabResult> View()
        {
            //List<LabResult> labResults = new List<LabResult>();

            //try
            //{
            //    string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True;";
            //    SqlConnection connection = new SqlConnection(connectionString);
            //    connection.Open();
            //    string query = "SELECT * FROM LabResult";
            //    SqlCommand cmd = new SqlCommand(query, connection);
            //    SqlDataReader reader = cmd.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        LabResult labResult = new LabResult
            //        {
            //            Id = Convert.ToInt32(reader[0]),
            //            PatientId = Convert.ToInt32(reader[1]),
            //            TestName = reader[2].ToString(),
            //            ResultFilePath = reader[3].ToString(),
            //        };

            //        labResults.Add(labResult);
            //    }
            //    connection.Close();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Error fetching lab results: " + ex.Message);
            //}

            //return labResults;

            return _labresultRepository.GetAll();
        }


        //public List<LabResult> Search(string search)
        //{
        //    string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True;";

        //    SqlConnection connection = new SqlConnection(connectionString);

        //    connection.Open();

        //    using (SqlConnection conn = new SqlConnection(connString))
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = new SqlCommand("SELECT * FROM Product WHERE Name LIKE @search", conn))
        //        {
        //            cmd.Parameters.AddWithValue("@search", "%" + search + "%");
        //            SqlDataReader reader = cmd.ExecuteReader();
        //            List<Product> products = new();
        //            while (reader.Read())
        //            {
        //                Product product = new Product();
        //                product.Id = reader.GetInt32(0);
        //                product.Name = reader.GetString(1);
        //                product.CategoryID = reader.GetInt32(2);
        //                product.BrandID = reader.GetInt32(3);
        //                product.UnitID = reader.GetInt32(4);
        //                product.Description = reader.IsDBNull(5) ? DBNull.Value.ToString() : reader.GetString(5);
        //                product.CreatedAt = reader.GetDateTime(6);
        //                product.UpdatedAt = reader.GetDateTime(7);
        //                product.ProductCode = reader.GetString(8);
        //                product.Quantity = reader.GetInt32(9);
        //                product.Weight = reader.GetDecimal(10);
        //                product.Price = reader.GetDecimal(11);
        //                product.SalePrice = reader.GetDecimal(12);
        //                product.ImagePath = reader.GetString(13);
        //                products.Add(product);
        //            }
        //            return products;
        //        }
        //    }
        //}



        public List<LabResult> Search(string search)
        {
            List<LabResult> labResults = new List<LabResult>();

            try
            {
                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True;";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "SELECT * FROM LabResult where TestName Like @search";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@search", "%" + search + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LabResult labResult = new LabResult
                    {
                        Id = Convert.ToInt32(reader[0]),
                        PatientId = Convert.ToInt32(reader[1]),
                        TestName = reader[2].ToString(),
                        ResultFilePath = reader[3].ToString(),
                    };

                    labResults.Add(labResult);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching lab results: " + ex.Message);
            }

            return labResults;
        }


        public void Update(int labResultID, LabResult lr)
        {

            _labresultRepository.Update(lr);
        }


        public new void Delete(int labresultID)
        {
            _labresultRepository.Delete(labresultID);

        }

    }
}
