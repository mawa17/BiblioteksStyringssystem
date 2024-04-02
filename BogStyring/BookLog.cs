using LibraryManagementSystem.Datatypes;
using System.Diagnostics.CodeAnalysis;

namespace LibraryManagementSystem.Datatypes
{
    public sealed record BookLog
    {
        [DisallowNull]
        public Book book { get; init; }
        public Member lender { get; init; }
        public DateTime lendDate { get; init; }
        public DateTime returnDate { get; init; }
        public double DaysExceededReturnDate => Math.Clamp((this.returnDate.Subtract(this.lendDate)).TotalDays, 0, double.MaxValue);
        public BookLog(Book book, Member lender, ushort maxLendDays = 7)
        {
            this.book = book;
            this.lender = lender;
            this.lendDate = DateTime.Now;
            this.returnDate = this.lendDate.AddDays(maxLendDays);
        }
    }
}