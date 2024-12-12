using Amazon.Lambda.Core;
using EB_Persona_Crear.Models;
using EB_Persona_Crear.Functions;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace EB_Persona_Crear;

public class Function
{
    
    /// <summary>
    /// A simple function that takes a string and does a ToUpper
    /// </summary>
    /// <param name="input">The event for the Lambda function handler to process.</param>
    /// <param name="context">The ILambdaContext that provides methods for logging and describing the Lambda environment.</param>
    /// <returns></returns>
    public ResponsePersona Crear(RequestPersona input, ILambdaContext context)
    {
        Persona persona = new();
        LambdaLogger.Log($"-----------   Inicia Insercion de persona   ---------- {DateTime.Now}");
        LambdaLogger.Log($"Request: {input.ToJson()}, {DateTime.Now}");
        var response = persona.Insert(input);
        LambdaLogger.Log($"Response: {response.ToJson()} {DateTime.Now}");
        LambdaLogger.Log($"-----------  Finaliza Insercion de persona  ---------- {DateTime.Now}");
        return response;
    }
}
