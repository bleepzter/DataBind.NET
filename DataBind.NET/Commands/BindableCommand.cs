using System;
using System.Threading;
using System.Windows.Input;
// ReSharper disable ArrangeAccessorOwnerBody
// ReSharper disable InconsistentNaming
namespace DataBind.Bcl.Commands {

	/// <summary>
	/// Represents a base class for implementations of <see cref="ICommand"/>
	/// </summary>
	public abstract class BindableCommandBase : BindableBase, ICommand {

		private readonly SynchronizationContext synchronizationContext;
		private event EventHandler canExecuteChanged;

		/// <summary>
		/// Represents a base class for implementations of <see cref="ICommand"/>
		/// </summary>
		protected BindableCommandBase() {
			this.synchronizationContext = SynchronizationContext.Current;
		}

		/// <summary>
		/// An event that notifies subscribers that the command's can execute condition has changed.
		/// </summary>
		event EventHandler ICommand.CanExecuteChanged {
			add { this.canExecuteChanged += value; }
			remove { this.canExecuteChanged -= value; }
		}

		/// <summary>
		/// Handle the internal invocation of <see cref="ICommand.Execute(object)"/>
		/// </summary>
		/// <param name="parameter">Command Parameter</param>
		protected abstract void Execute(object parameter);

		/// <summary>
		/// Handle the internal invocation of <see cref="ICommand.CanExecute(object)"/>
		/// </summary>
		/// <param name="parameter"></param>
		/// <returns><see langword="true"/> if the Command Can Execute, otherwise <see langword="false" /></returns>
		protected abstract bool CanExecute(object parameter);

		/// <summary>Defines the method that determines whether the command can execute in its current state.</summary>
		/// <param name="parameter">Data used by the command.If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
		/// <returns>
		/// <see langword="true" /> if this command can be executed; otherwise, <see langword="false" />.</returns>
		bool ICommand.CanExecute(object parameter) {
			throw new NotImplementedException();
		}

		/// <summary>Defines the method to be called when the command is invoked.</summary>
		/// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
		void ICommand.Execute(object parameter) {
			throw new NotImplementedException();
		}

		/// <summary>
		/// Raises <see cref="ICommand.CanExecuteChanged"/> so every command invoker
		/// can requery to check if the command can execute.
		/// </summary>
		/// <remarks>Note that this will trigger the execution of <see cref="ICommand.CanExecuteChanged"/> once for each invoker.</remarks>
		public void RaiseCanExecuteChanged() {
			this.RaiseCanExecuteChangedInternal();
		}

		/// <summary>
		/// Raises <see cref="ICommand.CanExecuteChanged"/> so every 
		/// command invoker can requery <see cref="ICommand.CanExecute"/>.
		/// </summary>
		private void RaiseCanExecuteChangedInternal() {
			
			var handler = this.canExecuteChanged;

			if (handler == null) {
				return;
			}

			if (this.synchronizationContext != null && this.synchronizationContext != SynchronizationContext.Current) {
				this.synchronizationContext.Post((o) => handler.Invoke(this, EventArgs.Empty), null);
			}
			else {
				handler.Invoke(this, EventArgs.Empty);
			}
		}
	}

}