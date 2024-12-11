using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EB_Persona_Consultar.Models
{
    public class ResponsePersona
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public List<PersonaModel> Persona { get; set; }

        public ResponsePersona() { 
            ErrorCode = 1;
            ErrorMessage = string.Empty;
            Persona = new List<PersonaModel>();
        }

        public string ToJson() => JsonSerializer.Serialize(this);
    }
}
