using AcademyWeek1.Prova.Core.Entities;
using AcademyWeek1.Prova.Core.IRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static AcademyWeek1.Prova.Core.Entities.Spese;

namespace AcademyWeek1.Prova.Core
{
    public class BusinessLayer : IBusinessLayer 
    {
        private readonly IRepositoryDipendenti dipendentiRepo;
        private readonly IRepositorySpese speseRepo;

        public BusinessLayer(IRepositoryDipendenti dipendentiRepository, IRepositorySpese speseRepository)
        {
            dipendentiRepo = dipendentiRepository;
            speseRepo = speseRepository;


        }


   
        public void InsertSpesa()
        {
             List<Spese> spese = new List<Spese>();
            List<Dipendenti> dipendenti = new List<Dipendenti>();

            try
            {
                spese = speseRepo.Insert();

                if (spese is null)
                {
                    foreach (var spesa in spese)
                    {
                        if (spesa.Spesa <= 400)
                        {
                            spesa.Approvata = true;

                        }

                        else { spesa.Approvata = false; }

                        Spese sManager = spese.Where(sp => sp.Approvatore == approvatori.Manager && spesa.Spesa <= 400).SingleOrDefault();


                        if (spesa.Spesa >= 401 && spesa.Spesa <= 1000)
                        {
                            spesa.Approvata = true;

                        }
                        else
                        {
                            spesa.Approvata =  false; }

                        Spese sOManager = spese.Where(sp => sp.Approvatore == approvatori.Manager && spesa.Spesa >= 401 && spesa.Spesa <= 1000).SingleOrDefault();

                         
                            if (spesa.Spesa >= 1000 && spesa.Spesa <= 2499)
                        {
                            spesa.Approvata = true;

                        }
                        else { spesa.Approvata = false; }
                    

                    Spese sCEO = spese.Where(sp => sp.Approvatore == approvatori.Manager && spesa.Spesa >= 401 && spesa.Spesa <= 1000).SingleOrDefault();


                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Rimborso()
        {
            List<Spese> spese = new List<Spese>();
            Spese spesa = new Spese();
            try
            {
                spese = speseRepo.Insert();
                double refund;

                if (speseRepo == null)

                {
                    foreach (var insertedcategoria in spese)
                    {
                        if (insertedcategoria as categorie.Vitto)
                        {
                            refund = spesa.Spesa * 70 / 100;

                        }
                        else
                        {

                        }
                        if (insertedcategoria as categorie.Alloggio)
                        {
                            refund = spesa.Spesa * 100 / 100;

                        }
                        else
                        {

                        }
                        if (insertedcategoria as categorie.Trasferta)
                        {
                            refund = spesa.Spesa * 50 / 100 + 50;

                        }
                        else
                        {

                        }
                        if (insertedcategoria as categorie.Altro)
                        {
                            refund = spesa.Spesa * 10 / 100;

                        }
                        else
                        {

                        }
                    }

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ScriviSuFile()
        {
            Spese spesa = new Spese();
            string path = @"C:\Users\v.cassano\Desktop\Stampa.txt";

            try
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine($"La spesa è stata effettuata il giorno {spesa.Data}, tra le {spesa.Categorie} " +
                      $"Approvata? {spesa.Approvata}, Rimborso: {spesa.Rimborso}");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}