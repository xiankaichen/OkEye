namespace OkEye.Core
{
    /// <summary>
    /// 区域名称
    /// </summary>
    public enum OkEyeCode
    {
		// 通用错误码
		Ok = 0,									// 成功
		Failed = -1,							// 失败				
		ParamError = 1002,				// 参数错误
		NotSupport = 1003,			// 不支持
		NotImplement = 1004,		// 未实现
		Timeout = 1005,					// 超时


		// 相机错误码
		CameraError = 2000,				//	相机错误
		CameraDisconnect =2001,		// 相机断开
		CameraNotFound = 2002,		// 未找到相机
		CameraNotSupported = 2003,		// 相机不支持
		CameraStatusError = 2004,				// 相机状态错误
		CameraIPError = 2005	,                   // 相机IP错误
        CameraDisConnectFailed = 2006,		// 连接相机失败
        CameraConnectFailed = 2007,     // 断开相机失败
        CameraFrameDataEmpty = 2008,    // 相机帧数据为空

        // 保存错误
        FrameSaveError = 3000,      // 保存帧错误


    }


}
