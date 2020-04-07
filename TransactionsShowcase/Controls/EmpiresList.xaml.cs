using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TransactionsShowcase.Db;
using TransactionsShowcase.Utils;

namespace TransactionsShowcase.Controls
{
    /// <summary>
    ///     Interaction logic for EmpiresList.xaml
    /// </summary>
    public partial class EmpiresList : UserControl
    {
        public EmpiresManager EmpiresManager { get; set; }

        public EmpiresList()
        {
            InitializeComponent();
        }

        private void FetchEmpires(object sender, RoutedEventArgs e)
        {
            EmpireListView.Items.Clear();
            MessageOnException.Execute(() =>
            {
                foreach (var empire in EmpiresManager.GetEmpires())
                {
                    EmpireListView.Items.Add(empire);
                }
            });
        }
    }
}
