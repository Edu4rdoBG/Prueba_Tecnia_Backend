using Amazon.Lambda.TestUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EB_Persona_Test.Tests
{
    public class BaseCrudTests
    {
        public void CreateLambda_ShouldStorePersonIdForOtherTests()
        {
            TestData.OutPut.WriteLine($"1.1 Crear Persona");
            //Arrange
            var context = new TestLambdaContext();
            var function = new EB_Persona_Crear.Function();
            var request = new EB_Persona_Crear.Models.RequestPersona()
            {
                Nombre = TestData.Nombre,
                Apellido = TestData.Apellido,
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
            TestData.OutPut.WriteLine($"    Persona creada con Id {response.Persona.Id}");
        }

        public void ReadLambda_ShouldReturnSuccessResponse()
        {
            TestData.OutPut.WriteLine($"1.2 Consultar Persona");
            //Arrange
            var context = new TestLambdaContext();
            var function = new EB_Persona_Consultar.Function();
            var request = new EB_Persona_Consultar.Models.RequestPersona()
            {
                Buscar = "",
                Host = TestData.Servidor.Host,
                Schema = TestData.Servidor.Schema,
                User = TestData.Servidor.User,
                Pass = TestData.Servidor.Pass,
                Port = TestData.Servidor.Port,
            };

            //Act
            var response = function.Consulta(request, context);

            //Assert
            Assert.NotNull(response);
            Assert.Equal(0, response.ErrorCode);
            Assert.NotNull(response.Persona);
            TestData.OutPut.WriteLine($"    Registros obtenidos: {response.Persona.Count}");
        }

        public void UpdateLambda_ShouldUseStoredPersonId()
        {
            TestData.OutPut.WriteLine($"1.3 Actualizar Persona");
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
            TestData.OutPut.WriteLine($"    Se actualizo la persona con Id: {response.Persona.Id}");
        }

        public void DeleteLambda_ShouldUseStoredPersonId()
        {
            TestData.OutPut.WriteLine($"1.4 Eliminar Persona");
            //Arrange
            var context = new TestLambdaContext();
            var function = new EB_Persona_Eliminar.Function();
            var request = new EB_Persona_Eliminar.Models.RequestPersona()
            {
                Id = TestData.Id,
                Host = TestData.Servidor.Host,
                Schema = TestData.Servidor.Schema,
                User = TestData.Servidor.User,
                Pass = TestData.Servidor.Pass,
                Port = TestData.Servidor.Port,
            };

            //Act
            var response = function.Eliminar(request, context);

            //Assert
            Assert.NotNull(response);
            Assert.Equal(0, response.ErrorCode);
            TestData.OutPut.WriteLine($"    Se elimino la persona con Id: {response.Persona.Id}");
        }
    }
}
