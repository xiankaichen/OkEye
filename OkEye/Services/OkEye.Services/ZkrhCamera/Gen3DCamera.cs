using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gen3d
{
    public class Gen3DCamera
    {
        public Gen3DCamera()
        {
            cam = CameraPro.CreateCamera(CamType.CamPro);
            camInfoVector = new CameraInfoVector();
        }

        ~Gen3DCamera()
        {

        }

        public Camera cam;
        public CameraInfoVector camInfoVector;
    }
}
