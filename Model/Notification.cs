using Microsoft.Extensions.Diagnostics.HealthChecks;

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

    public class EMailSettings
    {
        public string? smtpServer { get; set;}
        public int smtpPort { get; set; }   
    }

    public class EMailNotification
    {
        public string? toAddress { get; set; }
        public string? fromAddress { get; set;}
        public string? subject { get; set; }
        public string? body { get; set; }
    }

}
