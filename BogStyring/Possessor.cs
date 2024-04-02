using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Datatypes.Enum
{
    [Flags]
    public enum Possessor
    {
        Library = 1 << 0,
        Person = 1 << 1,
    }
}
