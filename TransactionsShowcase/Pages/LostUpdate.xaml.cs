using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using TransactionsShowcase.Db;

namespace TransactionsShowcase.Pages
{
    /// <summary>
    ///     Interaction logic for LostUpdate.xaml
    /// </summary>
    public partial class LostUpdate : Page
    {
        private readonly EmpiresManager _empiresManager = new EmpiresManager();
        private int Power => int.Parse(AmountBox.Text);

        public LostUpdate()
        {
            InitializeComponent();

            TransactionControl.EmpiresManager = _empiresManager;
            TransactionControl.IsolationLevel = IsolationLevel.RepeatableRead;

            EmpiresList.EmpiresManager = _empiresManager;
        }

        private void IncreasePower(object sender, RoutedEventArgs e)
        {
            try
            {
                _empiresManager.AddPower(Power);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.InnerException?.Message ?? exception.Message);
            }
        }
    }
}
