/* "CameraParam" contains some important camera parameters. It is especially useful when saving images. */
public class CameraParam : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal CameraParam(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(CameraParam obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~CameraParam() {
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
          CameraProPINVOKE.delete_CameraParam(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public int textureWidth { 
    get {
        int ret = CameraProPINVOKE.CameraParam_textureWidth_get(swigCPtr);
        return ret;
    } 
  }

  public int textureHeight {
    get {
        int ret = CameraProPINVOKE.CameraParam_textureHeight_get(swigCPtr);
        return ret;
    } 
  }

  public int irWidth {
    get {
      int ret = CameraProPINVOKE.CameraParam_irWidth_get(swigCPtr);
      return ret;
    } 
  }

  public int irHeight {
    get {
      int ret = CameraProPINVOKE.CameraParam_irHeight_get(swigCPtr);
      return ret;
    } 
  }

  public /*mutable*/ int irPerNum {
    get {
      int ret = CameraProPINVOKE.CameraParam_irPerNum_get(swigCPtr);
      return ret;
    } 
  }

  public int hdrCnt {
    get {
      int ret = CameraProPINVOKE.CameraParam_hdrCnt_get(swigCPtr);
      return ret;
    } 
  }

  public /*mutable*/ int pixelBytes {
    get {
      int ret = CameraProPINVOKE.CameraParam_pixelBytes_get(swigCPtr);
      return ret;
    } 
  }

  public /*mutable*/ int depthType {
    get {
      int ret = CameraProPINVOKE.CameraParam_depthType_get(swigCPtr);
      return ret;
    } 
  }

  // 0: Binocular Reconstruction 2£ºMonocular Reconstruction
  public int reconstructionType
  {
    get
    {
      int ret = CameraProPINVOKE.CameraParam_reconstructionType_get(swigCPtr);
      return ret;
    }
  }

  public CameraParam() : this(CameraProPINVOKE.new_CameraParam(), true) {
  }

}

#region CameraPosition
public enum CAMERA_POSITION
{
    CAM_LEFT = 0x00,
    CAM_RGB = 0x01,
    CAM_RIGHT = 0x02
}

#endregion