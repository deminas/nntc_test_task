using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace TestTask.ViewModel.Converters
{
    public class ListBoxIndexConverter : IValueConverter
    {
        public object Convert(object value, Type TargetType, object parameter, CultureInfo culture)
        {
            var item = (ListBoxItem)value;
            var listView = ItemsControl.ItemsControlFromItemContainer(item) as ListBox;
            return listView.ItemContainerGenerator.IndexFromContainer(item);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
