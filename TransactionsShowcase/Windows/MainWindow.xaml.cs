using System;
using System.Windows;
using TransactionsShowcase.Db;

namespace TransactionsShowcase.Windows
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IDisposable
    {
        private readonly StarTypeManager _manager = new StarTypeManager();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckIfExists(object obj, RoutedEventArgs args)
        {
            try
            {
                IsExistsBox.IsChecked = _manager.Exists(NameBox.Text);
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.InnerException?.Message ?? e.Message);
            }
        }

        private void Create(object obj, RoutedEventArgs args)
        {
            try
            {
                _manager.Add(NameBox.Text);
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.InnerException?.Message ?? e.Message);
            }
        }

        public void Dispose()
        {
            _manager?.Dispose();
        }

        private void BeginTransaction(object sender, RoutedEventArgs e)
        {
            _manager.BeginTransaction();
        }
    }
}