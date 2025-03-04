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
        var utente = new UtenteDTO { Ute_Nome = null };
        var results = ValidateModel(utente);
        Assert.Contains(results, v => v.MemberNames.Contains("Ute_Nome"));
    }

  
    [Fact]
    public void UtenteDTO_Password_ShouldBeRequired()
    {
        var utente = new UtenteDTO { Ute_Password = null };
        var results = ValidateModel(utente);
        Assert.Contains(results, v => v.MemberNames.Contains("Ute_Password"));
    }
}
