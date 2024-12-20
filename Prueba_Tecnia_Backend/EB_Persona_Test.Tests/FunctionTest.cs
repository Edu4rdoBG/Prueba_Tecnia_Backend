using Xunit;
using Amazon.Lambda.TestUtilities;
using Org.BouncyCastle.Asn1.Cmp;
using Xunit.Abstractions;

namespace EB_Persona_Test.Tests;

public class FunctionTest : BaseCrudTests
{
    private readonly ITestOutputHelper _output;

    public FunctionTest(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact(DisplayName = "1. Test - Ciclo CRUD")]
    public void CrudFlow_ShouldCompleteSuccessfully()
    {
        Initialize();
        CreateLambda_ShouldStorePersonIdForOtherTests();
        ReadLambda_ShouldReturnSuccessResponse();
        UpdateLambda_ShouldUseStoredPersonId();
        DeleteLambda_ShouldUseStoredPersonId();
    }
    internal void Initialize()
    {

        // Datos de conexi�n proporcionados para las pruebas
        TestData.Servidor = new TestData.Server()
        {
            Host = "localhost",
            Schema = "database",
            User = "admin",
            Pass = "123",
            Port = 3306
        };
        TestData.OutPut = _output;
        Assert.NotNull(TestData.Servidor);
    }



}
