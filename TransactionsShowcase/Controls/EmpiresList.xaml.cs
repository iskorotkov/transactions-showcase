using System.Windows;
using System.Windows.Controls;
using TransactionsShowcase.Db;

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
            foreach (var empire in EmpiresManager.GetEmpires())
            {
                EmpireListView.Items.Add(empire);
            }
        }
    }
}
