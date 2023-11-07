namespace TaskManagerAPI.Model
{
    public class UserModel
    {
        public int Id { get; set; }

        public string? EmployeeName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? Role { get; set; }

        public string? Department { get; set; }

        public IFormFile? ImageFile { get; set; }
    }
}
