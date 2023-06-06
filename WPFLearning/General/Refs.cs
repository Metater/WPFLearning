using devDept.Eyeshot.Control;
using System;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace WPFLearning.General
{
    public static class Refs
    {
        public static TextBlock tbDebugA;
        public static TextBlock tbDebugB;
        public static TextBlock tbDebugC;
        public static TextBlock tbDebugD;
        public static TextBlock tbDebugE;
        public static ToggleButton toggleButtonZoomFit;
        public static Slider sliderIterations;
        public static Slider sliderWeldMaxGap;

        public static event Action OnContentRendered;
        public static void InvokeOnContentRendered()
        {
            OnContentRendered?.Invoke();
        }

        public static event Action OnReload;
        public static void InvokeReload()
        {
            OnReload?.Invoke();
        }

        public static event Action OnCancel;
        public static void InvokeCancel()
        {
            OnCancel?.Invoke();
        }
    }
}
