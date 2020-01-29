namespace DataBind.Bcl.Converters {

	/// <summary>
	/// Converts a boolean value to its opposite.
	/// </summary>
	public class BooleanToBooleanInverterConverter : BooleanConverterBase<bool> {

		/// <summary>
		/// Converts a boolean value to its opposite.
		/// </summary>
		public BooleanToBooleanInverterConverter()
			: base(trueValue:true, falseValue:false, isInverted:true) {

		}
	}

}