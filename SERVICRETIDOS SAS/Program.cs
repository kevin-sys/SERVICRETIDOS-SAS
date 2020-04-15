using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Entity;

namespace SERVICRETIDOS_SAS
{
    class Program
    {
        static void Main(string[] args)
        {
            CreditoService service = new CreditoService();
            Menu();

     
        }


        private static void Menu()
        {
            Console.Clear();
            CreditoService service = new CreditoService();
            int opcion;
            do
            {

                Console.WriteLine("\t\t\t _____________________________");
                Console.WriteLine("\t\t\t|        MENU PRINCIPAL       |");
                Console.WriteLine("\t\t\t|_____________________________|");
                Console.WriteLine("\t\t\t|  1 Registro de creditos     |");
                Console.WriteLine("\t\t\t|  2 Listado de creditos      |");
                Console.WriteLine("\t\t\t|  3 eliminar                 |");
                Console.WriteLine("\t\t\t|  4 modificar                |");
                Console.WriteLine("\t\t\t|  5 salir de sitema          |");
                Console.WriteLine("\t\t\t|_____________________________|");
                Console.Write("\t\t\t  Escoja una opcion: ");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {

                    case 1:
                        Guardar();
                        break;
                    case 2:
                        ConsultaGeneral(service);
                        break;
                    case 3:
                        Eliminar();
                        break;

                    case 4:
                        Modificar(service);
                        break;

                    case 5:
                        Console.SetCursorPosition(25, 15);
                        Console.WriteLine("Gracias por usar el sistema");
                        break;

                    default:
                        Console.WriteLine("Opcion invalida");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }


            } while (opcion != 5);



            Console.ReadKey();
        }

        private static void Guardar()
        {

            Console.Clear();
            Credito credito = new Credito();

            Console.Write("Digite numero de credito: ");
            credito.NumeroCredito = Console.ReadLine();

            Console.Write("Digite identificacion del cliente: ");
            credito.IdentificacionCliente = Console.ReadLine();

            Console.Write("Digite tipo de interes: ");
            credito.TipoInteres = Console.ReadLine();

            Console.Write("Digite capital inicial: ");
            credito.CapitalInicialPrestamo = double.Parse(Console.ReadLine());

            Console.Write("Digite tasa de interes: ");
            credito.TasaInteres = double.Parse(Console.ReadLine());

            Console.Write("Digite periodo de prestamo: ");
            credito.PeriodoPrestamo = double.Parse(Console.ReadLine());
           

            CreditoService service = new CreditoService();
            credito.calcularCredito();
            string mensaje = service.Guardar(credito);
            Console.Write(mensaje);
            Console.ReadKey();
            Console.Clear();
        }


        private static void ConsultaGeneral(CreditoService service)
        {
            Console.Clear();
            RespuestaConsulta respuestaConsulta = service.Consultar();
            Console.WriteLine(respuestaConsulta.Mensaje);
            if (!respuestaConsulta.Error)
            {

                foreach (var item in respuestaConsulta.creditos)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            Console.ReadKey();
            Console.Clear();
        }


        public static void Eliminar()
        {
            Console.Clear();
            Console.WriteLine("ELIMINAR");
            Credito credito = new Credito();
            CreditoService service = new CreditoService();
            Console.WriteLine("digite numero de credito a eliminar");
            string numero;
            numero = Console.ReadLine();
            string mensaje = service.Eliminar(numero);
            Console.WriteLine(mensaje);
            Console.ReadKey();
            Console.Clear();
        }

        private static void Modificar(CreditoService service)
        {
            Credito credito = new Credito();
            
            Console.Clear();
            Console.WriteLine("\t\t\tModificar un credito");

            Console.Write("DIGITE NUMERO DE CREDITO: ");
            credito.NumeroCredito = Console.ReadLine();

            Console.Write("Digite identificacion del cliente: ");
            credito.IdentificacionCliente = Console.ReadLine();

            Console.Write("Digite tipo de interes: ");
            credito.TipoInteres = Console.ReadLine();

            Console.Write("Digite capital inicial: ");
            credito.CapitalInicialPrestamo = double.Parse(Console.ReadLine());

            Console.Write("Digite tasa de interes: ");
            credito.TasaInteres = double.Parse(Console.ReadLine());

            Console.Write("Digite periodo de prestamo: ");
            credito.PeriodoPrestamo = double.Parse(Console.ReadLine());

            credito.calcularCredito();
            string mensaje;
         service.Modificar(credito);
            mensaje = service.Modificar(credito);
            Console.WriteLine(mensaje);
            Console.ReadKey();
            Console.Clear();
        }

    }
}
