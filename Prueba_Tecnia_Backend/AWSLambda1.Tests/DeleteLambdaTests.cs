using Amazon.Lambda.TestUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EB_Persona_Test.Tests
{
    public class DeleteLambdaTests
    {
        public void DeleteLambda_ShouldUseStoredPersonId()
        {
            //Arrange
            var context = new TestLambdaContext();
            var function = new EB_Persona_Eliminar.Function();
            var request = new EB_Persona_Eliminar.Models.RequestPersona()
            {
                Id = TestData.Id,
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
        }
    }
}
