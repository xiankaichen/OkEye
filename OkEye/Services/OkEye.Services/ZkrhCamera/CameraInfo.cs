/* "CameraInfo" is a data structure of camera information. Equivalent to "handle". Most APIs require it as the first parameter. */
public class CameraInfo : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal CameraInfo(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(CameraInfo obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~CameraInfo() {
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
          CameraProPINVOKE.delete_CameraInfo(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public int errorCode {
    get {
      int ret = CameraProPINVOKE.CameraInfo_errorCode_get(swigCPtr);
      return ret;
    } 
  }

  public string cameraName {
    get {
      string ret = CameraProPINVOKE.CameraInfo_cameraName_get(swigCPtr);
      if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public string cameraModel {
    set {
      CameraProPINVOKE.CameraInfo_cameraModel_set(swigCPtr, value);
      if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      string ret = CameraProPINVOKE.CameraInfo_cameraModel_get(swigCPtr);
      if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public string cameraIP {
    get {
      string ret = CameraProPINVOKE.CameraInfo_cameraIP_get(swigCPtr);
      if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public uint port {
    get {
        uint ret = CameraProPINVOKE.CameraInfo_port_get(swigCPtr);
        return ret;
    }
  }

    public string userIP {
    get {
      string ret = CameraProPINVOKE.CameraInfo_userIP_get(swigCPtr);
      if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public string serialNum {
    get {
      string ret = CameraProPINVOKE.CameraInfo_serialNum_get(swigCPtr);
      if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public string macAddr {
    get {
      string ret = CameraProPINVOKE.CameraInfo_macAddr_get(swigCPtr);
      if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  //camera system version
  public string cameraSystemVersion {
    get {
      string ret = CameraProPINVOKE.CameraInfo_cameraSystemVersion_get(swigCPtr);
      if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  //algorithm version
  public string algorithmVersion {
    get {
      string ret = CameraProPINVOKE.CameraInfo_algorithmVersion_get(swigCPtr);
      if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  //mems hardware version
  public string memsVersion {
    get {
      string ret = CameraProPINVOKE.CameraInfo_memsVersion_get(swigCPtr);
      if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  //camera OS version
  public string cameraOSVersion {
    get {
      string ret = CameraProPINVOKE.CameraInfo_cameraOSVersion_get(swigCPtr);
      if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  //user SDK version
  public string sdkVersion {
    get {
      string ret = CameraProPINVOKE.CameraInfo_sdkVersion_get(swigCPtr);
      if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  //0 is ok, other is bad.
  public int rgbStatus {
    get {
      int ret = CameraProPINVOKE.CameraInfo_rgbStatus_get(swigCPtr);
      return ret;
    } 
  }

  //"-999" is bad, other is mems's temperature
  public string memsStatus {
    get {
      string ret = CameraProPINVOKE.CameraInfo_memsStatus_get(swigCPtr);
      if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public bool isDHCP {
    get {
      bool ret = CameraProPINVOKE.CameraInfo_isDHCP_get(swigCPtr);
      return ret;
    } 
  }

  public string moduleID
  {
    get {
      string ret = CameraProPINVOKE.CameraInfo_moduleID_get(swigCPtr);
      if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }
  }

  public int algoType {
    get {
      int ret = CameraProPINVOKE.CameraInfo_algoType_get(swigCPtr);
      return ret;
    } 
  }

  public CameraParam camParam {
    set {
      CameraProPINVOKE.CameraInfo_camParam_set(swigCPtr, CameraParam.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = CameraProPINVOKE.CameraInfo_camParam_get(swigCPtr);
      CameraParam ret = (cPtr == global::System.IntPtr.Zero) ? null : new CameraParam(cPtr, false);
      return ret;
    } 
  }

  public OutputSettings outputSettings
  {
    set {
      CameraProPINVOKE.CameraInfo_outputSettings_set(swigCPtr, OutputSettings.getCPtr(value));
    }
    get {
      global::System.IntPtr cPtr = CameraProPINVOKE.CameraInfo_outputSettings_get(swigCPtr);
      OutputSettings ret = (cPtr == global::System.IntPtr.Zero) ? null : new OutputSettings(cPtr, false);
      return ret;
    }
  }

  public CameraInfo() : this(CameraProPINVOKE.new_CameraInfo(), true) {
  }

}

#region class OutputSettings
public class OutputSettings : global::System.IDisposable
{
    private global::System.Runtime.InteropServices.HandleRef swigCPtr;
    protected bool swigCMemOwn;

    internal OutputSettings(global::System.IntPtr cPtr, bool cMemoryOwn)
    {
        swigCMemOwn = cMemoryOwn;
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
    }

    internal static global::System.Runtime.InteropServices.HandleRef getCPtr(OutputSettings obj)
    {
        return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
    }

    ~OutputSettings()
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
                    CameraProPINVOKE.delete_OutputSettings(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
        }
    }

    public bool sendPoint3D
    {
        set
        {
            CameraProPINVOKE.OutputSettings_sendPoint3D_set(swigCPtr, value);
        }
        get
        {
            bool ret = CameraProPINVOKE.OutputSettings_sendPoint3D_get(swigCPtr);
            return ret;
        }
    }

    public bool sendPointUV
    {
        set
        {
            CameraProPINVOKE.OutputSettings_sendPointUV_set(swigCPtr, value);
        }
        get
        {
            bool ret = CameraProPINVOKE.OutputSettings_sendPointUV_get(swigCPtr);
            return ret;
        }
    }

    public bool sendTriangleIndices
    {
        set
        {
            CameraProPINVOKE.OutputSettings_sendTriangleIndices_set(swigCPtr, value);
        }
        get
        {
            bool ret = CameraProPINVOKE.OutputSettings_sendTriangleIndices_get(swigCPtr);
            return ret;
        }
    }

    public bool sendDepthmap
    {
        set
        {
            CameraProPINVOKE.OutputSettings_sendDepthmap_set(swigCPtr, value);
        }
        get
        {
            bool ret = CameraProPINVOKE.OutputSettings_sendDepthmap_get(swigCPtr);
            return ret;
        }
    }

    public bool sendNormals
    {
        set
        {
            CameraProPINVOKE.OutputSettings_sendNormals_set(swigCPtr, value);
        }
        get
        {
            bool ret = CameraProPINVOKE.OutputSettings_sendNormals_get(swigCPtr);
            return ret;
        }
    }

    public bool sendPointColor
    {
        set
        {
            CameraProPINVOKE.OutputSettings_sendPointColor_set(swigCPtr, value);
        }
        get
        {
            bool ret = CameraProPINVOKE.OutputSettings_sendPointColor_get(swigCPtr);
            return ret;
        }
    }

    public bool sendTexture
    {
        set
        {
            CameraProPINVOKE.OutputSettings_sendTexture_set(swigCPtr, value);
        }
        get
        {
            bool ret = CameraProPINVOKE.OutputSettings_sendTexture_get(swigCPtr);
            return ret;
        }
    }

    public bool sendRemapTexture
    {
        set
        {
            CameraProPINVOKE.OutputSettings_sendRemapTexture_set(swigCPtr, value);
        }
        get
        {
            bool ret = CameraProPINVOKE.OutputSettings_sendRemapTexture_get(swigCPtr);
            return ret;
        }
    }

    public OutputSettings() : this(CameraProPINVOKE.new_OutputSettings(), true)
    {
    }

}
#endregion

#region class CameraInfoVector
public class CameraInfoVector : global::System.IDisposable, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<CameraInfo>
{
    private global::System.Runtime.InteropServices.HandleRef swigCPtr;
    protected bool swigCMemOwn;

    internal CameraInfoVector(global::System.IntPtr cPtr, bool cMemoryOwn)
    {
        swigCMemOwn = cMemoryOwn;
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
    }

    internal static global::System.Runtime.InteropServices.HandleRef getCPtr(CameraInfoVector obj)
    {
        return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
    }

    ~CameraInfoVector()
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
                    CameraProPINVOKE.delete_CameraInfoVector(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
        }
    }

    public CameraInfoVector(global::System.Collections.IEnumerable c) : this()
    {
        if (c == null)
            throw new global::System.ArgumentNullException("c");
        foreach (CameraInfo element in c)
        {
            this.Add(element);
        }
    }

    public CameraInfoVector(global::System.Collections.Generic.IEnumerable<CameraInfo> c) : this()
    {
        if (c == null)
            throw new global::System.ArgumentNullException("c");
        foreach (CameraInfo element in c)
        {
            this.Add(element);
        }
    }

    public bool IsFixedSize
    {
        get
        {
            return false;
        }
    }

    public bool IsReadOnly
    {
        get
        {
            return false;
        }
    }

    public CameraInfo this[int index]
    {
        get
        {
            return getitem(index);
        }
        set
        {
            setitem(index, value);
        }
    }

    public int Capacity
    {
        get
        {
            return (int)capacity();
        }
        set
        {
            if (value < size())
                throw new global::System.ArgumentOutOfRangeException("Capacity");
            reserve((uint)value);
        }
    }

    public int Count
    {
        get
        {
            return (int)size();
        }
    }

    public bool IsSynchronized
    {
        get
        {
            return false;
        }
    }

    public void CopyTo(CameraInfo[] array)
    {
        CopyTo(0, array, 0, this.Count);
    }

    public void CopyTo(CameraInfo[] array, int arrayIndex)
    {
        CopyTo(0, array, arrayIndex, this.Count);
    }

    public void CopyTo(int index, CameraInfo[] array, int arrayIndex, int count)
    {
        if (array == null)
            throw new global::System.ArgumentNullException("array");
        if (index < 0)
            throw new global::System.ArgumentOutOfRangeException("index", "Value is less than zero");
        if (arrayIndex < 0)
            throw new global::System.ArgumentOutOfRangeException("arrayIndex", "Value is less than zero");
        if (count < 0)
            throw new global::System.ArgumentOutOfRangeException("count", "Value is less than zero");
        if (array.Rank > 1)
            throw new global::System.ArgumentException("Multi dimensional array.", "array");
        if (index + count > this.Count || arrayIndex + count > array.Length)
            throw new global::System.ArgumentException("Number of elements to copy is too large.");
        for (int i = 0; i < count; i++)
            array.SetValue(getitemcopy(index + i), arrayIndex + i);
    }

    public CameraInfo[] ToArray()
    {
        CameraInfo[] array = new CameraInfo[this.Count];
        this.CopyTo(array);
        return array;
    }

    global::System.Collections.Generic.IEnumerator<CameraInfo> global::System.Collections.Generic.IEnumerable<CameraInfo>.GetEnumerator()
    {
        return new CameraInfoVectorEnumerator(this);
    }

    global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
    {
        return new CameraInfoVectorEnumerator(this);
    }

    public CameraInfoVectorEnumerator GetEnumerator()
    {
        return new CameraInfoVectorEnumerator(this);
    }

    // Type-safe enumerator
    /// Note that the IEnumerator documentation requires an InvalidOperationException to be thrown
    /// whenever the collection is modified. This has been done for changes in the size of the
    /// collection but not when one of the elements of the collection is modified as it is a bit
    /// tricky to detect unmanaged code that modifies the collection under our feet.
    public sealed class CameraInfoVectorEnumerator : global::System.Collections.IEnumerator
      , global::System.Collections.Generic.IEnumerator<CameraInfo>
    {
        private CameraInfoVector collectionRef;
        private int currentIndex;
        private object currentObject;
        private int currentSize;

        public CameraInfoVectorEnumerator(CameraInfoVector collection)
        {
            collectionRef = collection;
            currentIndex = -1;
            currentObject = null;
            currentSize = collectionRef.Count;
        }

        // Type-safe iterator Current
        public CameraInfo Current
        {
            get
            {
                if (currentIndex == -1)
                    throw new global::System.InvalidOperationException("Enumeration not started.");
                if (currentIndex > currentSize - 1)
                    throw new global::System.InvalidOperationException("Enumeration finished.");
                if (currentObject == null)
                    throw new global::System.InvalidOperationException("Collection modified.");
                return (CameraInfo)currentObject;
            }
        }

        // Type-unsafe IEnumerator.Current
        object global::System.Collections.IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public bool MoveNext()
        {
            int size = collectionRef.Count;
            bool moveOkay = (currentIndex + 1 < size) && (size == currentSize);
            if (moveOkay)
            {
                currentIndex++;
                currentObject = collectionRef[currentIndex];
            }
            else
            {
                currentObject = null;
            }
            return moveOkay;
        }

        public void Reset()
        {
            currentIndex = -1;
            currentObject = null;
            if (collectionRef.Count != currentSize)
            {
                throw new global::System.InvalidOperationException("Collection modified.");
            }
        }

        public void Dispose()
        {
            currentIndex = -1;
            currentObject = null;
        }
    }

    public void Clear()
    {
        CameraProPINVOKE.CameraInfoVector_Clear(swigCPtr);
    }

    public void Add(CameraInfo x)
    {
        CameraProPINVOKE.CameraInfoVector_Add(swigCPtr, CameraInfo.getCPtr(x));
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    private uint size()
    {
        uint ret = CameraProPINVOKE.CameraInfoVector_size(swigCPtr);
        return ret;
    }

    private uint capacity()
    {
        uint ret = CameraProPINVOKE.CameraInfoVector_capacity(swigCPtr);
        return ret;
    }

    private void reserve(uint n)
    {
        CameraProPINVOKE.CameraInfoVector_reserve(swigCPtr, n);
    }

    public CameraInfoVector() : this(CameraProPINVOKE.new_CameraInfoVector__SWIG_0(), true)
    {
    }

    public CameraInfoVector(CameraInfoVector other) : this(CameraProPINVOKE.new_CameraInfoVector__SWIG_1(CameraInfoVector.getCPtr(other)), true)
    {
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    public CameraInfoVector(int capacity) : this(CameraProPINVOKE.new_CameraInfoVector__SWIG_2(capacity), true)
    {
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    private CameraInfo getitemcopy(int index)
    {
        CameraInfo ret = new CameraInfo(CameraProPINVOKE.CameraInfoVector_getitemcopy(swigCPtr, index), true);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
        return ret;
    }

    private CameraInfo getitem(int index)
    {
        CameraInfo ret = new CameraInfo(CameraProPINVOKE.CameraInfoVector_getitem(swigCPtr, index), false);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
        return ret;
    }

    private void setitem(int index, CameraInfo val)
    {
        CameraProPINVOKE.CameraInfoVector_setitem(swigCPtr, index, CameraInfo.getCPtr(val));
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    public void AddRange(CameraInfoVector values)
    {
        CameraProPINVOKE.CameraInfoVector_AddRange(swigCPtr, CameraInfoVector.getCPtr(values));
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    public CameraInfoVector GetRange(int index, int count)
    {
        global::System.IntPtr cPtr = CameraProPINVOKE.CameraInfoVector_GetRange(swigCPtr, index, count);
        CameraInfoVector ret = (cPtr == global::System.IntPtr.Zero) ? null : new CameraInfoVector(cPtr, true);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
        return ret;
    }

    public void Insert(int index, CameraInfo x)
    {
        CameraProPINVOKE.CameraInfoVector_Insert(swigCPtr, index, CameraInfo.getCPtr(x));
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    public void InsertRange(int index, CameraInfoVector values)
    {
        CameraProPINVOKE.CameraInfoVector_InsertRange(swigCPtr, index, CameraInfoVector.getCPtr(values));
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    public void RemoveAt(int index)
    {
        CameraProPINVOKE.CameraInfoVector_RemoveAt(swigCPtr, index);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    public void RemoveRange(int index, int count)
    {
        CameraProPINVOKE.CameraInfoVector_RemoveRange(swigCPtr, index, count);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    public static CameraInfoVector Repeat(CameraInfo value, int count)
    {
        global::System.IntPtr cPtr = CameraProPINVOKE.CameraInfoVector_Repeat(CameraInfo.getCPtr(value), count);
        CameraInfoVector ret = (cPtr == global::System.IntPtr.Zero) ? null : new CameraInfoVector(cPtr, true);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
        return ret;
    }

    public void Reverse()
    {
        CameraProPINVOKE.CameraInfoVector_Reverse__SWIG_0(swigCPtr);
    }

    public void Reverse(int index, int count)
    {
        CameraProPINVOKE.CameraInfoVector_Reverse__SWIG_1(swigCPtr, index, count);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    public void SetRange(int index, CameraInfoVector values)
    {
        CameraProPINVOKE.CameraInfoVector_SetRange(swigCPtr, index, CameraInfoVector.getCPtr(values));
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

}
#endregion
