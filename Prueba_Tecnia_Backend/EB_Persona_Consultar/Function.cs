using Amazon.Lambda.Core;
using EB_Persona_Consultar.Models;
using EB_Persona_Consultar.Functions;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace EB_Persona_Consultar;

public class Function
{
    
    /// <summary>
    /// A simple function that takes a string and does a ToUpper
    /// </summary>
    /// <param name="input">The event for the Lambda function handler to process.</param>
    /// <param name="context">The ILambdaContext that provides methods for logging and describing the Lambda environment.</param>
    /// <returns></returns>
    public ResponsePersona Consulta(RequestPersona input, ILambdaContext context)
    {
        Persona persona = new();
        LambdaLogger.Log($"-----------   Inicia Obtener personas   ---------- {DateTime.Now}");
        LambdaLogger.Log($"Request: *Secrets Manager*, {DateTime.Now}");
        var response = persona.Select(input);
        LambdaLogger.Log($"Response: {response.ToJson()} {DateTime.Now}");
        LambdaLogger.Log($"-----------  Finaliza Obtener personas  ---------- {DateTime.Now}");
        return response;
    }
}
