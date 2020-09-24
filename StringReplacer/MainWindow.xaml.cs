using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
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

namespace StringReplacer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            EndString.IsReadOnly = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int first, last;
            List<string> str = new List<string>();
            str.AddRange(StartString.Text.ToLower().Split(' '));
            while (str.Contains(""))
                str.Remove("");
            if (str.Count == 0)
            {
                MessageBox.Show("Вы ввели пустую строку");
                EndString.Text = "Ошибка, попробуйте ещё раз";
                return;
            }
            if (!int.TryParse(start.Text,out first))
            {
                MessageBox.Show("В строке начального индекса не целое число");
                EndString.Text = "Ошибка, попробуйте ещё раз";
                return;
            }
            if (!int.TryParse(end.Text, out last))
            {
                MessageBox.Show("В строке конечного индекса не целое число");
                EndString.Text = "Ошибка, попробуйте ещё раз";
                return;
            }
            if (first == 0)
            {
                MessageBox.Show("Начальный индекс должен начинаться с единицы");
                EndString.Text = "Ошибка, попробуйте ещё раз";
                return;
            }
            if (first < 0)
            {
                MessageBox.Show("Начальный индекс не может быть отрицательным");
                EndString.Text = "Ошибка, попробуйте ещё раз";
                return;
            }
            if (last == 0)
            {
                MessageBox.Show("Конечный индекс должен начинаться с единицы");
                EndString.Text = "Ошибка, попробуйте ещё раз";
                return;
            }
            if (last < 0)
            {
                MessageBox.Show("Конечный индекс не может быть отрицательным");
                EndString.Text = "Ошибка, попробуйте ещё раз";
                return;
            }
            if (first > str.Count)
            {
                MessageBox.Show("Начальный индекс не может быть больше числа слов в предложении");
                EndString.Text = "Ошибка, попробуйте ещё раз";
                return;
            }
            if (last > str.Count)
            {
                MessageBox.Show("Конечный индекс не может быть больше числа слов в предложении");
                EndString.Text = "Ошибка, попробуйте ещё раз";
                return;
            }
            if (first > last)
            {
                MessageBox.Show("Начальный индекс не может быть больше конечного");
                EndString.Text = "Ошибка, попробуйте ещё раз";
                return;
            }
            var s = str.GetRange(first - 1, last - first + 1);
            str.RemoveRange(first - 1, last - first + 1);
            str.AddRange(s);
            EndString.Text = string.Join(' ', str);
        }
    }
}
