using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;

namespace DAL
{
    public class CreditoRepository
    {
      
       private string ruta = @"Credito.txt";
        private List<Credito> creditos;
        public CreditoRepository()
        {
            creditos = new List<Credito>();
        }

        public void Guardar(Credito credito)//por si las moscas, ultimo....
        {
            FileStream fileStream = new FileStream(ruta, FileMode.Append);
            StreamWriter writer = new StreamWriter(fileStream);
            writer.WriteLine(credito.ToString());
            writer.Close();
            fileStream.Close();
        }

        public List<Credito> Consultar()
        {
            creditos.Clear();
            FileStream fileStream = new FileStream(ruta, FileMode.OpenOrCreate);
            StreamReader streamReader = new StreamReader(fileStream);
            string linea = string.Empty;

            while ((linea = streamReader.ReadLine()) != null)
            {

                Credito credito = new Credito();
                string[] datos = linea.Split(';');
                credito.NumeroCredito = datos[0];
                credito.IdentificacionCliente = datos[1];
                credito.TipoInteres = datos[2];
                credito.CapitalInicialPrestamo = Convert.ToDouble(datos[3]);
                credito.TasaInteres = Convert.ToDouble(datos[4]);
                credito.PeriodoPrestamo = Convert.ToDouble(datos[5]);
                credito.ValorAPagar = Convert.ToDouble(datos[6]);
                creditos.Add(credito);
            }
            fileStream.Close();
            streamReader.Close();
            return creditos;
        }
        public void Eliminar(string numeroCredito)
        {
            creditos.Clear();
            creditos = Consultar();
            FileStream fileStream = new FileStream(ruta, FileMode.Create);
            fileStream.Close();
            foreach (var item in creditos)
            {
                if (item.NumeroCredito != numeroCredito)
                {
                    Guardar(item);
                }

            }
        }


        public void Modificar(Credito credito)
        {
            creditos.Clear();
            creditos = Consultar();
            FileStream fileStream = new FileStream(ruta, FileMode.Create);
            fileStream.Close();
            foreach (var item in creditos)
            {
                if (item.NumeroCredito != credito.NumeroCredito)
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(credito);
                }
            }
        }

        public Credito Buscar(string numeroCredito)
        {
            creditos.Clear();
            creditos = Consultar();
            Credito cr= new Credito();
            foreach (var item in creditos)
            {
                if (item.NumeroCredito.Equals(numeroCredito))
                {
                    return item;
                }
            }
            return null;
        }



    }
}
