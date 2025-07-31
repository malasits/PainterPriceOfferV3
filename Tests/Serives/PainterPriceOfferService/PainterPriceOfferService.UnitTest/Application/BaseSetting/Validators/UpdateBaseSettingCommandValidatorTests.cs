using FluentValidation.TestHelper;
using PainterPriceOfferServcie.Application.Features.BaseSettings.Commands.UpdateBaseSetting;

namespace PainterPriceOfferService.UnitTest.Application.BaseSetting.Validators
{
    public class UpdateBaseSettingCommandValidatorTests
    {
        private readonly UpdateBaseSettingCommandValidator _validator;

        public UpdateBaseSettingCommandValidatorTests()
        {
            _validator = new UpdateBaseSettingCommandValidator();
        }

        private static UpdateBaseSettingCommand GetValidCommand() => new(
            Id: "id-123",
            UserId: "user-xyz",
            DocumentTitle: "Ajánlat",
            DefaultAfaSelected: true,
            AfaText: "27%",
            NotAfaText: "Nincs Áfa",
            AfaKey: 27
        );

        [Fact]
        public void Should_Pass_When_CommandIsValid()
        {
            var command = GetValidCommand();
            var result = _validator.TestValidate(command);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [InlineData(null, "Document title is required.")]
        [InlineData("", "Document title is required.")]
        public void Should_Fail_When_DocumentTitleMissing(string? title, string expectedError)
        {
            var command = GetValidCommand() with { DocumentTitle = title! };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.DocumentTitle)
                  .WithErrorMessage(expectedError);
        }

        [Theory]
        [InlineData(null, "Afa text is required.")]
        [InlineData("", "Afa text is required.")]
        public void Should_Fail_When_AfaTextMissing(string? afaText, string expectedError)
        {
            var command = GetValidCommand() with { AfaText = afaText! };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.AfaText)
                  .WithErrorMessage(expectedError);
        }

        [Theory]
        [InlineData(null, "Not afa text is required.")]
        [InlineData("", "Not afa text is required.")]
        public void Should_Fail_When_NotAfaTextMissing(string? notAfaText, string expectedError)
        {
            var command = GetValidCommand() with { NotAfaText = notAfaText! };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.NotAfaText)
                  .WithErrorMessage(expectedError);
        }

        [Theory]
        [InlineData(0, "Afa key is required.")]
        public void Should_Fail_When_AfaKeyIsZero(int afaKey, string expectedError)
        {
            var command = GetValidCommand() with { AfaKey = afaKey };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.AfaKey)
                  .WithErrorMessage(expectedError);
        }

        [Theory]
        [InlineData(null, "Base setting ID is required.")]
        [InlineData("", "Base setting ID is required.")]
        public void Should_Fail_When_IdIsMissing(string? id, string expectedError)
        {
            var command = GetValidCommand() with { Id = id! };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.Id)
                  .WithErrorMessage(expectedError);
        }
    }
}
