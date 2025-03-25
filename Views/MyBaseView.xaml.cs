using BindToSwallowsExceptions.ViewModels;
using ReactiveUI;

namespace BindToSwallowsExceptions.Views;

public partial class MyBaseView : ReactiveUserControl<MyViewModel>
{
    public MyBaseView(object? startingDataContext)
    {
        InitializeComponent();
        DataContext = startingDataContext;

        ClassName.Text = GetType().Name;
        OriginalStatus.Text = startingDataContext is null ? "null" : "not null";
    }
}

