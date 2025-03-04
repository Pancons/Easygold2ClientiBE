
using Xunit;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using EasyGold.API.Models.Clients;

public class ClienteDettaglioDTOTests
{
    private IList<ValidationResult> ValidateModel(object model)
    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(model, null, null);
        Validator.TryValidateObject(model, context, results, true);
        return results;
    }

    [Fact]
    public void ClienteDettaglioDTO_RagioneSociale_ShouldBeRequired()
    {
        // Arrange
        var clienteDettaglio = new ClienteDettaglioDTO { Dtc_RagioneSociale = null };

        // Act
        var results = ValidateModel(clienteDettaglio);

        // Assert
        Assert.Contains(results, v => v.MemberNames.Contains("Dtc_RagioneSociale"));
    }

    
}
