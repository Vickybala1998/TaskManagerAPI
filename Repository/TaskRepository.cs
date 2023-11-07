using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TaskManagerAPI.Data;
using TaskManagerAPI.Model;

namespace TaskManagerAPI.Repository
{
    public class TaskRepository:ITaskRepository
    {
        private readonly DataContext _dataContext;
        public TaskRepository(DataContext dataContext) {
            _dataContext= dataContext;
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
    }
}
