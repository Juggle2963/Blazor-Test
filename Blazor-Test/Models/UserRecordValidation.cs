namespace Blazor_Test.Models
{
    public class UserRecordValidation
{
        //Går igenom Users, om validering !ok - spara i lista
        public User User { get; set; } = new();
        public List<string> Errors { get; set; } = new();
        public bool IsValid => Errors.Count == 0;

    }
}
