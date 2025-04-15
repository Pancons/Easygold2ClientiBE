using Xunit;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using EasyGold.API.Models.Allegati;

public class AllegatoDTOTests
{
    private IList<ValidationResult> ValidateModel(AllegatoDTO model)
    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(model, null, null);
        Validator.TryValidateObject(model, context, results, true);
        return results;
    }

    // ------------------------
    // Test per campi obbligatori [Required]
    // ------------------------

    [Fact]
    public void AllegatoDTO_ShouldFailValidation_When_All_NomeFile_IsMissing()
    {
        var dto = new AllegatoDTO
        {
            All_NomeFile = null,  // Campo richiesto mancante
            All_Estensione = "pdf",
            All_Dimensione = 100,
            All_EntitaRiferimento = "Documento",
            All_RecordId = 42,
            All_Note = "Nota valida",
            All_ImgUrl = "http://esempio.com/immagine.png"
        };

        var results = ValidateModel(dto);
        Assert.Contains(results, v => v.MemberNames.Contains("All_NomeFile"));
    }

    [Fact]
    public void AllegatoDTO_ShouldFailValidation_When_All_Estensione_IsMissing()
    {
        var dto = new AllegatoDTO
        {
            All_NomeFile = "file.pdf",
            All_Estensione = null,  // Campo richiesto mancante
            All_Dimensione = 50,
            All_EntitaRiferimento = "Documento",
            All_RecordId = 100,
            All_Note = null,
            All_ImgUrl = "http://esempio.com/img.png"
        };

        var results = ValidateModel(dto);
        Assert.Contains(results, v => v.MemberNames.Contains("All_Estensione"));
    }

    [Fact]
    public void AllegatoDTO_ShouldFailValidation_When_All_EntitaRiferimento_IsMissing()
    {
        var dto = new AllegatoDTO
        {
            All_NomeFile = "file.txt",
            All_Estensione = "txt",
            All_Dimensione = 10,
            All_EntitaRiferimento = null,  // Campo richiesto mancante
            All_RecordId = 5,
            All_Note = "Qualche nota",
            All_ImgUrl = "http://esempio.com/img.png"
        };

        var results = ValidateModel(dto);
        Assert.Contains(results, v => v.MemberNames.Contains("All_EntitaRiferimento"));
    }

    // ------------------------
    // Test per lunghezza massima [StringLength]
    // ------------------------

    [Fact]
    public void AllegatoDTO_ShouldFailValidation_When_All_NomeFile_ExceedsMaxLength()
    {
        string longName = new string('A', 256); // 256 caratteri, supera il limite
        var dto = new AllegatoDTO { All_NomeFile = longName };

        var results = ValidateModel(dto);
        Assert.Contains(results, v => v.MemberNames.Contains("All_NomeFile"));
    }

    [Fact]
    public void AllegatoDTO_ShouldFailValidation_When_All_Estensione_ExceedsMaxLength()
    {
        string longExt = new string('X', 11); // 11 caratteri, supera il limite
        var dto = new AllegatoDTO { All_NomeFile = "file.pdf", All_Estensione = longExt };

        var results = ValidateModel(dto);
        Assert.Contains(results, v => v.MemberNames.Contains("All_Estensione"));
    }

    [Fact]
    public void AllegatoDTO_ShouldFailValidation_When_All_Note_ExceedsMaxLength()
    {
        string longNote = new string('N', 501); // 501 caratteri, supera il limite
        var dto = new AllegatoDTO { All_NomeFile = "file.pdf", All_Note = longNote };

        var results = ValidateModel(dto);
        Assert.Contains(results, v => v.MemberNames.Contains("All_Note"));
    }

    // ------------------------
    // Test per range numerico [Range]
    // ------------------------

    [Fact]
    public void AllegatoDTO_ShouldFailValidation_When_All_Dimensione_IsNegative()
    {
        var dto = new AllegatoDTO
        {
            All_NomeFile = "file.pdf",
            All_Estensione = "pdf",
            All_Dimensione = -50 // Valore non valido
        };

        var results = ValidateModel(dto);
        Assert.Contains(results, v => v.MemberNames.Contains("All_Dimensione"));
    }

    // ------------------------
    // Test per URL valido [Url]
    // ------------------------

    [Fact]
    public void AllegatoDTO_ShouldFailValidation_When_All_ImgUrl_IsInvalid()
    {
        var dto = new AllegatoDTO
        {
            All_NomeFile = "immagine.png",
            All_Estensione = "png",
            All_Dimensione = 2048,
            All_EntitaRiferimento = "Foto",
            All_ImgUrl = "non_un_url_valido"  // Formato non valido
        };

        var results = ValidateModel(dto);
        Assert.Contains(results, v => v.MemberNames.Contains("All_ImgUrl"));
    }

    [Fact]
    public void AllegatoDTO_ShouldPassValidation_When_All_ImgUrl_IsValid()
    {
        var dto = new AllegatoDTO
        {
            All_NomeFile = "immagine.png",
            All_Estensione = "png",
            All_Dimensione = 2048,
            All_EntitaRiferimento = "Foto",
            All_ImgUrl = "http://esempio.com/immagine.png" // URL valido
        };

        var results = ValidateModel(dto);
        Assert.Empty(results); // Nessun errore atteso
    }
}
