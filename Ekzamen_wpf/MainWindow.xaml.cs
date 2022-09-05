using Ekzamen_wpf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ekzamen_wpf
{
    public partial class MainWindow : Window
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var at = db.jenres.ToList();
            var s = db.authors.ToList();
            foreach (Jenre a in at)
            {
                foreach (Author n in s)
                {
                    if (a.Name == book8.Text || n.surname == book9.Text)
                    {
                        Book pt = new Book() { Name = book1.Text, Jenre = a.Id, publisher = book2.Text, Num_pages = Convert.ToInt32(book3.Text), cost_price = Convert.ToInt32(book4.Text), year = Convert.ToInt32(book5.Text), price = Convert.ToInt32(book6.Text), seria = Convert.ToBoolean(book7.Text), Author = n.Id };
                        db.books.Add(pt);
                        db.SaveChanges();
                        MessageBox.Show("Книга добавлена");
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Введите значение");
                    }
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (jenre1.Text != "")
            {
                Jenre at = new Jenre() { Name = jenre1.Text};
                db.jenres.Add(at);
                db.SaveChanges();
                MessageBox.Show("Жанр добавлен");
            }
            else
            {
                MessageBox.Show("Введите значение");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (author1.Text != "" || author2.Text != "")
            {
                Author at = new Author() { Name = author1.Text, surname = author2.Text };
                db.authors.Add(at);
                db.SaveChanges();
                MessageBox.Show("Автор добавлен");
            }
            else
            {
                MessageBox.Show("Введите значение");
            }
        }

        private void Buttoun4_Click(object sender, RoutedEventArgs e)
        {
            var at = db.books.ToList();
            foreach (Book a in at)
            {
                if (a.Name == del_book.Text)
                {
                    db.books.Remove(a);
                    db.SaveChanges();
                    MessageBox.Show("Книга удаленна");
                }
                else
                {
                    MessageBox.Show("Книга не найдена");
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var at = db.authors.ToList();
            foreach (Author a in at)
            {
                if (a.surname == del_author.Text)
                {
                    db.authors.Remove(a);
                    db.SaveChanges();
                    MessageBox.Show("Автор удален");
                }
                else
                {
                    MessageBox.Show("Автор не найден");
                }
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var at = db.jenres.ToList();
            foreach (Jenre a in at)
            {
                if (a.Name == del_jenre.Text)
                {
                    db.jenres.Remove(a);
                    db.SaveChanges();
                    MessageBox.Show("Жанр удален");
                }
                else
                {
                    MessageBox.Show("Жанр не найден");
                }
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            search_list.Items.Clear();
            var st = db.authors.ToList();
            foreach (Author a in st)
            {
                var at = db.jenres.ToList();
                foreach (Jenre j in at)
                {
                    var bt = db.books.ToList();
                    foreach (Book b in bt)
                    {
                        if (a.surname == search1.Text && b.Author == a.Id) // поиск по автору
                        {
                            search_list.Items.Add(b.Name);
                            search_list.Items.Add(b.Num_pages);
                            search_list.Items.Add(b.Author);
                            search_list.Items.Add(b.cost_price);
                            search_list.Items.Add(b.Jenre);
                            search_list.Items.Add(b.publisher);
                            search_list.Items.Add(b.seria);
                            search_list.Items.Add(b.year);
                            break;
                        }
                        if (j.Name == search1.Text && b.Jenre == j.Id) // поиск по жанру
                        {
                            search_list.Items.Add(b.Name);
                            search_list.Items.Add(b.Num_pages);
                            search_list.Items.Add(b.Author);
                            search_list.Items.Add(b.cost_price);
                            search_list.Items.Add(b.Jenre);
                            search_list.Items.Add(b.publisher);
                            search_list.Items.Add(b.seria);
                            search_list.Items.Add(b.year);
                            break;
                        }
                        if (b.Name == search1.Text) // поиск по названию книги
                        {
                            search_list.Items.Add(b.Name);
                            search_list.Items.Add(b.Num_pages);
                            search_list.Items.Add(b.Author);
                            search_list.Items.Add(b.cost_price);
                            search_list.Items.Add(b.Jenre);
                            search_list.Items.Add(b.publisher);
                            search_list.Items.Add(b.seria);
                            search_list.Items.Add(b.year);
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Книга не найдена");
                        }
                    }
                }
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            var st = db.authors.ToList();
            foreach (Author a in st)
            {
                var at = db.jenres.ToList();
                foreach (Jenre j in at)
                {
                    var bt = db.books.ToList();
                    foreach (Book b in bt)
                    {
                        if (b.Name == red_book.Text) // поиск по названию книги
                        {
                            book1.Text = b.Name;
                            book2.Text = b.publisher;
                            book3.Text = Convert.ToString(b.Num_pages);
                            book4.Text = Convert.ToString(b.cost_price);
                            book5.Text = Convert.ToString(b.year);
                            book6.Text = Convert.ToString(b.price);
                            book7.Text = Convert.ToString(b.seria);
                            book8.Text = j.Name;
                            book9.Text = a.surname;
                            db.books.Remove(b);
                            db.SaveChanges();
                            break;
                        }
                        if (a.surname == red_book.Text && b.Author == a.Id) // поиск по автору
                        {
                            author1.Text = a.Name;
                            author2.Text = a.surname;
                            db.authors.Remove(a);
                            db.SaveChanges();
                            break;
                        }
                        if (j.Name == red_book.Text && b.Jenre == j.Id) // поиск по жанру
                        {
                            jenre1.Text = j.Name;
                            db.jenres.Remove(j);
                            db.SaveChanges();
                            break;
                        }
                    }
                }
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            book7.Text = "False";
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            book7.Text = "True";
        }
    }
}