namespace Calendar.ObjectModel.Models
{
    public sealed class User
    {
        public int Id { get; set; }

        public string? DisplayName { get; set; }

        public Account? Account { get; set; }
    }
}