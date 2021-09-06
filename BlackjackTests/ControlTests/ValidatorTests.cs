using Xunit;
using Validator = Blackjack.BackJackControl.Validator;

namespace BlackjackTests.ControlTests
{
    public class ValidatorTests
    {
        [Fact]
        public void IsHitOrStay_TakesStringInput0_ReturnsTrue()
        {
            Assert.True(Validator.IsHitOrStay("0"));
        }
        
        [Fact]
        public void IsHitOrStay_TakesStringInput1_ReturnsTrue()
        {
            Assert.True(Validator.IsHitOrStay("1"));
        }
        
        [Fact]
        public void IsHitOrStay_TakesCharacterInput_ReturnsFalse()
        {
            Assert.False(Validator.IsHitOrStay("a"));
        }
        
        [Fact]
        public void IsHitOrStay_TakesNumericInputOtherThan0And1_ReturnsFalse()
        {
            Assert.False(Validator.IsHitOrStay("5"));
        }
        
        [Fact]
        public void IsHitOrStay_TakesSpecialCharacterInput_ReturnsFalse()
        {
            Assert.False(Validator.IsHitOrStay("@"));
        }
    }
}