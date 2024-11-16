using System;using OkEye.Services.Interfaces;

/* "FrameData" is the data structure used to store the frame data returned from the camera. It will automatically allocate and free memory*/
/* The length below does not include the number of bytes of the data type .
@ point3D: the data storage method is x0y0z0xlylz1x2y2z2..., its length is point3DSize, same as irWidth * irHeight * 3. The number of point is pointCount, same as point3DSize / 3.
@ pointUV : UV data , its length is irWidth * irHeight * 2.
@ triangleIndices : Triangular patch data , its length is triangleIndicesSize , same as irWidth * irHeight * 6.
@ depthmap : depth data , its length is textureWidth * textureHeight when "depthType = 1" in CameraParam. Its length is irWidth * irHeight when "depthType = 2".
@ normals : normal vector data ( normal [ nx ny nz ]), its length is irWidth * irHeight * 3.
@ pointColor : Color data , its length is pointColorSize , same as irWidth * irHeight * 3.
@ texture : raw texture data , its length is textureWidth * textureHeight * 3.
@ remapTexture : remaped texture(IR) data, it contains a bright and a normal picture for left and right(FYI: monocular camera doesn’t contain right) respectively. Each picture length is irWidth * irHeight.
*/
public class FrameData : global::System.IDisposable, ICloneable
{
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal FrameData(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(FrameData obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  public object Clone()
  {
    return new FrameData(this);
  }

  ~FrameData() {
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
          CameraProPINVOKE.delete_FrameData(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public FrameData() : this(CameraProPINVOKE.new_FrameData__SWIG_0(), true) {
  }

  public FrameData(FrameData other) : this(CameraProPINVOKE.new_FrameData__SWIG_1(FrameData.getCPtr(other)), true)
  {
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
  }

  public FrameInfo frameInfo
  {
    set
    {
      CameraProPINVOKE.FrameData_frameInfo_set(swigCPtr, FrameInfo.getCPtr(value));
    }
    get
    {
      global::System.IntPtr cPtr = CameraProPINVOKE.FrameData_frameInfo_get(swigCPtr);
      FrameInfo ret = (cPtr == global::System.IntPtr.Zero) ? null : new FrameInfo(cPtr, false);
      return ret;
    }
  }

  /*!< 3D点云数据,如果为nullptr则表示不需要输出点云数据 */
  unsafe public float* point3D {
    get {
        float* ret = (float*)CameraProPINVOKE.FrameData_point3D_get(swigCPtr);
        return ret;
    } 
  }

  /*!< UV数据,如果为nullptr则表示不需要输出UV数据 */
  unsafe public float* pointUV {
    get {
      float* ret = (float*)CameraProPINVOKE.FrameData_pointUV_get(swigCPtr);
      return ret;
    } 
  }

  /*!< 三角面片数据,如果为nullptr则表示不需要输出三角面片数据 */
  unsafe public int* triangleIndices {
    get {
      int* ret = (int*)CameraProPINVOKE.FrameData_triangleIndices_get(swigCPtr);
      return ret;
    } 
  }

  /*!< 深度数据,如果为nullptr则表示不需要输出深度数据 */
  unsafe public float* depthmap {
    get {
      float* ret = (float*)CameraProPINVOKE.FrameData_depthmap_get(swigCPtr);
      return ret;
    } 
  }

  /*!< 法向量数据(法线[nx ny nz curavture]),如果为nullptr则表示不需要输出法向量数据 */
  unsafe public float* normals
  {
    get
    {
      float* ret = (float*)CameraProPINVOKE.FrameData_normals_get(swigCPtr);
      return ret;
    }
  }

  /*!< 彩色数据,如果为nullptr则表示不需要输出彩色数据 */
  unsafe public byte* pointColor
  {
    get
    {
      byte* ret = (byte*)CameraProPINVOKE.FrameData_pointColor_get(swigCPtr);
      return ret;
    }
  }

  /*!< 原始纹理数据 */
  unsafe public byte* texture
  {
    get
    {
      unsafe
      {
        byte* ret = (byte*)CameraProPINVOKE.FrameData_texture_get(swigCPtr);
        return ret;
      }
    }
  }

  unsafe public byte* remapTexture
  {
    get
    {
      byte* ret = (byte*)CameraProPINVOKE.FrameData_remapTexture_get(swigCPtr);
      return ret;
    }
  }

  public uint point3DSize {
    set {
      CameraProPINVOKE.FrameData_point3DSize_set(swigCPtr, value);
    } 
    get {
      uint ret = CameraProPINVOKE.FrameData_point3DSize_get(swigCPtr);
      return ret;
    } 
  }

  public uint pointUVSize {
    set {
      CameraProPINVOKE.FrameData_pointUVSize_set(swigCPtr, value);
    } 
    get {
      uint ret = CameraProPINVOKE.FrameData_pointUVSize_get(swigCPtr);
      return ret;
    } 
  }

  public uint triangleIndicesSize {
    set {
      CameraProPINVOKE.FrameData_triangleIndicesSize_set(swigCPtr, value);
    } 
    get {
      uint ret = CameraProPINVOKE.FrameData_triangleIndicesSize_get(swigCPtr);
      return ret;
    } 
  }

  public uint depthmapSize {
    set {
      CameraProPINVOKE.FrameData_depthmapSize_set(swigCPtr, value);
    } 
    get {
      uint ret = CameraProPINVOKE.FrameData_depthmapSize_get(swigCPtr);
      return ret;
    } 
  }

  public uint normalsSize {
    set {
      CameraProPINVOKE.FrameData_normalsSize_set(swigCPtr, value);
    } 
    get {
      uint ret = CameraProPINVOKE.FrameData_normalsSize_get(swigCPtr);
      return ret;
    } 
  }

  public uint pointColorSize {
    set {
      CameraProPINVOKE.FrameData_pointColorSize_set(swigCPtr, value);
    } 
    get {
      uint ret = CameraProPINVOKE.FrameData_pointColorSize_get(swigCPtr);
      return ret;
    } 
  }

  public uint textureSize {
    set {
      CameraProPINVOKE.FrameData_textureSize_set(swigCPtr, value);
    } 
    get {
      uint ret = CameraProPINVOKE.FrameData_textureSize_get(swigCPtr);
      return ret;
    } 
  }

  public uint pointCount {
    set {
      CameraProPINVOKE.FrameData_pointCount_set(swigCPtr, value);
    } 
    get {
      uint ret = CameraProPINVOKE.FrameData_pointCount_get(swigCPtr);
      return ret;
    } 
  }

  public uint remapTextureSize
  {
    get
      {
        uint ret = CameraProPINVOKE.FrameData_remapTextureSize_get(swigCPtr);
        return ret;
      }
  }

}

#region FrameInfo
public class FrameInfo : global::System.IDisposable
{
    private global::System.Runtime.InteropServices.HandleRef swigCPtr;
    protected bool swigCMemOwn;

    internal FrameInfo(global::System.IntPtr cPtr, bool cMemoryOwn)
    {
        swigCMemOwn = cMemoryOwn;
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
    }

    internal static global::System.Runtime.InteropServices.HandleRef getCPtr(FrameInfo obj)
    {
        return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
    }

    ~FrameInfo()
    {
        Dispose(false);
    }

    public void Dispose()
    {
        Dispose(true);
        global::System.GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        lock (this)
        {
            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    CameraProPINVOKE.delete_FrameInfo(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
        }
    }

    // Frame index counted from the connection start
    public ulong frameIndex
    {
        set
        {
            CameraProPINVOKE.FrameInfo_frameIndex_set(swigCPtr, value);
        }
        get
        {
            ulong ret = CameraProPINVOKE.FrameInfo_frameIndex_get(swigCPtr);
            return ret;
        }
    }

    // Unix timestamp with precision in seconds
    public double frameTimestamp
    {
        set
        {
            CameraProPINVOKE.FrameInfo_frameTimestamp_set(swigCPtr, value);
        }
        get
        {
            double ret = CameraProPINVOKE.FrameInfo_frameTimestamp_get(swigCPtr);
            return ret;
        }
    }

    // Frame total duration in ms
    public double frameTotalDuration
    {
        set
        {
            CameraProPINVOKE.FrameInfo_frameTotalDuration_set(swigCPtr, value);
        }
        get
        {
            double ret = CameraProPINVOKE.FrameInfo_frameTotalDuration_get(swigCPtr);
            return ret;
        }
    }

    // Frame acquisition duration in ms
    public double frameAcquisitionDuration
    {
        set
        {
            CameraProPINVOKE.FrameInfo_frameAcquisitionDuration_set(swigCPtr, value);
        }
        get
        {
            double ret = CameraProPINVOKE.FrameInfo_frameAcquisitionDuration_get(swigCPtr);
            return ret;
        }
    }

    // Frame computation duration in ms
    public double frameComputationDuration
    {
        set
        {
            CameraProPINVOKE.FrameInfo_frameComputationDuration_set(swigCPtr, value);
        }
        get
        {
            double ret = CameraProPINVOKE.FrameInfo_frameComputationDuration_get(swigCPtr);
            return ret;
        }
    }

    // Frame transfer duration in ms
    public double frameTransferDuration
    {
        set
        {
            CameraProPINVOKE.FrameInfo_frameTransferDuration_set(swigCPtr, value);
        }
        get
        {
            double ret = CameraProPINVOKE.FrameInfo_frameTransferDuration_get(swigCPtr);
            return ret;
        }
    }

    public FrameInfo() : this(CameraProPINVOKE.new_FrameInfo(), true)
    {
    }

}

#endregion
