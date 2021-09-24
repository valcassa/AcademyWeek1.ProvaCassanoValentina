using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyWeek1.Prova.Core.Entities
{
    public class Spese
    {

        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Spesa { get; set; }

        public string Descrizione { get; set; }

        public int Dipendente { get; set; }


        public bool? Approvata { get; set; }
        public bool? Rimborso { get; set; }

        public categorie Categorie { get; set; }

        public approvatori Approvatore { get; set; }


        public enum approvatori
        {
            Manager,
            OperationManager,
            CEO

        }

        public enum categorie
        {
            Vitto = 1,
            Alloggio,
            Trasferta,
            Altro

        }

    }
}
