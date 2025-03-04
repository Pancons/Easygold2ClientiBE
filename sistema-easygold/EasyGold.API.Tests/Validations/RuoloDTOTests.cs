using Xunit;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using EasyGold.API.Models.Roles;

public class RuoloDTOTests
{
    private IList<ValidationResult> ValidateModel(object model)
    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(model, null, null);
        Validator.TryValidateObject(model, context, results, true);
        return results;
    }

    [Fact]
    public void RuoloDTO_Descrizione_ShouldBeRequired()
    {
        var ruolo = new RuoloDTO { Ur_Descrizione = null };
        var results = ValidateModel(ruolo);
        Assert.Contains(results, v => v.MemberNames.Contains("Ur_Descrizione"));
    }
}
