using System;
using System.Windows;

namespace TransactionsShowcase.Utils
{
    public static class MessageOnException
    {
        public static void Execute(Action fn)
        {
            try
            {
                fn?.Invoke();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.InnerException?.Message ?? exception.Message);
            }
        }
    }
}
