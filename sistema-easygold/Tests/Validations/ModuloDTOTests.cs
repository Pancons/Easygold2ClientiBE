
using Xunit;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using EasyGold.API.Models.Clients;

public class ModuloDTOTests
{
    private IList<ValidationResult> ValidateModel(object model)
    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(model, null, null);
        Validator.TryValidateObject(model, context, results, true);
        return results;
    }

    [Fact]
    public void ModuloDTO_Descrizione_ShouldBeRequired()
    {
        // Arrange
        var modulo = new ModuloDTO { Mde_Descrizione = null };

        // Act
        var results = ValidateModel(modulo);

        // Assert
        Assert.Contains(results, v => v.MemberNames.Contains("Mde_Descrizione"));
    }
}
