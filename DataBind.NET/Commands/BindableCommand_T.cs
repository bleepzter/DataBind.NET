using System;
namespace DataBind.Bcl.Commands {

	/// <summary>
	/// Represents a command with a parameter.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class BindableCommand<T>: BindableCommandBase {

		private readonly Action<T> executeAction;
		private readonly Func<T, bool> canExecuteAction;

		/// <summary>
		/// Creates an instance of a command with a specific action.
		/// </summary>
		public BindableCommand(Action<T> executeAction) : this(executeAction, (x) => true) {

		}

		/// <summary>
		/// Creates an instance of a command with an action and the ability to turn on/off the execution of that action.
		/// </summary>
		/// <param name="executeAction"></param>
		/// <param name="canExecuteAction"></param>
		public BindableCommand(Action<T> executeAction, Func<T, bool> canExecuteAction) {
			this.executeAction = executeAction.ThrowIfNull(nameof(executeAction));
			this.canExecuteAction = canExecuteAction.ThrowIfNull(nameof(canExecuteAction));
		}

		/// <summary>
		/// Executes the command.
		/// </summary>
		public void Execute(T parameter) {
			this.executeAction(parameter);
		}

		/// <summary>
		/// Checks to see if the command can be executed.
		/// </summary>
		public bool CanExecute(T parameter) {
			return this.canExecuteAction(parameter);
		}

		protected override void ExecuteInternal(object parameter) {
			this.Execute((T)(parameter));
		}

		protected override bool CanExecuteInternal(object parameter) {
			return this.CanExecute((T)(parameter));
		}
	}

}