using EB_Persona_Editar.Models;

namespace EB_Persona_Editar.Functions
{
    public static class Validator
    {
        public static (bool IsValid, string ErrorMessage) ValidatePersona(RequestPersona persona)
        {
            if (string.IsNullOrWhiteSpace(persona.Nombre))
                return (false, "El campo 'Nombre' no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(persona.Apellido))
                return (false, "El campo 'Apellido' no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(persona.Identificacion))
                return (false, "El campo 'Identificación' no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(persona.Correo))
                return (false, "El campo 'Correo' no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(persona.Profesion))
                return (false, "El campo 'Profesión' no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(persona.EstadoCivil))
                return (false, "El campo 'Estado Civil' no puede estar vacío.");

            return (true, string.Empty);
        }
    }
}
