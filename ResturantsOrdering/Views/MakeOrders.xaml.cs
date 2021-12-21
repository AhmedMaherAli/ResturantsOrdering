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

namespace ResturantsOrdering.Views
{
    /// <summary>
    /// Interaction logic for MakeOrders.xaml
    /// </summary>
    public partial class MakeOrders : UserControl
    {
        public MakeOrders()
        {
            InitializeComponent();
        }
    }
}
/*
 * 
 *  <Grid Grid.Row="1" Margin="10 10 10 0">
            <Grid.RowDefinitions>
                <RowDefinition Height="auto"/>
            </Grid.RowDefinitions>
            <TextBox
                 Name="OrderItems"
                 TextWrapping="Wrap"
                 AcceptsReturn="True"
                 VerticalScrollBarVisibility="Visible" Grid.Row="1" Margin="0 5 0 0" Height="200"/>
        </Grid>
*/