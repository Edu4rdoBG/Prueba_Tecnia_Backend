using System.Text.Json;

namespace EB_Persona_Editar.Models
{
    public class RequestPersona : PersonaModel
    {
        public string Host { get; set; }
        public string Schema { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public int Port { get; set; }

        public string ToJson() => JsonSerializer.Serialize(this);
    }
}
