using System.Globalization;
using System.Windows;
using DataBind.Bcl.Converters;
using Xunit;
namespace DataBind.Bcl.Tests.Converters {

	public class BooleanToVisibilityInverterConverterTests {

		[Fact]
		public void Converts_Null_To_Visibility_Visible() {

			var converter = new BooleanToVisibilityInverterConverter();
			bool? inputValue = new bool();

			var actual = converter.Convert(inputValue, typeof(Visibility), null, CultureInfo.CurrentCulture);
			var expected = Visibility.Visible;

			Assert.Equal(expected, actual);

		}

		[Fact]
		public void Converts_Boolean_True_Condition_To_Visibility_Collapsed() {

			var converter = new BooleanToVisibilityInverterConverter();
			bool inputValue = true;

			var actual = converter.Convert(inputValue, typeof(Visibility), null, CultureInfo.CurrentCulture);
			var expected = Visibility.Collapsed;

			Assert.Equal(expected, actual);

		}

		[Fact]
		public void Converts_Boolean_False_Condition_To_Visibility_Visible() {

			var converter = new BooleanToVisibilityInverterConverter();
			bool inputValue = false;

			var actual = converter.Convert(inputValue, typeof(Visibility), null, CultureInfo.CurrentCulture);
			var expected = Visibility.Visible;

			Assert.Equal(expected, actual);

		}

		[Fact]
		public void Converts_Nullable_Boolean_True_Condition_To_Visibility_Collapsed() {

			var converter = new BooleanToVisibilityInverterConverter();
			bool? inputValue = new bool?(true);

			var actual = converter.Convert(inputValue, typeof(Visibility), null, CultureInfo.CurrentCulture);
			var expected = Visibility.Collapsed;

			Assert.Equal(expected, actual);

		}

		[Fact]
		public void Converts_Nullable_Boolean_False_Condition_To_Visibility_Visible() {

			var converter = new BooleanToVisibilityInverterConverter();
			bool? inputValue = new bool?(false);

			var actual = converter.Convert(inputValue, typeof(Visibility), null, CultureInfo.CurrentCulture);
			var expected = Visibility.Visible;

			Assert.Equal(expected, actual);

		}

		[Fact]
		public void Converts_Back_Null_Visibility_To_Boolean_True() {

			var converter = new BooleanToVisibilityInverterConverter();
			Visibility? inputValue = new Visibility?();

			var actual = converter.ConvertBack(inputValue, typeof(Visibility), null, CultureInfo.CurrentCulture);
			var expected = true;

			Assert.Equal(expected, actual);

		}

		[Fact]
		public void Converts_Back_Visibility_Visible_State_To_Boolean_False() {

			var converter = new BooleanToVisibilityInverterConverter();
			Visibility inputValue = Visibility.Visible;

			var actual = converter.ConvertBack(inputValue, typeof(Visibility), null, CultureInfo.CurrentCulture);
			var expected = false;

			Assert.Equal(expected, actual);

		}

		[Fact]
		public void Converts_Back_Visibility_Collapsed_State_To_Boolean_True() {

			var converter = new BooleanToVisibilityInverterConverter();
			Visibility inputValue = Visibility.Collapsed;

			var actual = converter.ConvertBack(inputValue, typeof(bool), null, CultureInfo.CurrentCulture);
			var expected = true;

			Assert.Equal(expected, actual);

		}

		[Fact]
		public void Converts_Back_Nullable_Visibility_Visible_State_To_Boolean_False() {

			var converter = new BooleanToVisibilityInverterConverter();
			Visibility? inputValue = new Visibility?(Visibility.Visible);

			var actual = converter.ConvertBack(inputValue, typeof(Visibility), null, CultureInfo.CurrentCulture);
			var expected = false;

			Assert.Equal(expected, actual);

		}

		[Fact]
		public void Converts_Back_Nullable_Visibility_Collapsed_State_To_Boolean_True() {

			var converter = new BooleanToVisibilityInverterConverter();
			Visibility? inputValue = new Visibility?(Visibility.Collapsed);

			var actual = converter.ConvertBack(inputValue, typeof(Visibility), null, CultureInfo.CurrentCulture);
			var expected = true;

			Assert.Equal(expected, actual);

		}


	}

}