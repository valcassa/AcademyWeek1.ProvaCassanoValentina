using AcademyWeek1.Prova.Core.Entities;
using AcademyWeek1.Prova.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyWeek1.Prova.AdoRepository
{
    public class RepositoryDipendenti : IRepositoryDipendenti
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb;" +
                                "Initial Catalog = AcademyI.EsercitazioneFinale;" +
                                "Integrated Security = true";
        public List<Dipendenti> Fetch()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "select * from dbo.Dipendenti where Stato is null";

                    SqlDataReader reader = command.ExecuteReader();

                    List<Dipendenti> dipendenti = new List<Dipendenti>();

                    while (reader.Read())
                    {
                        Dipendenti d = new Dipendenti();
                        d.Id = (int)reader["Id"];
                        d.Nome = (string)reader["Nome"];


                        dipendenti.Add(d);
                    }

                    return dipendenti;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
        }
    }
}