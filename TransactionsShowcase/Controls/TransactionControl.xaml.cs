using System.Data;
using System.Windows;
using System.Windows.Controls;
using TransactionsShowcase.Db;

namespace TransactionsShowcase.Controls
{
    /// <summary>
    ///     Interaction logic for TransactionControl.xaml
    /// </summary>
    public partial class TransactionControl : UserControl
    {
        public TransactionControl()
        {
            InitializeComponent();
        }

        public EmpiresManager EmpiresManager { get; set; }
        public IsolationLevel IsolationLevel { get; set; } = IsolationLevel.Unspecified;

        private void BeginTransaction(object sender, RoutedEventArgs e)
        {
            if (IsolationLevel != IsolationLevel.Unspecified)
            {
                EmpiresManager.BeginTransaction(IsolationLevel);
            }
            else
            {
                EmpiresManager.BeginTransaction();
            }
        }

        private void Commit(object sender, RoutedEventArgs e)
        {
            EmpiresManager.CommitTransaction();
        }
    }
}
