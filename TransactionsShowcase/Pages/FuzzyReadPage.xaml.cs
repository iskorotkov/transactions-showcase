using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using TransactionsShowcase.Db;
using TransactionsShowcase.Utils;

namespace TransactionsShowcase.Pages
{
    /// <summary>
    ///     Interaction logic for FuzzyReadPage.xaml
    /// </summary>
    public partial class FuzzyReadPage : Page
    {
        private readonly EmpiresManager _empiresManager = new EmpiresManager();
        private int? _firstPower;
        private int? _secondPower;

        public FuzzyReadPage()
        {
            InitializeComponent();

            TransactionControl.EmpiresManager = _empiresManager;
            TransactionControl.IsolationLevel = IsolationLevel.RepeatableRead;

            Reload(null, null);
        }

        private void ConfirmFirst(object sender, RoutedEventArgs e)
        {
            var empire = (Empire) FirstEmpireBox.SelectedItem;
            _firstPower = empire?.Power;
            FirstPowerBlock.Text = $"Power = {_firstPower}";
            ShowResult();
        }

        private void ConfirmSecond(object sender, RoutedEventArgs e)
        {
            var empire = (Empire) SecondEmpireBox.SelectedItem;
            _secondPower = empire?.Power;
            SecondPowerBlock.Text = $"Power = {_secondPower}";
            ShowResult();
        }

        private void ShowResult()
        {
            if (_firstPower == null || _secondPower == null)
            {
                return;
            }

            if (_firstPower > _secondPower)
            {
                OutputBlock.Text = $"First empire is stronger by {_firstPower - _secondPower} points";
            }
            else if (_secondPower > _firstPower)
            {
                OutputBlock.Text = $"Second empire is stronger by {_secondPower - _firstPower} points";
            }
            else
            {
                OutputBlock.Text = "Powers are equal";
            }
        }


        private void Reload(object sender, RoutedEventArgs e)
        {
            FirstEmpireBox.Items.Clear();
            SecondEmpireBox.Items.Clear();
            MessageOnException.Execute(() =>
            {
                foreach (var empire in _empiresManager.GetEmpires())
                {
                    FirstEmpireBox.Items.Add(empire);
                    SecondEmpireBox.Items.Add(empire);
                }
            });
        }
    }
}
