This project establishes that `BindTo` can sometimes cause Exceptions to be swallowed.

By choosing `Set DataContext with BindTo` => `Starting with non-null DataContext`, an exception will be swallowed.
![An image showing which File Menu option to choose](https://github.com/user-attachments/assets/5a7fe08b-400c-4126-a9c3-40fae5817861)

You can see the exception in the Debug Output:
```
PropertyBinderImplementation: x.DataContext Binding received an Exception! - System.Reflection.TargetInvocationException: Exception has been thrown by the target of an invocation.
 ---> System.InvalidOperationException: A TwoWay or OneWayToSource binding cannot work on the read-only property 'MyReadOnlyProperty' of type 'BindToSwallowsExceptions.ViewModels.MyViewModel'.
   at MS.Internal.Data.PropertyPathWorker.CheckReadOnly(Object item, Object info)
   at MS.Internal.Data.PropertyPathWorker.ReplaceItem(Int32 k, Object newO, Object parent)
   at MS.Internal.Data.PropertyPathWorker.UpdateSourceValueState(Int32 k, ICollectionView collectionView, Object newValue, Boolean isASubPropertyChange)
   at MS.Internal.Data.ClrBindingWorker.AttachDataItem()
   at System.Windows.Data.BindingExpression.Activate(Object item)
   at System.Windows.Data.BindingExpression.HandlePropertyInvalidation(DependencyObject d, DependencyPropertyChangedEventArgs args)
   at System.Windows.Data.BindingExpression.OnPropertyInvalidation(DependencyObject d, DependencyPropertyChangedEventArgs args)
   at System.Windows.DependentList.InvalidateDependents(DependencyObject source, DependencyPropertyChangedEventArgs sourceArgs)
   at System.Windows.DependencyObject.NotifyPropertyChange(DependencyPropertyChangedEventArgs args)
   at System.Windows.DependencyObject.UpdateEffectiveValue(EntryIndex entryIndex, DependencyProperty dp, PropertyMetadata metadata, EffectiveValueEntry oldEntry, EffectiveValueEntry& newEntry, Boolean coerceWithDeferredReference, Boolean coerceWithCurrentValue, OperationType operationType)
   at System.Windows.TreeWalkHelper.OnInheritablePropertyChanged(DependencyObject d, InheritablePropertyChangeInfo info, Boolean visitedViaVisualTree)
   at System.Windows.DescendentsWalker`1._VisitNode(DependencyObject d, Boolean visitedViaVisualTree)
   at System.Windows.DescendentsWalker`1.WalkLogicalChildren(FrameworkElement feParent, FrameworkContentElement fceParent, IEnumerator logicalChildren)
   at System.Windows.DescendentsWalker`1.WalkFrameworkElementLogicalThenVisualChildren(FrameworkElement feParent, Boolean hasLogicalChildren)
   at System.Windows.DescendentsWalker`1.IterateChildren(DependencyObject d)
   at System.Windows.DescendentsWalker`1._VisitNode(DependencyObject d, Boolean visitedViaVisualTree)
   at System.Windows.DescendentsWalker`1.WalkLogicalChildren(FrameworkElement feParent, FrameworkContentElement fceParent, IEnumerator logicalChildren)
   at System.Windows.DescendentsWalker`1.WalkFrameworkElementLogicalThenVisualChildren(FrameworkElement feParent, Boolean hasLogicalChildren)
   at System.Windows.DescendentsWalker`1.IterateChildren(DependencyObject d)
   at System.Windows.DescendentsWalker`1.StartWalk(DependencyObject startNode, Boolean skipStartNode)
   at System.Windows.FrameworkElement.OnPropertyChanged(DependencyPropertyChangedEventArgs e)
   at System.Windows.DependencyObject.NotifyPropertyChange(DependencyPropertyChangedEventArgs args)
   at System.Windows.DependencyObject.UpdateEffectiveValue(EntryIndex entryIndex, DependencyProperty dp, PropertyMetadata metadata, EffectiveValueEntry oldEntry, EffectiveValueEntry& newEntry, Boolean coerceWithDeferredReference, Boolean coerceWithCurrentValue, OperationType operationType)
   at System.Windows.DependencyObject.SetValueCommon(DependencyProperty dp, Object value, PropertyMetadata metadata, Boolean coerceWithDeferredReference, Boolean coerceWithCurrentValue, OperationType operationType, Boolean isInternal)
   at System.Windows.DependencyObject.SetValue(DependencyProperty dp, Object value)
   at System.RuntimeMethodHandle.InvokeMethod(Object target, Void** arguments, Signature sig, Boolean isConstructor)
   at System.Reflection.MethodBaseInvoker.InvokeDirectByRefWithFewArgs(Object obj, Span`1 copyOfArgs, BindingFlags invokeAttr)
   --- End of inner exception stack trace ---
   at System.Reflection.MethodBaseInvoker.InvokeDirectByRefWithFewArgs(Object obj, Span`1 copyOfArgs, BindingFlags invokeAttr)
   at System.Reflection.RuntimePropertyInfo.SetValue(Object obj, Object value, Object[] index)
   at ReactiveUI.PropertyBinderImplementation.<>c__DisplayClass11_0`3.<BindToDirect>g__SetThenGet|0(Object paramTarget, Object paramValue, Object[] paramParams) in c:\temp\releaser\ReactiveUI\src\ReactiveUI\Bindings\Property\PropertyBinderImplementation.cs:line 240
   at ReactiveUI.PropertyBinderImplementation.<>c__DisplayClass11_0`3.<BindToDirect>b__1(TObs x) in c:\temp\releaser\ReactiveUI\src\ReactiveUI\Bindings\Property\PropertyBinderImplementation.cs:line 252
   at System.Reactive.Linq.ObservableImpl.Select`2.Selector._.OnNext(TSource value)
```

In a more complicated View, this can leave the View in a broken state, where only some logical children would have the new `DataContext` propagated. Other logical children would retain the previous `DataContext`.

All other options will not swallow the exception. The exception will fire the Dispatcher's `UnhandledException` event.
![An image showing that the Dispatcher's UnhandledException event is fired.](https://github.com/user-attachments/assets/c2bf8238-2825-4ef4-b470-4f4b36e9b70f)

