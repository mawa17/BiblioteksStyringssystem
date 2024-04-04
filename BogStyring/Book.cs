using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Datatypes
{
    public sealed record Book
    {
        
        [DisallowNull]
        public string Title { get; init; }

        [DisallowNull]
        public string Author { get; init; } = "Unknown";

        public Book([Optional] string title, [Optional] string author)
        {
            this.Title = title;
            this.Author = author;
        }
    }
}
