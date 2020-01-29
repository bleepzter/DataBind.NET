using System.Windows;
namespace DataBind.Bcl.Converters {

	/// <summary>
	/// Converts a boolean value to a visibility.
	/// </summary>
	public class BooleanToVisibilityConverter : BooleanConverterBase<Visibility> {

		/// <summary>
		/// Converts a boolean value to a visibility.
		/// </summary>
		public BooleanToVisibilityConverter()
			: base(trueValue: Visibility.Visible, falseValue: Visibility.Collapsed, isInverted: false) {

		}
	}

}