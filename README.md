# DataBind.NET

An MVVM framework for building WPF/UWP applications.

## Usage

### BindableBase

The `BindableBase` class is the base class describing view models within the application.
It provides a basic implementation of the `INotifyPropertyChanged` event used to notify 
 subscribers (views) bound to the view model that the view model has changed. 

 To create your own view models, one has to simply inherit from the BindableBase as follows:
 
 ```csharp

 public class ViewModelExample : BindableBase {
 
	private string name;

	public string Name {
		get { return this.name; }
		set { base.SetValue(ref this.name, value); }  /* This line will set the value of 'name' and also raise the INotifyPropertyChanged event. */
	}

 }
 ```

