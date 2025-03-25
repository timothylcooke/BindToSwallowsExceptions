namespace BindToSwallowsExceptions.ViewModels;

public class MyViewModel
{
    public MyViewModel()
    {
        MyReadOnlyProperty = "MyReadOnlyPropertyValue";
    }

    public string MyReadOnlyProperty { get; private set; }
}
