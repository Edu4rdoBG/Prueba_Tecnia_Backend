using Amazon.Lambda.Core;
using EB_Persona_Editar.Functions.Data;
using EB_Persona_Editar.Models;

namespace EB_Persona_Editar.Functions
{
    public class Persona
    {
        private ResponsePersona response = null;
        private string mensaje = "";
        public ResponsePersona Update(RequestPersona input)
        {

            LambdaLogger.Log("Inicia validación de los parametros");
            response = new ResponsePersona();

            var validationResult = Validator.ValidatePersona(input);
            if (!validationResult.IsValid)
            {
                LambdaLogger.Log($"Validación fallida: {validationResult.ErrorMessage}");
                response.ErrorCode = 3;
                response.ErrorMessage = validationResult.ErrorMessage;
                return response;
            }
            LambdaLogger.Log("validación exitosa");

            LambdaLogger.Log("Creando conexión a base de datos");

            if(!DataProvider.CreateConn(input.Host, input.Schema, "", input.User, input.Pass, input.Port.ToString()))
            {
                response.ErrorCode = 1;
                response.ErrorMessage = "Error: No se logro establecer conexión a la base de datos.";
                return response;
            }

            var persona = new PersonaModel();
            if (!DataProvider.Execute_sp_update_eb_persona(input, out mensaje, out persona))
            {
                response.ErrorCode = 2;
                response.ErrorMessage = $"Error: {mensaje}";
                return response;
            }

            response.ErrorCode = 0;
            response.ErrorMessage = "Exito";
            response.Persona = persona;
            return response;
        }
    }
}
