using ReactiveUI;
using System.Reactive.Linq;

namespace BindToSwallowsExceptions.Views;

public class JustSetDataContextView : MyBaseView
{
    public JustSetDataContextView(object? startingDataContext)
        : base(startingDataContext)
    {
        this.WhenActivated(_ =>
        {
            // The exception will throw.
            DataContext = ViewModel;
        });
    }
}

public class SetDataContextInDoView : MyBaseView
{
    public SetDataContextInDoView(object? startingDataContext)
        : base(startingDataContext)
    {
        this.WhenActivated(d =>
        {
            // The exception will throw.
            d(this.WhenAnyValue(x => x.ViewModel).DistinctUntilChanged().Do(x => DataContext = x).Subscribe());
        });
    }
}

public class SetDataContextWithBindToView : MyBaseView
{
    public SetDataContextWithBindToView(object? startingDataContext)
        : base(startingDataContext)
    {
        this.WhenActivated(d =>
        {
            // The exception will:
            //  - throw if startingDataContext is null
            //  - be swallowed if startingDataContext is not null
            d(this.WhenAnyValue(x => x.ViewModel).DistinctUntilChanged().BindTo(this, x => x.DataContext));
        });
    }
}
