using System.Globalization;
using System.Windows;
using DataBind.Bcl.Converters;
using Xunit;
namespace DataBind.Bcl.Tests.Converters {

	public class BooleanToBooleanInverterConverterTests {

		[Fact]
		public void Converts_Null_To_Boolean_True() {

			var converter = new BooleanToBooleanInverterConverter();
			bool? inputValue = new bool();

			var actual = converter.Convert(inputValue, typeof(bool), null, CultureInfo.CurrentCulture);
			var expected = true;

			Assert.Equal(expected, actual);

		}

		[Fact]
		public void Converts_Nullable_Boolean_True_To_Boolean_False() {

			var converter = new BooleanToBooleanInverterConverter();
			bool? inputValue = new bool?(true);

			var actual = converter.Convert(inputValue, typeof(bool), null, CultureInfo.CurrentCulture);
			var expected = false;

			Assert.Equal(expected, actual);

		}

		[Fact]
		public void Converts_Nullable_Boolean_False_To_Boolean_True() {

			var converter = new BooleanToBooleanInverterConverter();
			bool? inputValue = new bool?(true);

			var actual = converter.Convert(inputValue, typeof(bool), null, CultureInfo.CurrentCulture);
			var expected = false;

			Assert.Equal(expected, actual);

		}

		[Fact]
		public void Converts_Boolean_True_To_Boolean_False() {

			var converter = new BooleanToBooleanInverterConverter();
			bool inputValue = true;

			var actual = converter.Convert(inputValue, typeof(bool), null, CultureInfo.CurrentCulture);
			var expected = false;

			Assert.Equal(expected, actual);

		}

		[Fact]
		public void Converts_Boolean_False_To_Boolean_True() {

			var converter = new BooleanToBooleanInverterConverter();
			bool inputValue = true;

			var actual = converter.Convert(inputValue, typeof(bool), null, CultureInfo.CurrentCulture);
			var expected = false;

			Assert.Equal(expected, actual);

		}

		[Fact]
		public void Converts_Back_Null_To_Boolean_True() {

			var converter = new BooleanToBooleanInverterConverter();
			bool? inputValue = new bool?();

			var actual = converter.ConvertBack(inputValue, typeof(bool), null, CultureInfo.CurrentCulture);
			var expected = true;

			Assert.Equal(expected, actual);

		}

		[Fact]
		public void Converts_Back_Nullabale_Boolean_True_To_Boolean_False() {

			var converter = new BooleanToBooleanInverterConverter();
			bool? inputValue = new bool?(true);

			var actual = converter.ConvertBack(inputValue, typeof(bool), null, CultureInfo.CurrentCulture);
			var expected = false;

			Assert.Equal(expected, actual);

		}

		[Fact]
		public void Converts_Back_Nullabale_Boolean_False_To_Boolean_True() {

			var converter = new BooleanToBooleanInverterConverter();
			bool? inputValue = new bool?(false);

			var actual = converter.ConvertBack(inputValue, typeof(bool), null, CultureInfo.CurrentCulture);
			var expected = true;

			Assert.Equal(expected, actual);

		}

		[Fact]
		public void Converts_Back_Boolean_True_To_Boolean_False() {

			var converter = new BooleanToBooleanInverterConverter();
			bool inputValue = true;

			var actual = converter.ConvertBack(inputValue, typeof(bool), null, CultureInfo.CurrentCulture);
			var expected = false;

			Assert.Equal(expected, actual);

		}

		[Fact]
		public void Converts_Back_Boolean_False_To_Boolean_True() {

			var converter = new BooleanToBooleanInverterConverter();
			bool inputValue = false;

			var actual = converter.ConvertBack(inputValue, typeof(bool), null, CultureInfo.CurrentCulture);
			var expected = true;

			Assert.Equal(expected, actual);

		}

	}

}