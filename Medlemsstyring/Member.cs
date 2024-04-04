using System.Runtime.InteropServices;

namespace LibraryManagementSystem.Datatypes
{
    public sealed record Member
    {
        public string Name { get; init; }
        public string Email { get; init; }

        public Member([Optional]string name, [Optional]string email)
        {
            this.Name = name;
            this.Email = email;
        }
    }
}