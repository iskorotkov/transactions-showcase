using System.Windows;
using System.Windows.Controls;
using TransactionsShowcase.Db;

namespace TransactionsShowcase.Pages
{
    /// <summary>
    ///     Interaction logic for FuzzyReadPage.xaml
    /// </summary>
    public partial class FuzzyReadPage : Page
    {
        private readonly EmpiresManager _empiresManager = new EmpiresManager();

        public FuzzyReadPage()
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

        private void FetchEmpiresWithRuler(object sender, RoutedEventArgs e)
        {
            EmpiresWithRulerList.Items.Clear();
            foreach (var empire in _empiresManager.GetEmpiresWithRuler())
            {
                EmpiresWithRulerList.Items.Add(empire);
            }
        }

        private void BeginTransaction(object sender, RoutedEventArgs e)
        {
            _empiresManager.BeginTransaction();
        }

        private void Commit(object sender, RoutedEventArgs e)
        {
            _empiresManager.CommitTransaction();
        }
    }
}