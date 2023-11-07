namespace TaskManagerAPI.Model
{
    public class TaskDetails
    {
        public int id {  get; set; }
        public string? heading { get; set; }
        public string? description { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public string? status { get; set; }
        public string? assignedTo { get; set; }
    }
}
