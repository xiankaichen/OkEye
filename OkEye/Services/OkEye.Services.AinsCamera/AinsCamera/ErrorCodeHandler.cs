public class ErrorCodeHandler : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal ErrorCodeHandler(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ErrorCodeHandler obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~ErrorCodeHandler() {
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
          CameraProPINVOKE.delete_ErrorCodeHandler(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public virtual void Handle(int errorCode) {
    if (SwigDerivedClassHasMethod("Handle", swigMethodTypes0)) CameraProPINVOKE.ErrorCodeHandler_HandleSwigExplicitErrorCodeHandler(swigCPtr, errorCode); else CameraProPINVOKE.ErrorCodeHandler_Handle(swigCPtr, errorCode);
  }

  public ErrorCodeHandler() : this(CameraProPINVOKE.new_ErrorCodeHandler(), true) {
    SwigDirectorConnect();
  }

  private void SwigDirectorConnect() {
    if (SwigDerivedClassHasMethod("Handle", swigMethodTypes0))
      swigDelegate0 = new SwigDelegateErrorCodeHandler_0(SwigDirectorMethodHandle);
    CameraProPINVOKE.ErrorCodeHandler_director_connect(swigCPtr, swigDelegate0);
  }

  private bool SwigDerivedClassHasMethod(string methodName, global::System.Type[] methodTypes) {
    global::System.Reflection.MethodInfo methodInfo = this.GetType().GetMethod(methodName, global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.NonPublic | global::System.Reflection.BindingFlags.Instance, null, methodTypes, null);
    bool hasDerivedMethod = methodInfo.DeclaringType.IsSubclassOf(typeof(ErrorCodeHandler));
    return hasDerivedMethod;
  }

  private void SwigDirectorMethodHandle(int errorCode) {
    Handle(errorCode);
  }

  public delegate void SwigDelegateErrorCodeHandler_0(int errorCode);

  private SwigDelegateErrorCodeHandler_0 swigDelegate0;

  private static global::System.Type[] swigMethodTypes0 = new global::System.Type[] { typeof(int) };
}
