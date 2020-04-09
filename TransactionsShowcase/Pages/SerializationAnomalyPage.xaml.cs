using System.Data;
using System.Windows;
using System.Windows.Controls;
using TransactionsShowcase.Db;

namespace TransactionsShowcase.Pages
{
    /// <summary>
    ///     Interaction logic for SerializationAnomalyPage.xaml
    /// </summary>
    public partial class SerializationAnomalyPage : Page
    {
        private readonly EmpiresManager _empiresManager = new EmpiresManager();

        public SerializationAnomalyPage()
        {
            InitializeComponent();

            TransactionControl.IsolationLevel = IsolationLevel.Serializable;
            TransactionControl.EmpiresManager = _empiresManager;

            EmpiresList.EmpiresManager = _empiresManager;
        }

        private void SetWeakest(object sender, RoutedEventArgs e)
        {
            var maxPower = _empiresManager.GetMaxPower();
            _empiresManager.SetWeakestPower(maxPower * 2);
        }

        private void SetStrongest(object sender, RoutedEventArgs e)
        {
            var minPower = _empiresManager.GetMinPower();
            _empiresManager.SetStrongestPower(minPower / 2);
        }
    }
}
