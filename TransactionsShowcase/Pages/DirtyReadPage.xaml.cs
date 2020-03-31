﻿using System.Data;
using System.Windows;
using System.Windows.Controls;
using TransactionsShowcase.Db;

namespace TransactionsShowcase.Pages
{
    /// <summary>
    ///     Interaction logic for DirtyReadPage.xaml
    /// </summary>
    public partial class DirtyReadPage : Page
    {
        private readonly EmpiresManager _empiresManager = new EmpiresManager();
        private int Amount => int.Parse(AmountBox.Text);

        public DirtyReadPage()
        {
            InitializeComponent();

            TransControl.EmpiresManager = _empiresManager;
            TransControl.IsolationLevel = IsolationLevel.ReadCommitted;

            EmpiresList.EmpiresManager = _empiresManager;

            foreach (var empire in _empiresManager.GetEmpires())
            {
                FromEmpireBox.Items.Add(empire);
                ToEmpireBox.Items.Add(empire);
            }
        }

        private void ReducePower(object sender, RoutedEventArgs e)
        {
            var empire = (Empires) FromEmpireBox.SelectedItem;
            _empiresManager.SetPower(empire.Id, empire.Power - Amount);
        }

        private void IncreasePower(object sender, RoutedEventArgs e)
        {
            var empire = (Empires) ToEmpireBox.SelectedItem;
            _empiresManager.SetPower(empire.Id, empire.Power + Amount);
        }

        private void FetchSum(object sender, RoutedEventArgs e)
        {
            SumOfPowersBlock.Text = _empiresManager.GetSumOfPowers().ToString();
        }
    }
}
