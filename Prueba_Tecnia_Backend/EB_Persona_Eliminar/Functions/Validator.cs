using EB_Persona_Eliminar.Models;

namespace EB_Persona_Eliminar.Functions
{
    public static class Validator
    {
        public static (bool IsValid, string ErrorMessage) ValidatePersona(RequestPersona persona)
        {
            if (persona.Id == 0)
                return (false, "El campo 'Id' es requerido.");

            return (true, string.Empty);
        }
    }
}
