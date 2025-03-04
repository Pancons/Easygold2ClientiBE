
using Xunit;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using EasyGold.API.Models.Clienti;

public class ClienteDTOTests
{
    private IList<ValidationResult> ValidateModel(object model)
    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(model, null, null);
        Validator.TryValidateObject(model, context, results, true);
        return results;
    }

    [Fact]
    public void ClienteDTO_RagioneSociale_ShouldBeRequired()
    {
        // Arrange
        var cliente = new ClienteDTO { Dtc_RagioneSociale = null };

        // Act
        var results = ValidateModel(cliente);

        // Assert
        Assert.Contains(results, v => v.MemberNames.Contains("Dtc_RagioneSociale"));
    }

    [Fact]
    public void ClienteDTO_Email_ShouldBeValid()
    {
        // Arrange
        
        var cliente = new ClienteDTO { Dtc_Email = "invalid-email" };

        // Act
        var results = ValidateModel(cliente);

        // Assert
        Assert.Contains(results, v => v.MemberNames.Contains("Dtc_Email"));
    }
}
