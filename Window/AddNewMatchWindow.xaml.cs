using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using MahApps.Metro.Controls;

namespace FifaRating
{
    /// <summary>
    /// Логика взаимодействия для AddNewMatchWindow.xaml
    /// </summary>
    public partial class AddNewMatchWindow : MetroWindow
    {
        public AddNewMatchWindow(ViewModelAddNewMatch viewModelAddNewMatch)
        {
            DataContext = viewModelAddNewMatch;
            InitializeComponent();
        }

        private void AddMatch(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
