using System;
using System.Threading.Tasks;

namespace DataBind.Specialized {

	/// <summary>
	/// Represents a task that could be binded to 
	/// </summary>
	public interface IBindableTask {

		/// <summary>
		/// Gets the task status.
		/// </summary>
		TaskStatus Status { get; }

		/// <summary>
		/// Gets a flag denoting if the task is completed.
		/// </summary>
		bool IsCompleted { get; }

		/// <summary>
		/// Gets a flag denoting if the task is not completed.
		/// </summary>
		bool IsNotCompleted { get; }

		/// <summary>
		/// Gets a flag denoting if the task has successfully completed.
		/// </summary>
		bool IsSuccessfullyCompleted { get; }

		/// <summary>
		/// Gets a flag denoting if the task is cancelled.
		/// </summary>
		bool IsCanceled { get; }

		/// <summary>
		/// Gets a flag denoting if the task has an error.
		/// </summary>
		bool IsFaulted { get; }

		/// <summary>
		/// Gets the execution exception of the task.
		/// </summary>
		AggregateException Exception { get; }
	}

}