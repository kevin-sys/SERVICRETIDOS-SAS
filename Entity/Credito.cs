using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Credito
    {
        public string NumeroCredito { get; set; }
        public string IdentificacionCliente { get; set; }
        public string TipoInteres { get; set; }
        public double CapitalInicialPrestamo { get; set; }
        public double TasaInteres { get; set; }
        public double PeriodoPrestamo { get; set; }
        public double ValorAPagar { get; set; }
        public override string ToString()
        {
            return $"{NumeroCredito};{IdentificacionCliente};{TipoInteres};{CapitalInicialPrestamo};{TasaInteres};{PeriodoPrestamo};{ValorAPagar}";
        }
    

        public void calcularCredito()
        {
            if (TipoInteres == "Simple")
            {
                ValorAPagar = CapitalInicialPrestamo*(1+PeriodoPrestamo*TasaInteres);
            }
            else if (TipoInteres == "Compuesto")
            {
                ValorAPagar = CapitalInicialPrestamo * (1 + TasaInteres);
                ValorAPagar = CapitalInicialPrestamo * Math.Pow((1 + TasaInteres), PeriodoPrestamo);
            }

        }
    }
  
}
