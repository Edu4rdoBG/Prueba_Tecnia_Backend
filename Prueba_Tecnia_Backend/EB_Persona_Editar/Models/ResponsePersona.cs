using System.Text.Json;

namespace EB_Persona_Editar.Models
{
    public class ResponsePersona
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public PersonaModel Persona { get; set; }

        public ResponsePersona() { 
            ErrorCode = 1;
            ErrorMessage = string.Empty;
            Persona = new PersonaModel();
        }

        public string ToJson() => JsonSerializer.Serialize(this);
    }
}
