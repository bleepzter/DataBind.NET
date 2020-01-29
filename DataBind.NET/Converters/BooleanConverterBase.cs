using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
namespace DataBind.Bcl.Converters {

	/// <summary>
	/// A boolean converter
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class BooleanConverterBase<T> : DependencyObject, IValueConverter {

		private readonly IEqualityComparer<T> comparer;

		public BooleanConverterBase(T trueValue, T falseValue, bool isInverted)
			: base() {

			this.comparer = EqualityComparer<T>.Default;
			this.TrueValue = trueValue;
			this.FalseValue = falseValue;
			this.IsInverted = isInverted;
		}

		/// <summary>
		/// Converts a boolean value to T.
		/// </summary>
		/// <param name="value">The value to convert.</param>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {

			T result;

			if (object.ReferenceEquals(value, null)) {
				result = this.FalseValue;
			}
			else if (value.GetType() != typeof(bool)) {
				result = this.FalseValue;
			}
			else {
				bool temp = (bool)value;
				result = temp ? this.TrueValue : this.FalseValue;
			}

			return this.IsInverted
				? (this.comparer.Equals(result, this.TrueValue) ? this.FalseValue : this.TrueValue)
				: (this.comparer.Equals(result, this.TrueValue) ? this.TrueValue : this.FalseValue);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {

			bool result = false;

			if (object.ReferenceEquals(value, null)) {
				result = false;
			}
			else {

				var type = value.GetType();

				if (type == typeof(T)) {

					T temp = (T)value;

					if (this.comparer.Equals(this.TrueValue, temp)) {
						result = true;
					}
					else if (this.comparer.Equals(this.FalseValue, temp)) {
						result = false;
					}
					else {
						result = false;
					}
				}
				else {
					result = false;
				}
			}

			return this.IsInverted ? !result : result;
		}

		public T TrueValue { get; set; }

		public T FalseValue { get; set; }

		public bool IsInverted { get; set; }
	}

}