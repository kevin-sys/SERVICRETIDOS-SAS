using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;
namespace BLL
{
    public class CreditoService
    {
        private static CreditoRepository creditoRepository = new CreditoRepository();
        public CreditoService()
        {
            creditoRepository = new CreditoRepository();
        }

        public string Guardar(Credito credito)
        {

            try
            {
                if (creditoRepository.Buscar(credito.NumeroCredito) == null)
                {
                    creditoRepository.Guardar(credito);
                    return "Los Datos han sido guardados satisfactoriamente";
                }
                else
                {
                    return $"El credito numero: {credito.NumeroCredito} ya se encuentra registrado, por favor verifique los datos";

                }

            }
            catch (Exception e)
            {

                return "Error de Datos: " + e.Message;
            }
        }

        public string Eliminar(string numeroCredito)
        {
            try
            {

                if (creditoRepository.Buscar(numeroCredito) != null)
                {

                    creditoRepository.Eliminar(numeroCredito);
                    return $"El credito numero: {numeroCredito} ha sido eliminado satisfacatoriamente";
                }
                return $"El credito no esta registrada en el sistema";

            }
            catch (Exception e)
            {

                return $"ERROR" + e.Message;
            }

        }

        public string Modificar(Credito credito)
        {

            try
            {
                if (creditoRepository.Buscar(credito.NumeroCredito) != null)
                {

                    creditoRepository.Modificar(credito);
                    return $" El credito numero:  {credito.NumeroCredito} ha sido modificada con exito!";
                }
                return $"El credito numero: {credito.NumeroCredito} no se encuentra registrado por favor verifique los datos";

            }
            catch (Exception e)
            {

                return "Error de datos" + e.Message;
            }
        }

        public Credito BuscarID(string numeroCredito)
        {
            Credito persona = new Credito();
            try
            {
                return creditoRepository.Buscar(numeroCredito);
            }
            catch (Exception e)
            {
                string mensaje = " ERROR" + e.Message;
                return null;
            }

        }


        public static List<Credito> ConsultarTodos()
        {
            return creditoRepository.Consultar();
        }

        public RespuestaBusqueda Buscar(string numeroCredito)
        {
            RespuestaBusqueda respuesta = new RespuestaBusqueda();

            try
            {
                respuesta.Error = false;

                respuesta.Credito = creditoRepository.Buscar(numeroCredito);
                if (respuesta.Credito != null)
                {
                    respuesta.Mensaje = "INFORMACIÓN DE CREDITO";
                }
                else
                {
                    respuesta.Mensaje = "NO HAY INFORMACION DE ESE CREDITO";
                }
                return respuesta;
            }
            catch (Exception e)
            {
                respuesta.Error = true;
                respuesta.Mensaje = "ERROR: " + e.Message;
                respuesta.Credito = null;
                return respuesta;

            }
        }

        public RespuestaConsulta Consultar()
        {
            RespuestaConsulta respuesta = new RespuestaConsulta();
            try
            {
                respuesta.Error = false;
                respuesta.creditos = creditoRepository.Consultar();
                if (respuesta.creditos != null)
                {
                    respuesta.Mensaje = "LISTADO DE CREDITOS";
                }
                else
                {
                    respuesta.Mensaje = "NO HAY DATOS";
                }

            }
            catch (Exception e)
            {
                respuesta.Error = true;
                respuesta.Mensaje = $"ERROR" + e.Message;
            }
            return respuesta;

        }

    }

    public class RespuestaBusqueda
    {
        public string Mensaje { get; set; }
        public Credito Credito { get; set; }
        public bool Error { get; set; }
    }

    public class RespuestaConsulta
    {
        public string Mensaje { get; set; }
        public List<Credito> creditos { get; set; }
        public bool Error { get; set; }
    }
}
