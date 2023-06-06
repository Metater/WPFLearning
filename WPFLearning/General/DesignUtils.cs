using devDept.Eyeshot.Control;
using devDept.Eyeshot;
using devDept.Graphics;
using devDept.Geometry;

namespace WPFLearning.General
{
    public static class DesignUtils
    {
        public static void Configure(Design design, bool isOptimized)
        {
            design.ShowFps = true;
            design.ProgressBar.Visible = true;
            design.MinimumFramerate = 10; // 75
            // design.ActionMode = actionType.SelectVisibleByPick;

            if (isOptimized)
            {
                // http://documentation.devdept.com/100/Common/topic36.html

                design.Renderer = rendererType.OpenGL;

                design.ActiveViewport.DisplayMode = displayType.Shaded;

                design.Wireframe.SilhouettesDrawingMode = silhouettesDrawingType.Never;
                design.Shaded.SilhouettesDrawingMode = silhouettesDrawingType.Never;
                design.Rendered.SilhouettesDrawingMode = silhouettesDrawingType.Never;

                design.Rendered.PlanarReflections = false;

                design.Rendered.ShadowMode = shadowType.None;

                design.Rendered.RealisticShadowQuality = realisticShadowQualityType.Low;

                design.Shaded.ShowEdges = false;
                design.Shaded.ShowInternalWires = false;
                design.Rendered.ShowEdges = false;
            }
            else
            {

            }
        }
    }
}
