using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public abstract class Book
    {
        private int catalogNumber;
        private string title;
        private string authors;
        protected DateTime dueDate;
        protected Customer c;

        public int CatalogNumber
        {
            get { return catalogNumber; }
        }
        public Book(string title, string authors, int catalogNo)
        {
            this.title = title;
            this.authors = authors;
            this.catalogNumber = catalogNo;
        }
        public Book()
        { }
        public abstract DateTime findDueDate();
        public virtual string ToString()
        {
            string s = this.catalogNumber + "\t\t" + this.title + "\t\t" + this.authors + "\t\t";
            if (this.c == null)
                return string.Format("{0,-6}{1,-30}{2,-15}{3,-10}", this.catalogNumber, this.title, this.authors, "Available");
            else
                return string.Format("{0,-6}{1,-30}{2,-15}{3,-10}{4,-30}", this.catalogNumber, this.title, this.authors, "Checked out to Customer " + c.Id, " Due on " + dueDate);

        }
        public bool CheckOut(Customer c)
        {
            if (this.c == null)
            {
                this.c = c;
                dueDate = findDueDate();
                return true;
            }
            else
                return false;
        }
        public bool CheckIn()
        {
            if (this.c != null)
            {
                this.c = null;
                return true;
            }
            else
                return false;
        }
    }

    class TextBook : Book, IRenewable
    {
        private int edition;
        public TextBook(string title, string authors, int edition, int catalogNo) : base(title, authors, catalogNo)
        {
            this.edition = edition;
        }
        public override DateTime findDueDate()
        {
            DateTime today = DateTime.Now;
            dueDate = today.AddDays(30);
            return dueDate;
        }
        public bool Renew()
        {
            if (c != null)
            {

                dueDate = dueDate.AddDays(15);
                return true;
            }
            else
                return false;
        }
        public override string ToString()
        {
            return string.Format("{0,-120}{1,-15}", base.ToString(), "Edition: " + edition);
        }
    }

    class GeneralBook : Book
    {
        public GeneralBook(string title, string authors, int catalogNo) : base(title, authors, catalogNo)
        { }
        public override DateTime findDueDate()
        {
            DateTime today = DateTime.Now;
            dueDate = today.AddDays(7);
            return dueDate;
        }
    }

}
