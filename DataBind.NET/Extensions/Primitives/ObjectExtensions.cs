using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace System {

	/// <summary>
	/// Extension methods for the object type.
	/// </summary>
	public static class ObjectExtensions {

		/// <summary>
		/// Returns the second parameter if the first is null.
		/// </summary>
		/// <typeparam name="T">The type of the object.</typeparam>
		/// <param name="x">The first parameter.</param>
		/// <param name="y">Acts as a replacement value if the first parameter is null.</param>
		/// <returns>An instance of <see cref="T"/>.</returns>
		public static T Coalesce<T>(this T x, T y) where T : class {
			return x ?? y;
		}

		/// <summary>
		/// Returns the second parameter if the first is null.
		/// </summary>
		/// <typeparam name="T">The type of the object.</typeparam>
		/// <param name="x">The first parameter.</param>
		/// <param name="y">Acts as a replacement value if the first parameter is null.</param>
		/// <returns>An instance of <see cref="T"/>.</returns>
		public static T Coalesce<T>(this T? x, T y) where T : struct {
			return x ?? y;
		}

		/// <summary>
		/// Converts a single object to an <see cref="IEnumerable{T}"/> of the same type
		/// </summary>
		/// <typeparam name="T">Describes the type of the object.</typeparam>
		/// <param name="object">The object to convert to enumerable.</param>
		/// <returns><see cref="IEnumerable{T}"/>.</returns>
		public static IEnumerable<T> ToEnumerable<T>(this T @object) {

			if (@object == null) {
				yield break;
			}

			yield return @object;
		}

		/// <summary>
		/// Checks to see if the object is null.
		/// </summary>
		/// <typeparam name="T">The type of the object.</typeparam>
		/// <param name="input">The instance of the object.</param>
		/// <param name="name">The name of the object.</param>
		/// <returns>The object if it is not null</returns>
		/// <exception cref="ArgumentNullException">If the object is null.</exception>
		public static T ThrowIfNull<T>(this T input, string name) {
			if (object.ReferenceEquals(input, null)) {
				throw new ArgumentNullException(name);
			}

			return input;
		}

  }

}