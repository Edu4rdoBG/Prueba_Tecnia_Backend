using Amazon.Lambda.TestUtilities;
using Xunit;

namespace EB_Persona_Test.Tests
{
    public class CreateLambdaTests
    {
        public void CreateLambda_ShouldStorePersonIdForOtherTests()
        {
            //Arrange
            var context = new TestLambdaContext();
            var function = new EB_Persona_Crear.Function();
            var request = new EB_Persona_Crear.Models.RequestPersona()
            {
                Nombre = TestData.Nombre,
                Apellido =TestData.Apellido,
                Identificacion = TestData.Identificacion,
                Correo = TestData.Correo,
                Profesion = TestData.Profesion,
                EstadoCivil = TestData.EstadoCivil,
                Host = TestData.Servidor.Host,
                Schema = TestData.Servidor.Schema,
                User = TestData.Servidor.User,
                Pass = TestData.Servidor.Pass,
                Port = TestData.Servidor.Port,
            };

            //Act
            var response = function.Crear(request, context);

            //Assert
            Assert.NotNull(response);
            Assert.Equal(0, response.ErrorCode); 
            Assert.NotNull(response.Persona); 
            Assert.True(response.Persona.Id > 0);

            // Store the ID for other tests
            TestData.Id = response.Persona.Id;
        }
    }
}
