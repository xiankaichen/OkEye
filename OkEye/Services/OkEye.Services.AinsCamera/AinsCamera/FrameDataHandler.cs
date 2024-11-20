public class FrameDataHandler : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal FrameDataHandler(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(FrameDataHandler obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~FrameDataHandler() {
    Dispose(false);
  }

  public void Dispose() {
    Dispose(true);
    global::System.GC.SuppressFinalize(this);
  }

  protected virtual void Dispose(bool disposing) {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          CameraProPINVOKE.delete_FrameDataHandler(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public virtual void Handle(CameraInfo cameraInfo, FrameData frameData) {
    if (SwigDerivedClassHasMethod("Handle", swigMethodTypes0)) CameraProPINVOKE.FrameDataHandler_HandleSwigExplicitFrameDataHandler(swigCPtr, CameraInfo.getCPtr(cameraInfo), FrameData.getCPtr(frameData)); else CameraProPINVOKE.FrameDataHandler_Handle(swigCPtr, CameraInfo.getCPtr(cameraInfo), FrameData.getCPtr(frameData));
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
  }

  public FrameDataHandler() : this(CameraProPINVOKE.new_FrameDataHandler(), true) {
    SwigDirectorConnect();
  }

  private void SwigDirectorConnect() {
    if (SwigDerivedClassHasMethod("Handle", swigMethodTypes0))
      swigDelegate0 = new SwigDelegateFrameDataHandler_0(SwigDirectorMethodHandle);
    CameraProPINVOKE.FrameDataHandler_director_connect(swigCPtr, swigDelegate0);
  }

  private bool SwigDerivedClassHasMethod(string methodName, global::System.Type[] methodTypes) {
    global::System.Reflection.MethodInfo methodInfo = this.GetType().GetMethod(methodName, global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.NonPublic | global::System.Reflection.BindingFlags.Instance, null, methodTypes, null);
    bool hasDerivedMethod = methodInfo.DeclaringType.IsSubclassOf(typeof(FrameDataHandler));
    return hasDerivedMethod;
  }

  private void SwigDirectorMethodHandle(global::System.IntPtr cameraInfo, global::System.IntPtr frameData) {
    Handle(new CameraInfo(cameraInfo, false), new FrameData(frameData, false));
  }

  public delegate void SwigDelegateFrameDataHandler_0(global::System.IntPtr cameraInfo, global::System.IntPtr frameData);

  private SwigDelegateFrameDataHandler_0 swigDelegate0;

  private static global::System.Type[] swigMethodTypes0 = new global::System.Type[] { typeof(CameraInfo), typeof(FrameData) };
}
