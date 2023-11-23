using TaskManagerAPI.Model;

namespace TaskManagerAPI.Repository
{
    public interface ITaskRepository
    {
        Task<List<TaskDetails>> getTaskDetails();
        Task createNewTask(TaskDetails taskDetails);

        Task updateTask(TaskDetails taskDetails);

        Task<TaskDetails> getTaskDetailsById(int id);

        Task deleteTask(int id);

        Task createNotification(Notification notification);

        Task<List<Notification>> getNotification();

        Task sendEmailNotification();
    
    }
}
