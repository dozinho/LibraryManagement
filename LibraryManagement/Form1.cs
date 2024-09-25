using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{

    public partial class Form1 : Form
    {
        private Library _library;

        public Form1()
        {
            InitializeComponent();
            _library = new Library(); // Initialize the library
                                      // Add columns to the ListView
            listView1.View = View.Details;
            listView1.Columns.Add("Title", 150);
            listView1.Columns.Add("Author", 150);
            listView1.Columns.Add("ISBN", 100);
            listView1.Columns.Add("Status", 100);
            //string imagePath = @"C:\Users\princ\source\repos\LibraryManagement\LibraryManagement\pictures\lib.jpeg";
            // this.BackgroundImage = Image.FromFile(imagePath);
            this.BackgroundImage = Properties.Resources.lib2;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }
        
        private void btnAddBook_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            string author = txtAuthor.Text;
            string isbn = txtISBN.Text;
            if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(author) && !string.IsNullOrWhiteSpace(isbn))
            {
                Book book = new Book(title, author, isbn);
                _library.AddBook(book);
                DisplayBooks(_library.GetBooks());
                txtTitle.Clear();
                txtAuthor.Clear();
                txtISBN.Clear();
                txtSearchTitle.Clear();
                txtSearchAuthor.Clear();
            }
            else
            {
                MessageBox.Show("Please enter all book details.");
            }
        }

        private void btnRemoveBook_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            if (!string.IsNullOrWhiteSpace(title))
            {
                Book bookToRemove = _library.GetBooks().FirstOrDefault(b => b.Title == title);
                if (bookToRemove != null)
                {
                    _library.RemoveBook(bookToRemove);
                    DisplayBooks(_library.GetBooks());
                    txtTitle.Clear();
                    txtAuthor.Clear();
                    txtISBN.Clear();
                    txtSearchTitle.Clear();
                    txtSearchAuthor.Clear();
                }
                else
                {
                    MessageBox.Show("Book not found.");
                }
            }
            else
            {
                MessageBox.Show("Please enter the title of the book to remove.");
            }
        }

        private void btnDisplayBooks_Click(object sender, EventArgs e)
        {
            DisplayBooks(_library.GetBooks());
        }

        private void btnSearchByTitle_Click(object sender, EventArgs e)
        {
            string title = txtSearchTitle.Text;
            if (!string.IsNullOrWhiteSpace(title))
            {
                List<Book> searchResults = _library.SearchByTitle(title);
                DisplayBooks(searchResults);
                txtTitle.Clear();
                txtAuthor.Clear();
                txtISBN.Clear();
                txtSearchTitle.Clear();
                txtSearchAuthor.Clear();
            }
            else
            {
                MessageBox.Show("Please enter a title to search for.");
            }
        }

        private void btnSearchByAuthor_Click(object sender, EventArgs e)
        {
            string author = txtSearchAuthor.Text;
            if (!string.IsNullOrWhiteSpace(author))
            {
                List<Book> searchResults = _library.SearchByAuthor(author);
                DisplayBooks(searchResults);
                txtTitle.Clear();
                txtAuthor.Clear();
                txtISBN.Clear();
                txtSearchTitle.Clear();
                txtSearchAuthor.Clear();
            }
            else
            {
                MessageBox.Show("Please enter an author to search for.");
            }
        }

        private void btnBorrowBook_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            if (!string.IsNullOrWhiteSpace(title))
            {
                Book bookToBorrow = _library.GetBooks().FirstOrDefault(b => b.Title == title);
                if (bookToBorrow != null)
                {
                    if (!bookToBorrow.IsBorrowed)
                    {
                        _library.BorrowBook(bookToBorrow);
                        DisplayBooks(_library.GetBooks());
                        txtTitle.Clear();
                        txtAuthor.Clear();
                        txtISBN.Clear();
                        txtSearchTitle.Clear();
                        txtSearchAuthor.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Book is already borrowed.");
                    }
                }
                else
                {
                    MessageBox.Show("Book not found.");
                }
            }
            else
            {
                MessageBox.Show("Please enter the title of the book to borrow.");
            }
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            if (!string.IsNullOrWhiteSpace(title))
            {
                Book bookToReturn = _library.GetBooks().FirstOrDefault(b => b.Title == title);
                if (bookToReturn != null)
                {
                    if (bookToReturn.IsBorrowed)
                    {
                        _library.ReturnBook(bookToReturn);
                        DisplayBooks(_library.GetBooks());
                        txtTitle.Clear();
                        txtAuthor.Clear();
                        txtISBN.Clear();
                        txtSearchTitle.Clear();
                        txtSearchAuthor.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Book is not borrowed.");
                    }
                }
                else
                {
                    MessageBox.Show("Book not found.");
                }
            }
            else
            {
                MessageBox.Show("Please enter the title of the book to return.");
            }
        }
        private List<Book> books = new List<Book>();
        private void DisplayBooks(List<Book> booksToDisplay)
        {
            // Clear the list box
            listView1.Items.Clear();

            // Display the books
   //         if (booksToDisplay == null)
     //       {
       //         booksToDisplay = _books;
         //   }

            foreach (Book book in booksToDisplay)
            {
                ListViewItem item = new ListViewItem(book.Title);
                item.SubItems.Add(book.Author);
                item.SubItems.Add(book.ISBN);
                if (book.IsBorrowed)
                {
                    item.SubItems.Add("Borrowed");
                }
                else
                {
                    item.SubItems.Add("Available");
                }
                listView1.Items.Add(item);
            }            
        }
    }
}
