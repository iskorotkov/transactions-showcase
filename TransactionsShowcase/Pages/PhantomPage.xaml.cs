using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using TransactionsShowcase.Db;

namespace TransactionsShowcase.Pages
{
    /// <summary>
    ///     Interaction logic for PhantomPage.xaml
    /// </summary>
    public partial class PhantomPage : Page
    {
        private readonly EmpiresManager _empiresManager = new EmpiresManager();
        private readonly Random _rng = new Random();

        public PhantomPage()
        {
            InitializeComponent();

            TransactionControl.IsolationLevel = IsolationLevel.Serializable;
            TransactionControl.EmpiresManager = _empiresManager;

            EmpiresList.EmpiresManager = _empiresManager;

            SetEmpireNewName();
        }

        private void AddEmpire(object sender, RoutedEventArgs e)
        {
            var empire = new Empire
            {
                Name = EmpireNameBox.Text,
                Power = int.Parse(EmpirePowerBox.Text),
                GovernmentTypeId = int.Parse(GovIdBox.Text)
            };
            _empiresManager.Add(empire);

            SetAlliancePower(null, null);
            SetEmpireNewName();
        }

        private void SetEmpireNewName()
        {
            EmpireNameBox.Text = $"Empire #{_rng.Next(int.MaxValue)}";
        }

        private void SetAlliancePower(object sender, RoutedEventArgs e)
        {
            var power = _empiresManager.GetSumOfPowers();
            _empiresManager.SetOneAlliancePower(power);
        }

        private void GetAlliancePower(object sender, RoutedEventArgs e)
        {
            var power = _empiresManager.GetOneAlliancePower();
            AlliancePowerBlock.Text = power.ToString();
        }
    }
}
