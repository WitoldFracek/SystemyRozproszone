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
    public partial class BookForm : Form
    {
        private int padding = 30;
        public BookForm()
        {
            InitializeComponent();
            UpdateList();
            if(BooksListBox.Items.Count > 0)
            {
                BooksListBox.SelectedIndex = 0;
                //currentBook = GuiClient.GetAllBooks()[BooksListBox.SelectedIndex];
            }
            else
            {
                ModifyButton.Enabled = false;
                DeleteButton.Enabled = false;
            }

            TitleTextBox.Text = "Id".PadRight(padding) + "Title".PadRight(padding) + "Author".PadRight(padding) + "Price".PadRight(padding);
        }

        private void UpdateList()
        {
            BooksListBox.Items.Clear();
            var allBooks = GuiClient.GetAllBooks();
            foreach(var book in allBooks)
            {
                BooksListBox.Items.Add(book);
            }
            if (allBooks.Count > 0)
            {
                ModifyButton.Enabled = true;
                DeleteButton.Enabled = true;
                BooksListBox.SelectedIndex = 0;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Form dialog = new AddAndEditForm(new Book());
            dialog.ShowDialog(this);
            UpdateList();
        }

        private void ModifyButton_Click(object sender, EventArgs e)
        {
            if(BooksListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Select the book you want to modify.");
                return;
            }
            Book selected = (Book)BooksListBox.SelectedItem;
            Form dialog = new AddAndEditForm(selected, true);
            dialog.ShowDialog(this);
            UpdateList();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (BooksListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Select the book you want to delete.");
                return;
            }
            Book selected = (Book)BooksListBox.SelectedItem;
            GuiClient.DeleteBook(selected.Id);
            UpdateList();
        }

        private void MyDataInfoButton_Click(object sender, EventArgs e)
        {
            string r = GuiClient.GetMyData();
            MessageBox.Show(r);
        }

        private void BooksListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void MyDataClientButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(InfoPresenter.MyData.InfoString());
        }
    }
}
