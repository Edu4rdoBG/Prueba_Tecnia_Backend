using Amazon.Lambda.Core;
using EB_Persona_Eliminar.Models;
using EB_Persona_Eliminar.Functions;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace EB_Persona_Eliminar;

public class Function
{
    
    /// <summary>
    /// A simple function that takes a string and does a ToUpper
    /// </summary>
    /// <param name="input">The event for the Lambda function handler to process.</param>
    /// <param name="context">The ILambdaContext that provides methods for logging and describing the Lambda environment.</param>
    /// <returns></returns>
    public ResponsePersona Eliminar(RequestPersona input, ILambdaContext context)
    {
        Persona persona = new();
        LambdaLogger.Log($"-----------   Inicia eliminación de persona   ---------- {DateTime.Now}");
        LambdaLogger.Log($"Request: {input.ToJson()}, {DateTime.Now}");
        var response = persona.Delete(input);
        LambdaLogger.Log($"Response: {response.ToJson()} {DateTime.Now}");
        LambdaLogger.Log($"-----------  Finaliza eliminación de persona  ---------- {DateTime.Now}");
        return response;
    }
}
