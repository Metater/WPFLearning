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
    /// Interaction logic for FooterPane.xaml
    /// </summary>
    public partial class FooterPane : UserControl
    {
        public FooterPane()
        {
            InitializeComponent();

            Refs.tbDebugA = tbDebugA;
            Refs.tbDebugB = tbDebugB;
            Refs.tbDebugC = tbDebugC;
            Refs.tbDebugD = tbDebugD;
            Refs.tbDebugE = tbDebugE;
        }
    }
}
