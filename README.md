# DataBind.NET

An MVVM framework for building WPF/UWP applications.

## Usage

### BindableBase

The `BindableBase` class is the base class describing view models within the application.
It provides a basic implementation of the `INotifyPropertyChanged` event used to notify 
 subscribers (views) bound to the view model that the view model has changed. 

 To create your own view models, one has to simply inherit from the BindableBase as shown
 in the example bellow:
 
 ```csharp

 public class ViewModelExample : BindableBase {
 
	private string name;

	public string Name {
		get { return this.name; }
		set { base.SetValue(ref this.name, value); }  
	}

 }
 ```

 The line `base.SetValue(ref this.name, value)` updates the value of the private field `name` and 
 will also raise the `INotifyPropertyChanged` event.

 ### BindableTask

 The `BindableTask` class is a wrapper around `System.Threading.Task` or `System.Threading.Task<T>`
 so that the UI can databound to a long running operation (the task) and be able to be notified when the
 task has finished its execution. 
 
 For the purpose - a `BindableTask` or `BindableTask<T>` expose the following properties, for each of which
 the `INotifiedPropertyChanged` event is reaised whenever the underlying task has completed depending on
 how the task has actually completed:

* Status
* IsCompleted
* IsNotCompleted
* IsCanceled
* IsFaulted
* Exception
* IsSuccessfullyCompleted

In the case of `BindableTask<T>` the `INotifyPropertyChanged` is also raised for the `Result` property.

