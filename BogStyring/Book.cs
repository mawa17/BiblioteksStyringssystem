using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

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