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
using WPFLearning.General;

namespace WPFLearning.View
{
    /// <summary>
    /// Interaction logic for ControlsPane.xaml
    /// </summary>
    public partial class ControlsPane : UserControl
    {
        public ControlsPane()
        {
            InitializeComponent();

            Refs.toggleButtonZoomFit = ToggleButtonZoomFit;
            Refs.sliderIterations = SliderIterations;
            Refs.sliderWeldMaxGap = SliderWeldMaxGap;
        }

        private void ButtonReload_Click(object sender, RoutedEventArgs e)
        {
            Refs.InvokeReload();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Refs.InvokeCancel();
        }

        private void SliderIterations_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TextSliderIterations.Text = $"Iterations: {(int)e.NewValue}";
        }

        private void SliderWeldMaxGap_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TextSliderWeldMaxGap.Text = $"Weld max gap: {Math.Round(e.NewValue, 3)}";
        }
    }
}
