
using Xunit;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using EasyGold.API.Models.Clients;

public class ConfigurazioneDTOTests
{
    private IList<ValidationResult> ValidateModel(object model)
    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(model, null, null);
        Validator.TryValidateObject(model, context, results, true);
        return results;
    }

    [Fact]
    public void ConfigurazioneDTO_NegoziAttivabili_ShouldBeInRange()
    {
        // Arrange
        var configurazione = new ConfigurazioneDTO { Utw_NegoziAttivabili = -1 };

        // Act
        var results = ValidateModel(configurazione);

        // Assert
        Assert.Contains(results, v => v.MemberNames.Contains("Utw_NegoziAttivabili"));
    }

    [Fact]
    public void ConfigurazioneDTO_DataAttivazione_ShouldBeValidDate()
    {
        // Arrange
        var configurazione = new ConfigurazioneDTO { Utw_DataAttivazione = DateTime.MinValue };

        // Act
        var results = ValidateModel(configurazione);

        // Assert
        Assert.Empty(results); // Assuming DateTime.MinValue is a valid date for this context
    }
}
