using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using TransactionsShowcase.Db;
using TransactionsShowcase.Utils;

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
            MessageOnException.Execute(() =>
            {
                foreach (var item in EmpiresList.EmpireListView.Items)
                {
                    var empire = (Empire) item;
                    _empiresManager.SetPower(empire.Id, empire.Power + Power);
                }
            });
        }
    }
}
