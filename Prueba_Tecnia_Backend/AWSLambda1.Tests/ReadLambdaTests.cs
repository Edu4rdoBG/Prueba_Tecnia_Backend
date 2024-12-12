using Amazon.Lambda.TestUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EB_Persona_Test.Tests
{
    public class ReadLambdaTests
    {
        public void ReadLambda_ShouldReturnSuccessResponse()
        {
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
            var cntresponse = function.Consulta(request, context);

            //Assert
            Assert.NotNull(cntresponse);
            Assert.Equal(0, cntresponse.ErrorCode); 
            Assert.NotNull(cntresponse.Persona); 
        }
    }
}
