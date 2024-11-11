public interface ICamera 
{
    /*! DiscoverCameras() :
    * @brief: Discover camera(s) by broadcasting.
    * @param camInfoVector: Store the discovered camera(s) in vector.
    * @param timeout: Set the timeout(unit: ms) of discovering.
    * @return: Success, return AC_OK. Failure, return error code(e.g. AC_E_NO_CAMERA).
    */
    int DiscoverCameras(CameraInfoVector camInfoVector, uint timeout = 1000);

    /*! Open() :
    * @brief: Open a camera and get some parameters from camera into cameraInfo.
    * @param cameraInfo: a struct of camera info.
    * @param timeout: Set the timeout(unit: ms) of the operation.
    * @return: Success, return AC_OK. Failure, return error code.
    */
    int Open(CameraInfo cameraInfo, uint timeout = 60000);

    /*! Capture() :
    * @brief: Capture the data of the camera(cameraInfo).
    * @param frameData: A struct be used to restore the data. The struct will automatically allocate memory and automatically release memory at the end of its life cycle.
    */
    int Capture(CameraInfo cameraInfo, FrameData frameData);

    /*! RegisterErrorCodeHandler() :
    * @brief: Register the ErrorCode Handler. So that you can handle the real-time error code in Trigger mode(contains Camera_GPIOTrigger Camera_SoftContinuousTrigger Camera_SoftSingleAsyncTrigger).
    * @param errorCodeHandler: The ErrorCode Handler. Customize your Handler by overloading class 'ErrorCodeHandler'.
    */
    void RegisterErrorCodeHandler(ErrorCodeHandler errorCodeHandler);

    /*! RegisterFrameDataHandler() :
    * @brief: Register the FrameData Handler. So that you can handle the real-time FrameData in Trigger mode(contains Camera_GPIOTrigger Camera_SoftContinuousTrigger Camera_SoftSingleAsyncTrigger).
    * @param frameDataHandler: The FrameData Handler. Customize your Handler by overloading class 'FrameDataHandler'.
    * @param timeout: Set The timeout in ms of waiting data.
    */
    void RegisterFrameDataHandler(FrameDataHandler frameDataHandler, uint timeout = 3000);

    /*! Capture() :
    * @brief: Single asynchronous trigger, the working mode (CameraWorkMode) needs to be set to Camera_SoftSingleAsyncTrigger, and data is obtained through the GPIODataCallBack interface. 
    */
    int CaptureDataAsync(CameraInfo cameraInfo);

    /*! SetCameraIP() :
    * @brief: Set the camera's IP to a static IP.
    */
    void SetCameraIP(CameraInfo cameraInfo, string newIP);

    /*! SetCameraToDHCP() :
    * @brief: Set the camera's network to DHCP.
    */
    void SetCameraToDHCP(CameraInfo cameraInfo);

    /*! CameraGetStatus() :
    * @brief: Get some real-time info from camera and update into cameraInfo.
    */
    int CameraGetStatus(CameraInfo cameraInfo);

    /*! SetValue/GetValue():
    * @brief: Set/Get the value into/from camera. 
    *    When Set, the function will check the validity of value according to the rules('range' 'DataType' 'read and write properties' and so on) explained in Common.h
    *    When Set/Get, the value's data type must match ParamType according to the 'DataType:' explained in Common.h. Defalut 'DataType' is 'int32_t'.
    */
    int SetValue(CameraInfo cameraInfo, ParamType type, int value);
    int GetValue(CameraInfo cameraInfo, ParamType type, ref int value);
    int SetValue(CameraInfo cameraInfo, ParamType type, float value);
    int GetValue(CameraInfo cameraInfo, ParamType type, ref float value);

    /*! SendMemsCommands() and SendAndRecvMemsCommands():
    * @brief: Send original hexadecimal string commands to MEMS laser.
    */
    int SendMemsCommands(CameraInfo cameraInfo, string strCommands);
    unsafe int SendAndRecvMemsCommands(CameraInfo cameraInfo, string strCommands, out string strRecv);

    /*! CameraGetVersion():
    * @brief: Get the version information from camera. We will call the function in Open() automatically.
    */
    int CameraGetVersion(CameraInfo cameraInfo);

    /*! CameraSet/SetTriggerOutParam():
    * @brief: Set/Get the param values of the GPIO(Trigger) mode.
    * @param mode: GPIO trigger mode. Range:[0, 4]
	* @param cycleNumValue: Number of output square waves.
	* @param cycleLenValue: The length of the output square wave, in ms.
    */
    int CameraSetTriggerOutParam(CameraInfo cameraInfo, ushort mode, ushort cycleNumValue, ushort cycleLenValue);
    int CameraGetTriggerOutParam(CameraInfo cameraInfo, ref ushort mode, ref ushort cycleNumValue, ref ushort cycleLenValue);

    /*! AddParamGroup():
    * @brief: Add a new param group to camera.
    * @param paramGroupName: The name of this param group.
    */
    int AddParamGroup(CameraInfo cameraInfo, string paramGroupName);

    /*! GetParamGroups():
    * @brief: Get all of the param groups in camera.
    * @param paramGroupNames: The names of all param groups in camera.
    */
    int GetParamGroups(CameraInfo cameraInfo, StringVector paramGroupNames);

    /*! DeleteParamGroup():
    * @brief: Delete a param group in camera.
    * @param paramGroupName: The name of the param group in camera.
    */
    int DeleteParamGroup(CameraInfo cameraInfo, string paramGroupName);

    /*! ApplyParamGroup():
    * @brief: Apply a param group in camera.
    * @param paramGroupName: The name of the param group in camera.
    */
    int ApplyParamGroup(CameraInfo cameraInfo, string paramGroupName);

    /*! ReconstructPoints():
    * @brief: Reconstruct points for hand-eye calibration
    * @param[in]  leftPoints  : left picture feature points
    * @param[in]  rightPoints : right picture feature points
    * @param[out] points      : reconstructed points
    */
    int ReconstructPoints(CameraInfo cameraInfo, Point2fVector leftPoints, Point2fVector rightPoints, Point3fVector points);

    /*! GetAttributeTreeJson():
    * @brief: Get the attribute tree json of camera
    * @param[out] strAttributeTreeJson: the attribute tree json of camera
    */
    int GetAttributeTreeJson(CameraInfo cameraInfo, out string strAttributeTreeJson);

    /*! GetNodeAttributeJson():
    * @brief: Get the node's attribute json by key
    * @param[out] strNodeAttributeJson: the node's attribute json
    */
    int GetNodeAttributeJson(CameraInfo cameraInfo, string key, /*cstype*/ out string strNodeAttributeJson);

    /*! SetValue/GetValue():
    * @brief: Set/Get the value into/from camera by key. 
    *    You can query all supported keys, their range , types, step and other information through GetAttributeTreeJson().
    */
    int SetValue(CameraInfo cameraInfo, string key, bool value);
	int SetValue(CameraInfo cameraInfo, string key, int value);
	int SetValue(CameraInfo cameraInfo, string key, float value);
	int SetValue(CameraInfo cameraInfo, string key, double value);

	int GetValue(CameraInfo cameraInfo, string key, ref bool value);
	int GetValue(CameraInfo cameraInfo, string key, ref int value);
	int GetValue(CameraInfo cameraInfo, string key, ref float value);
	int GetValue(CameraInfo cameraInfo, string key, ref double value);

    /*!
	* @brief : Obtain the 3D camera internal parameter matrix, and the customer obtains Z through depth maps and calculates x, y, and z based on the internal parameters provided by the interface
	* @param position [IN] : Camera position
	* @param cameraIntrinsic [OUT] : 3D camera internal parameter matrix:
		///  a 3x3 matrix
		///  |.|.|.|
		///  | --|---|---|
		///  | fx|  0| cx|
		///  |  0| fy| cy|
		///  |  0|  0|  1|
	* @return : Success, return 0. Failure, return error code.
	*/
    int Get3DCameraIntrinsic(CameraInfo cameraInfo, CAMERA_POSITION cameraPosition, DoubleVector cameraIntrinsic);

    /*!
	* @brief : Calculate the transformation matrix from point cloud to target camera coordinate system
	* @param extrinsicType [IN]  : Type of point cloud to target camera coordinate system
	* @param cameraExtrinsic [OUT]    : Transformation matrix£º
		///  a 4x4 matrix
		///  |.|.|.|.|
		///  |---|----|----|---|
		///  |r11| r12| r13| t1|
		///  |r21| r22| r23| t2|
		///  |r31| r32| r33| t3|
		///  | 0 |   0|   0|  1|
		// This parameter is used to convert coordinate points in the initial coordinate system to a new coordinate system
		// R11  R12  R13  T1 : The rotation coefficients and offsets of x, y, and z axes in the new coordinate system
		// R21  R22  R23  T2 : The rotation coefficients and offsets of the x, y, and z axes in the new coordinate system are respectively y
		// R31  R32  R33  T3 : The rotation coefficients and offsets of the x, y, and z axes in the new coordinate system are respectively z
	* @return : Success, return 0. Failure, return error code.
	*/
    int Get3DCameraExtrinsic(CameraInfo cameraInfo, EXTRINSIC_TYPE extrinsicType, DoubleVector cameraExtrinsic);

    /*! CameraReboot():
    * @brief: Send the reboot command to camera.
    */
    int CameraReboot(CameraInfo cameraInfo);

    /*! Close():
    * @brief: Close and disconnect from the camera.
    */
    void Close(CameraInfo cameraInfo);
}

/* "CamType" is used to instantiate the camera handle by API CreateCamera(). Only support CamPro currently. */
public enum CamType
{
    CamPro,
}

/* "CameraWorkMode" is used to define the current working mode of the camera. */
public enum CameraWorkMode
{
    Camera_SoftTrigger = 0,           // software trigger (default)
    Camera_GPIOTrigger = 1,           // hardware GPIO trigger
    Camera_SoftSingleAsyncTrigger = 3 // software single asynchronous trigger
}

/* This parameter is used to represent the target coordinate system. */
public enum EXTRINSIC_TYPE
{
    POINT_TO_CAM_LEFT = 0x00,
    POINT_TO_CAM_RGB = 0x01,
    POINT_TO_CAM_RIGHT = 0x02  // reserved
}

/* "ParamType" contains some parameters that can be SetValue/GetValue. The hexadecimal enumeration value defined following is also the command value sent to the camera */
public enum ParamType
{
    ParamType_Begin                 = 0x0100,
   
    Capture_WorkMode                = 0x0101, // @brief: camera's working mode          @range: [0,3]      @defalut: 0(Camera_SoftTrigger)  @value meaning: see CameraWorkMode above
    Capture_Delay                   = 0x0102, // @brief: delay time(ms) before capture  @range: [0,65535]  @defalut: 0
   
    IR_Exposure                     = 0x0200, // @brief: exposure time(ms) of IR camera      @range: [1, 100]  @defalut: 15 
    IR_Gain                         = 0x0201, // @brief: gain of IR camera                   @range: [0, 15]   @defalut: 0
    IR_LightSource                  = 0x0202, // @brief: light source of IR camera           @range: [0, 1]    @defalut: 0(MEMS laser)
    IR_HDRCnt                       = 0x0203, // @brief: times of HDR of IR camera           @range: [1, 3]    @defalut: 1  @value meaning: HDRExposure2 and HDRExposure3 do not take effect when this parameter is set to 1
    IR_HDRExposure2                 = 0x0204, // @brief: 2nd exposure time(ms) of IR camera  @range: [1, 100]  @defalut: 25
    IR_HDRExposure3                 = 0x0205, // @brief: 3rd exposure time(ms) of IR camera  @range: [1, 100]  @defalut: 5
    IR_PixelType                    = 0x0206, // @brief: type of image pixel                 @range: {8, 10, 12}   @defalut: 8  @value meaning: The value only can be 8, 10 or 12. The corresponding type is Mono8, Mono10 and Mono12 respectively.
   
    Rgb_BrightnessSet               = 0x0300, // @brief: brightness setting of RGB camera    @range: [-64, 64]    @defalut: 0
    Rgb_Contrast                    = 0x0301, // @brief: contrast of RGB camera              @range: [0, 100]     @defalut: 50
    Rgb_Saturation                  = 0x0302, // @brief: saturation of RGB camera            @range: [0, 100]     @defalut: 64
    Rgb_Hue                         = 0x0303, // @brief: hue of RGB camera                   @range: [-180, 180]  @defalut: 0
    Rgb_Gamma                       = 0x0304, // @brief: Gamma coefficient of RGB camera     @range: [100, 500]   @defalut: 300
    Rgb_WhiteBalanceTemperature     = 0x0305, // @brief: white balance temperature of RGB camera            @range: [2800, 6500]  @defalut: 4600 @step: 10
    Rgb_Sharpness                   = 0x0306, // @brief: sharpness of RGB camera                            @range: [0, 100]      @defalut: 50
    Rgb_BacklightCompensation       = 0x0307, // @brief: backlight compensation of RGB camera               @range: [0, 2]        @defalut: 0
    Rgb_ExposureAbsolute            = 0x0308, // @brief: exposure time of RGB camera                        @range: [50, 10000]   @defalut: 350
    Rgb_WhiteBalanceTemperatureAuto = 0x0309, // @brief: antomatic white balance temperature of RGB camera  @range: [0, 1]        @defalut: 1   @value meaning: 1(Auto) 0(Manual)
    Rgb_ExposureAuto                = 0x030A, // @brief: automatic exposure of RGB camera                   @range: [1, 3]        @defalut: 3   @value meaning: 3(Auto) 1(Manual)

    Mems_TriggerDelay               = 0x0400, // @brief: MEMS laser trigger interval time(ms). It must be greater than the maximum IR exposure time.  @range: [1, 1000]  @defalut: 25
    Mems_LaserKValue                = 0x0401, // @brief: MEMS laser's power.  @range: [0, 200]  @defalut: 50

    Algo_DepthMapType               = 0x0500, // @brief: depth map type                       @range: [1, 2]            @defalut: 2   @value meaning: 1(texture alignment) 2(point cloud alignment)
    Algo_DilateKsize                = 0x0501, // @brief: size of the window to fill the hole  @range: {3, 5, 7, 9, 11}  @defalut: 11  @value meaning: More holes will be filled when the value is larger
    Algo_FillHole                   = 0x0502, // @brief: enable switch of hole filling        @range: [0, 1]            @defalut: 0(disabled)
    Algo_KSize                      = 0x0503, // @brief: size of smoothing window             @range: {3, 5, 7, 9, 11, 13, 15, 17, 19, 21} @defalut: 11
    Algo_Sigma                      = 0x0504, // @brief: Gaussian smooth standard deviation   @range: [1, 7]            @defalut: 7   @value meaning: Larger value means harder smoothing
    Algo_Smooth                     = 0x0505, // @brief: enable switch of smooth  @range: [0, 1]  @defalut: 0(disabled)
    Algo_SmoothType                 = 0x0506, // @brief: smoothing type           @range: [0, 4]  @defalut: 2  @value meaning: 0(Gaussian smoothing), 1(bilateral smoothing), 2(Z-mean smoothing), 3(Z-bilateral smoothing), 4(Z-median smoothing)
    Algo_ZfRangeMax                 = 0x0507, // @brief: filter out points where z-direction is greater than max (mm)   @range: [0, 4000]  @defalut: 3000   @DataType: float
    Algo_ZfRangeMin                 = 0x0508, // @brief: filter out points where z-direction is less than min (mm)      @range: [0, 3000]  @defalut: 40     @DataType: float
    Algo_WrapphaseType              = 0x0509, // @brief: projection type of laser                     @range: [0, 11]   @defalut: based on system and mems version. attention: value 10/11 means signle white/black picture type, cann't generate apoint cloud under this type.
    Algo_FilterType                 = 0x050B, // @brief: filtering type  @range: {1, 3}  @defalut: 3  @value meaning:  1(gradient filtering), 3( piece segment match filtering)
    Algo_TriThreshold               = 0x050C, // @brief: filtering threshold of point cloud triangle  @range: [0, 300]  @defalut: 0
    Algo_ShadowThreshold            = 0x050F, // @brief: shadow threshold               @range: [0, 5]       @defalut: 0(disabled)
    Algo_GradNeedSerialNum          = 0x0510, // @brief: continuous effective phase     @range: [1, 5]       @defalut: 3   @remark: It takes effect when gradient filtering and multi-gradient matching are enabled.
    Algo_RecommendedZfRangeMax      = 0x0511, // @brief: recommended maximum z-direction distance (mm)       @read and write properties: ReadOnly
    Algo_RecommendedZfRangeMin      = 0x0512, // @brief: recommended minimum z-direction distance (mm)       @read and write properties: ReadOnly
    Algo_OutlierRemoval             = 0x0513, // @brief: outlier filtering              @range: [0, 1]       @defalut: 0(disabled)
    Algo_XfRangeMax                 = 0x0514, // @brief: upper limit of x-direction coordinate value in point cloud ROI (mm)  @range: [-10000.0, 10000.0]  @defalut: 10000.0   @DataType: float
    Algo_XfRangeMin                 = 0x0515, // @brief: lower limit of x-direction coordinate value in point cloud ROI (mm)  @range: [-10000.0, 10000.0]  @defalut: -10000.0  @DataType: float
    Algo_YfRangeMax                 = 0x0516, // @brief: upper limit of y-direction coordinate value in point cloud ROI (mm)  @range: [-10000.0, 10000.0]  @defalut: 10000.0   @DataType: float
    Algo_YfRangeMin                 = 0x0517, // @brief: lower limit of y-direction coordinate value in point cloud ROI (mm)  @range: [-10000.0, 10000.0]  @defalut: -10000.0  @DataType: float
    Algo_ImageFilterType            = 0x0518, // @brief: type of fringe image filtering  @range: [0, 1]     @defalut: 0   @value meaning: 0 means disabled and 1 means Gaussian filtering
    Algo_SmoothRadius               = 0x0519, // @brief: radius of Z smoothing           @range: [1, 5]     @defalut: 2   @value meaning: Larger value means harder smoothing
    Algo_ZSigma                     = 0x051A, // @brief: scale factor in Z smoothing     @range: [20, 150]  @defalut: 20  @value meaning: Larger value means harder smoothing
    Algo_TextureMappingType         = 0x051C, // @brief: texture mapping type            @range: [0, 2]     @defalut: 1   @value meaning: 0 means disabled, 1 means RGB texture mapping; 2 means IR mapping
    Algo_LrCheck                    = 0x051D, // @brief: left and right disparity consistency check switch  @range: [0, 1] @defalut: 0      @value meaning: 0 means disabled, 1 means enabling Consistency Check
    Algo_LrCheckThreshold           = 0x051E, // @brief: disparity constraint threshold  @range: [0.3, 2.0] @defalut: 1.0  @DataType: float @value meaning: Larger value means harder threshold

    ParamType_End                   = 0x0E00,

    ParamType_Get_Offset            = 0xA000 // @brief: In order to distinguish between set and get in internal communication, the get command will add this offset.
}

#region class Camera
public class Camera : global::System.IDisposable, ICamera
{
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal Camera(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Camera obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~Camera() {
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
          CameraProPINVOKE.delete_Camera(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public virtual int DiscoverCameras(CameraInfoVector camInfoVector, uint timeout = 6000) {
    int ret = CameraProPINVOKE.Camera_DiscoverCameras__SWIG_0(swigCPtr, CameraInfoVector.getCPtr(camInfoVector), timeout);
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual int DiscoverCameras(CameraInfoVector camInfoVector) {
    int ret = CameraProPINVOKE.Camera_DiscoverCameras__SWIG_1(swigCPtr, CameraInfoVector.getCPtr(camInfoVector));
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual int Open(CameraInfo cameraInfo, uint timeout) {
    int ret = CameraProPINVOKE.Camera_Open__SWIG_0(swigCPtr, CameraInfo.getCPtr(cameraInfo), timeout);
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual int Open(CameraInfo cameraInfo) {
    int ret = CameraProPINVOKE.Camera_Open__SWIG_1(swigCPtr, CameraInfo.getCPtr(cameraInfo));
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual int Capture(CameraInfo cameraInfo, FrameData frameData) {
    int ret = CameraProPINVOKE.Camera_Capture(swigCPtr, CameraInfo.getCPtr(cameraInfo), FrameData.getCPtr(frameData));
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual void RegisterErrorCodeHandler(ErrorCodeHandler errorCodeHandler) {
    CameraProPINVOKE.Camera_RegisterErrorCodeHandler(swigCPtr, ErrorCodeHandler.getCPtr(errorCodeHandler));
  }

  public virtual void RegisterFrameDataHandler(FrameDataHandler frameDataHandler, uint timeout = 3000) {
    CameraProPINVOKE.Camera_RegisterFrameDataHandler__SWIG_0(swigCPtr, FrameDataHandler.getCPtr(frameDataHandler), timeout);
  }

  public virtual int CaptureDataAsync(CameraInfo cameraInfo) {
    int ret = CameraProPINVOKE.Camera_CaptureDataAsync(swigCPtr, CameraInfo.getCPtr(cameraInfo));
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual void SetCameraIP(CameraInfo cameraInfo, string newIP) {
    CameraProPINVOKE.Camera_SetCameraIP(swigCPtr, CameraInfo.getCPtr(cameraInfo), newIP);
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void SetCameraToDHCP(CameraInfo cameraInfo) {
    CameraProPINVOKE.Camera_SetCameraToDHCP(swigCPtr, CameraInfo.getCPtr(cameraInfo));
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual int CameraGetStatus(CameraInfo cameraInfo) {
    int ret = CameraProPINVOKE.Camera_CameraGetStatus(swigCPtr, CameraInfo.getCPtr(cameraInfo));
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual int SetValue(CameraInfo cameraInfo, ParamType type, int value) {
    int ret = CameraProPINVOKE.Camera_SetValue__SWIG_0(swigCPtr, CameraInfo.getCPtr(cameraInfo), (int)type, value);
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual int GetValue(CameraInfo cameraInfo, ParamType type, ref int value) {
    int ret = CameraProPINVOKE.Camera_GetValue__SWIG_0(swigCPtr, CameraInfo.getCPtr(cameraInfo), (int)type, ref value);
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual int SetValue(CameraInfo cameraInfo, ParamType type, float value) {
    int ret = CameraProPINVOKE.Camera_SetValue__SWIG_1(swigCPtr, CameraInfo.getCPtr(cameraInfo), (int)type, value);
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual int GetValue(CameraInfo cameraInfo, ParamType type, ref float value) {
    int ret = CameraProPINVOKE.Camera_GetValue__SWIG_1(swigCPtr, CameraInfo.getCPtr(cameraInfo), (int)type, ref value);
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual int SendMemsCommands(CameraInfo cameraInfo, string strCommands) {
    int ret = CameraProPINVOKE.Camera_SendMemsCommands(swigCPtr, CameraInfo.getCPtr(cameraInfo), strCommands);
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  unsafe public virtual int SendAndRecvMemsCommands(CameraInfo cameraInfo, string strCommands, out string strRecv) {
    int ret = CameraProPINVOKE.Camera_SendAndRecvMemsCommands(swigCPtr, CameraInfo.getCPtr(cameraInfo), strCommands, out strRecv);
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual int CameraGetVersion(CameraInfo cameraInfo) {
    int ret = CameraProPINVOKE.Camera_CameraGetVersion(swigCPtr, CameraInfo.getCPtr(cameraInfo));
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual int CameraSetTriggerOutParam(CameraInfo cameraInfo, ushort mode, ushort cycleNumValue, ushort cycleLenValue) {
    int ret = CameraProPINVOKE.Camera_CameraSetTriggerOutParam(swigCPtr, CameraInfo.getCPtr(cameraInfo), mode, cycleNumValue, cycleLenValue);
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual int CameraGetTriggerOutParam(CameraInfo cameraInfo, ref ushort mode, ref ushort cycleNumValue, ref ushort cycleLenValue) {
        int ret = CameraProPINVOKE.Camera_CameraGetTriggerOutParam(swigCPtr, CameraInfo.getCPtr(cameraInfo), ref mode, ref cycleNumValue, ref cycleLenValue);
        if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
        return ret;
    }

  public virtual int AddParamGroup(CameraInfo cameraInfo, string paramGroupName) {
    int ret = CameraProPINVOKE.Camera_AddParamGroup(swigCPtr, CameraInfo.getCPtr(cameraInfo), paramGroupName);
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual int GetParamGroups(CameraInfo cameraInfo, StringVector paramGroupNames) {
    int ret = CameraProPINVOKE.Camera_GetParamGroups(swigCPtr, CameraInfo.getCPtr(cameraInfo), StringVector.getCPtr(paramGroupNames));
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual int DeleteParamGroup(CameraInfo cameraInfo, string paramGroupName) {
    int ret = CameraProPINVOKE.Camera_DeleteParamGroup(swigCPtr, CameraInfo.getCPtr(cameraInfo), paramGroupName);
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual int ApplyParamGroup(CameraInfo cameraInfo, string paramGroupName) {
    int ret = CameraProPINVOKE.Camera_ApplyParamGroup(swigCPtr, CameraInfo.getCPtr(cameraInfo), paramGroupName);
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual int ReconstructPoints(CameraInfo cameraInfo, Point2fVector leftPoints, Point2fVector rightPoints, Point3fVector points) {
    int ret = CameraProPINVOKE.Camera_ReconstructPoints(swigCPtr, CameraInfo.getCPtr(cameraInfo), Point2fVector.getCPtr(leftPoints), Point2fVector.getCPtr(rightPoints), Point3fVector.getCPtr(points));
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual int GetAttributeTreeJson(CameraInfo cameraInfo, /*cstype*/ out string strAttributeTreeJson)
  {
    int ret = CameraProPINVOKE.Camera_GetAttributeTreeJson(swigCPtr, CameraInfo.getCPtr(cameraInfo), out strAttributeTreeJson);
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual int GetNodeAttributeJson(CameraInfo cameraInfo, string key, /*cstype*/ out string strNodeAttributeJson)
  {
    int ret = CameraProPINVOKE.Camera_GetNodeAttributeJson(swigCPtr, CameraInfo.getCPtr(cameraInfo), key, out strNodeAttributeJson);
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
      return ret;
  }

    public virtual int SetValue(CameraInfo cameraInfo, string key, bool value)
  {
    int ret = CameraProPINVOKE.Camera_SetValue__SWIG_2(swigCPtr, CameraInfo.getCPtr(cameraInfo), key, value);
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual int SetValue(CameraInfo cameraInfo, string key, int value)
  {
    int ret = CameraProPINVOKE.Camera_SetValue__SWIG_3(swigCPtr, CameraInfo.getCPtr(cameraInfo), key, value);
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual int SetValue(CameraInfo cameraInfo, string key, float value)
  {
    int ret = CameraProPINVOKE.Camera_SetValue__SWIG_4(swigCPtr, CameraInfo.getCPtr(cameraInfo), key, value);
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual int SetValue(CameraInfo cameraInfo, string key, double value)
  {
    int ret = CameraProPINVOKE.Camera_SetValue__SWIG_5(swigCPtr, CameraInfo.getCPtr(cameraInfo), key, value);
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual int GetValue(CameraInfo cameraInfo, string key, ref bool value)
  {
    int ret = CameraProPINVOKE.Camera_GetValue__SWIG_2(swigCPtr, CameraInfo.getCPtr(cameraInfo), key, ref value);
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual int GetValue(CameraInfo cameraInfo, string key, ref int value)
  {
    int ret = CameraProPINVOKE.Camera_GetValue__SWIG_3(swigCPtr, CameraInfo.getCPtr(cameraInfo), key, ref value);
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual int GetValue(CameraInfo cameraInfo, string key, ref float value)
  {
    int ret = CameraProPINVOKE.Camera_GetValue__SWIG_4(swigCPtr, CameraInfo.getCPtr(cameraInfo), key, ref value);
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual int GetValue(CameraInfo cameraInfo, string key, ref double value)
  {
    int ret = CameraProPINVOKE.Camera_GetValue__SWIG_5(swigCPtr, CameraInfo.getCPtr(cameraInfo), key, ref value);
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual int Get3DCameraIntrinsic(CameraInfo cameraInfo, CAMERA_POSITION cameraPosition, DoubleVector cameraIntrinsic) 
  {
    int ret = CameraProPINVOKE.Camera_Get3DCameraIntrinsic(swigCPtr, CameraInfo.getCPtr(cameraInfo), (int)cameraPosition, DoubleVector.getCPtr(cameraIntrinsic));
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual int Get3DCameraExtrinsic(CameraInfo cameraInfo, EXTRINSIC_TYPE extrinsicType, DoubleVector cameraExtrinsic)
  {
    int ret = CameraProPINVOKE.Camera_Get3DCameraExtrinsic(swigCPtr, CameraInfo.getCPtr(cameraInfo), (int)extrinsicType, DoubleVector.getCPtr(cameraExtrinsic));
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual int CameraReboot(CameraInfo cameraInfo) {
    int ret = CameraProPINVOKE.Camera_CameraReboot(swigCPtr, CameraInfo.getCPtr(cameraInfo));
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual void Close(CameraInfo cameraInfo) {
    CameraProPINVOKE.Camera_Close(swigCPtr, CameraInfo.getCPtr(cameraInfo));
    if (CameraProPINVOKE.SWIGPendingException.Pending) throw CameraProPINVOKE.SWIGPendingException.Retrieve();
  }
}
#endregion