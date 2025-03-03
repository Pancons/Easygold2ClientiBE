
using Xunit;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using EasyGold.API.Models.Clients;

public class NegozioDTOTests
{
    private IList<ValidationResult> ValidateModel(object model)
    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(model, null, null);
        Validator.TryValidateObject(model, context, results, true);
        return results;
    }

    [Fact]
    public void NegozioDTO_RagioneSociale_ShouldBeRequired()
    {
        // Arrange
        var negozio = new NegozioDTO { Neg_RagioneSociale = null };

        // Act
        var results = ValidateModel(negozio);

        // Assert
        Assert.Contains(results, v => v.MemberNames.Contains("Neg_RagioneSociale"));
    }

    [Fact]
    public void NegozioDTO_NomeNegozio_ShouldBeRequired()
    {
        // Arrange
        var negozio = new NegozioDTO { Neg_NomeNegozio = null };

        // Act
        var results = ValidateModel(negozio);

        // Assert
        Assert.Contains(results, v => v.MemberNames.Contains("Neg_NomeNegozio"));
    }
}
