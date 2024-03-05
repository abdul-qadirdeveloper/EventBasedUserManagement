namespace UserManagement.Domain.Entities
{
    public class User : IdEntity
    {
        public required string UserName { get; set; }

        public UserStatus Status { get; set; }
        // Add other properties as needed
    }
}
