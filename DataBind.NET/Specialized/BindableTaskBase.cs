using System;
using System.Threading.Tasks;
using System.ComponentModel;
// ReSharper disable ArrangeAccessorOwnerBody


namespace DataBind.Specialized {

	public abstract class BindableTaskBase : BindableBase, IBindableTask {

		protected readonly Task task;

		protected BindableTaskBase(Task task) {
			this.task = task;
			var watch = this.WatchTaskAsync(this.task);
		}

		/// <summary>
		/// Gets the task status.
		/// </summary>
		public TaskStatus Status {
			get { return this.task.Status; }
		}

		/// <summary>
		/// Gets a flag denoting if the task is completed.
		/// </summary>
		public bool IsCompleted {
			get { return this.task.IsCompleted; }
		}

		/// <summary>
		/// Gets a flag denoting if the task is not completed.
		/// </summary>
		public bool IsNotCompleted {
			get { return !this.task.IsCompleted; }
		}

		/// <summary>
		/// Gets a flag denoting if the task has successfully completed.
		/// </summary>
		public bool IsSuccessfullyCompleted {
			get { return this.task.Status == TaskStatus.RanToCompletion; }
		}

		/// <summary>
		/// Gets a flag denoting if the task is cancelled.
		/// </summary>
		public bool IsCanceled {
			get { return this.task.IsCanceled; }
		}

		/// <summary>
		/// Gets a flag denoting if the task has an error.
		/// </summary>
		public bool IsFaulted {
			get { return this.task.IsFaulted; }
		}

		/// <summary>
		/// Gets the execution exception of the task.
		/// </summary>
		public AggregateException Exception {
			get { return this.task.Exception; }
		}

		protected virtual void OnTaskSuccess() {

		}

		private async Task WatchTaskAsync(Task operation) {
			try {
				await operation;
			}
			catch { }

			this.RaisePropertyChanged(nameof(this.Status));
			this.RaisePropertyChanged(nameof(this.IsCompleted));
			this.RaisePropertyChanged(nameof(this.IsNotCompleted));

			if (operation.IsCanceled) {
				this.RaisePropertyChanged(nameof(this.IsCanceled));
			}
			else if (operation.IsFaulted) {
				this.RaisePropertyChanged(nameof(this.IsFaulted));
				this.RaisePropertyChanged(nameof(this.Exception));
			}
			else {
				this.RaisePropertyChanged(nameof(this.IsSuccessfullyCompleted));
				this.OnTaskSuccess();
			}
		}
	}

}