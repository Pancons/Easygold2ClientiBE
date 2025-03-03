
using Xunit;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using EasyGold.API.Models.Users;

public class UtenteDettaglioDTOTests
{
    private IList<ValidationResult> ValidateModel(object model)
    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(model, null, null);
        Validator.TryValidateObject(model, context, results, true);
        return results;
    }

    [Fact]
    public void UtenteDettaglioDTO_Nome_ShouldBeRequired()
    {
        // Arrange
        var utenteDettaglio = new UtenteDettaglioDTO { Utw_Nome = null };

        // Act
        var results = ValidateModel(utenteDettaglio);

        // Assert
        Assert.Contains(results, v => v.MemberNames.Contains("Utw_Nome"));
    }

    [Fact]
    public void UtenteDettaglioDTO_Email_ShouldBeValid()
    {
        // Arrange
        var utenteDettaglio = new UtenteDettaglioDTO { Utw_Email = "invalid-email" };

        // Act
        var results = ValidateModel(utenteDettaglio);

        // Assert
        Assert.Contains(results, v => v.MemberNames.Contains("Utw_Email"));
    }
}
