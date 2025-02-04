using Domain;
using TechChallenge.Tests.Entitiy;

namespace TechChallenge.Tests.Domain
{
    public class MedicoTests
    {
        // [Fact]
        // public void Create_ShouldReturnMedico_WhenMedicoDTOIsValid()
        // {
        //     // Arrange
        //     var contactDto = MedicoBuilder.Build();

        //     // Act
        //     var contact = Medico.Create(contactDto);

        //     // Assert
        //     Assert.NotNull(contact);
        //     Assert.Equal(int.Parse(contactDto.Phone[..2]), contact.DDDId);
        //     Assert.Empty(contact.ValidationResult.Errors);
        //     Assert.Equal(contactDto.Name, contact.Name);
        //     Assert.Equal(contactDto.Phone, string.Concat(contact.DDDId.ToString(), contact.Phone));
        //     Assert.Equal(contactDto.Email, contact.Email);
        // }

        // [Fact]
        // public void Create_ShouldHaveValidationErrors_WhenEmailMedicoDTOIsInvalid()
        // {
        //     // Arrange
        //     var contactDto = MedicoBuilder.Build();
        //     contactDto.Email = contactDto.Email.Replace("@", "");

        //     // Act
        //     var contact = Medico.Create(contactDto);

        //     // Assert
        //     Assert.NotNull(contact);
        //     Assert.NotEmpty(contact.ValidationResult.Errors);
        //     Assert.False(contact.ValidationResult.IsValid);
        // }

        // [Fact]
        // public void Update_ShouldUpdateMedicoDetails()
        // {
        //     // Arrange
        //     var contact = Medico.Create(MedicoBuilder.Build());

        //     var contactUpdateDto = MedicoBuilder.BuildUpdateDto();

        //     // Act
        //     contact.Update(contactUpdateDto);

        //     // Assert
        //     Assert.Equal(contactUpdateDto.Name, contact.Name);
        //     Assert.Equal(contactUpdateDto.Phone[2..], contact.Phone);
        //     Assert.Equal(contactUpdateDto.Email, contact.Email);
        //     Assert.Equal(int.Parse(contactUpdateDto.Phone[..2]), contact.DDDId);
        // }

        // [Fact]
        // public void Create_ShouldHaveValidationErrors_WhenPhoneMedicoDTOIsInvalid()
        // {
        //     // Arrange
        //     var contactDto = MedicoBuilder.Build();
        //     contactDto.Phone = contactDto.Phone[3..];
        //     // Act
        //     var contact = Medico.Create(contactDto);

        //     // Assert
        //     Assert.NotNull(contact);
        //     Assert.NotEmpty(contact.ValidationResult.Errors);
        // }

        // [Fact]
        // public void Update_ShouldThrowException_WhenPhoneIsInvalid()
        // {
        //     // Arrange            
        //     var contact = Medico.Create(MedicoBuilder.WrongBuild());

        //     // Act & Assert            
        //     Assert.False(contact.ValidationResult.IsValid);
        // }

        // [Fact]
        // public void Create_ShouldHaveValidationErrors_WhenDDDIsInvalid()
        // {
        //     // Arrange
        //     var contactDto = MedicoBuilder.WrongBuildDDD();
        //     // Act
        //     var contact = Medico.Create(contactDto);

        //     // Assert
        //     Assert.NotNull(contact);
        //     Assert.NotEmpty(contact.ValidationResult.Errors);
        // }
    }
}
