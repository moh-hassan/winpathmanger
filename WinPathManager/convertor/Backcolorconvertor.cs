using System;
using System.Drawing;
using System.Globalization;
using MvvmFx.Windows.Data;

namespace WinPathManager.convertor
{
    // Implementation of IValueConverter
    public class StringToColor : IValueConverter
    {
     

        /// <summary>
        /// Converts the source value to a target value.
        /// </summary>
        /// <param name="value">The source value to convert.</param>
        /// <param name="targetType">The type of the target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        /// <remarks>
        /// This method will only be called if the mode of the <see cref="SingleSourceBinding"/> is either <see cref="BindingMode.TwoWay"/>
        /// or <see cref="BindingMode.OneWayToTarget"/>.
        /// </remarks>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var s = value;

             var value2 = s =true  ? Color.Red : Color.Black ;
            return value2;
        }

        /// <summary>
        /// Converts back the target value to a source value.
        /// </summary>
        /// <param name="value">The target value to convert.</param>
        /// <param name="sourceType">The type of the source property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        /// <remarks>
        /// This method will only be called if the mode of the <see cref="SingleSourceBinding"/> is either <see cref="BindingMode.TwoWay"/>
        /// or <see cref="BindingMode.OneWayToSource"/>.
        /// </remarks>
        public object ConvertBack(object value, Type sourceType, object parameter, CultureInfo culture)
        {
            return value;
        }
 
    }
}
