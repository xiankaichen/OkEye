#region Point2f
using System;

public class Point2f : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal Point2f(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Point2f obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~Point2f() {
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
          CameraProPINVOKE.delete_Point2f(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public float x {
    set {
      CameraProPINVOKE.Point2f_x_set(swigCPtr, value);
    } 
    get {
      float ret = CameraProPINVOKE.Point2f_x_get(swigCPtr);
      return ret;
    } 
  }

  public float y {
    set {
      CameraProPINVOKE.Point2f_y_set(swigCPtr, value);
    } 
    get {
      float ret = CameraProPINVOKE.Point2f_y_get(swigCPtr);
      return ret;
    } 
  }

  public Point2f() : this(CameraProPINVOKE.new_Point2f(), true) {
  }

  public Point2f(float x, float y) : this(CameraProPINVOKE.new_Point2f(), true) {
    CameraProPINVOKE.Point2f_x_set(swigCPtr, x);
    CameraProPINVOKE.Point2f_y_set(swigCPtr, y);
  }

  public Point2f(double x, double y) : this(CameraProPINVOKE.new_Point2f(), true) {
    CameraProPINVOKE.Point2f_x_set(swigCPtr, (float)x);
    CameraProPINVOKE.Point2f_y_set(swigCPtr, (float)y);
  }

}
#endregion

#region Point3f
public class Point3f : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal Point3f(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Point3f obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~Point3f() {
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
          CameraProPINVOKE.delete_Point3f(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public float x {
    set {
      CameraProPINVOKE.Point3f_x_set(swigCPtr, value);
    } 
    get {
      float ret = CameraProPINVOKE.Point3f_x_get(swigCPtr);
      return ret;
    } 
  }

  public float y {
    set {
      CameraProPINVOKE.Point3f_y_set(swigCPtr, value);
    } 
    get {
      float ret = CameraProPINVOKE.Point3f_y_get(swigCPtr);
      return ret;
    } 
  }

  public float z {
    set {
      CameraProPINVOKE.Point3f_z_set(swigCPtr, value);
    } 
    get {
      float ret = CameraProPINVOKE.Point3f_z_get(swigCPtr);
      return ret;
    } 
  }

  public Point3f() : this(CameraProPINVOKE.new_Point3f(), true) {
  }

}
#endregion

#region Point2fVector
public class Point2fVector : global::System.IDisposable, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<Point2f>
 {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal Point2fVector(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Point2fVector obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~Point2fVector() {
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
          CameraProPINVOKE.delete_Point2fVector(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public Point2fVector(global::System.Collections.IEnumerable c) : this() {
    if (c == null)
      throw new global::System.ArgumentNullException("c");
    foreach (Point2f element in c) {
      this.Add(element);
    }
  }

  public Point2fVector(global::System.Collections.Generic.IEnumerable<Point2f> c) : this() {
    if (c == null)
      throw new global::System.ArgumentNullException("c");
    foreach (Point2f element in c) {
      this.Add(element);
    }
  }

  public bool IsFixedSize {
    get {
      return false;
    }
  }

  public bool IsReadOnly {
    get {
      return false;
    }
  }

  public Point2f this[int index]  {
    get {
      return getitem(index);
    }
    set {
      setitem(index, value);
    }
  }

  public int Capacity {
    get {
      return (int)capacity();
    }
    set {
      if (value < size())
        throw new global::System.ArgumentOutOfRangeException("Capacity");
      reserve((uint)value);
    }
  }

  public int Count {
    get {
      return (int)size();
    }
  }

  public bool IsSynchronized {
    get {
      return false;
    }
  }

  public void CopyTo(Point2f[] array)
  {
    CopyTo(0, array, 0, this.Count);
  }

  public void CopyTo(Point2f[] array, int arrayIndex)
  {
    CopyTo(0, array, arrayIndex, this.Count);
  }

  public void CopyTo(int index, Point2f[] array, int arrayIndex, int count)
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
    if (index+count > this.Count || arrayIndex+count > array.Length)
      throw new global::System.ArgumentException("Number of elements to copy is too large.");
    for (int i=0; i<count; i++)
      array.SetValue(getitemcopy(index+i), arrayIndex+i);
  }

  public Point2f[] ToArray() {
    Point2f[] array = new Point2f[this.Count];
    this.CopyTo(array);
    return array;
  }

  global::System.Collections.Generic.IEnumerator<Point2f> global::System.Collections.Generic.IEnumerable<Point2f>.GetEnumerator() {
    return new Point2fVectorEnumerator(this);
  }

  global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator() {
    return new Point2fVectorEnumerator(this);
  }

  public Point2fVectorEnumerator GetEnumerator() {
    return new Point2fVectorEnumerator(this);
  }

  // Type-safe enumerator
  /// Note that the IEnumerator documentation requires an InvalidOperationException to be thrown
  /// whenever the collection is modified. This has been done for changes in the size of the
  /// collection but not when one of the elements of the collection is modified as it is a bit
  /// tricky to detect unmanaged code that modifies the collection under our feet.
  public sealed class Point2fVectorEnumerator : global::System.Collections.IEnumerator
    , global::System.Collections.Generic.IEnumerator<Point2f>
  {
    private Point2fVector collectionRef;
    private int currentIndex;
    private object currentObject;
    private int currentSize;

    public Point2fVectorEnumerator(Point2fVector collection) {
      collectionRef = collection;
      currentIndex = -1;
      currentObject = null;
      currentSize = collectionRef.Count;
    }

    // Type-safe iterator Current
    public Point2f Current {
      get {
        if (currentIndex == -1)
          throw new global::System.InvalidOperationException("Enumeration not started.");
        if (currentIndex > currentSize - 1)
          throw new global::System.InvalidOperationException("Enumeration finished.");
        if (currentObject == null)
          throw new global::System.InvalidOperationException("Collection modified.");
        return (Point2f)currentObject;
      }
    }

    // Type-unsafe IEnumerator.Current
    object global::System.Collections.IEnumerator.Current {
      get {
        return Current;
      }
    }

    public bool MoveNext() {
      int size = collectionRef.Count;
      bool moveOkay = (currentIndex+1 < size) && (size == currentSize);
      if (moveOkay) {
        currentIndex++;
        currentObject = collectionRef[currentIndex];
      } else {
        currentObject = null;
      }
      return moveOkay;
    }

    public void Reset() {
      currentIndex = -1;
      currentObject = null;
      if (collectionRef.Count != currentSize) {
        throw new global::System.InvalidOperationException("Collection modified.");
      }
    }

    public void Dispose() {
        currentIndex = -1;
        currentObject = null;
    }
  }

  public void Clear() {
    CameraProPINVOKE.Point2fVector_Clear(swigCPtr);
  }

  public void Add(Point2f x) {
    CameraProPINVOKE.Point2fVector_Add(swigCPtr, Point2f.getCPtr(x));
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
  }

  private uint size() {
    uint ret = CameraProPINVOKE.Point2fVector_size(swigCPtr);
    return ret;
  }

  private uint capacity() {
    uint ret = CameraProPINVOKE.Point2fVector_capacity(swigCPtr);
    return ret;
  }

  private void reserve(uint n) {
    CameraProPINVOKE.Point2fVector_reserve(swigCPtr, n);
  }

  public Point2fVector() : this(CameraProPINVOKE.new_Point2fVector__SWIG_0(), true) {
  }

  public Point2fVector(Point2fVector other) : this(CameraProPINVOKE.new_Point2fVector__SWIG_1(Point2fVector.getCPtr(other)), true) {
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
  }

  public Point2fVector(int capacity) : this(CameraProPINVOKE.new_Point2fVector__SWIG_2(capacity), true) {
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
  }

  private Point2f getitemcopy(int index) {
    Point2f ret = new Point2f(CameraProPINVOKE.Point2fVector_getitemcopy(swigCPtr, index), true);
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private Point2f getitem(int index) {
    Point2f ret = new Point2f(CameraProPINVOKE.Point2fVector_getitem(swigCPtr, index), false);
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private void setitem(int index, Point2f val) {
    CameraProPINVOKE.Point2fVector_setitem(swigCPtr, index, Point2f.getCPtr(val));
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
  }

  public void AddRange(Point2fVector values) {
    CameraProPINVOKE.Point2fVector_AddRange(swigCPtr, Point2fVector.getCPtr(values));
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
  }

  public Point2fVector GetRange(int index, int count) {
    global::System.IntPtr cPtr = CameraProPINVOKE.Point2fVector_GetRange(swigCPtr, index, count);
    Point2fVector ret = (cPtr == global::System.IntPtr.Zero) ? null : new Point2fVector(cPtr, true);
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void Insert(int index, Point2f x) {
    CameraProPINVOKE.Point2fVector_Insert(swigCPtr, index, Point2f.getCPtr(x));
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
  }

  public void InsertRange(int index, Point2fVector values) {
    CameraProPINVOKE.Point2fVector_InsertRange(swigCPtr, index, Point2fVector.getCPtr(values));
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
  }

  public void RemoveAt(int index) {
    CameraProPINVOKE.Point2fVector_RemoveAt(swigCPtr, index);
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
  }

  public void RemoveRange(int index, int count) {
    CameraProPINVOKE.Point2fVector_RemoveRange(swigCPtr, index, count);
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
  }

  public static Point2fVector Repeat(Point2f value, int count) {
    global::System.IntPtr cPtr = CameraProPINVOKE.Point2fVector_Repeat(Point2f.getCPtr(value), count);
    Point2fVector ret = (cPtr == global::System.IntPtr.Zero) ? null : new Point2fVector(cPtr, true);
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void Reverse() {
    CameraProPINVOKE.Point2fVector_Reverse__SWIG_0(swigCPtr);
  }

  public void Reverse(int index, int count) {
    CameraProPINVOKE.Point2fVector_Reverse__SWIG_1(swigCPtr, index, count);
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
  }

  public void SetRange(int index, Point2fVector values) {
    CameraProPINVOKE.Point2fVector_SetRange(swigCPtr, index, Point2fVector.getCPtr(values));
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
  }

}
#endregion

#region Point3fVector
public class Point3fVector : global::System.IDisposable, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<Point3f>
 {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal Point3fVector(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Point3fVector obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~Point3fVector() {
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
          CameraProPINVOKE.delete_Point3fVector(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public Point3fVector(global::System.Collections.IEnumerable c) : this() {
    if (c == null)
      throw new global::System.ArgumentNullException("c");
    foreach (Point3f element in c) {
      this.Add(element);
    }
  }

  public Point3fVector(global::System.Collections.Generic.IEnumerable<Point3f> c) : this() {
    if (c == null)
      throw new global::System.ArgumentNullException("c");
    foreach (Point3f element in c) {
      this.Add(element);
    }
  }

  public bool IsFixedSize {
    get {
      return false;
    }
  }

  public bool IsReadOnly {
    get {
      return false;
    }
  }

  public Point3f this[int index]  {
    get {
      return getitem(index);
    }
    set {
      setitem(index, value);
    }
  }

  public int Capacity {
    get {
      return (int)capacity();
    }
    set {
      if (value < size())
        throw new global::System.ArgumentOutOfRangeException("Capacity");
      reserve((uint)value);
    }
  }

  public int Count {
    get {
      return (int)size();
    }
  }

  public bool IsSynchronized {
    get {
      return false;
    }
  }

  public void CopyTo(Point3f[] array)
  {
    CopyTo(0, array, 0, this.Count);
  }

  public void CopyTo(Point3f[] array, int arrayIndex)
  {
    CopyTo(0, array, arrayIndex, this.Count);
  }

  public void CopyTo(int index, Point3f[] array, int arrayIndex, int count)
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
    if (index+count > this.Count || arrayIndex+count > array.Length)
      throw new global::System.ArgumentException("Number of elements to copy is too large.");
    for (int i=0; i<count; i++)
      array.SetValue(getitemcopy(index+i), arrayIndex+i);
  }

  public Point3f[] ToArray() {
    Point3f[] array = new Point3f[this.Count];
    this.CopyTo(array);
    return array;
  }

  global::System.Collections.Generic.IEnumerator<Point3f> global::System.Collections.Generic.IEnumerable<Point3f>.GetEnumerator() {
    return new Point3fVectorEnumerator(this);
  }

  global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator() {
    return new Point3fVectorEnumerator(this);
  }

  public Point3fVectorEnumerator GetEnumerator() {
    return new Point3fVectorEnumerator(this);
  }

  // Type-safe enumerator
  /// Note that the IEnumerator documentation requires an InvalidOperationException to be thrown
  /// whenever the collection is modified. This has been done for changes in the size of the
  /// collection but not when one of the elements of the collection is modified as it is a bit
  /// tricky to detect unmanaged code that modifies the collection under our feet.
  public sealed class Point3fVectorEnumerator : global::System.Collections.IEnumerator
    , global::System.Collections.Generic.IEnumerator<Point3f>
  {
    private Point3fVector collectionRef;
    private int currentIndex;
    private object currentObject;
    private int currentSize;

    public Point3fVectorEnumerator(Point3fVector collection) {
      collectionRef = collection;
      currentIndex = -1;
      currentObject = null;
      currentSize = collectionRef.Count;
    }

    // Type-safe iterator Current
    public Point3f Current {
      get {
        if (currentIndex == -1)
          throw new global::System.InvalidOperationException("Enumeration not started.");
        if (currentIndex > currentSize - 1)
          throw new global::System.InvalidOperationException("Enumeration finished.");
        if (currentObject == null)
          throw new global::System.InvalidOperationException("Collection modified.");
        return (Point3f)currentObject;
      }
    }

    // Type-unsafe IEnumerator.Current
    object global::System.Collections.IEnumerator.Current {
      get {
        return Current;
      }
    }

    public bool MoveNext() {
      int size = collectionRef.Count;
      bool moveOkay = (currentIndex+1 < size) && (size == currentSize);
      if (moveOkay) {
        currentIndex++;
        currentObject = collectionRef[currentIndex];
      } else {
        currentObject = null;
      }
      return moveOkay;
    }

    public void Reset() {
      currentIndex = -1;
      currentObject = null;
      if (collectionRef.Count != currentSize) {
        throw new global::System.InvalidOperationException("Collection modified.");
      }
    }

    public void Dispose() {
        currentIndex = -1;
        currentObject = null;
    }
  }

  public void Clear() {
    CameraProPINVOKE.Point3fVector_Clear(swigCPtr);
  }

  public void Add(Point3f x) {
    CameraProPINVOKE.Point3fVector_Add(swigCPtr, Point3f.getCPtr(x));
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
  }

  private uint size() {
    uint ret = CameraProPINVOKE.Point3fVector_size(swigCPtr);
    return ret;
  }

  private uint capacity() {
    uint ret = CameraProPINVOKE.Point3fVector_capacity(swigCPtr);
    return ret;
  }

  private void reserve(uint n) {
    CameraProPINVOKE.Point3fVector_reserve(swigCPtr, n);
  }

  public Point3fVector() : this(CameraProPINVOKE.new_Point3fVector__SWIG_0(), true) {
  }

  public Point3fVector(Point3fVector other) : this(CameraProPINVOKE.new_Point3fVector__SWIG_1(Point3fVector.getCPtr(other)), true) {
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
  }

  public Point3fVector(int capacity) : this(CameraProPINVOKE.new_Point3fVector__SWIG_2(capacity), true) {
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
  }

  private Point3f getitemcopy(int index) {
    Point3f ret = new Point3f(CameraProPINVOKE.Point3fVector_getitemcopy(swigCPtr, index), true);
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private Point3f getitem(int index) {
    Point3f ret = new Point3f(CameraProPINVOKE.Point3fVector_getitem(swigCPtr, index), false);
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private void setitem(int index, Point3f val) {
    CameraProPINVOKE.Point3fVector_setitem(swigCPtr, index, Point3f.getCPtr(val));
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
  }

  public void AddRange(Point3fVector values) {
    CameraProPINVOKE.Point3fVector_AddRange(swigCPtr, Point3fVector.getCPtr(values));
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
  }

  public Point3fVector GetRange(int index, int count) {
    global::System.IntPtr cPtr = CameraProPINVOKE.Point3fVector_GetRange(swigCPtr, index, count);
    Point3fVector ret = (cPtr == global::System.IntPtr.Zero) ? null : new Point3fVector(cPtr, true);
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void Insert(int index, Point3f x) {
    CameraProPINVOKE.Point3fVector_Insert(swigCPtr, index, Point3f.getCPtr(x));
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
  }

  public void InsertRange(int index, Point3fVector values) {
    CameraProPINVOKE.Point3fVector_InsertRange(swigCPtr, index, Point3fVector.getCPtr(values));
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
  }

  public void RemoveAt(int index) {
    CameraProPINVOKE.Point3fVector_RemoveAt(swigCPtr, index);
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
  }

  public void RemoveRange(int index, int count) {
    CameraProPINVOKE.Point3fVector_RemoveRange(swigCPtr, index, count);
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
  }

  public static Point3fVector Repeat(Point3f value, int count) {
    global::System.IntPtr cPtr = CameraProPINVOKE.Point3fVector_Repeat(Point3f.getCPtr(value), count);
    Point3fVector ret = (cPtr == global::System.IntPtr.Zero) ? null : new Point3fVector(cPtr, true);
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void Reverse() {
    CameraProPINVOKE.Point3fVector_Reverse__SWIG_0(swigCPtr);
  }

  public void Reverse(int index, int count) {
    CameraProPINVOKE.Point3fVector_Reverse__SWIG_1(swigCPtr, index, count);
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
  }

  public void SetRange(int index, Point3fVector values) {
    CameraProPINVOKE.Point3fVector_SetRange(swigCPtr, index, Point3fVector.getCPtr(values));
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
  }

}
#endregion
