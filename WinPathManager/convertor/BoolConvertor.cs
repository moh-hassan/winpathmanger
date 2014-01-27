using System;
using System.Drawing;
using System.Globalization;
using MvvmFx.Windows.Data;

namespace WinPathManager.convertor
{
    public class BoolConvertor : IValueConverter
    {
        #region Implementation of IValueConverter

       
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //if (targetType != typeof (string))
            //    return value;
            var s = value is bool ? (bool) value : false ;

            var Value2 = s  ? true  : false  ;
            return Value2;
        }


        public object ConvertBack(object value, Type sourceType, object parameter, CultureInfo culture)
        {
            return value;
        }

        #endregion
    }
}
