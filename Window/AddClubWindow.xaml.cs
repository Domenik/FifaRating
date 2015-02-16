using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FifaRating
{
    /// <summary>
    /// Логика взаимодействия для AddClubWindow.xaml
    /// </summary>
    public partial class AddClubWindow : Window
    {
        public AddClubWindow()
        {
            InitializeComponent();
        }

        private void AddClubToList(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
