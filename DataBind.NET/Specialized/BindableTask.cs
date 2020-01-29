using System.Threading.Tasks;
// ReSharper disable ArrangeAccessorOwnerBody

namespace DataBind.Bcl.Specialized {

	/// <summary>
	/// A task that could be binded to 
	/// </summary>
	public class BindableTask : BindableTaskBase {

		/// <summary>
		/// A task that could be binded to 
		/// </summary>
		/// <param name="task"></param>
		public BindableTask(Task task) : base(task) {

		}
	}

}