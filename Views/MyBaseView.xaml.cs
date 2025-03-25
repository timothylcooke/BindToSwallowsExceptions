using BindToSwallowsExceptions.ViewModels;
using ReactiveUI;

namespace BindToSwallowsExceptions.Views;

public partial class MyBaseView : ReactiveUserControl<MyViewModel>
{
    public MyBaseView()
    {
        InitializeComponent();

        ClassNameTextBlock.Text = GetType().Name;
    }
}

