using System;
using System.Runtime.InteropServices;

class CameraProPINVOKE {

  protected class SWIGExceptionHelper {

    public delegate void ExceptionDelegate(string message);
    public delegate void ExceptionArgumentDelegate(string message, string paramName);

    static ExceptionDelegate applicationDelegate = new ExceptionDelegate(SetPendingApplicationException);
    static ExceptionDelegate arithmeticDelegate = new ExceptionDelegate(SetPendingArithmeticException);
    static ExceptionDelegate divideByZeroDelegate = new ExceptionDelegate(SetPendingDivideByZeroException);
    static ExceptionDelegate indexOutOfRangeDelegate = new ExceptionDelegate(SetPendingIndexOutOfRangeException);
    static ExceptionDelegate invalidCastDelegate = new ExceptionDelegate(SetPendingInvalidCastException);
    static ExceptionDelegate invalidOperationDelegate = new ExceptionDelegate(SetPendingInvalidOperationException);
    static ExceptionDelegate ioDelegate = new ExceptionDelegate(SetPendingIOException);
    static ExceptionDelegate nullReferenceDelegate = new ExceptionDelegate(SetPendingNullReferenceException);
    static ExceptionDelegate outOfMemoryDelegate = new ExceptionDelegate(SetPendingOutOfMemoryException);
    static ExceptionDelegate overflowDelegate = new ExceptionDelegate(SetPendingOverflowException);
    static ExceptionDelegate systemDelegate = new ExceptionDelegate(SetPendingSystemException);

    static ExceptionArgumentDelegate argumentDelegate = new ExceptionArgumentDelegate(SetPendingArgumentException);
    static ExceptionArgumentDelegate argumentNullDelegate = new ExceptionArgumentDelegate(SetPendingArgumentNullException);
    static ExceptionArgumentDelegate argumentOutOfRangeDelegate = new ExceptionArgumentDelegate(SetPendingArgumentOutOfRangeException);

    [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="SWIGRegisterExceptionCallbacks_CameraPro")]
    public static extern void SWIGRegisterExceptionCallbacks_CameraPro(
                                ExceptionDelegate applicationDelegate,
                                ExceptionDelegate arithmeticDelegate,
                                ExceptionDelegate divideByZeroDelegate, 
                                ExceptionDelegate indexOutOfRangeDelegate, 
                                ExceptionDelegate invalidCastDelegate,
                                ExceptionDelegate invalidOperationDelegate,
                                ExceptionDelegate ioDelegate,
                                ExceptionDelegate nullReferenceDelegate,
                                ExceptionDelegate outOfMemoryDelegate, 
                                ExceptionDelegate overflowDelegate, 
                                ExceptionDelegate systemExceptionDelegate);

    [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="SWIGRegisterExceptionArgumentCallbacks_CameraPro")]
    public static extern void SWIGRegisterExceptionCallbacksArgument_CameraPro(
                                ExceptionArgumentDelegate argumentDelegate,
                                ExceptionArgumentDelegate argumentNullDelegate,
                                ExceptionArgumentDelegate argumentOutOfRangeDelegate);

    static void SetPendingApplicationException(string message) {
      SWIGPendingException.Set(new global::System.ApplicationException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingArithmeticException(string message) {
      SWIGPendingException.Set(new global::System.ArithmeticException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingDivideByZeroException(string message) {
      SWIGPendingException.Set(new global::System.DivideByZeroException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingIndexOutOfRangeException(string message) {
      SWIGPendingException.Set(new global::System.IndexOutOfRangeException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingInvalidCastException(string message) {
      SWIGPendingException.Set(new global::System.InvalidCastException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingInvalidOperationException(string message) {
      SWIGPendingException.Set(new global::System.InvalidOperationException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingIOException(string message) {
      SWIGPendingException.Set(new global::System.IO.IOException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingNullReferenceException(string message) {
      SWIGPendingException.Set(new global::System.NullReferenceException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingOutOfMemoryException(string message) {
      SWIGPendingException.Set(new global::System.OutOfMemoryException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingOverflowException(string message) {
      SWIGPendingException.Set(new global::System.OverflowException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingSystemException(string message) {
      SWIGPendingException.Set(new global::System.SystemException(message, SWIGPendingException.Retrieve()));
    }

    static void SetPendingArgumentException(string message, string paramName) {
      SWIGPendingException.Set(new global::System.ArgumentException(message, paramName, SWIGPendingException.Retrieve()));
    }
    static void SetPendingArgumentNullException(string message, string paramName) {
      global::System.Exception e = SWIGPendingException.Retrieve();
      if (e != null) message = message + " Inner Exception: " + e.Message;
      SWIGPendingException.Set(new global::System.ArgumentNullException(paramName, message));
    }
    static void SetPendingArgumentOutOfRangeException(string message, string paramName) {
      global::System.Exception e = SWIGPendingException.Retrieve();
      if (e != null) message = message + " Inner Exception: " + e.Message;
      SWIGPendingException.Set(new global::System.ArgumentOutOfRangeException(paramName, message));
    }

    static SWIGExceptionHelper() {
      SWIGRegisterExceptionCallbacks_CameraPro(
                                applicationDelegate,
                                arithmeticDelegate,
                                divideByZeroDelegate,
                                indexOutOfRangeDelegate,
                                invalidCastDelegate,
                                invalidOperationDelegate,
                                ioDelegate,
                                nullReferenceDelegate,
                                outOfMemoryDelegate,
                                overflowDelegate,
                                systemDelegate);

      SWIGRegisterExceptionCallbacksArgument_CameraPro(
                                argumentDelegate,
                                argumentNullDelegate,
                                argumentOutOfRangeDelegate);
    }
  }

  protected static SWIGExceptionHelper swigExceptionHelper = new SWIGExceptionHelper();

  public class SWIGPendingException {
    [global::System.ThreadStatic]
    private static global::System.Exception pendingException = null;
    private static int numExceptionsPending = 0;
    private static global::System.Object exceptionsLock = null;

    public static bool Pending {
      get {
        bool pending = false;
        if (numExceptionsPending > 0)
          if (pendingException != null)
            pending = true;
        return pending;
      } 
    }

    public static void Set(global::System.Exception e) {
      if (pendingException != null)
        throw new global::System.ApplicationException("FATAL: An earlier pending exception from unmanaged code was missed and thus not thrown (" + pendingException.ToString() + ")", e);
      pendingException = e;
      lock(exceptionsLock) {
        numExceptionsPending++;
      }
    }

    public static global::System.Exception Retrieve() {
      global::System.Exception e = null;
      if (numExceptionsPending > 0) {
        if (pendingException != null) {
          e = pendingException;
          pendingException = null;
          lock(exceptionsLock) {
            numExceptionsPending--;
          }
        }
      }
      return e;
    }

    static SWIGPendingException() {
      exceptionsLock = new global::System.Object();
    }
  }


  protected class SWIGStringHelper {

    public delegate string SWIGStringDelegate(string message);
    static SWIGStringDelegate stringDelegate = new SWIGStringDelegate(CreateString);

    [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="SWIGRegisterStringCallback_CameraPro")]
    public static extern void SWIGRegisterStringCallback_CameraPro(SWIGStringDelegate stringDelegate);

    static string CreateString(string cString) {
      return cString;
    }

    static SWIGStringHelper() {
      SWIGRegisterStringCallback_CameraPro(stringDelegate);
    }
  }

  static protected SWIGStringHelper swigStringHelper = new SWIGStringHelper();


  static CameraProPINVOKE() {
  }

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_SUCCESS_get")]
  public static extern int AC_SUCCESS_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_OK_get")]
  public static extern int AC_OK_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_AC_E_UNKNOWN_get")]
  public static extern int AC_E_UNKNOWN_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_TIMEOUT_get")]
  public static extern int AC_E_TIMEOUT_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_NOT_SUPPORT_get")]
  public static extern int AC_E_NOT_SUPPORT_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_VERSION_get")]
  public static extern int AC_E_VERSION_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_LOGIC_get")]
  public static extern int AC_E_LOGIC_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_SET_get")]
  public static extern int AC_E_SET_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_GET_get")]
  public static extern int AC_E_GET_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_EXECUTE_get")]
  public static extern int AC_E_EXECUTE_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_BUSY_get")]
  public static extern int AC_E_BUSY_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_OFFLINE_get")]
  public static extern int AC_E_OFFLINE_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_NOT_EXIST_get")]
  public static extern int AC_E_NOT_EXIST_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_NOT_FOUND_get")]
  public static extern int AC_E_NOT_FOUND_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_INIT_get")]
  public static extern int AC_E_INIT_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_NOT_INIT_get")]
  public static extern int AC_E_NOT_INIT_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_OPEN_get")]
  public static extern int AC_E_OPEN_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_NOT_OPENED_get")]
  public static extern int AC_E_NOT_OPENED_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_NOT_READY_get")]
  public static extern int AC_E_NOT_READY_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_NO_PERMISSION_get")]
  public static extern int AC_E_NO_PERMISSION_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_USER_PASSWORD_get")]
  public static extern int AC_E_USER_PASSWORD_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_NO_KEY_get")]
  public static extern int AC_E_NO_KEY_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_LICENSE_OUT_OF_DATE_get")]
  public static extern int AC_E_LICENSE_OUT_OF_DATE_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_VERIFY_LICENSE_get")]
  public static extern int AC_E_VERIFY_LICENSE_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_EXCEED_MAXIMUM_CALL_FREQUENCY_get")]
  public static extern int AC_E_EXCEED_MAXIMUM_CALL_FREQUENCY_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_INVALID_HANDLE_get")]
  public static extern int AC_E_INVALID_HANDLE_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_INVALID_PARAM_get")]
  public static extern int AC_E_INVALID_PARAM_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_INVALID_LENGTH_get")]
  public static extern int AC_E_INVALID_LENGTH_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_NULL_PTR_get")]
  public static extern int AC_E_NULL_PTR_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_OUT_OF_RANGE_get")]
  public static extern int AC_E_OUT_OF_RANGE_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_TYPE_get")]
  public static extern int AC_E_TYPE_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_DATA_IS_EMPTY_get")]
  public static extern int AC_E_DATA_IS_EMPTY_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_DATA_SIZE_get")]
  public static extern int AC_E_DATA_SIZE_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_DATA_EXCEPTION_get")]
  public static extern int AC_E_DATA_EXCEPTION_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_VERIFICATION_get")]
  public static extern int AC_E_VERIFICATION_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_FORMAT_get")]
  public static extern int AC_E_FORMAT_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_COMPRESSION_get")]
  public static extern int AC_E_COMPRESSION_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_DECOMPRESSION_get")]
  public static extern int AC_E_DECOMPRESSION_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_FILE_NOT_EXIST_get")]
  public static extern int AC_E_FILE_NOT_EXIST_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_FILE_READ_get")]
  public static extern int AC_E_FILE_READ_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_FILE_WRITE_get")]
  public static extern int AC_E_FILE_WRITE_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_FILE_TYPE_get")]
  public static extern int AC_E_FILE_TYPE_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_FILE_CREATE_get")]
  public static extern int AC_E_FILE_CREATE_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_FILE_OPEN_get")]
  public static extern int AC_E_FILE_OPEN_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_NETWORK_get")]
  public static extern int AC_E_NETWORK_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_ADDRESS_UNREACHABLE_get")]
  public static extern int AC_E_ADDRESS_UNREACHABLE_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_IP_CONFLICT_get")]
  public static extern int AC_E_IP_CONFLICT_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_CONNECTION_get")]
  public static extern int AC_E_CONNECTION_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_ALREADY_DISCONNECTED_get")]
  public static extern int AC_E_ALREADY_DISCONNECTED_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_PARSE_PACKET_get")]
  public static extern int AC_E_PARSE_PACKET_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_ETH_NOT_LINK_get")]
  public static extern int AC_E_ETH_NOT_LINK_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_SLOW_TRANSMISSION_SPEED_get")]
  public static extern int AC_E_SLOW_TRANSMISSION_SPEED_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_READ_get")]
  public static extern int AC_E_READ_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_WRITE_get")]
  public static extern int AC_E_WRITE_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_NOT_ENOUGH_MEMORY_get")]
  public static extern int AC_E_NOT_ENOUGH_MEMORY_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_NOT_ENOUGH_DISK_SPACE_get")]
  public static extern int AC_E_NOT_ENOUGH_DISK_SPACE_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_IMAGE_IS_EMPTY_get")]
  public static extern int AC_E_IMAGE_IS_EMPTY_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_IMAGE_SIZE_get")]
  public static extern int AC_E_IMAGE_SIZE_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_IMAGE_FORMAT_get")]
  public static extern int AC_E_IMAGE_FORMAT_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_NUMBER_OF_IMAGES_get")]
  public static extern int AC_E_NUMBER_OF_IMAGES_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_NO_CAMERA_get")]
  public static extern int AC_E_NO_CAMERA_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_RECV_INCORRECT_get")]
  public static extern int AC_E_RECV_INCORRECT_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_VERSION_MISSMATCH_get")]
  public static extern int AC_E_VERSION_MISSMATCH_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_CAMERA_IS_INVALID_get")]
  public static extern int AC_E_CAMERA_IS_INVALID_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_TYPE_MISSMATCH_get")]
  public static extern int AC_E_TYPE_MISSMATCH_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_CMD_NOT_SUPPORT_get")]
  public static extern int AC_E_CMD_NOT_SUPPORT_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_DECOMPRESS_get")]
  public static extern int AC_E_DECOMPRESS_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_AC_E_NOT_EXSIT_get")]
  public static extern int AC_E_NOT_EXSIT_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_INFINITE_get")]
  public static extern int INFINITE_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_DEPTH_MAP_ALIGN_RGB_get")]
  public static extern int DEPTH_MAP_ALIGN_RGB_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_DEPTH_MAP_ALIGN_CAMERA_get")]
  public static extern int DEPTH_MAP_ALIGN_CAMERA_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_BINOCULAR_RECONSTRUCTION_get")]
  public static extern int BINOCULAR_RECONSTRUCTION_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_MONOCULAR_RECONSTRUCTION_get")]
  public static extern int MONOCULAR_RECONSTRUCTION_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameInfo_frameIndex_set")]
  public static extern void FrameInfo_frameIndex_set(global::System.Runtime.InteropServices.HandleRef jarg1, ulong jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameInfo_frameIndex_get")]
  public static extern ulong FrameInfo_frameIndex_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameInfo_frameTimestamp_set")]
  public static extern void FrameInfo_frameTimestamp_set(global::System.Runtime.InteropServices.HandleRef jarg1, double jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameInfo_frameTimestamp_get")]
  public static extern double FrameInfo_frameTimestamp_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameInfo_frameTotalDuration_set")]
  public static extern void FrameInfo_frameTotalDuration_set(global::System.Runtime.InteropServices.HandleRef jarg1, double jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameInfo_frameTotalDuration_get")]
  public static extern double FrameInfo_frameTotalDuration_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameInfo_frameAcquisitionDuration_set")]
  public static extern void FrameInfo_frameAcquisitionDuration_set(global::System.Runtime.InteropServices.HandleRef jarg1, double jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameInfo_frameAcquisitionDuration_get")]
  public static extern double FrameInfo_frameAcquisitionDuration_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameInfo_frameComputationDuration_set")]
  public static extern void FrameInfo_frameComputationDuration_set(global::System.Runtime.InteropServices.HandleRef jarg1, double jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameInfo_frameComputationDuration_get")]
  public static extern double FrameInfo_frameComputationDuration_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameInfo_frameTransferDuration_set")]
  public static extern void FrameInfo_frameTransferDuration_set(global::System.Runtime.InteropServices.HandleRef jarg1, double jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameInfo_frameTransferDuration_get")]
  public static extern double FrameInfo_frameTransferDuration_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_new_FrameInfo")]
  public static extern global::System.IntPtr new_FrameInfo();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_delete_FrameInfo")]
  public static extern void delete_FrameInfo(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_new_FrameData__SWIG_0")]
  public static extern global::System.IntPtr new_FrameData__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_delete_FrameData")]
  public static extern void delete_FrameData(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_new_FrameData__SWIG_1")]
  public static extern global::System.IntPtr new_FrameData__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameData_frameInfo_set")]
  public static extern void FrameData_frameInfo_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameData_frameInfo_get")]
  public static extern global::System.IntPtr FrameData_frameInfo_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameData_point3D_set")]
  public static extern void FrameData_point3D_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.IntPtr jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameData_point3D_get")]
  public static extern global::System.IntPtr FrameData_point3D_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameData_pointUV_set")]
  public static extern void FrameData_pointUV_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.IntPtr jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameData_pointUV_get")]
  public static extern global::System.IntPtr FrameData_pointUV_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameData_triangleIndices_set")]
  public static extern void FrameData_triangleIndices_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.IntPtr jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameData_triangleIndices_get")]
  unsafe public static extern global::System.IntPtr FrameData_triangleIndices_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameData_depthmap_set")]
  public static extern void FrameData_depthmap_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameData_depthmap_get")]
  public static extern global::System.IntPtr FrameData_depthmap_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameData_normals_set")]
  public static extern void FrameData_normals_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameData_normals_get")]
  public static extern global::System.IntPtr FrameData_normals_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameData_pointColor_set")]
  public static extern void FrameData_pointColor_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameData_pointColor_get")]
  public static extern global::System.IntPtr FrameData_pointColor_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameData_texture_set")]
  public static extern void FrameData_texture_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameData_texture_get")]
  public static extern global::System.IntPtr FrameData_texture_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameData_remapTexture_set")]
  public static extern void FrameData_remapTexture_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameData_remapTexture_get")]
  public static extern global::System.IntPtr FrameData_remapTexture_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameData_point3DSize_set")]
  public static extern void FrameData_point3DSize_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameData_point3DSize_get")]
  public static extern uint FrameData_point3DSize_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameData_pointUVSize_set")]
  public static extern void FrameData_pointUVSize_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameData_pointUVSize_get")]
  public static extern uint FrameData_pointUVSize_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameData_triangleIndicesSize_set")]
  public static extern void FrameData_triangleIndicesSize_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameData_triangleIndicesSize_get")]
  public static extern uint FrameData_triangleIndicesSize_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameData_depthmapSize_set")]
  public static extern void FrameData_depthmapSize_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameData_depthmapSize_get")]
  public static extern uint FrameData_depthmapSize_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameData_normalsSize_set")]
  public static extern void FrameData_normalsSize_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameData_normalsSize_get")]
  public static extern uint FrameData_normalsSize_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameData_pointColorSize_set")]
  public static extern void FrameData_pointColorSize_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameData_pointColorSize_get")]
  public static extern uint FrameData_pointColorSize_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameData_textureSize_set")]
  public static extern void FrameData_textureSize_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameData_textureSize_get")]
  public static extern uint FrameData_textureSize_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameData_pointCount_set")]
  public static extern void FrameData_pointCount_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameData_pointCount_get")]
  public static extern uint FrameData_pointCount_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameData_remapTextureSize_set")]
  public static extern void FrameData_remapTextureSize_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameData_remapTextureSize_get")]
  public static extern uint FrameData_remapTextureSize_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_OutputSettings_sendPoint3D_set")]
  public static extern void OutputSettings_sendPoint3D_set(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_OutputSettings_sendPoint3D_get")]
  public static extern bool OutputSettings_sendPoint3D_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_OutputSettings_sendPointUV_set")]
  public static extern void OutputSettings_sendPointUV_set(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_OutputSettings_sendPointUV_get")]
  public static extern bool OutputSettings_sendPointUV_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_OutputSettings_sendTriangleIndices_set")]
  public static extern void OutputSettings_sendTriangleIndices_set(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_OutputSettings_sendTriangleIndices_get")]
  public static extern bool OutputSettings_sendTriangleIndices_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_OutputSettings_sendDepthmap_set")]
  public static extern void OutputSettings_sendDepthmap_set(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_OutputSettings_sendDepthmap_get")]
  public static extern bool OutputSettings_sendDepthmap_get(global::System.Runtime.InteropServices.HandleRef jarg1);
  
  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_OutputSettings_sendNormals_set")]
  public static extern void OutputSettings_sendNormals_set(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_OutputSettings_sendNormals_get")]
  public static extern bool OutputSettings_sendNormals_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_OutputSettings_sendPointColor_set")]
  public static extern void OutputSettings_sendPointColor_set(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_OutputSettings_sendPointColor_get")]
  public static extern bool OutputSettings_sendPointColor_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_OutputSettings_sendTexture_set")]
  public static extern void OutputSettings_sendTexture_set(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_OutputSettings_sendTexture_get")]
  public static extern bool OutputSettings_sendTexture_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_OutputSettings_sendRemapTexture_set")]
  public static extern void OutputSettings_sendRemapTexture_set(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_OutputSettings_sendRemapTexture_get")]
  public static extern bool OutputSettings_sendRemapTexture_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_new_OutputSettings")]
  public static extern global::System.IntPtr new_OutputSettings();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_delete_OutputSettings")]
  public static extern void delete_OutputSettings(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraParam_textureWidth_set")]
  public static extern void CameraParam_textureWidth_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraParam_textureWidth_get")]
  public static extern int CameraParam_textureWidth_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraParam_textureHeight_set")]
  public static extern void CameraParam_textureHeight_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraParam_textureHeight_get")]
  public static extern int CameraParam_textureHeight_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraParam_irWidth_set")]
  public static extern void CameraParam_irWidth_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraParam_irWidth_get")]
  public static extern int CameraParam_irWidth_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraParam_irHeight_set")]
  public static extern void CameraParam_irHeight_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraParam_irHeight_get")]
  public static extern int CameraParam_irHeight_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraParam_irPerNum_set")]
  public static extern void CameraParam_irPerNum_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraParam_irPerNum_get")]
  public static extern int CameraParam_irPerNum_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraParam_hdrCnt_set")]
  public static extern void CameraParam_hdrCnt_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraParam_hdrCnt_get")]
  public static extern int CameraParam_hdrCnt_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraParam_pixelBytes_set")]
  public static extern void CameraParam_pixelBytes_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraParam_pixelBytes_get")]
  public static extern int CameraParam_pixelBytes_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraParam_depthType_set")]
  public static extern void CameraParam_depthType_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraParam_depthType_get")]
  public static extern int CameraParam_depthType_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraParam_reconstructionType_set")]
  public static extern void CameraParam_reconstructionType_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraParam_reconstructionType_get")]
  public static extern int CameraParam_reconstructionType_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_new_CameraParam")]
  public static extern global::System.IntPtr new_CameraParam();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_delete_CameraParam")]
  public static extern void delete_CameraParam(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_errorCode_set")]
  public static extern void CameraInfo_errorCode_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_errorCode_get")]
  public static extern int CameraInfo_errorCode_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_cameraName_set")]
  public static extern void CameraInfo_cameraName_set(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_cameraName_get")]
  public static extern string CameraInfo_cameraName_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_cameraModel_set")]
  public static extern void CameraInfo_cameraModel_set(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_cameraModel_get")]
  public static extern string CameraInfo_cameraModel_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_cameraIP_set")]
  public static extern void CameraInfo_cameraIP_set(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_cameraIP_get")]
  public static extern string CameraInfo_cameraIP_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_port_set")]
  public static extern void CameraInfo_port_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_port_get")]
  public static extern uint CameraInfo_port_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_userIP_set")]
  public static extern void CameraInfo_userIP_set(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_userIP_get")]
  public static extern string CameraInfo_userIP_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_serialNum_set")]
  public static extern void CameraInfo_serialNum_set(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_serialNum_get")]
  public static extern string CameraInfo_serialNum_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_macAddr_set")]
  public static extern void CameraInfo_macAddr_set(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_macAddr_get")]
  public static extern string CameraInfo_macAddr_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_cameraSystemVersion_set")]
  public static extern void CameraInfo_cameraSystemVersion_set(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_cameraSystemVersion_get")]
  public static extern string CameraInfo_cameraSystemVersion_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_algorithmVersion_set")]
  public static extern void CameraInfo_algorithmVersion_set(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_algorithmVersion_get")]
  public static extern string CameraInfo_algorithmVersion_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_memsVersion_set")]
  public static extern void CameraInfo_memsVersion_set(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_memsVersion_get")]
  public static extern string CameraInfo_memsVersion_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_cameraOSVersion_set")]
  public static extern void CameraInfo_cameraOSVersion_set(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_cameraOSVersion_get")]
  public static extern string CameraInfo_cameraOSVersion_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_sdkVersion_set")]
  public static extern void CameraInfo_sdkVersion_set(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_sdkVersion_get")]
  public static extern string CameraInfo_sdkVersion_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_rgbStatus_set")]
  public static extern void CameraInfo_rgbStatus_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_rgbStatus_get")]
  public static extern int CameraInfo_rgbStatus_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_memsStatus_set")]
  public static extern void CameraInfo_memsStatus_set(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_memsStatus_get")]
  public static extern string CameraInfo_memsStatus_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_isDHCP_set")]
  public static extern void CameraInfo_isDHCP_set(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_isDHCP_get")]
  public static extern bool CameraInfo_isDHCP_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_moduleID_set")]
  public static extern void CameraInfo_moduleID_set(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_moduleID_get")]
  public static extern string CameraInfo_moduleID_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_algoType_set")]
  public static extern void CameraInfo_algoType_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_algoType_get")]
  public static extern int CameraInfo_algoType_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_camParam_set")]
  public static extern void CameraInfo_camParam_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_camParam_get")]
  public static extern global::System.IntPtr CameraInfo_camParam_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_outputSettings_set")]
  public static extern void CameraInfo_outputSettings_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfo_outputSettings_get")]
  public static extern global::System.IntPtr CameraInfo_outputSettings_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_new_CameraInfo")]
  public static extern global::System.IntPtr new_CameraInfo();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_delete_CameraInfo")]
  public static extern void delete_CameraInfo(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_delete_ErrorCodeHandler")]
  public static extern void delete_ErrorCodeHandler(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_ErrorCodeHandler_Handle")]
  public static extern void ErrorCodeHandler_Handle(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_ErrorCodeHandler_HandleSwigExplicitErrorCodeHandler")]
  public static extern void ErrorCodeHandler_HandleSwigExplicitErrorCodeHandler(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_new_ErrorCodeHandler")]
  public static extern global::System.IntPtr new_ErrorCodeHandler();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_ErrorCodeHandler_director_connect")]
  public static extern void ErrorCodeHandler_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, ErrorCodeHandler.SwigDelegateErrorCodeHandler_0 delegate0);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_delete_FrameDataHandler")]
  public static extern void delete_FrameDataHandler(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameDataHandler_Handle")]
  public static extern void FrameDataHandler_Handle(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameDataHandler_HandleSwigExplicitFrameDataHandler")]
  public static extern void FrameDataHandler_HandleSwigExplicitFrameDataHandler(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_new_FrameDataHandler")]
  public static extern global::System.IntPtr new_FrameDataHandler();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameDataHandler_director_connect")]
  public static extern void FrameDataHandler_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, FrameDataHandler.SwigDelegateFrameDataHandler_0 delegate0);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point3f_x_set")]
  public static extern void Point3f_x_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point3f_x_get")]
  public static extern float Point3f_x_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point3f_y_set")]
  public static extern void Point3f_y_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point3f_y_get")]
  public static extern float Point3f_y_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point3f_z_set")]
  public static extern void Point3f_z_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point3f_z_get")]
  public static extern float Point3f_z_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_new_Point3f")]
  public static extern global::System.IntPtr new_Point3f();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_delete_Point3f")]
  public static extern void delete_Point3f(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point2f_x_set")]
  public static extern void Point2f_x_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point2f_x_get")]
  public static extern float Point2f_x_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point2f_y_set")]
  public static extern void Point2f_y_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point2f_y_get")]
  public static extern float Point2f_y_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_new_Point2f")]
  public static extern global::System.IntPtr new_Point2f();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_delete_Point2f")]
  public static extern void delete_Point2f(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Camera_DiscoverCameras__SWIG_0")]
  public static extern int Camera_DiscoverCameras__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, uint jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Camera_DiscoverCameras__SWIG_1")]
  public static extern int Camera_DiscoverCameras__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Camera_Open__SWIG_0")]
  public static extern int Camera_Open__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, uint jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Camera_Open__SWIG_1")]
  public static extern int Camera_Open__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Camera_Capture")]
  public static extern int Camera_Capture(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Camera_RegisterErrorCodeHandler")]
  public static extern void Camera_RegisterErrorCodeHandler(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Camera_RegisterFrameDataHandler__SWIG_0")]
  public static extern void Camera_RegisterFrameDataHandler__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, uint jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Camera_RegisterFrameDataHandler__SWIG_1")]
  public static extern void Camera_RegisterFrameDataHandler__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Camera_CaptureDataAsync")]
  public static extern int Camera_CaptureDataAsync(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Camera_SetCameraIP")]
  public static extern void Camera_SetCameraIP(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, string jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Camera_SetCameraToDHCP")]
  public static extern void Camera_SetCameraToDHCP(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Camera_CameraGetStatus")]
  public static extern int Camera_CameraGetStatus(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Camera_SetValue__SWIG_0")]
  public static extern int Camera_SetValue__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, int jarg4);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Camera_GetValue__SWIG_0")]
  public static extern int Camera_GetValue__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, ref int jarg4);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Camera_SetValue__SWIG_1")]
  public static extern int Camera_SetValue__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, float jarg4);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Camera_GetValue__SWIG_1")]
  public static extern int Camera_GetValue__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, ref float jarg4);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Camera_SendMemsCommands")]
  public static extern int Camera_SendMemsCommands(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, string jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Camera_SendAndRecvMemsCommands")]
  public static extern int Camera_SendAndRecvMemsCommands(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, string jarg3, out string jarg4);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Camera_CameraGetVersion")]
  public static extern int Camera_CameraGetVersion(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Camera_CameraSetTriggerOutParam")]
  public static extern int Camera_CameraSetTriggerOutParam(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, ushort jarg3, ushort jarg4, ushort jarg5);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Camera_CameraGetTriggerOutParam")]
  public static extern int Camera_CameraGetTriggerOutParam(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, ref ushort jarg3, ref ushort jarg4, ref ushort jarg5);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Camera_CameraReboot")]
  public static extern int Camera_CameraReboot(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Camera_AddParamGroup")]
  public static extern int Camera_AddParamGroup(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, string jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Camera_GetParamGroups")]
  public static extern int Camera_GetParamGroups(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Camera_DeleteParamGroup")]
  public static extern int Camera_DeleteParamGroup(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, string jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Camera_ApplyParamGroup")]
  public static extern int Camera_ApplyParamGroup(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, string jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Camera_ReconstructPoints")]
  public static extern int Camera_ReconstructPoints(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Camera_GetAttributeTreeJson")]
  public static extern int Camera_GetAttributeTreeJson(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, /*imtype*/ out string jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Camera_GetNodeAttributeJson")]
  public static extern int Camera_GetNodeAttributeJson(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, string jarg3, /*imtype*/ out string jarg4);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_Camera_SetValue__SWIG_2")]
  public static extern int Camera_SetValue__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, string jarg3, bool jarg4);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_Camera_SetValue__SWIG_3")]
  public static extern int Camera_SetValue__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, string jarg3, int jarg4);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_Camera_SetValue__SWIG_4")]
  public static extern int Camera_SetValue__SWIG_4(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, string jarg3, float jarg4);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_Camera_SetValue__SWIG_5")]
  public static extern int Camera_SetValue__SWIG_5(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, string jarg3, double jarg4);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_Camera_GetValue__SWIG_2")]
  public static extern int Camera_GetValue__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, string jarg3, ref bool jarg4);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_Camera_GetValue__SWIG_3")]
  public static extern int Camera_GetValue__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, string jarg3, ref int jarg4);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_Camera_GetValue__SWIG_4")]
  public static extern int Camera_GetValue__SWIG_4(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, string jarg3, ref float jarg4);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_Camera_GetValue__SWIG_5")]
  public static extern int Camera_GetValue__SWIG_5(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, string jarg3, ref double jarg4);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_Camera_Get3DCameraIntrinsic")]
  public static extern int Camera_Get3DCameraIntrinsic(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_Camera_Get3DCameraExtrinsic")]
  public static extern int Camera_Get3DCameraExtrinsic(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Camera_Close")]
  public static extern void Camera_Close(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_delete_Camera")]
  public static extern void delete_Camera(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CreateCamera")]
  public static extern global::System.IntPtr CreateCamera(int jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_DestoryCamera")]
  public static extern void DestoryCamera(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_new_FrameDataEx__SWIG_0")]
  public static extern global::System.IntPtr new_FrameDataEx__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_delete_FrameDataEx")]
  public static extern void delete_FrameDataEx(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_new_FrameDataEx__SWIG_1")]
  public static extern global::System.IntPtr new_FrameDataEx__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameDataEx_outputIR_set")]
  public static extern void FrameDataEx_outputIR_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameDataEx_outputIR_get")]
  public static extern global::System.IntPtr FrameDataEx_outputIR_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameDataEx_outputIRSize_set")]
  public static extern void FrameDataEx_outputIRSize_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameDataEx_outputIRSize_get")]
  public static extern uint FrameDataEx_outputIRSize_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_new_CameraInterfaceEx__SWIG_0")]
  public static extern global::System.IntPtr new_CameraInterfaceEx__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_new_CameraInterfaceEx__SWIG_1")]
  public static extern global::System.IntPtr new_CameraInterfaceEx__SWIG_1(int jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_delete_CameraInterfaceEx")]
  public static extern void delete_CameraInterfaceEx(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInterfaceEx_CaptureEx")]
  public static extern int CameraInterfaceEx_CaptureEx(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInterfaceEx_CameraImportFile__SWIG_0")]
  public static extern int CameraInterfaceEx_CameraImportFile__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, string jarg4, uint jarg5);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInterfaceEx_CameraImportFile__SWIG_1")]
  public static extern int CameraInterfaceEx_CameraImportFile__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, string jarg4);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInterfaceEx_CameraExportFile__SWIG_0")]
  public static extern int CameraInterfaceEx_CameraExportFile__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, string jarg4, uint jarg5);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInterfaceEx_CameraExportFile__SWIG_1")]
  public static extern int CameraInterfaceEx_CameraExportFile__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, string jarg4);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInterfaceEx_RestoreParam")]
  public static extern int CameraInterfaceEx_RestoreParam(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInterfaceEx_SaveParam")]
  public static extern int CameraInterfaceEx_SaveParam(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInterfaceEx_GetConnectionStatus")]
  public static extern bool CameraInterfaceEx_GetConnectionStatus(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInterfaceEx_ExportParamGroup__SWIG_0")]
  public static extern int CameraInterfaceEx_ExportParamGroup__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, string jarg3, string jarg4, uint jarg5);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInterfaceEx_ExportParamGroup__SWIG_1")]
  public static extern int CameraInterfaceEx_ExportParamGroup__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, string jarg3, string jarg4);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInterfaceEx_SetDebugMode")]
  public static extern int CameraInterfaceEx_SetDebugMode(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint = "CSharp_CameraInterfaceEx_CameraGetCalibrationMatrix")]
  public static extern int CameraInterfaceEx_CameraGetCalibrationMatrix(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInterfaceEx_SetContinuousExposure")]
  public static extern int CameraInterfaceEx_SetContinuousExposure(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInterfaceEx_SetInternalValue")]
  public static extern int CameraInterfaceEx_SetInternalValue(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, string jarg3, int jarg4);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_mapMemsStripesType_get")]
  public static extern global::System.IntPtr mapMemsStripesType_get();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfoVector_Clear")]
  public static extern void CameraInfoVector_Clear(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfoVector_Add")]
  public static extern void CameraInfoVector_Add(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfoVector_size")]
  public static extern uint CameraInfoVector_size(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfoVector_capacity")]
  public static extern uint CameraInfoVector_capacity(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfoVector_reserve")]
  public static extern void CameraInfoVector_reserve(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_new_CameraInfoVector__SWIG_0")]
  public static extern global::System.IntPtr new_CameraInfoVector__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_new_CameraInfoVector__SWIG_1")]
  public static extern global::System.IntPtr new_CameraInfoVector__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_new_CameraInfoVector__SWIG_2")]
  public static extern global::System.IntPtr new_CameraInfoVector__SWIG_2(int jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfoVector_getitemcopy")]
  public static extern global::System.IntPtr CameraInfoVector_getitemcopy(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfoVector_getitem")]
  public static extern global::System.IntPtr CameraInfoVector_getitem(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfoVector_setitem")]
  public static extern void CameraInfoVector_setitem(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfoVector_AddRange")]
  public static extern void CameraInfoVector_AddRange(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfoVector_GetRange")]
  public static extern global::System.IntPtr CameraInfoVector_GetRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfoVector_Insert")]
  public static extern void CameraInfoVector_Insert(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfoVector_InsertRange")]
  public static extern void CameraInfoVector_InsertRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfoVector_RemoveAt")]
  public static extern void CameraInfoVector_RemoveAt(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfoVector_RemoveRange")]
  public static extern void CameraInfoVector_RemoveRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfoVector_Repeat")]
  public static extern global::System.IntPtr CameraInfoVector_Repeat(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfoVector_Reverse__SWIG_0")]
  public static extern void CameraInfoVector_Reverse__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfoVector_Reverse__SWIG_1")]
  public static extern void CameraInfoVector_Reverse__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_CameraInfoVector_SetRange")]
  public static extern void CameraInfoVector_SetRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_delete_CameraInfoVector")]
  public static extern void delete_CameraInfoVector(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_IntVector_Clear")]
  public static extern void IntVector_Clear(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_IntVector_Add")]
  public static extern void IntVector_Add(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_IntVector_size")]
  public static extern uint IntVector_size(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_IntVector_capacity")]
  public static extern uint IntVector_capacity(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_IntVector_reserve")]
  public static extern void IntVector_reserve(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_new_IntVector__SWIG_0")]
  public static extern global::System.IntPtr new_IntVector__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_new_IntVector__SWIG_1")]
  public static extern global::System.IntPtr new_IntVector__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_new_IntVector__SWIG_2")]
  public static extern global::System.IntPtr new_IntVector__SWIG_2(int jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_IntVector_getitemcopy")]
  public static extern int IntVector_getitemcopy(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_IntVector_getitem")]
  public static extern int IntVector_getitem(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_IntVector_setitem")]
  public static extern void IntVector_setitem(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_IntVector_AddRange")]
  public static extern void IntVector_AddRange(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_IntVector_GetRange")]
  public static extern global::System.IntPtr IntVector_GetRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_IntVector_Insert")]
  public static extern void IntVector_Insert(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_IntVector_InsertRange")]
  public static extern void IntVector_InsertRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_IntVector_RemoveAt")]
  public static extern void IntVector_RemoveAt(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_IntVector_RemoveRange")]
  public static extern void IntVector_RemoveRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_IntVector_Repeat")]
  public static extern global::System.IntPtr IntVector_Repeat(int jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_IntVector_Reverse__SWIG_0")]
  public static extern void IntVector_Reverse__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_IntVector_Reverse__SWIG_1")]
  public static extern void IntVector_Reverse__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_IntVector_SetRange")]
  public static extern void IntVector_SetRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_IntVector_Contains")]
  public static extern bool IntVector_Contains(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_IntVector_IndexOf")]
  public static extern int IntVector_IndexOf(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_IntVector_LastIndexOf")]
  public static extern int IntVector_LastIndexOf(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_IntVector_Remove")]
  public static extern bool IntVector_Remove(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_delete_IntVector")]
  public static extern void delete_IntVector(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_DoubleVector_Clear")]
  public static extern void DoubleVector_Clear(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_DoubleVector_Add")]
  public static extern void DoubleVector_Add(global::System.Runtime.InteropServices.HandleRef jarg1, double jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_DoubleVector_size")]
  public static extern uint DoubleVector_size(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_DoubleVector_capacity")]
  public static extern uint DoubleVector_capacity(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_DoubleVector_reserve")]
  public static extern void DoubleVector_reserve(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_new_DoubleVector__SWIG_0")]
  public static extern global::System.IntPtr new_DoubleVector__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_new_DoubleVector__SWIG_1")]
  public static extern global::System.IntPtr new_DoubleVector__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_new_DoubleVector__SWIG_2")]
  public static extern global::System.IntPtr new_DoubleVector__SWIG_2(int jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_DoubleVector_getitemcopy")]
  public static extern double DoubleVector_getitemcopy(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_DoubleVector_getitem")]
  public static extern double DoubleVector_getitem(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_DoubleVector_setitem")]
  public static extern void DoubleVector_setitem(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, double jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_DoubleVector_AddRange")]
  public static extern void DoubleVector_AddRange(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_DoubleVector_GetRange")]
  public static extern global::System.IntPtr DoubleVector_GetRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_DoubleVector_Insert")]
  public static extern void DoubleVector_Insert(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, double jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_DoubleVector_InsertRange")]
  public static extern void DoubleVector_InsertRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_DoubleVector_RemoveAt")]
  public static extern void DoubleVector_RemoveAt(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_DoubleVector_RemoveRange")]
  public static extern void DoubleVector_RemoveRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_DoubleVector_Repeat")]
  public static extern global::System.IntPtr DoubleVector_Repeat(double jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_DoubleVector_Reverse__SWIG_0")]
  public static extern void DoubleVector_Reverse__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_DoubleVector_Reverse__SWIG_1")]
  public static extern void DoubleVector_Reverse__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_DoubleVector_SetRange")]
  public static extern void DoubleVector_SetRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_DoubleVector_Contains")]
  public static extern bool DoubleVector_Contains(global::System.Runtime.InteropServices.HandleRef jarg1, double jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_DoubleVector_IndexOf")]
  public static extern int DoubleVector_IndexOf(global::System.Runtime.InteropServices.HandleRef jarg1, double jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_DoubleVector_LastIndexOf")]
  public static extern int DoubleVector_LastIndexOf(global::System.Runtime.InteropServices.HandleRef jarg1, double jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_DoubleVector_Remove")]
  public static extern bool DoubleVector_Remove(global::System.Runtime.InteropServices.HandleRef jarg1, double jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_delete_DoubleVector")]
  public static extern void delete_DoubleVector(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_StringVector_Clear")]
  public static extern void StringVector_Clear(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_StringVector_Add")]
  public static extern void StringVector_Add(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_StringVector_size")]
  public static extern uint StringVector_size(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_StringVector_capacity")]
  public static extern uint StringVector_capacity(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_StringVector_reserve")]
  public static extern void StringVector_reserve(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_new_StringVector__SWIG_0")]
  public static extern global::System.IntPtr new_StringVector__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_new_StringVector__SWIG_1")]
  public static extern global::System.IntPtr new_StringVector__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_new_StringVector__SWIG_2")]
  public static extern global::System.IntPtr new_StringVector__SWIG_2(int jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_StringVector_getitemcopy")]
  public static extern string StringVector_getitemcopy(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_StringVector_getitem")]
  public static extern string StringVector_getitem(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_StringVector_setitem")]
  public static extern void StringVector_setitem(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, string jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_StringVector_AddRange")]
  public static extern void StringVector_AddRange(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_StringVector_GetRange")]
  public static extern global::System.IntPtr StringVector_GetRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_StringVector_Insert")]
  public static extern void StringVector_Insert(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, string jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_StringVector_InsertRange")]
  public static extern void StringVector_InsertRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_StringVector_RemoveAt")]
  public static extern void StringVector_RemoveAt(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_StringVector_RemoveRange")]
  public static extern void StringVector_RemoveRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_StringVector_Repeat")]
  public static extern global::System.IntPtr StringVector_Repeat(string jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_StringVector_Reverse__SWIG_0")]
  public static extern void StringVector_Reverse__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_StringVector_Reverse__SWIG_1")]
  public static extern void StringVector_Reverse__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_StringVector_SetRange")]
  public static extern void StringVector_SetRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_StringVector_Contains")]
  public static extern bool StringVector_Contains(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_StringVector_IndexOf")]
  public static extern int StringVector_IndexOf(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_StringVector_LastIndexOf")]
  public static extern int StringVector_LastIndexOf(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_StringVector_Remove")]
  public static extern bool StringVector_Remove(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_delete_StringVector")]
  public static extern void delete_StringVector(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point2fVector_Clear")]
  public static extern void Point2fVector_Clear(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point2fVector_Add")]
  public static extern void Point2fVector_Add(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point2fVector_size")]
  public static extern uint Point2fVector_size(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point2fVector_capacity")]
  public static extern uint Point2fVector_capacity(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point2fVector_reserve")]
  public static extern void Point2fVector_reserve(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_new_Point2fVector__SWIG_0")]
  public static extern global::System.IntPtr new_Point2fVector__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_new_Point2fVector__SWIG_1")]
  public static extern global::System.IntPtr new_Point2fVector__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_new_Point2fVector__SWIG_2")]
  public static extern global::System.IntPtr new_Point2fVector__SWIG_2(int jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point2fVector_getitemcopy")]
  public static extern global::System.IntPtr Point2fVector_getitemcopy(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point2fVector_getitem")]
  public static extern global::System.IntPtr Point2fVector_getitem(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point2fVector_setitem")]
  public static extern void Point2fVector_setitem(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point2fVector_AddRange")]
  public static extern void Point2fVector_AddRange(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point2fVector_GetRange")]
  public static extern global::System.IntPtr Point2fVector_GetRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point2fVector_Insert")]
  public static extern void Point2fVector_Insert(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point2fVector_InsertRange")]
  public static extern void Point2fVector_InsertRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point2fVector_RemoveAt")]
  public static extern void Point2fVector_RemoveAt(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point2fVector_RemoveRange")]
  public static extern void Point2fVector_RemoveRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point2fVector_Repeat")]
  public static extern global::System.IntPtr Point2fVector_Repeat(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point2fVector_Reverse__SWIG_0")]
  public static extern void Point2fVector_Reverse__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point2fVector_Reverse__SWIG_1")]
  public static extern void Point2fVector_Reverse__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point2fVector_SetRange")]
  public static extern void Point2fVector_SetRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_delete_Point2fVector")]
  public static extern void delete_Point2fVector(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point3fVector_Clear")]
  public static extern void Point3fVector_Clear(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point3fVector_Add")]
  public static extern void Point3fVector_Add(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point3fVector_size")]
  public static extern uint Point3fVector_size(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point3fVector_capacity")]
  public static extern uint Point3fVector_capacity(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point3fVector_reserve")]
  public static extern void Point3fVector_reserve(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_new_Point3fVector__SWIG_0")]
  public static extern global::System.IntPtr new_Point3fVector__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_new_Point3fVector__SWIG_1")]
  public static extern global::System.IntPtr new_Point3fVector__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_new_Point3fVector__SWIG_2")]
  public static extern global::System.IntPtr new_Point3fVector__SWIG_2(int jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point3fVector_getitemcopy")]
  public static extern global::System.IntPtr Point3fVector_getitemcopy(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point3fVector_getitem")]
  public static extern global::System.IntPtr Point3fVector_getitem(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point3fVector_setitem")]
  public static extern void Point3fVector_setitem(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point3fVector_AddRange")]
  public static extern void Point3fVector_AddRange(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point3fVector_GetRange")]
  public static extern global::System.IntPtr Point3fVector_GetRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point3fVector_Insert")]
  public static extern void Point3fVector_Insert(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point3fVector_InsertRange")]
  public static extern void Point3fVector_InsertRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point3fVector_RemoveAt")]
  public static extern void Point3fVector_RemoveAt(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point3fVector_RemoveRange")]
  public static extern void Point3fVector_RemoveRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point3fVector_Repeat")]
  public static extern global::System.IntPtr Point3fVector_Repeat(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point3fVector_Reverse__SWIG_0")]
  public static extern void Point3fVector_Reverse__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point3fVector_Reverse__SWIG_1")]
  public static extern void Point3fVector_Reverse__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_Point3fVector_SetRange")]
  public static extern void Point3fVector_SetRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_delete_Point3fVector")]
  public static extern void delete_Point3fVector(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("CameraPro", EntryPoint="CSharp_FrameDataEx_SWIGUpcast")]
  public static extern global::System.IntPtr FrameDataEx_SWIGUpcast(global::System.IntPtr jarg1);

}

#region class SWIGTYPE_p_bool
public class SWIGTYPE_p_bool
{
    private global::System.Runtime.InteropServices.HandleRef swigCPtr;

    internal SWIGTYPE_p_bool(global::System.IntPtr cPtr, bool futureUse)
    {
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
    }

    protected SWIGTYPE_p_bool()
    {
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
    }

    internal static global::System.Runtime.InteropServices.HandleRef getCPtr(SWIGTYPE_p_bool obj)
    {
        return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
    }
}
#endregion

#region class SWIGTYPE_p_double
public class SWIGTYPE_p_double
{
    private global::System.Runtime.InteropServices.HandleRef swigCPtr;

    internal SWIGTYPE_p_double(global::System.IntPtr cPtr, bool futureUse)
    {
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
    }

    protected SWIGTYPE_p_double()
    {
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
    }

    internal static global::System.Runtime.InteropServices.HandleRef getCPtr(SWIGTYPE_p_double obj)
    {
        return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
    }
}
#endregion

#region class SWIGTYPE_p_float
public class SWIGTYPE_p_float
{
    private global::System.Runtime.InteropServices.HandleRef swigCPtr;

    internal SWIGTYPE_p_float(global::System.IntPtr cPtr, bool futureUse)
    {
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
    }

    protected SWIGTYPE_p_float()
    {
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
    }

    internal static global::System.Runtime.InteropServices.HandleRef getCPtr(SWIGTYPE_p_float obj)
    {
        return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
    }
}
#endregion

#region class SWIGTYPE_p_int
public class SWIGTYPE_p_int
{
    private global::System.Runtime.InteropServices.HandleRef swigCPtr;

    internal SWIGTYPE_p_int(global::System.IntPtr cPtr, bool futureUse)
    {
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
    }

    protected SWIGTYPE_p_int()
    {
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
    }

    internal static global::System.Runtime.InteropServices.HandleRef getCPtr(SWIGTYPE_p_int obj)
    {
        return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
    }
}
#endregion

#region class SWIGTYPE_p_std__string
public class SWIGTYPE_p_std__string
{
    private global::System.Runtime.InteropServices.HandleRef swigCPtr;

    internal SWIGTYPE_p_std__string(global::System.IntPtr cPtr, bool futureUse)
    {
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
    }

    protected SWIGTYPE_p_std__string()
    {
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
    }

    internal static global::System.Runtime.InteropServices.HandleRef getCPtr(SWIGTYPE_p_std__string obj)
    {
        return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
    }
}
#endregion

#region class SWIGTYPE_p_unsigned_char
public class SWIGTYPE_p_unsigned_char
{
    private global::System.Runtime.InteropServices.HandleRef swigCPtr;

    internal SWIGTYPE_p_unsigned_char(global::System.IntPtr cPtr, bool futureUse)
    {
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
    }

    protected SWIGTYPE_p_unsigned_char()
    {
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
    }

    internal static global::System.Runtime.InteropServices.HandleRef getCPtr(SWIGTYPE_p_unsigned_char obj)
    {
        return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
    }
}
#endregion

#region class SWIGTYPE_p_unsigned_short
public class SWIGTYPE_p_unsigned_short
{
    private global::System.Runtime.InteropServices.HandleRef swigCPtr;

    internal SWIGTYPE_p_unsigned_short(global::System.IntPtr cPtr, bool futureUse)
    {
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
    }

    protected SWIGTYPE_p_unsigned_short()
    {
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
    }

    internal static global::System.Runtime.InteropServices.HandleRef getCPtr(SWIGTYPE_p_unsigned_short obj)
    {
        return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
    }
}
#endregion

#region class SWIGTYPE_p_a_64__unsigned_char
public class SWIGTYPE_p_a_64__unsigned_char {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal SWIGTYPE_p_a_64__unsigned_char(global::System.IntPtr cPtr, bool futureUse) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  protected SWIGTYPE_p_a_64__unsigned_char() {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(SWIGTYPE_p_a_64__unsigned_char obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }
}
#endregion

#region class SWIGTYPE_p_std__mapT_int_std__string_std__lessT_int_t_t
public class SWIGTYPE_p_std__mapT_int_std__string_std__lessT_int_t_t {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal SWIGTYPE_p_std__mapT_int_std__string_std__lessT_int_t_t(global::System.IntPtr cPtr, bool futureUse) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  protected SWIGTYPE_p_std__mapT_int_std__string_std__lessT_int_t_t() {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(SWIGTYPE_p_std__mapT_int_std__string_std__lessT_int_t_t obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }
}
#endregion

#region class SWIGTYPE_p_std__vectorT_int_t
public class SWIGTYPE_p_std__vectorT_int_t
{
    private global::System.Runtime.InteropServices.HandleRef swigCPtr;

    internal SWIGTYPE_p_std__vectorT_int_t(global::System.IntPtr cPtr, bool futureUse)
    {
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
    }

    protected SWIGTYPE_p_std__vectorT_int_t()
    {
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
    }

    internal static global::System.Runtime.InteropServices.HandleRef getCPtr(SWIGTYPE_p_std__vectorT_int_t obj)
    {
        return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
    }
}
#endregion

#region class DoubleVector
public class DoubleVector : global::System.IDisposable, global::System.Collections.IEnumerable, global::System.Collections.Generic.IList<double>
{
    private global::System.Runtime.InteropServices.HandleRef swigCPtr;
    protected bool swigCMemOwn;

    internal DoubleVector(global::System.IntPtr cPtr, bool cMemoryOwn)
    {
        swigCMemOwn = cMemoryOwn;
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
    }

    internal static global::System.Runtime.InteropServices.HandleRef getCPtr(DoubleVector obj)
    {
        return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
    }

    ~DoubleVector()
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
                    CameraProPINVOKE.delete_DoubleVector(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
        }
    }

    public DoubleVector(global::System.Collections.IEnumerable c) : this()
    {
        if (c == null)
            throw new global::System.ArgumentNullException("c");
        foreach (double element in c)
        {
            this.Add(element);
        }
    }

    public DoubleVector(global::System.Collections.Generic.IEnumerable<double> c) : this()
    {
        if (c == null)
            throw new global::System.ArgumentNullException("c");
        foreach (double element in c)
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

    public double this[int index]
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

    public void CopyTo(double[] array)
    {
        CopyTo(0, array, 0, this.Count);
    }

    public void CopyTo(double[] array, int arrayIndex)
    {
        CopyTo(0, array, arrayIndex, this.Count);
    }

    public void CopyTo(int index, double[] array, int arrayIndex, int count)
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

    public double[] ToArray()
    {
        double[] array = new double[this.Count];
        this.CopyTo(array);
        return array;
    }

    global::System.Collections.Generic.IEnumerator<double> global::System.Collections.Generic.IEnumerable<double>.GetEnumerator()
    {
        return new DoubleVectorEnumerator(this);
    }

    global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
    {
        return new DoubleVectorEnumerator(this);
    }

    public DoubleVectorEnumerator GetEnumerator()
    {
        return new DoubleVectorEnumerator(this);
    }

    // Type-safe enumerator
    /// Note that the IEnumerator documentation requires an InvalidOperationException to be thrown
    /// whenever the collection is modified. This has been done for changes in the size of the
    /// collection but not when one of the elements of the collection is modified as it is a bit
    /// tricky to detect unmanaged code that modifies the collection under our feet.
    public sealed class DoubleVectorEnumerator : global::System.Collections.IEnumerator
      , global::System.Collections.Generic.IEnumerator<double>
    {
        private DoubleVector collectionRef;
        private int currentIndex;
        private object currentObject;
        private int currentSize;

        public DoubleVectorEnumerator(DoubleVector collection)
        {
            collectionRef = collection;
            currentIndex = -1;
            currentObject = null;
            currentSize = collectionRef.Count;
        }

        // Type-safe iterator Current
        public double Current
        {
            get
            {
                if (currentIndex == -1)
                    throw new global::System.InvalidOperationException("Enumeration not started.");
                if (currentIndex > currentSize - 1)
                    throw new global::System.InvalidOperationException("Enumeration finished.");
                if (currentObject == null)
                    throw new global::System.InvalidOperationException("Collection modified.");
                return (double)currentObject;
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
        CameraProPINVOKE.DoubleVector_Clear(swigCPtr);
    }

    public void Add(double x)
    {
        CameraProPINVOKE.DoubleVector_Add(swigCPtr, x);
    }

    private uint size()
    {
        uint ret = CameraProPINVOKE.DoubleVector_size(swigCPtr);
        return ret;
    }

    private uint capacity()
    {
        uint ret = CameraProPINVOKE.DoubleVector_capacity(swigCPtr);
        return ret;
    }

    private void reserve(uint n)
    {
        CameraProPINVOKE.DoubleVector_reserve(swigCPtr, n);
    }

    public DoubleVector() : this(CameraProPINVOKE.new_DoubleVector__SWIG_0(), true)
    {
    }

    public DoubleVector(DoubleVector other) : this(CameraProPINVOKE.new_DoubleVector__SWIG_1(DoubleVector.getCPtr(other)), true)
    {
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    public DoubleVector(int capacity) : this(CameraProPINVOKE.new_DoubleVector__SWIG_2(capacity), true)
    {
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    private double getitemcopy(int index)
    {
        double ret = CameraProPINVOKE.DoubleVector_getitemcopy(swigCPtr, index);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
        return ret;
    }

    private double getitem(int index)
    {
        double ret = CameraProPINVOKE.DoubleVector_getitem(swigCPtr, index);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
        return ret;
    }

    private void setitem(int index, double val)
    {
        CameraProPINVOKE.DoubleVector_setitem(swigCPtr, index, val);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    public void AddRange(DoubleVector values)
    {
        CameraProPINVOKE.DoubleVector_AddRange(swigCPtr, DoubleVector.getCPtr(values));
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    public DoubleVector GetRange(int index, int count)
    {
        global::System.IntPtr cPtr = CameraProPINVOKE.DoubleVector_GetRange(swigCPtr, index, count);
        DoubleVector ret = (cPtr == global::System.IntPtr.Zero) ? null : new DoubleVector(cPtr, true);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
        return ret;
    }

    public void Insert(int index, double x)
    {
        CameraProPINVOKE.DoubleVector_Insert(swigCPtr, index, x);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    public void InsertRange(int index, DoubleVector values)
    {
        CameraProPINVOKE.DoubleVector_InsertRange(swigCPtr, index, DoubleVector.getCPtr(values));
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    public void RemoveAt(int index)
    {
        CameraProPINVOKE.DoubleVector_RemoveAt(swigCPtr, index);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    public void RemoveRange(int index, int count)
    {
        CameraProPINVOKE.DoubleVector_RemoveRange(swigCPtr, index, count);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    public static DoubleVector Repeat(double value, int count)
    {
        global::System.IntPtr cPtr = CameraProPINVOKE.DoubleVector_Repeat(value, count);
        DoubleVector ret = (cPtr == global::System.IntPtr.Zero) ? null : new DoubleVector(cPtr, true);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
        return ret;
    }

    public void Reverse()
    {
        CameraProPINVOKE.DoubleVector_Reverse__SWIG_0(swigCPtr);
    }

    public void Reverse(int index, int count)
    {
        CameraProPINVOKE.DoubleVector_Reverse__SWIG_1(swigCPtr, index, count);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    public void SetRange(int index, DoubleVector values)
    {
        CameraProPINVOKE.DoubleVector_SetRange(swigCPtr, index, DoubleVector.getCPtr(values));
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    public bool Contains(double value)
    {
        bool ret = CameraProPINVOKE.DoubleVector_Contains(swigCPtr, value);
        return ret;
    }

    public int IndexOf(double value)
    {
        int ret = CameraProPINVOKE.DoubleVector_IndexOf(swigCPtr, value);
        return ret;
    }

    public int LastIndexOf(double value)
    {
        int ret = CameraProPINVOKE.DoubleVector_LastIndexOf(swigCPtr, value);
        return ret;
    }

    public bool Remove(double value)
    {
        bool ret = CameraProPINVOKE.DoubleVector_Remove(swigCPtr, value);
        return ret;
    }

}
#endregion

#region class IntVector
public class IntVector : global::System.IDisposable, global::System.Collections.IEnumerable, global::System.Collections.Generic.IList<int>
{
    private global::System.Runtime.InteropServices.HandleRef swigCPtr;
    protected bool swigCMemOwn;

    internal IntVector(global::System.IntPtr cPtr, bool cMemoryOwn)
    {
        swigCMemOwn = cMemoryOwn;
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
    }

    internal static global::System.Runtime.InteropServices.HandleRef getCPtr(IntVector obj)
    {
        return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
    }

    ~IntVector()
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
                    CameraProPINVOKE.delete_IntVector(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
        }
    }

    public IntVector(global::System.Collections.IEnumerable c) : this()
    {
        if (c == null)
            throw new global::System.ArgumentNullException("c");
        foreach (int element in c)
        {
            this.Add(element);
        }
    }

    public IntVector(global::System.Collections.Generic.IEnumerable<int> c) : this()
    {
        if (c == null)
            throw new global::System.ArgumentNullException("c");
        foreach (int element in c)
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

    public int this[int index]
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

    public void CopyTo(int[] array)
    {
        CopyTo(0, array, 0, this.Count);
    }

    public void CopyTo(int[] array, int arrayIndex)
    {
        CopyTo(0, array, arrayIndex, this.Count);
    }

    public void CopyTo(int index, int[] array, int arrayIndex, int count)
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

    public int[] ToArray()
    {
        int[] array = new int[this.Count];
        this.CopyTo(array);
        return array;
    }

    global::System.Collections.Generic.IEnumerator<int> global::System.Collections.Generic.IEnumerable<int>.GetEnumerator()
    {
        return new IntVectorEnumerator(this);
    }

    global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
    {
        return new IntVectorEnumerator(this);
    }

    public IntVectorEnumerator GetEnumerator()
    {
        return new IntVectorEnumerator(this);
    }

    // Type-safe enumerator
    /// Note that the IEnumerator documentation requires an InvalidOperationException to be thrown
    /// whenever the collection is modified. This has been done for changes in the size of the
    /// collection but not when one of the elements of the collection is modified as it is a bit
    /// tricky to detect unmanaged code that modifies the collection under our feet.
    public sealed class IntVectorEnumerator : global::System.Collections.IEnumerator
      , global::System.Collections.Generic.IEnumerator<int>
    {
        private IntVector collectionRef;
        private int currentIndex;
        private object currentObject;
        private int currentSize;

        public IntVectorEnumerator(IntVector collection)
        {
            collectionRef = collection;
            currentIndex = -1;
            currentObject = null;
            currentSize = collectionRef.Count;
        }

        // Type-safe iterator Current
        public int Current
        {
            get
            {
                if (currentIndex == -1)
                    throw new global::System.InvalidOperationException("Enumeration not started.");
                if (currentIndex > currentSize - 1)
                    throw new global::System.InvalidOperationException("Enumeration finished.");
                if (currentObject == null)
                    throw new global::System.InvalidOperationException("Collection modified.");
                return (int)currentObject;
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
        CameraProPINVOKE.IntVector_Clear(swigCPtr);
    }

    public void Add(int x)
    {
        CameraProPINVOKE.IntVector_Add(swigCPtr, x);
    }

    private uint size()
    {
        uint ret = CameraProPINVOKE.IntVector_size(swigCPtr);
        return ret;
    }

    private uint capacity()
    {
        uint ret = CameraProPINVOKE.IntVector_capacity(swigCPtr);
        return ret;
    }

    private void reserve(uint n)
    {
        CameraProPINVOKE.IntVector_reserve(swigCPtr, n);
    }

    public IntVector() : this(CameraProPINVOKE.new_IntVector__SWIG_0(), true)
    {
    }

    public IntVector(IntVector other) : this(CameraProPINVOKE.new_IntVector__SWIG_1(IntVector.getCPtr(other)), true)
    {
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    public IntVector(int capacity) : this(CameraProPINVOKE.new_IntVector__SWIG_2(capacity), true)
    {
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    private int getitemcopy(int index)
    {
        int ret = CameraProPINVOKE.IntVector_getitemcopy(swigCPtr, index);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
        return ret;
    }

    private int getitem(int index)
    {
        int ret = CameraProPINVOKE.IntVector_getitem(swigCPtr, index);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
        return ret;
    }

    private void setitem(int index, int val)
    {
        CameraProPINVOKE.IntVector_setitem(swigCPtr, index, val);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    public void AddRange(IntVector values)
    {
        CameraProPINVOKE.IntVector_AddRange(swigCPtr, IntVector.getCPtr(values));
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    public IntVector GetRange(int index, int count)
    {
        global::System.IntPtr cPtr = CameraProPINVOKE.IntVector_GetRange(swigCPtr, index, count);
        IntVector ret = (cPtr == global::System.IntPtr.Zero) ? null : new IntVector(cPtr, true);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
        return ret;
    }

    public void Insert(int index, int x)
    {
        CameraProPINVOKE.IntVector_Insert(swigCPtr, index, x);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    public void InsertRange(int index, IntVector values)
    {
        CameraProPINVOKE.IntVector_InsertRange(swigCPtr, index, IntVector.getCPtr(values));
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    public void RemoveAt(int index)
    {
        CameraProPINVOKE.IntVector_RemoveAt(swigCPtr, index);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    public void RemoveRange(int index, int count)
    {
        CameraProPINVOKE.IntVector_RemoveRange(swigCPtr, index, count);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    public static IntVector Repeat(int value, int count)
    {
        global::System.IntPtr cPtr = CameraProPINVOKE.IntVector_Repeat(value, count);
        IntVector ret = (cPtr == global::System.IntPtr.Zero) ? null : new IntVector(cPtr, true);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
        return ret;
    }

    public void Reverse()
    {
        CameraProPINVOKE.IntVector_Reverse__SWIG_0(swigCPtr);
    }

    public void Reverse(int index, int count)
    {
        CameraProPINVOKE.IntVector_Reverse__SWIG_1(swigCPtr, index, count);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    public void SetRange(int index, IntVector values)
    {
        CameraProPINVOKE.IntVector_SetRange(swigCPtr, index, IntVector.getCPtr(values));
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    public bool Contains(int value)
    {
        bool ret = CameraProPINVOKE.IntVector_Contains(swigCPtr, value);
        return ret;
    }

    public int IndexOf(int value)
    {
        int ret = CameraProPINVOKE.IntVector_IndexOf(swigCPtr, value);
        return ret;
    }

    public int LastIndexOf(int value)
    {
        int ret = CameraProPINVOKE.IntVector_LastIndexOf(swigCPtr, value);
        return ret;
    }

    public bool Remove(int value)
    {
        bool ret = CameraProPINVOKE.IntVector_Remove(swigCPtr, value);
        return ret;
    }

}
#endregion

#region class StringVector
public class StringVector : global::System.IDisposable, global::System.Collections.IEnumerable, global::System.Collections.Generic.IList<string>
{
    private global::System.Runtime.InteropServices.HandleRef swigCPtr;
    protected bool swigCMemOwn;

    internal StringVector(global::System.IntPtr cPtr, bool cMemoryOwn)
    {
        swigCMemOwn = cMemoryOwn;
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
    }

    internal static global::System.Runtime.InteropServices.HandleRef getCPtr(StringVector obj)
    {
        return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
    }

    ~StringVector()
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
                    CameraProPINVOKE.delete_StringVector(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
        }
    }

    public StringVector(global::System.Collections.IEnumerable c) : this()
    {
        if (c == null)
            throw new global::System.ArgumentNullException("c");
        foreach (string element in c)
        {
            this.Add(element);
        }
    }

    public StringVector(global::System.Collections.Generic.IEnumerable<string> c) : this()
    {
        if (c == null)
            throw new global::System.ArgumentNullException("c");
        foreach (string element in c)
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

    public string this[int index]
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

    public void CopyTo(string[] array)
    {
        CopyTo(0, array, 0, this.Count);
    }

    public void CopyTo(string[] array, int arrayIndex)
    {
        CopyTo(0, array, arrayIndex, this.Count);
    }

    public void CopyTo(int index, string[] array, int arrayIndex, int count)
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

    public string[] ToArray()
    {
        string[] array = new string[this.Count];
        this.CopyTo(array);
        return array;
    }

    global::System.Collections.Generic.IEnumerator<string> global::System.Collections.Generic.IEnumerable<string>.GetEnumerator()
    {
        return new StringVectorEnumerator(this);
    }

    global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
    {
        return new StringVectorEnumerator(this);
    }

    public StringVectorEnumerator GetEnumerator()
    {
        return new StringVectorEnumerator(this);
    }

    // Type-safe enumerator
    /// Note that the IEnumerator documentation requires an InvalidOperationException to be thrown
    /// whenever the collection is modified. This has been done for changes in the size of the
    /// collection but not when one of the elements of the collection is modified as it is a bit
    /// tricky to detect unmanaged code that modifies the collection under our feet.
    public sealed class StringVectorEnumerator : global::System.Collections.IEnumerator
      , global::System.Collections.Generic.IEnumerator<string>
    {
        private StringVector collectionRef;
        private int currentIndex;
        private object currentObject;
        private int currentSize;

        public StringVectorEnumerator(StringVector collection)
        {
            collectionRef = collection;
            currentIndex = -1;
            currentObject = null;
            currentSize = collectionRef.Count;
        }

        // Type-safe iterator Current
        public string Current
        {
            get
            {
                if (currentIndex == -1)
                    throw new global::System.InvalidOperationException("Enumeration not started.");
                if (currentIndex > currentSize - 1)
                    throw new global::System.InvalidOperationException("Enumeration finished.");
                if (currentObject == null)
                    throw new global::System.InvalidOperationException("Collection modified.");
                return (string)currentObject;
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
        CameraProPINVOKE.StringVector_Clear(swigCPtr);
    }

    public void Add(string x)
    {
        CameraProPINVOKE.StringVector_Add(swigCPtr, x);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    private uint size()
    {
        uint ret = CameraProPINVOKE.StringVector_size(swigCPtr);
        return ret;
    }

    private uint capacity()
    {
        uint ret = CameraProPINVOKE.StringVector_capacity(swigCPtr);
        return ret;
    }

    private void reserve(uint n)
    {
        CameraProPINVOKE.StringVector_reserve(swigCPtr, n);
    }

    public StringVector() : this(CameraProPINVOKE.new_StringVector__SWIG_0(), true)
    {
    }

    public StringVector(StringVector other) : this(CameraProPINVOKE.new_StringVector__SWIG_1(StringVector.getCPtr(other)), true)
    {
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    public StringVector(int capacity) : this(CameraProPINVOKE.new_StringVector__SWIG_2(capacity), true)
    {
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    private string getitemcopy(int index)
    {
        string ret = CameraProPINVOKE.StringVector_getitemcopy(swigCPtr, index);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
        return ret;
    }

    private string getitem(int index)
    {
        string ret = CameraProPINVOKE.StringVector_getitem(swigCPtr, index);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
        return ret;
    }

    private void setitem(int index, string val)
    {
        CameraProPINVOKE.StringVector_setitem(swigCPtr, index, val);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    public void AddRange(StringVector values)
    {
        CameraProPINVOKE.StringVector_AddRange(swigCPtr, StringVector.getCPtr(values));
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    public StringVector GetRange(int index, int count)
    {
        global::System.IntPtr cPtr = CameraProPINVOKE.StringVector_GetRange(swigCPtr, index, count);
        StringVector ret = (cPtr == global::System.IntPtr.Zero) ? null : new StringVector(cPtr, true);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
        return ret;
    }

    public void Insert(int index, string x)
    {
        CameraProPINVOKE.StringVector_Insert(swigCPtr, index, x);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    public void InsertRange(int index, StringVector values)
    {
        CameraProPINVOKE.StringVector_InsertRange(swigCPtr, index, StringVector.getCPtr(values));
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    public void RemoveAt(int index)
    {
        CameraProPINVOKE.StringVector_RemoveAt(swigCPtr, index);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    public void RemoveRange(int index, int count)
    {
        CameraProPINVOKE.StringVector_RemoveRange(swigCPtr, index, count);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    public static StringVector Repeat(string value, int count)
    {
        global::System.IntPtr cPtr = CameraProPINVOKE.StringVector_Repeat(value, count);
        StringVector ret = (cPtr == global::System.IntPtr.Zero) ? null : new StringVector(cPtr, true);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
        return ret;
    }

    public void Reverse()
    {
        CameraProPINVOKE.StringVector_Reverse__SWIG_0(swigCPtr);
    }

    public void Reverse(int index, int count)
    {
        CameraProPINVOKE.StringVector_Reverse__SWIG_1(swigCPtr, index, count);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    public void SetRange(int index, StringVector values)
    {
        CameraProPINVOKE.StringVector_SetRange(swigCPtr, index, StringVector.getCPtr(values));
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    }

    public bool Contains(string value)
    {
        bool ret = CameraProPINVOKE.StringVector_Contains(swigCPtr, value);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
        return ret;
    }

    public int IndexOf(string value)
    {
        int ret = CameraProPINVOKE.StringVector_IndexOf(swigCPtr, value);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
        return ret;
    }

    public int LastIndexOf(string value)
    {
        int ret = CameraProPINVOKE.StringVector_LastIndexOf(swigCPtr, value);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
        return ret;
    }

    public bool Remove(string value)
    {
        bool ret = CameraProPINVOKE.StringVector_Remove(swigCPtr, value);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
        return ret;
    }

}
#endregion