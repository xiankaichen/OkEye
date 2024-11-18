namespace OkEye.Services.Interfaces
{
    /// <summary>
    /// 系统信息服务接口
    /// </summary>
    public interface ISystemInfoService
    {
        string GetCupRate();    // 获取CPU使用率
        string GetDiskRate();   // 获取磁盘使用率
        string GetRamRate();   // 获取内存使用率
    }
}
