using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MailKit.Net.Smtp;
using MailKit.Security;
using TaskManagerAPI.Data;
using TaskManagerAPI.Model;
using MimeKit;

namespace TaskManagerAPI.Repository
{
    public class TaskRepository:ITaskRepository
    {
        private readonly DataContext _dataContext;
        private readonly EMailSettings _emailSettings;
        public TaskRepository(DataContext dataContext,IOptions<EMailSettings> emailSettings) {
            _dataContext= dataContext;
            _emailSettings= emailSettings.Value;
        }

        public async Task createNewTask(TaskDetails taskDetails)
        {
            await _dataContext._tasks.AddAsync(taskDetails);
            _dataContext.SaveChanges();
        }

        public async Task<List<TaskDetails>> getTaskDetails()
        {
            
           List<TaskDetails> task= await _dataContext._tasks.Where(tasks=>tasks.heading!=null)
                                   .ToListAsync();
            return task;
        }

        public async Task<TaskDetails> getTaskDetailsById(int id)
        {

            TaskDetails? task = await _dataContext._tasks.FirstOrDefaultAsync(x => x.id == id);
            return task;
        }

        public async Task updateTask(TaskDetails taskDetails)
        {
            TaskDetails? selectedDetails = await _dataContext._tasks.Where(x => x.id == taskDetails.id).FirstOrDefaultAsync();
            if(taskDetails?.heading!=null && taskDetails.heading!=selectedDetails.heading)
            {
                selectedDetails.heading= taskDetails.heading;
            }
            if (taskDetails?.description!= null && taskDetails.description!=selectedDetails.description)
            {
                selectedDetails.description = taskDetails.description;
            }
            if (taskDetails?.startDate != null && taskDetails.startDate != selectedDetails.startDate)
            {
                selectedDetails.startDate = taskDetails.startDate;
            }
            if (taskDetails?.endDate != null && taskDetails.endDate != selectedDetails.endDate)
            {
                selectedDetails.endDate = taskDetails.endDate;
            }
            if (taskDetails?.status != null && taskDetails.status != selectedDetails.status)
            {
                selectedDetails.status = taskDetails.status;
            }
            if (taskDetails?.assignedTo != null && taskDetails.assignedTo != selectedDetails.assignedTo)
            {
                selectedDetails.assignedTo = taskDetails.assignedTo;
            }
            _dataContext.SaveChanges();
        }

        public async Task deleteTask(int id)
        {
            TaskDetails? selectedDetails = await _dataContext._tasks.Where(x => x.id == id).FirstOrDefaultAsync();
            if(selectedDetails != null)
            {
                _dataContext._tasks.Remove(selectedDetails);
                _dataContext.SaveChanges();
            } 
        }
        public async Task<List<Notification>> getNotification()
        {
            List<Notification> notification = await _dataContext._notifications.ToListAsync();
            return notification;
        }

        public async Task createNotification(Notification _notification)
        {
            await _dataContext._notifications.AddAsync(_notification);
            _dataContext.SaveChanges();
        }

        public async Task sendEmailNotification()
        {
            using (var client=new SmtpClient())
            {
                var mail = new MimeKit.MimeMessage();
                mail.Sender = MailboxAddress.Parse("vickybalaautomobile@gmail.com");
                mail.To.Add(MailboxAddress.Parse("vigneshkumar10698@gmail.com"));
                var builder = new BodyBuilder();
                builder.HtmlBody = "_emailNotification.body";
                mail.Body=builder.ToMessageBody();
                mail.Subject= "_emailNotification.subject";

                client.Connect(_emailSettings.smtpServer, _emailSettings.smtpPort, SecureSocketOptions.StartTls);
                client.Authenticate("vickybalaautomobile@gmail.com", "uewb exzg ybbm smsi");
                await client.SendAsync(mail);
            }
        }
    }
}
