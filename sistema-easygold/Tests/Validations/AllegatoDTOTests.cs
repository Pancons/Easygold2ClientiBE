
using Xunit;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using EasyGold.API.Models.Clients;

public class AllegatoDTOTests
{
    private IList<ValidationResult> ValidateModel(object model)
    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(model, null, null);
        Validator.TryValidateObject(model, context, results, true);
        return results;
    }

    [Fact]
    public void AllegatoDTO_NomeFile_ShouldBeRequired()
    {
        // Arrange
        var allegato = new AllegatoDTO { All_NomeFile = null };

        // Act
        var results = ValidateModel(allegato);

        // Assert
        Assert.Contains(results, v => v.MemberNames.Contains("All_NomeFile"));
    }

    [Fact]
    public void AllegatoDTO_Estensione_ShouldBeRequired()
    {
        // Arrange
        var allegato = new AllegatoDTO { All_Estensione = null };

        // Act
        var results = ValidateModel(allegato);

        // Assert
        Assert.Contains(results, v => v.MemberNames.Contains("All_Estensione"));
    }
}

using Xunit;
using EasyGold.API.Models.Clients;

public class AllegatoDTOTests
{
    [Fact]
    public void AllegatoDTO_NomeFile_ShouldNotBeNullOrEmpty()
    {
        // Arrange
        var allegato = new AllegatoDTO
        {
            All_NomeFile = "example.txt"
        };

        // Act & Assert
        Assert.False(string.IsNullOrEmpty(allegato.All_NomeFile));
    }

    [Fact]
    public void AllegatoDTO_Estensione_ShouldNotBeNullOrEmpty()
    {
        // Arrange
        var allegato = new AllegatoDTO
        {
            All_Estensione = ".txt"
        };

        // Act & Assert
        Assert.False(string.IsNullOrEmpty(allegato.All_Estensione));
    }
}
