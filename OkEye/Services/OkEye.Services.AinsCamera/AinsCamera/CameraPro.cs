using System.Collections;

public class CameraPro {
  public static Camera CreateCamera(CamType type) {
    global::System.IntPtr cPtr = CameraProPINVOKE.CreateCamera((int)type);
    Camera ret = (cPtr == global::System.IntPtr.Zero) ? null : new Camera(cPtr, false);
    return ret;
  }

    public static readonly int AC_SUCCESS                          = 0;
    public static readonly int AC_OK                               = AC_SUCCESS;

    // operation related:
    public static readonly int AC_E_UNKNOWN                        = 1;
    public static readonly int AC_E_TIMEOUT                        = 2;
    public static readonly int AC_E_NOT_SUPPORT                    = 3;
    public static readonly int AC_E_VERSION                        = 4;
    public static readonly int AC_E_LOGIC                          = 5;
    public static readonly int AC_E_SET                            = 6;
    public static readonly int AC_E_GET                            = 7;
    public static readonly int AC_E_EXECUTE                        = 8;
                                                                   
    // system/device related:                                      
    public static readonly int AC_E_BUSY                           = 3000;    // for compatibility
    public static readonly int AC_E_OFFLINE                        = 11;
    public static readonly int AC_E_NOT_EXIST                      = 12;
    public static readonly int AC_E_NOT_FOUND                      = 13;
    public static readonly int AC_E_INIT                           = 14;
    public static readonly int AC_E_NOT_INIT                       = 15;
    public static readonly int AC_E_OPEN                           = 16;
    public static readonly int AC_E_NOT_OPENED                     = 17;
    public static readonly int AC_E_NOT_READY                      = 18;

    // permission related:
    public static readonly int AC_E_NO_PERMISSION                  = 20;
    public static readonly int AC_E_USER_PASSWORD                  = 21;
    public static readonly int AC_E_NO_KEY                         = 22;
    public static readonly int AC_E_LICENSE_OUT_OF_DATE            = 23;
    public static readonly int AC_E_VERIFY_LICENSE                 = 24;
    public static readonly int AC_E_EXCEED_MAXIMUM_CALL_FREQUENCY  = 25;

    // handle/parameter related:
    public static readonly int AC_E_INVALID_HANDLE                 = 30;
    public static readonly int AC_E_INVALID_PARAM                  = 31;
    public static readonly int AC_E_INVALID_LENGTH                 = 32;
    public static readonly int AC_E_NULL_PTR                       = 33;
    public static readonly int AC_E_OUT_OF_RANGE                   = 34;
    public static readonly int AC_E_TYPE                           = 35;

    // data related:
    public static readonly int AC_E_DATA_IS_EMPTY                  = 40;
    public static readonly int AC_E_DATA_SIZE                      = 41;
    public static readonly int AC_E_DATA_EXCEPTION                 = 42;
    public static readonly int AC_E_VERIFICATION                   = 43;
    public static readonly int AC_E_FORMAT                         = 44;
    public static readonly int AC_E_COMPRESSION                    = 45;
    public static readonly int AC_E_DECOMPRESSION                  = 46;

    // file related:
    public static readonly int AC_E_FILE_NOT_EXIST                 = 50;
    public static readonly int AC_E_FILE_READ                      = 51;
    public static readonly int AC_E_FILE_WRITE                     = 52;
    public static readonly int AC_E_FILE_TYPE                      = 53;
    public static readonly int AC_E_FILE_CREATE                    = 54;
    public static readonly int AC_E_FILE_OPEN                      = 55;

    // network/communication related:
    public static readonly int AC_E_NETWORK                        = 60;
    public static readonly int AC_E_ADDRESS_UNREACHABLE            = 61;
    public static readonly int AC_E_IP_CONFLICT                    = 62;
    public static readonly int AC_E_CONNECTION                     = 63;
    public static readonly int AC_E_ALREADY_DISCONNECTED           = 64;
    public static readonly int AC_E_PARSE_PACKET                   = 65;
    public static readonly int AC_E_ETH_NOT_LINK                   = 66;
    public static readonly int AC_E_SLOW_TRANSMISSION_SPEED        = 67;

    // hardware related:
    public static readonly int AC_E_READ                           = 70;
    public static readonly int AC_E_WRITE                          = 71;
    public static readonly int AC_E_NOT_ENOUGH_MEMORY              = 72;
    public static readonly int AC_E_NOT_ENOUGH_DISK_SPACE          = 73;

    // image related:
    public static readonly int AC_E_IMAGE_IS_EMPTY                 = 80;
    public static readonly int AC_E_IMAGE_SIZE                     = 81;
    public static readonly int AC_E_IMAGE_FORMAT                   = 82;
    public static readonly int AC_E_NUMBER_OF_IMAGES               = 83;

    // deprecated; not suggest; for compatibility:
    public static readonly int AC_E_NO_CAMERA                      = AC_E_NOT_FOUND;
    public static readonly int AC_E_RECV_INCORRECT                 = AC_E_DATA_EXCEPTION;
    public static readonly int AC_E_VERSION_MISSMATCH              = AC_E_VERSION;
    public static readonly int AC_E_CAMERA_IS_INVALID              = AC_E_INVALID_HANDLE;
    public static readonly int AC_E_TYPE_MISSMATCH                 = AC_E_TYPE;
    public static readonly int AC_E_CMD_NOT_SUPPORT                = AC_E_NOT_SUPPORT;
    public static readonly int AC_E_DECOMPRESS                     = AC_E_DECOMPRESSION;
    public static readonly int AC_E_NOT_EXSIT                      = AC_E_NOT_EXIST;

  public static void DestoryCamera(Camera cam)
  {
    CameraProPINVOKE.DestoryCamera(Camera.getCPtr(cam));
  }
}
