using OkEye.Services.Interfaces;
using System.Collections.Generic;

using System.Diagnostics;
using System.Linq;
using System.Management;

namespace OkEye.Services
{
    /// <summary>
    /// 系统消息服务
    /// </summary>
    public class SystemInfoService : ISystemInfoService
    {
        public PerformanceCounter CpuOccupied;  // CPU占用率
        public PerformanceCounter RamOccupied; // 内存占用率

        /// <summary>
        /// 构造函数
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "Only run in Windows")]
        public SystemInfoService()
        {
            CpuOccupied = new PerformanceCounter("Processor Information", "% Processor Utility", "_Total");
            RamOccupied = new PerformanceCounter("Memory", "% Committed Bytes In Use");
        }

        /// <summary>
        /// 获取CPU使用率
        /// </summary>
        /// <returns></returns>
        public string GetCupRate()
        {
            // 获取CPU占用率
            string cpurate = CpuOccupied.NextValue().ToString("F1") + "%";
            return cpurate;
        }

        /// <summary>
        /// 获取磁盘使用率
        /// </summary>
        /// <returns></returns>
        public string GetDiskRate()
        {
            string diskrate = "0%";
            return diskrate;
        }

        /// <summary>
        /// 获取内存使用率
        /// </summary>
        /// <returns></returns>
        public string GetRamRate()
        {
            string ramrate = RamOccupied.NextValue().ToString("F1") + "%";
            return ramrate;
        }
    }



}
