
using Xunit;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using EasyGold.API.Models.Users;

public class UtenteDTOTests
{
    private IList<ValidationResult> ValidateModel(object model)
    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(model, null, null);
        Validator.TryValidateObject(model, context, results, true);
        return results;
    }

    [Fact]
    public void UtenteDTO_Nome_ShouldBeRequired()
    {
        // Arrange
        var utente = new UtenteDTO { Utw_Nome = null };

        // Act
        var results = ValidateModel(utente);

        // Assert
        Assert.Contains(results, v => v.MemberNames.Contains("Utw_Nome"));
    }

    [Fact]
    public void UtenteDTO_Cognome_ShouldBeRequired()
    {
        // Arrange
        var utente = new UtenteDTO { Utw_Cognome = null };

        // Act
        var results = ValidateModel(utente);

        // Assert
        Assert.Contains(results, v => v.MemberNames.Contains("Utw_Cognome"));
    }
}
