using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFLearning.General
{
    public class CustomMesh : Mesh
    {
        public CustomMesh(Mesh mesh) : base(mesh)
        {
            
        }

        public override void Regen(double deviation)
        {
            base.Regen(deviation);

            Refs.tbDebugE.Text = deviation.ToString();
        }

        public override void Regen(RegenParams data)
        {
            base.Regen(data);

            Refs.tbDebugE.Text = data.ToString();
        }
    }
}
