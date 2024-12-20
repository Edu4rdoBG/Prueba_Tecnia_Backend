﻿using System.Text.Json;

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
