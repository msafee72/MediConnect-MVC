using System;
using System.Diagnostics.Contracts;
using System.Numerics;
using Generic_Medi_Connect.Models.Repositories;
using Medi_Connect.Models.Interfaces;
using Microsoft.Data.SqlClient;


namespace Medi_Connect.Models
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        List<Doctor> _doctors = new List<Doctor>();

        IRepository<Doctor> _doctorsRepository = new GenericRepository<Doctor>("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True;");
        
        private readonly string _connString;

        public DoctorRepository(string conn):base(conn)
        {
            _connString = conn;
        }

        public new void Add(Doctor doctor)
        {

            _doctorsRepository.Add(doctor);

            //try
            //{
            //    string connection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True;";
            //    SqlConnection con = new SqlConnection(connection);
            //    con.Open();

            //    string query = $"insert into Doctor values(@DoctorName,@Contact,@Experience,@Specialization,@Gender,@Address,@DOB,@Email,@Password)";
            //    SqlCommand cmd = new SqlCommand(query, con);

            //    //cmd.Parameters.AddWithValue("@Id", doctor.DoctorId);
            //    cmd.Parameters.AddWithValue("@DoctorName", doctor.DoctorName);
            //    cmd.Parameters.AddWithValue("@Contact", doctor.Contact);
            //    cmd.Parameters.AddWithValue("@Experience", doctor.Experience);
            //    cmd.Parameters.AddWithValue("@Specialization", doctor.Specialization);
            //    cmd.Parameters.AddWithValue("@Gender", doctor.Gender);
            //    cmd.Parameters.AddWithValue("@Address", doctor.Address);
            //    cmd.Parameters.AddWithValue("@DOB", doctor.DOB);
            //    cmd.Parameters.AddWithValue("@Email", doctor.Email);
            //    cmd.Parameters.AddWithValue("@Password", doctor.Password);

            //    int rowsAffected = cmd.ExecuteNonQuery();
            //    con.Close();
            //    if (rowsAffected > 0)
            //    {
            //        Console.WriteLine("Doctor Added!");
            //    }

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

        }



        public IEnumerable<Doctor> View()
        {

            //try
            //{
            //    string connection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True";
            //    SqlConnection con = new SqlConnection(connection);
            //    con.Open();
            //    string read = "select * from Doctor";
            //    SqlCommand cmd = new SqlCommand(read, con);
            //    SqlDataReader reader = cmd.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        Doctor m = new Doctor
            //        {
            //            Id = (int)reader[0],
            //            DoctorName = (string)reader[1],
            //            Contact = (string)reader[2],
            //            Experience = (int)reader[3],
            //            Specialization = (string)reader[4],
            //            Gender = (string)reader[5],
            //            Address = (string)reader[6],
            //            DOB = DateTime.Parse(reader[7].ToString()),
            //            Email = reader[8].ToString(),
            //            Password = reader[9].ToString()
            //        };
            //        _doctors.Add(m);
            //    }
            //    con.Close();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            return _doctorsRepository.GetAll();

        }


        public void Update(int doctorID, Doctor doctor)
        {

            _doctorsRepository.Update(doctor);


            //try
            //{
            //    string connection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True;";

            //    using (SqlConnection con = new SqlConnection(connection))
            //    {
            //        con.Open();

            //        string query = @"UPDATE Doctor SET DoctorName=@DoctorName,Contact=@Contact,Experience=@Experience, 
            //                     Specialization=@Specialization, Gender=@Gender, Address=@Address, 
            //                     DOB=@DOB, Email=@Email, Password=@Password 
            //                     WHERE Id=@Id";


            //        using (SqlCommand cmd = new SqlCommand(query, con))
            //        {
            //            cmd.Parameters.AddWithValue("@Id", doctorID);
            //            cmd.Parameters.AddWithValue("@DoctorName", doctor.DoctorName);
            //            cmd.Parameters.AddWithValue("@Contact", doctor.Contact);
            //            cmd.Parameters.AddWithValue("@Experience", doctor.Experience);
            //            cmd.Parameters.AddWithValue("@Specialization", doctor.Specialization);
            //            cmd.Parameters.AddWithValue("@Gender", doctor.Gender);
            //            cmd.Parameters.AddWithValue("@Address", doctor.Address);
            //            cmd.Parameters.AddWithValue("@DOB", doctor.DOB);
            //            cmd.Parameters.AddWithValue("@Email", (object)doctor.Email ?? DBNull.Value);
            //            cmd.Parameters.AddWithValue("@Password", (object)doctor.Password ?? DBNull.Value);

            //            cmd.ExecuteNonQuery();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }



        public new void Delete(int doctorID)
        {
            _doctorsRepository.Delete(doctorID);

            //try
            //{
            //    string connection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True;";
            //    SqlConnection con = new SqlConnection(connection);
            //    con.Open();

            //    string query = "delete from Doctor where Id = @Id";
            //    SqlCommand cmd = new SqlCommand(query, con);

            //    cmd.Parameters.AddWithValue("@Id", doctorID);

            //    int rowsAffected = cmd.ExecuteNonQuery();

            //    if (rowsAffected > 0)
            //    {
            //        Console.WriteLine("Doctor Deleted!");
            //    }
            //}

            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}


        }

    }
}






//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Data.SqlClient;

//namespace Medi_Connect.Models
//{
//    public class DoctorRepository
//    {
//        private readonly string _connectionString;

//        public DoctorRepository(IConfiguration configuration)
//        {
//            _connectionString = configuration.GetConnectionString("DefaultConnection");
//        }

//        public void Add(Doctor doctor)
//        {
//            try
//            {
//                using (SqlConnection con = new SqlConnection(_connectionString))
//                {
//                    con.Open();

//                    string query = @"INSERT INTO Doctor (DoctorName, Contact, Experience, Specialization, Gender, Address, DOB, Email, Password) 
//                                     VALUES (@DoctorName, @Contact, @Experience, @Specialization, @Gender, @Address, @DOB, @Email, @Password)";

//                    using (SqlCommand cmd = new SqlCommand(query, con))
//                    {
//                        cmd.Parameters.AddWithValue("@DoctorName", doctor.DoctorName);
//                        cmd.Parameters.AddWithValue("@Contact", doctor.Contact);
//                        cmd.Parameters.AddWithValue("@Experience", doctor.Experience);
//                        cmd.Parameters.AddWithValue("@Specialization", doctor.Specialization);
//                        cmd.Parameters.AddWithValue("@Gender", doctor.Gender);
//                        cmd.Parameters.AddWithValue("@Address", doctor.Address);
//                        cmd.Parameters.AddWithValue("@DOB", doctor.DOB);
//                        cmd.Parameters.AddWithValue("@Email", doctor.Email);
//                        cmd.Parameters.AddWithValue("@Password", doctor.Password);

//                        int rowsAffected = cmd.ExecuteNonQuery();
//                        if (rowsAffected > 0)
//                        {
//                            Console.WriteLine("Doctor Added!");
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//                // Consider logging the error instead of just writing to console
//            }
//        }

//        public List<Doctor> View()
//        {
//            List<Doctor> doctors = new List<Doctor>();

//            try
//            {
//                using (SqlConnection con = new SqlConnection(_connectionString))
//                {
//                    con.Open();

//                    string query = "SELECT * FROM Doctor";
//                    using (SqlCommand cmd = new SqlCommand(query, con))
//                    {
//                        using (SqlDataReader reader = cmd.ExecuteReader())
//                        {
//                            while (reader.Read())
//                            {
//                                Doctor doctor = new Doctor
//                                {
//                                    DoctorId = reader.GetInt32(0),
//                                    DoctorName = reader.GetString(1),
//                                    Contact = reader.GetString(2),
//                                    Experience = reader.GetInt32(3),
//                                    Specialization = reader.GetString(4),
//                                    Gender = reader.GetString(5),
//                                    Address = reader.GetString(6),
//                                    DOB = reader.GetDateTime(7),
//                                    Email = reader.IsDBNull(8) ? null : reader.GetString(8),
//                                    Password = reader.IsDBNull(9) ? null : reader.GetString(9)
//                                };
//                                doctors.Add(doctor);
//                            }
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//                // Consider logging the error instead of just writing to console
//            }

//            return doctors;
//        }

//        public bool Update(int doctorID, Doctor doctor)
//        {
//            try
//            {
//                using (SqlConnection con = new SqlConnection(_connectionString))
//                {
//                    con.Open();

//                    string query = @"UPDATE Doctor SET DoctorName = @DoctorName, Contact = @Contact, Experience = @Experience, 
//                                     Specialization = @Specialization, Gender = @Gender, Address = @Address, 
//                                     DOB = @DOB, Email = @Email, Password = @Password 
//                                     WHERE DoctorId = @DoctorId";

//                    using (SqlCommand cmd = new SqlCommand(query, con))
//                    {
//                        cmd.Parameters.AddWithValue("@DoctorId", doctorID);
//                        cmd.Parameters.AddWithValue("@DoctorName", doctor.DoctorName);
//                        cmd.Parameters.AddWithValue("@Contact", doctor.Contact);
//                        cmd.Parameters.AddWithValue("@Experience", doctor.Experience);
//                        cmd.Parameters.AddWithValue("@Specialization", doctor.Specialization);
//                        cmd.Parameters.AddWithValue("@Gender", doctor.Gender);
//                        cmd.Parameters.AddWithValue("@Address", doctor.Address);
//                        cmd.Parameters.AddWithValue("@DOB", doctor.DOB);
//                        cmd.Parameters.AddWithValue("@Email", (object)doctor.Email ?? DBNull.Value);
//                        cmd.Parameters.AddWithValue("@Password", (object)doctor.Password ?? DBNull.Value);

//                        int rowsAffected = cmd.ExecuteNonQuery();
//                        return rowsAffected > 0;
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//                // Consider logging the error instead of just writing to console
//                return false;
//            }
//        }

//        public void Delete(int doctorID)
//        {
//            try
//            {
//                using (SqlConnection con = new SqlConnection(_connectionString))
//                {
//                    con.Open();

//                    string query = "DELETE FROM Doctor WHERE DoctorId = @DoctorId";

//                    using (SqlCommand cmd = new SqlCommand(query, con))
//                    {
//                        cmd.Parameters.AddWithValue("@DoctorId", doctorID);

//                        int rowsAffected = cmd.ExecuteNonQuery();
//                        if (rowsAffected > 0)
//                        {
//                            Console.WriteLine("Doctor Deleted!");
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//        }
//    }
//}



