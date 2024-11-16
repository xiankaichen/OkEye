using OpenCvSharp;
using Prism.Events;

namespace OkEye.Modules.ModuleCamera.Events
{
    public class ImagePubSubEvent : PubSubEvent<Mat>
    {

    }

    public class DepthPubSubEvent : PubSubEvent<Mat>
    {

    }

    public class CloudPubSubEvent : PubSubEvent<Mat>
    {

    }

}
