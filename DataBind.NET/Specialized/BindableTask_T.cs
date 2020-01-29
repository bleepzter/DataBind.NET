using System;
using System.Threading.Tasks;
// ReSharper disable ArrangeAccessorOwnerBody
namespace DataBind.Specialized {

	/// <summary>
	/// A task with result that could be binded to 
	/// </summary>
	public class BindableTask<TResult> : BindableTaskBase {

		/// <summary>
		/// A task with result that could be binded to 
		/// </summary>
		/// <param name="task"></param>
		public BindableTask(Task<TResult> task) : base(task: task) {

		}

		/// <summary>
		/// Gets the result of the task
		/// </summary>
		public TResult Result {
			get {
				return (this.task.Status == TaskStatus.RanToCompletion)
					? ((Task<TResult>)this.task).Result
					: default(TResult);
			}
		}

		/// <summary>
		/// Raises the <see cref="INotifyPropertyChanged"/> event when the task is completed for the <see cref="Result"/> property.
		/// </summary>
		protected override void OnTaskSuccess() {
			this.RaisePropertyChanged(nameof(this.Result));
		}
	}

}