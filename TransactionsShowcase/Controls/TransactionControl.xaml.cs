using System.Data;
using System.Windows;
using System.Windows.Controls;
using TransactionsShowcase.Db;
using TransactionsShowcase.Utils;

namespace TransactionsShowcase.Controls
{
    /// <summary>
    ///     Interaction logic for TransactionControl.xaml
    /// </summary>
    public partial class TransactionControl : UserControl
    {
        private IsolationLevel _isolationLevel = IsolationLevel.Unspecified;

        public TransactionControl()
        {
            InitializeComponent();

            IsolationLevelBox.Items.Add(IsolationLevel.ReadUncommitted);
            IsolationLevelBox.Items.Add(IsolationLevel.ReadCommitted);
            IsolationLevelBox.Items.Add(IsolationLevel.RepeatableRead);
            IsolationLevelBox.Items.Add(IsolationLevel.Serializable);
        }

        public EmpiresManager EmpiresManager { get; set; }

        public IsolationLevel IsolationLevel
        {
            get => _isolationLevel;
            set
            {
                _isolationLevel = value;
                IsolationLevelBox.SelectedItem = value;
            }
        }

        private void BeginTransaction(object sender, RoutedEventArgs e)
        {
            MessageOnException.Execute(() =>
            {
                if (IsolationLevel != IsolationLevel.Unspecified)
                {
                    EmpiresManager.BeginTransaction(IsolationLevel);
                }
                else
                {
                    EmpiresManager.BeginTransaction();
                }
            });
        }

        private void Commit(object sender, RoutedEventArgs e)
        {
            MessageOnException.Execute(() => EmpiresManager.CommitTransaction());
        }

        private void OnIsolationLevelSelected(object sender, SelectionChangedEventArgs e)
        {
            _isolationLevel = (IsolationLevel) IsolationLevelBox.SelectedItem;
        }
    }
}
