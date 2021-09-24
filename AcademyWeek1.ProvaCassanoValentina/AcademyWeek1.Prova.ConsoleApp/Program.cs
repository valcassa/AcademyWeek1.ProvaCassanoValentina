using AcademyWeek1.Prova.AdoRepository;
using AcademyWeek1.Prova.Core;
using AcademyWeek1.Prova.Core.Entities;
using AcademyWeek1.Prova.Core.IRepository;
using System;

namespace AcademyWeek1.Prova.ConsoleApp
{
    public class Program
    {
        private static readonly IBusinessLayer bl = new BusinessLayer(new RepositorySpese(), new RepositoryDipendenti());
        static void Main(string[] args)
        {
            //bool conversioneRiuscita;
            //double ppm;

            bool confermaId = true;
            do
            {
                Dipendenti dipendenti = new Dipendenti();


                int searchId;

                Console.WriteLine("Inserisci il tuo Id");
                int.TryParse(Console.ReadLine(), out searchId);

                searchId = dipendenti.Id;


            } while (!confermaId){
                Dipendenti dipendenti = new Dipendenti();

                Console.WriteLine($"Benvenuto dipendente {dipendenti.Nome}");
            }

            bool continuare = true;
            string risposta;
            do
            {
                Console.WriteLine("Continui nel programma?");
                risposta = Console.ReadLine();
                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);
            if (risposta == "si")
            {
                bl.InsertSpesa();
            }

            do

            {

                Spese spese = new Spese();


                DateTime dataTrasferta;
                int dipendente;
                double ammontare;

                Console.WriteLine("Inserisci Data di riferimento");
                DateTime.TryParse(Console.ReadLine(), out dataTrasferta);
                Console.WriteLine("Inserisci una breve descrizione della Spesa");
                spese.Descrizione = Console.ReadLine();
                Console.WriteLine("Conferma Dipendente");
                Int32.TryParse(Console.ReadLine(), out dipendente);
                Console.WriteLine("Inserisci Ammontare:");
                Double.TryParse(Console.ReadLine(), out ammontare);


                spese.Data = dataTrasferta;
                spese.Spesa = ammontare;
                spese.Dipendente = dipendente;

                bl.InsertSpesa();

            } while (continuare);

                try
                {
                    bl.Rimborso();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
    }
    }


