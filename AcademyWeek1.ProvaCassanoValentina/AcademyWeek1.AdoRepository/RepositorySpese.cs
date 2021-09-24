using AcademyWeek1.Prova.Core.Entities;
using AcademyWeek1.Prova.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AcademyWeek1.Prova.ConsoleApp
{

    public class RepositorySpese : IRepositorySpese
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb;" +
                               "Initial Catalog = AcademyI.EsercitazioneFinale;" +
                               "Integrated Security = true";

        public List<Spese> Fetch()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "select * from dbo.Spese where Approvata is null";

                    SqlDataReader reader = command.ExecuteReader();

                    List<Spese> spese = new List<Spese>();

                    while (reader.Read())
                    {
                        Spese s = new Spese();
                        s.Id = (int)reader["Id"];
                        s.Data = Convert.ToDateTime(reader["Data"]);
                        s.Spesa = (double)reader["Spesa"];
                        s.Approvata = (bool)reader["Approvata"];
                        s.Rimborso = (bool)reader["Rimborso"];


                        spese.Add(s);
                    }

                    return spese;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
        
        public void Insert()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "insert into dbo.Spese values(@refund, @data, @desc)";
                    command.Parameters.AddWithValue("@refund", s.Rimborso);
                    command.Parameters.AddWithValue("@data", s.Data);
                    command.Parameters.AddWithValue("@desc", s.Descrizione);
                    command.Parameters.AddWithValue("@approvata", DBNull.Value);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        List<Spese> IRepositorySpese.Insert()
        {
            throw new NotImplementedException();
        }
    }
}