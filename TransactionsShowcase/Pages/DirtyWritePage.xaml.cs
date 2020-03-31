using System.Data;
using System.Windows;
using System.Windows.Controls;
using TransactionsShowcase.Db;

namespace TransactionsShowcase.Pages
{
    /// <summary>
    ///     Interaction logic for FuzzyReadPage.xaml
    /// </summary>
    public partial class DirtyWritePage : Page
    {
        private readonly EmpiresManager _empiresManager = new EmpiresManager();

        private int Power => int.Parse(PowerBox.Text);
        private int GovId => int.Parse(GovIdBox.Text);

        public DirtyWritePage()
        {
            InitializeComponent();
        }

        private void FetchEmpires(object sender, RoutedEventArgs e)
        {
            EmpiresList.Items.Clear();
            foreach (var empire in _empiresManager.GetEmpires())
            {
                EmpiresList.Items.Add(empire);
            }
        }

        private void BeginTransaction(object sender, RoutedEventArgs e)
        {
            _empiresManager.BeginTransaction(IsolationLevel.ReadUncommitted);
        }

        private void Commit(object sender, RoutedEventArgs e)
        {
            _empiresManager.CommitTransaction();
        }

        private void UpdatePower(object sender, RoutedEventArgs e)
        {
            _empiresManager.SetPower(Power);
        }

        private void UpdateGovId(object sender, RoutedEventArgs e)
        {
            _empiresManager.SetGovId(GovId);
        }
    }
}