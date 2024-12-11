using Amazon.Lambda.Core;
using EB_Persona_Consultar.Functions.Data;
using EB_Persona_Consultar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB_Persona_Consultar.Functions
{
    public class Persona
    {
        private ResponsePersona response = null;
        private string mensaje = "";
        public ResponsePersona Select(RequestPersona input)
        {

            LambdaLogger.Log("Inicia Obtener personas");
            response = new ResponsePersona();
            LambdaLogger.Log("Creando conexión a base de datos");

            if(!DataProvider.CreateConn(input.Host, input.Schema, "", input.User, input.Pass, input.Port.ToString()))
            {
                response.ErrorCode = 1;
                response.ErrorMessage = "Error: No se logro establecer conexión a la base de datos.";
                return response;
            }

            var personas = new List<PersonaModel>();
            if (!DataProvider.Execute_sp_select_eb_persona(input.Buscar, out mensaje, out personas))
            {
                response.ErrorCode = 2;
                response.ErrorMessage = $"Error: {mensaje}.";
                return response;
            }

            response.ErrorCode = 0;
            response.ErrorMessage = "Exito";
            response.Persona = personas;
            return response;
        }
    }
}
