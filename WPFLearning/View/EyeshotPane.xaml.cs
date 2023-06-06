using devDept;
using devDept.Eyeshot.Entities;
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
    /// Interaction logic for EyeshotPane.xaml
    /// </summary>
    public partial class EyeshotPane : UserControl
    {
        private readonly WorkManager<WorkUnit> workManager = new WorkManager<WorkUnit>();
        private readonly List<Entity> entities = new List<Entity>();
        private readonly Random random = new Random();

        public EyeshotPane()
        {
            InitializeComponent();

            DesignUtils.Configure(design, true);

            Refs.OnContentRendered += Refs_OnContentRendered;
            Refs.OnReload += Refs_OnReload;
            Refs.OnCancel += Refs_OnCancel;

            design.WorkCompleted += Design_WorkCompleted;
        }

        private void Design_WorkCompleted(object sender, WorkCompletedEventArgs e)
        {
            // design.
        }

        private void Refs_OnContentRendered()
        {
            Refs.tbDebugA.Text = "Hello, World!";

            Load();
        }

        private void Refs_OnReload()
        {
            Load();
        }

        private void Refs_OnCancel()
        {
            workManager.ClearQueue();
            workManager.Cancel();
            design.CancelWork();
        }

        private void Load()
        {
            workManager.AppendToQueue(new LoadWork((int)Refs.sliderIterations.Value, Refs.sliderWeldMaxGap.Value, entities, random));
            workManager.RunAll(design);
        }
    }
}
