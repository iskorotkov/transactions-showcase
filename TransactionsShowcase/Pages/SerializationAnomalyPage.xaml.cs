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
        private int _powerForWeakest;
        private int _powerForStrongest;

        public SerializationAnomalyPage()
        {
            InitializeComponent();

            TransactionControl.IsolationLevel = IsolationLevel.Serializable;
            TransactionControl.EmpiresManager = _empiresManager;

            EmpiresList.EmpiresManager = _empiresManager;
        }

        private void SetWeakest(object sender, RoutedEventArgs e)
        {
            _empiresManager.SetWeakestPower(_powerForWeakest);
        }

        private void SetStrongest(object sender, RoutedEventArgs e)
        {
            _empiresManager.SetStrongestPower(_powerForStrongest);
        }

        private void CalculatePowerForWeakest(object sender, RoutedEventArgs e)
        {
            _powerForWeakest = _empiresManager.GetMaxPower() * 2;
            PowerForWeakestBlock.Text = _powerForWeakest.ToString();
        }

        private void CalculatePowerForStrongest(object sender, RoutedEventArgs e)
        {
            _powerForStrongest = _empiresManager.GetMinPower() / 2;
            PowerForStrongestBlock.Text = _powerForStrongest.ToString();
        }
    }
}
