using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIClient
{
    public partial class AddAndEditForm : Form
    {
        Book currentBook;
        private bool editMode = false;
        public AddAndEditForm(int id)
        {
            InitializeComponent();
        }

        public AddAndEditForm(Book book, bool editMode = false)
        {
            InitializeComponent();
            currentBook = book;
            TitleTextBox.Text = book.Title;
            AuthorTextBox.Text = book.Author;
            PriceTextBox.Text = book.Price.ToString().Replace('.', ',');
            this.editMode = editMode;
        }

        private void AuthorLabel_Click(object sender, EventArgs e)
        {

        }

        private void AuthorTextBox_TextChanged(object sender, EventArgs e)
        {
            currentBook.Author = AuthorTextBox.Text;
        }

        private void TitleTextBox_TextChanged(object sender, EventArgs e)
        {
            currentBook.Title = TitleTextBox.Text;
        }

        private void PriceTextBox_TextChanged(object sender, EventArgs e)
        {
            double price = 0.0;
            try
            {
                price = double.Parse(PriceTextBox.Text);
            }
            catch (Exception err)
            {
                MessageBox.Show($"{PriceTextBox.Text} is not a valid price.");
            }
            currentBook.Price = price;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if(editMode)
            {
                GuiClient.ModifyBook(currentBook);
            }
            else
            {
                GuiClient.AddBook(currentBook);
            }
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
