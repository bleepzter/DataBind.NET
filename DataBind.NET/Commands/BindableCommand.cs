﻿using System;
using Accessibility;
namespace DataBind.Bcl.Commands {

	/// <summary>
	/// Represents a command.
	/// </summary>
	public class BindableCommand : BindableCommandBase {

		private readonly Action executeAction;
		private readonly Func<bool> canExecuteAction;

		/// <summary>
		/// Creates an instance of a command with a specific action.
		/// </summary>
		/// <param name="executeAction"></param>
		public BindableCommand(Action executeAction) : this(executeAction, () => true) {

		}

		/// <summary>
		/// Creates an instance of a command with an action and the ability to turn on/off the execution of that action.
		/// </summary>
		/// <param name="executeAction"></param>
		/// <param name="canExecuteAction"></param>
		public BindableCommand(Action executeAction, Func<bool> canExecuteAction) {
			this.executeAction = executeAction.ThrowIfNull(nameof(executeAction));
			this.canExecuteAction = canExecuteAction.ThrowIfNull(nameof(canExecuteAction));
		}

		/// <summary>
		/// Executes the command.
		/// </summary>
		public void Execute() {
			this.executeAction();
		}

		/// <summary>
		/// Checks to see if the command can be executed.
		/// </summary>
		/// <returns></returns>
		public bool CanExecute() {
			return this.canExecuteAction();
		}

		protected override void ExecuteInternal(object parameter) {
			this.Execute();
		}

		protected override bool CanExecuteInternal(object parameter) {
			return this.CanExecute();
		}
	}

}