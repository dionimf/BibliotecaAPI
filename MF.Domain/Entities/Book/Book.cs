using System;
using FluentValidation.Results;
using MF.Domain.Validation.Book;

namespace MF.Domain.Entities.Book
{
    public class Book : BaseEntity
    {
        public string BookName { get; protected set; }
        public string Author { get; protected set; }
        public string PublishingCompany { get; set; }
        public DateTime PostedDate { get; protected set; }
        public string Edition { get; protected set; }
        public int Status { get; protected set; }
        public bool Active { get; protected set; }

        protected Book()
        {
        }

        public Book(string bookName, string author, string publishingCompany, DateTime postedDate, string edition,
            int status, bool active)
        {
            BookName = bookName;
            Author = author;
            PublishingCompany = publishingCompany;
            PostedDate = postedDate;
            Edition = edition;
            Status = status;
            Active = active;
        }

        public void Update(string bookName, string author, string publishingCompany, DateTime postedDate, string edition,
            int status, bool active)
        {
            BookName = bookName;
            Author = author;
            PublishingCompany = publishingCompany;
            PostedDate = postedDate;
            Edition = edition;
            Status = status;
            Active = active;
        }

        public void Disable()
        {
            Active = false;
        }

        public void UpdateStatus(int status)
        {
            Status = status;
        }

        public ValidationResult IsValid()
        {
            return new BookValidation().Validate(this);
        }
    }
}