#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Helpers;
using Syncfusion.Windows.Shared;


namespace SfDataGridDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.dataGrid.CurrentCellEndEdit += dataGrid_CurrentCellEndEdit;
        }

        void dataGrid_CurrentCellEndEdit(object sender, CurrentCellEndEditEventArgs args)
        {
            //Refreshing the DisCount unbound column at runtime
            this.dataGrid.UpdateUnboundColumn(this.dataGrid.CurrentItem, "Discount");
        }
    }

    public class UnboundCellStyleConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var unboundCell = value as GridCell;
            var unboundValue = (unboundCell.Content as TextBlock).Text;
            var data = System.Convert.ToDouble(unboundValue.Substring(0, unboundValue.Length - 1));

            if (data > 75000)
                return new SolidColorBrush(Colors.DarkGreen);
            return new SolidColorBrush(Colors.Red);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
