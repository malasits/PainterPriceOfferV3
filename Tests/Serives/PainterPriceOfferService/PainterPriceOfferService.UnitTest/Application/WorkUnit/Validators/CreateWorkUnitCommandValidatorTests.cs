using FluentAssertions;
using PainterPriceOfferServcie.Application.Features.WorkUnits.Commands.CreateWorkUnit;

namespace PainterPriceOfferService.UnitTest.Application.WorkUnit.Validators
{
    public class CreateWorkUnitCommandValidatorTests
    {
        private readonly CreateWorkUnitCommandValidator _validator = new();

        [Fact]
        public void Should_Have_Error_When_Name_Is_Empty()
        {
            var command = new CreateWorkUnitCommand("", "user1");
            var result = _validator.Validate(command);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "Name");
        }

        [Fact]
        public void Should_Have_Error_When_UserId_Is_Empty()
        {
            var command = new CreateWorkUnitCommand("UnitName", "");
            var result = _validator.Validate(command);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "UserId");
        }
    }
}
