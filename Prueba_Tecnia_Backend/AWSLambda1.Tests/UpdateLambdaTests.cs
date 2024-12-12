using Amazon.Lambda.TestUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EB_Persona_Test.Tests
{
    public class UpdateLambdaTests
    {
        public void UpdateLambda_ShouldUseStoredPersonId()
        {
            //Arrange
            var context = new TestLambdaContext();
            var function = new EB_Persona_Editar.Function();
            var request = new EB_Persona_Editar.Models.RequestPersona()
            {
                Id = TestData.Id,
                Nombre = "Federico",
                Apellido = "Valverde",
                Identificacion = TestData.Identificacion,
                Correo = "federico.valverde@tests.com",
                Profesion = TestData.Profesion,
                EstadoCivil = TestData.EstadoCivil,
                Host = TestData.Servidor.Host,
                Schema = TestData.Servidor.Schema,
                User = TestData.Servidor.User,
                Pass = TestData.Servidor.Pass,
                Port = TestData.Servidor.Port,
            };

            //Act
            var response = function.Editar(request, context);

            //Assert
            Assert.NotNull(response);
            Assert.Equal(0, response.ErrorCode);
            Assert.NotNull(response.Persona);
            Assert.True(response.Persona.Id == TestData.Id);
        }

    }
}
