using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class Library
    {
        private Customer[] customerArray = new Customer[5];
        private Book[] bookArray = new Book[5];
        private static int ids = 0;
        private static int catalog = 101;
        public bool AddNewCustomer(string customerName)
        {
            for (int i = 0; i < customerArray.Length; i++)
            {
                if (customerArray[i] == null)
                {
                    customerArray[i] = new Customer(customerName, ids + 1);
                    ids++;
                    return true;
                }
            }
            return false;
        }
        public bool AddNewBook(string bookTitle, string bookAuthor)
        {
            for (int i = 0; i < bookArray.Length; i++)
            {
                if (bookArray[i] == null)
                {
                    bookArray[i] = new GeneralBook(bookTitle, bookAuthor, catalog);
                    catalog++;
                    return true;
                }
            }
            return false;
        }
        public bool AddNewBook(string bTitle, string bAuthor, int edition)
        {
            for (int i = 0; i < bookArray.Length; i++)
            {
                if (bookArray[i] == null)
                {
                    bookArray[i] = new TextBook(bTitle, bAuthor, edition, catalog);
                    catalog++;
                    return true;
                }
            }
            return false;
        }
        public bool IssueBook(int custId, int bookCatalogNum)
        {
            for (int i = 0; i < bookArray.Length; i++)
            {
                if (bookArray[i] != null && bookArray[i].CatalogNumber == bookCatalogNum)
                {
                    for (int j = 0; j < customerArray.Length; j++)
                    {
                        if (customerArray[j] != null && customerArray[j].Id == custId)
                        {
                            return bookArray[i].CheckOut(customerArray[j]);
                        }
                    }
                }
            }
            return false;
        }
        public bool ReturnBook(int bookCatalogNum)
        {
            for (int i = 0; i < bookArray.Length; i++)
            {
                if (bookArray[i] != null && bookArray[i].CatalogNumber == bookCatalogNum)
                {
                    return bookArray[i].CheckIn();
                }
            }
            return false;
        }
        public bool RenewBook(int bookCatalogNum)
        {
            for (int i = 0; i < bookArray.Length; i++)
            {
                if (bookArray[i] != null && bookArray[i].CatalogNumber == bookCatalogNum)
                {
                    IRenewable r = bookArray[i] as IRenewable;
                    if (r != null)
                        return r.Renew();
                }
            }
            return false;
        }
        public string[] GetCustomerList()
        {
            string[] s = new string[customerArray.Length];
            for (int i = 0; i < customerArray.Length; i++)
            {
                if (customerArray[i] != null)
                    s[i] = customerArray[i].ToString();
            }
            return s;
        }
        public string[] GetBooksList()
        {
            string[] s = new string[bookArray.Length];
            for (int i = 0; i < bookArray.Length; i++)
            {
                if (bookArray[i] != null)
                    s[i] = bookArray[i].ToString();
            }
            return s;

        }

        public string ToString()
        {
            string s = "";
            for (int i = 0; i < customerArray.Length; i++)
            {
                if (customerArray[i] != null)
                    s = s + "\n" + customerArray[i].ToString();
            }
            s = s + "\n";
            for (int i = 0; i < bookArray.Length; i++)
            {
                if (bookArray[i] != null)
                    s = s + "\n" + bookArray[i].ToString();
            }
            return s;
        }

    }
}
