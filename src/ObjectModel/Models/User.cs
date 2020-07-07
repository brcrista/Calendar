namespace Calendar.ObjectModel.Models
{
    public sealed class User
    {
        public long Id { get; set; }

        public string? DisplayName { get; set; }

        public Account? Account { get; set; }
    }
}