using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Datatypes
{
    public sealed record Member
    {
        public string Name { get; init; }

        public string Email { get; init; }
        public uint? Id { get; init; }

        public Member([Optional]string name, [Optional]string email)
        {
            this.Name = name;
            this.Email = email;
        }
    }
}
