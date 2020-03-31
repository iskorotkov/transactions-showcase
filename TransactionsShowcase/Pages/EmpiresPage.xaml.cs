using System;
using System.Windows;
using System.Windows.Controls;
using TransactionsShowcase.Db;

namespace TransactionsShowcase.Pages
{
    /// <summary>
    ///     Interaction logic for EmpiresPage.xaml
    /// </summary>
    public partial class EmpiresPage : Page
    {
        private readonly EmpiresManager _empiresManager = new EmpiresManager();

        public EmpiresPage()
        {
            InitializeComponent();
        }

        private void CreateEmpire(object sender, RoutedEventArgs e)
        {
            _empiresManager.Add(NameBox.Text, RulerBox.Text, 1, 100);
        }
    }
}