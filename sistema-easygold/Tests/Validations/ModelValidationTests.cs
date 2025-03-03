
using Xunit;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

public class ModelValidationTests
{
    public class ExampleModel
    {
        [Required]
        public string Nome { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Range(18, 99)]
        public int Età { get; set; }
    }

    private IList<ValidationResult> ValidateModel(object model)
    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(model, null, null);
        Validator.TryValidateObject(model, context, results, true);
        return results;
    }

    [Fact]
    public void Model_WithInvalidEmail_ShouldFailValidation()
    {
        // Arrange
        var model = new ExampleModel { Nome = "Mario", Email = "invalid-email", Età = 25 };

        // Act
        var results = ValidateModel(model);

        // Assert
        Assert.Contains(results, v => v.MemberNames.Contains("Email"));
    }
}
