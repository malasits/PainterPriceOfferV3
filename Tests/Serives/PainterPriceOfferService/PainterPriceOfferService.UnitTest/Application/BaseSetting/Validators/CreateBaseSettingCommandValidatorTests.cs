using FluentValidation.TestHelper;
using PainterPriceOfferServcie.Application.Features.BaseSettings.Commands.CreateBaseSetting;

namespace PainterPriceOfferService.UnitTest.Application.BaseSetting.Validators
{
    public class CreateBaseSettingCommandValidatorTests
    {
        private readonly CreateBaseSettingCommandValidator _validator = new();

        private static CreateBaseSettingCommand GetValidCommand() =>
            new(
                UserId: "user123",
                DocumentTitle: "Ajánlat",
                DefaultAfaSelected: true,
                AfaText: "Áfa van",
                NotAfaText: "Nincs áfa",
                AfaKey: 27
            );

        [Fact]
        public void Should_Pass_When_AllFieldsAreValid()
        {
            var result = _validator.TestValidate(GetValidCommand());
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Should_Have_Error_When_UserId_IsEmpty()
        {
            var command = GetValidCommand() with { UserId = string.Empty };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.UserId)
                  .WithErrorMessage("User ID is required.");
        }

        [Fact]
        public void Should_Have_Error_When_DocumentTitle_IsEmpty()
        {
            var command = GetValidCommand() with { DocumentTitle = string.Empty };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.DocumentTitle)
                  .WithErrorMessage("Document title is required.");
        }

        [Fact]
        public void Should_Have_Error_When_AfaText_IsEmpty()
        {
            var command = GetValidCommand() with { AfaText = string.Empty };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.AfaText)
                  .WithErrorMessage("Afa text is required.");
        }

        [Fact]
        public void Should_Have_Error_When_NotAfaText_IsEmpty()
        {
            var command = GetValidCommand() with { NotAfaText = string.Empty };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.NotAfaText)
                  .WithErrorMessage("Not afa text is required.");
        }

        [Fact]
        public void Should_Have_Error_When_AfaKey_IsEmpty()
        {
            var command = GetValidCommand() with { AfaKey = 0 };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.AfaKey)
                  .WithErrorMessage("Afa key is required.");
        }
    }
}
