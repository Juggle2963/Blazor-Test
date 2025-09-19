using Blazor_Test.Models;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Blazor_Test.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void UserEmail_HasNoValidEmail_ShouldContainsError()
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
            Assert.Contains(result, r => r.ErrorMessage!.Contains("Email"));
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

      

		

		
		[Fact]
		public void FullName_Required_ShouldFailWhenEmpty()
		{
			var user = new User()
			{
				FullName = "", // tomt
				UserName = "User",
				Email = "valid@test.com",
				Password = "Aa1@aaaa"
			};

			var context = new ValidationContext(user);
			var result = new List<ValidationResult>();

			bool IsOk = Validator.TryValidateObject(user, context, result, true);

			Assert.False(IsOk);
			Assert.Contains(result, r => r.ErrorMessage!.Contains("required", StringComparison.OrdinalIgnoreCase));
		}

		[Fact]
		public void FullName_MaxLength_ShouldFailWhenTooLong()
		{
			var user = new User()
			{
				FullName = new string('a', 101),
				UserName = "User",
				Email = "valid@test.com",
				Password = "Aa1@aaaa"
			};

			var context = new ValidationContext(user);
			var result = new List<ValidationResult>();

			bool IsOk = Validator.TryValidateObject(user, context, result, true);

			Assert.False(IsOk);
			Assert.Contains(result, r => r.ErrorMessage!.Contains("maximum", StringComparison.OrdinalIgnoreCase));
		}

		
		[Fact]
		public void UserName_Required_ShouldFailWhenEmpty()
		{
			var user = new User()
			{
				FullName = "Name",
				UserName = "", //
				Email = "Okej@gmail.com",
				Password = "Ag1@aaaa"
			};

			var context = new ValidationContext(user);
			var result = new List<ValidationResult>();

			bool IsOk = Validator.TryValidateObject(user, context, result, true);

			Assert.False(IsOk);
			Assert.Contains(result, r => r.ErrorMessage!.Contains("required", StringComparison.OrdinalIgnoreCase));
		}

		
		[Fact]
		public void Password_ShouldFailWhenNotFullfilled()
		{
			var user = new User()
			{
				FullName = "Name",
				UserName = "User",
				Email = "Okej@gmail.com",
				Password = "password"
			};

			var context = new ValidationContext(user);
			var result = new List<ValidationResult>();

			bool IsOk = Validator.TryValidateObject(user, context, result, true);

			Assert.False(IsOk);
			Assert.Contains(result, r => r.ErrorMessage!.Contains("regular", StringComparison.OrdinalIgnoreCase) || r.ErrorMessage!.Contains("match", StringComparison.OrdinalIgnoreCase));
		}

		[Fact]
		public void Password_ShouldPassWhenFullFilled()
		{
			var user = new User()
			{
				FullName = "Name",
				UserName = "User",
				Email = "valid@test.com",
				Password = "Ab1@aawa"
			};

			var context = new ValidationContext(user);
			var result = new List<ValidationResult>();

			bool IsOk = Validator.TryValidateObject(user, context, result, true);

			Assert.True(IsOk);
		}
	}
}
