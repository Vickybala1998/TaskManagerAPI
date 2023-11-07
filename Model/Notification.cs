namespace TaskManagerAPI.Model
{
    public class Notification
    {
        public int id { get; set; }

        public string? title { get;set; }
        public string? message { get; set; }

        public DateTime date { get; set; }
        public string? assignedBy { get; set; }

    }
}
