using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
