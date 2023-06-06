using devDept;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPFLearning.General
{
    public class LoadWork : WorkUnit
    {
        // https://devdept.zendesk.com/hc/en-us/articles/217842588-Group-thousands-of-Quads-into-a-single-Mesh-object

        private readonly int iterations;
        private readonly double weldMaxGap;
        private readonly List<Entity> entities;
        private readonly Random random;

        private double v1Time, v2Time, v3Time;

        public LoadWork(int iterations, double weldMaxGap, List<Entity> entities, Random random)
        {
            this.iterations = iterations;
            this.weldMaxGap = weldMaxGap;
            this.entities = entities;
            this.random = random;
        }

        public override void DoWork(BackgroundWorker worker, DoWorkEventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            // V1(worker, e);
            // v1Time = sw.Elapsed.TotalSeconds;

            sw.Restart();
            // V2(worker, e);
            // v2Time = sw.Elapsed.TotalSeconds;

            sw.Restart();
            V5(worker, e);
            v3Time = sw.Elapsed.TotalSeconds;
        }

        private void V1(BackgroundWorker worker, DoWorkEventArgs e)
        {
            entities.Clear();

            for (int i = 0; i < iterations; i++)
            {
                Mesh mesh = Mesh.CreateSphere(0.5, 16, 16);

                mesh.ColorMethod = colorMethodType.byEntity;
                mesh.Color = random.GetRandomColor();

                mesh.Translate(random.GetRandomPosition(-10, 10));

                // mesh.EntityData = new StressTestEntityData();

                // mesh.Weld(weldMaxGap, true);

                entities.Add(mesh);

                // TODO Merge meshes for better performance

                if (Cancelled(worker, e))
                    return;

                UpdateProgress(i, iterations, $"V1", worker);

                // vertCount = mesh.Vertices.Length;
            }
        }

        private void V2(BackgroundWorker worker, DoWorkEventArgs e)
        {
            entities.Clear();

            Mesh prefab = Mesh.CreateSphere(0.5, 16, 16);

            for (int i = 0; i < iterations; i++)
            {
                Mesh mesh = (Mesh)prefab.Clone();

                mesh.ColorMethod = colorMethodType.byEntity;
                mesh.Color = random.GetRandomColor();

                mesh.Translate(random.GetRandomPosition(-10, 10));

                // mesh.EntityData = new StressTestEntityData();

                // mesh.Weld(weldMaxGap, true);

                entities.Add(mesh);

                // TODO Merge meshes for better performance

                if (Cancelled(worker, e))
                    return;

                UpdateProgress(i, iterations, $"V2", worker);

                // vertCount = mesh.Vertices.Length;
            }
        }

        private void V3(BackgroundWorker worker, DoWorkEventArgs e)
        {
            entities.Clear();

            FastMesh prefab = Mesh.CreateSphere(0.5, 16, 16).ConvertToFastMesh();

            for (int i = 0; i < iterations; i++)
            {
                FastMesh mesh = (FastMesh)prefab.Clone();

                mesh.ColorMethod = colorMethodType.byEntity;
                mesh.Color = random.GetRandomColor();

                mesh.Translate(random.GetRandomPosition(-10, 10));

                // mesh.EntityData = new StressTestEntityData();

                // mesh.Weld(weldMaxGap, true);

                entities.Add(mesh);

                // TODO Merge meshes for better performance

                if (Cancelled(worker, e))
                    return;

                UpdateProgress(i, iterations, $"V3", worker);

                // vertCount = mesh.Vertices.Length;
            }
        }

        private void V4(BackgroundWorker worker, DoWorkEventArgs e)
        {
            entities.Clear();

            FastMesh root = null;
            FastMesh prefab = Mesh.CreateSphere(0.5, 16, 16).ConvertToFastMesh();

            for (int i = 0; i < iterations; i++)
            {
                FastMesh mesh = (FastMesh)prefab.Clone();

                mesh.ColorMethod = colorMethodType.byEntity;
                mesh.Color = random.GetRandomColor();

                mesh.Translate(random.GetRandomPosition(-10, 10));

                // mesh.EntityData = new StressTestEntityData();

                // mesh.Weld(weldMaxGap, true);

                if (root == null)
                {
                    root = mesh;
                }
                else
                {
                    root.MergeWith(mesh);
                }

                // TODO Merge meshes for better performance

                if (Cancelled(worker, e))
                    return;

                UpdateProgress(i, iterations, $"V3", worker);

                // vertCount = mesh.Vertices.Length;
            }

            entities.Add(root);
        }

        private void V5(BackgroundWorker worker, DoWorkEventArgs e)
        {
            entities.Clear();

            FastMesh root = null;

            Mesh sphere = new CustomMesh(Mesh.CreateSphere(0.5, 16, 16));
            sphere.Weld(weldMaxGap, true);
            sphere.ColorMethod = colorMethodType.byEntity;

            FastMesh prefab = sphere.ConvertToFastMesh();

            for (int i = 0; i < iterations; i++)
            {
                FastMesh mesh = (FastMesh)prefab.Clone();

                mesh.Color = random.GetRandomColor();

                mesh.Translate(random.GetRandomPosition(-10, 10) * Math.Sqrt(random.GetRandomDouble(0, 100)));

                // mesh.EntityData = new StressTestEntityData();

                if (root == null)
                {
                    root = mesh;
                }
                else
                {
                    root.MergeWith(mesh);

                    if (i % 50 == 0)
                    {
                        entities.Add(root);
                        root = null;
                    }
                }

                // TODO Merge meshes for better performance

                if (Cancelled(worker, e))
                    return;

                UpdateProgress(i, iterations, $"V3", worker);

                // vertCount = mesh.Vertices.Length;
            }

            if (root != null)
            {
                entities.Add(root);
            }
        }

        public override void WorkCompleted(object sender)
        {
            var workspace = (Workspace)sender;

            workspace.Entities.Clear();

            workspace.Entities.AddRange(entities);

            // workspace.Entities.RegenAllCurved() // Can reduce segments/triangles count, call with the biggest acceptable deviation (chordal error) tolerance

            if (Refs.toggleButtonZoomFit.IsChecked.Value)
            {
                workspace.ZoomFit();
            }

            Refs.tbDebugB.Text = $"Load v1 time {v1Time} seconds";
            Refs.tbDebugC.Text = $"Load v2 time {v2Time} seconds";
            Refs.tbDebugD.Text = $"Load v3 time {v3Time} seconds";

            GC.Collect();
        }
    }
}
