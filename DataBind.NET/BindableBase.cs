using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataBind {

	/// <summary>
	/// A base view model class
	/// </summary>
	public class BindableBase : DisposableObject, INotifyPropertyChanged {

		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// A base view model class.
		/// </summary>
		public BindableBase() { }

		/// <summary>
		/// Checks if a property already matches a desired value. Sets the property and
		/// notifies listeners only when necessary.
		/// </summary>
		/// <typeparam name="T">Type of the property.</typeparam>
		/// <param name="storage">Reference to a property with both getter and setter.</param>
		/// <param name="value">Desired value for the property.</param>
		/// <param name="propertyName">Name of the property used to notify listeners. This
		/// value is optional and can be provided automatically when invoked from compilers that
		/// support CallerMemberName.</param>
		/// <returns>True if the value was changed, false if the existing value matched the
		/// desired value.</returns>
		protected virtual bool SetValue<T>(ref T storage, T value, [CallerMemberName] string propertyName = null) {

			if (EqualityComparer<T>.Default.Equals(storage, value)) {
				return false;
			}

			storage = value;

			this.RaisePropertyChanged(propertyName);

			return true;
		}

		/// <summary>
		/// Checks if a property already matches a desired value. Sets the property and
		/// notifies listeners only when necessary.
		/// </summary>
		/// <typeparam name="T">Type of the property.</typeparam>
		/// <param name="storage">Reference to a property with both getter and setter.</param>
		/// <param name="value">Desired value for the property.</param>
		/// <param name="propertyName">Name of the property used to notify listeners. This
		/// value is optional and can be provided automatically when invoked from compilers that
		/// support CallerMemberName.</param>
		/// <param name="onChanged">Action that is called after the property value has been changed.</param>
		/// <returns>True if the value was changed, false if the existing value matched the
		/// desired value.</returns>
		protected virtual bool SetValue<T>(ref T storage, T value, Action onChanged, [CallerMemberName] string propertyName = null) {

			if (EqualityComparer<T>.Default.Equals(storage, value)) {
				return false;
			}

			storage = value;

			onChanged?.Invoke();

			this.RaisePropertyChanged(propertyName);

			return true;
		}

		/// <summary>
		/// Raises this object's PropertyChanged event.
		/// </summary>
		/// <param name="propertyName">Name of the property used to notify listeners. This
		/// value is optional and can be provided automatically when invoked from compilers
		/// that support <see cref="CallerMemberNameAttribute"/>.</param>
		protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null) {
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}

}