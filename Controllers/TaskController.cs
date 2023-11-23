using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using TaskManagerAPI.Model;
using TaskManagerAPI.Repository;

namespace TaskManagerAPI.Controllers
{
    [Route("api/v1.0/TaskManager")]
    [ApiController]
    public class TaskController:ControllerBase
    {
        private readonly ITaskRepository _taskRepository; 
        public TaskController(ITaskRepository taskRepository) {
            _taskRepository = taskRepository;
         }

        [HttpPost("createTask")]
        public async Task createNewTask([FromBody] TaskDetails task) {
            await _taskRepository.createNewTask(task);
        }

        [HttpPut("updateTask")]
        public async Task updateTask([FromForm] TaskDetails task)
        {
            await _taskRepository.updateTask(task);
        }

        [HttpGet("getTaskDetails")]
        public async Task<List<TaskDetails>> getTaskDetails()
        {
            return await _taskRepository.getTaskDetails();
        }

        [HttpGet("getTaskDetailsById/{id}")]
        public async Task<TaskDetails> getTaskDetailsById(int id)
        {
            return await _taskRepository.getTaskDetailsById(id);
        }

        [HttpDelete("deleteTask/{id}")]
        public async Task deleteTask(int id)
        {
            await _taskRepository.deleteTask(id);
        }

        [HttpPost("createNotification")]
        public async Task createNotification([FromForm] Notification notification)
        {
            await _taskRepository.createNotification(notification);
        }

        [HttpGet("getNotification")]
        public async Task<List<Notification>> getNotification()
        {
            return await _taskRepository.getNotification();
        }

        [HttpGet("Emailnotification")]
        public async Task<ActionResult> sendEMailNotification()
        {
            await _taskRepository.sendEmailNotification();
            return StatusCode(200);
        }

    }
}
