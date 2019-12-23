using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstMVCProject.Models
{
    public class CreditCard
    {
        public String Id { get; set; }
        public String NumeroTarjeta { get; set; }
        public String FechaCaducidad { get; set; }
        public String CodigoSeguridad { get; set; }
        public String Pin { get; set; }

        public CreditCard()
        {
          
        }
        public CreditCard(string v0, string v1, string v2, string v3, string v4)
        {
            this.Id=v0;
            this.NumeroTarjeta = v1;
            this.FechaCaducidad = v2;
            this.CodigoSeguridad = v3;
            this.Pin = v4;
        }








        public CreditCard(string v1)
        {
          
            this.NumeroTarjeta = v1;
           
        }
    }
}
