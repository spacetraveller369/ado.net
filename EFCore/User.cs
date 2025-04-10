namespace EFCore
{
    internal static partial class Program
    {
        public class User
        {
            public int ID { get; set; }
            public string? UserName { get; set; }
            public string? PasswordHash { get; set; }
            public byte[]? ProfilePicture { get; set; }
        }
    }
}