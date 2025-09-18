using Blazor_Test.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;

namespace Blazor_Test.Services
{
    public class CsvImportService
    {
        public async Task<List<UserRecordValidation>> ImportAsync(Stream fileStream)
        {
            //Läser in csv fil
            using var reader = new StreamReader(fileStream);

            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) //konfigurera för att slippa headers

            {
                HasHeaderRecord = false,
                TrimOptions = TrimOptions.Trim,
                Delimiter = ","
            });

            csv.Context.RegisterClassMap<UserMap>();


            var users = new List<User>();
            while (await csv.ReadAsync())
            {
                var u = csv.GetRecord<User>();
                users.Add(u);
            }

            var Records = new List<UserRecordValidation>();
            foreach (var u in users)
            {
                Console.WriteLine($"{u.FullName} | {u.UserName} | {u.Email} | {u.Password}");
            }



            Records.Clear();

            foreach (var u in users)
            {
                var validation = new UserRecordValidation { User = u };
                var results = new List<ValidationResult>();
                var context = new ValidationContext(u);

                if (!Validator.TryValidateObject(u, context, results, true))
                {
                    validation.Errors.AddRange(results.Select(r => r.ErrorMessage ?? "fel inmatning"));
                }
                Records.Add(validation);
            }
            return Records;
        }


        public sealed class UserMap : ClassMap<User>
        {
            public UserMap()
            {
                Map(m => m.FullName).Index(0);
                Map(m => m.UserName).Index(1);
                Map(m => m.Email).Index(2);
                Map(m => m.Password).Index(3);
            }
        }
    }
}
