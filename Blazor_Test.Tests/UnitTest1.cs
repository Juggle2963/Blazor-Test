using Blazor_Test.Models;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Blazor_Test.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void EmailFail()
        {
            var user = new User()
            {
                FullName = "Okej",
                UserName = "Okej",
                Email = "NotOk",
                Password = "1@rT3456kl!gdsfRT"
            };
            var context = new ValidationContext(user);
                var result = new List<ValidationResult>();

            bool IsOk = Validator.TryValidateObject(user, context, result, true);

            Assert.False(IsOk); //validering inte ok
            Assert.DoesNotContain(result, r => r.ErrorMessage!.Contains("Email"));
        }
        [Fact]

        public void EmailPass()
        {
            var user = new User()
            {
                FullName = "Okej",
                UserName = "Okej",
                Email = "Thisisok@gmail.com",
                Password = "1@rT3456kl!gdsfRT"
            };
            var context = new ValidationContext(user);
            var result = new List<ValidationResult>();

            bool IsOk = Validator.TryValidateObject(user, context, result, true);

            Assert.True(IsOk); //validering ok
            Assert.DoesNotContain(result, r => r.ErrorMessage!.Contains("Email"));
        }

       
        }
}
