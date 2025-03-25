using BindToSwallowsExceptions.ViewModels;
using BindToSwallowsExceptions.Views;
using ReactiveUI;
using System.Reactive;
using System.Windows;
using System.Windows.Threading;

namespace BindToSwallowsExceptions
{
    public partial class MainWindow : Window
    {
        static MainWindow()
        {
            RxApp.DefaultExceptionHandler = Observer.Create<Exception>(ex => MessageBox.Show(ex.ToString(), "RxApp.DefaultExceptionHandler fired"));

            Dispatcher.CurrentDispatcher.UnhandledException += (_, e) => MessageBox.Show(e.Exception.ToString(), "Dispatcher.CurrentDispatcher.UnhandledException fired");
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void JustSetDataContext_StartWithNull_Click(object sender, RoutedEventArgs e)
        {
            MyContentControl.Content = new JustSetDataContextView(null) { ViewModel = new MyViewModel() };
        }
        private void JustSetDataContext_StartWithNotNull_Click(object sender, RoutedEventArgs e)
        {
            MyContentControl.Content = new JustSetDataContextView(new object()) { ViewModel = new MyViewModel() };
        }

        private void SetDataContextInDo_StartWithNull_Click(object sender, RoutedEventArgs e)
        {
            MyContentControl.Content = new SetDataContextInDoView(null) { ViewModel = new MyViewModel() };
        }
        private void SetDataContextInDo_StartWithNotNull_Click(object sender, RoutedEventArgs e)
        {
            MyContentControl.Content = new SetDataContextInDoView(new object()) { ViewModel = new MyViewModel() };
        }

        private void SetDataContextWithBindTo_StartWithNull_Click(object sender, RoutedEventArgs e)
        {
            MyContentControl.Content = new SetDataContextWithBindToView(null) { ViewModel = new MyViewModel() };
        }
        private void SetDataContextWithBindTo_StartWithNotNull_Click(object sender, RoutedEventArgs e)
        {
            MyContentControl.Content = new SetDataContextWithBindToView(new object()) { ViewModel = new MyViewModel() };
        }
    }
}