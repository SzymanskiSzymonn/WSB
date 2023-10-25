using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zajęcia_3
{
    internal class Adres
    {
        public string Ulica {  get; set; }
        public string NrDomu { get; set; } 
        public string NrMieszkania { get; set; }
        public string KodPocztowy {  get; set; }
        public string Miasto {  get; set; }
        public string Panstwo {  get; set; }
        public string kontynent {  get; set; }

        public string AdresPelny => $"{AdresPocztowy}";
        //public string AdresPelny => $"{AdresPocztowy} {kontynent}";

        public string AdresPocztowy
        {
            get
            {
                return "Ul." + this.Ulica + " " + this.NrDomu + "/" + this.NrMieszkania + "\n" + this.KodPocztowy + " " + this.Miasto + "\n" + this.Panstwo;
            } 
        }

    }
}
