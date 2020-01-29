using System.Windows;
namespace DataBind.Bcl.Converters {

	/// <summary>
	/// Converts a boolean value to a visibility but inverted.
	/// </summary>
	public class BooleanToVisibilityInverterConverter : BooleanConverterBase<Visibility> {

		/// <summary>
		/// Converts a boolean value to a visibility but inverted.
		/// </summary>
		public BooleanToVisibilityInverterConverter()
			: base(trueValue: Visibility.Visible, falseValue: Visibility.Collapsed, isInverted: true) {

		}
	}

}