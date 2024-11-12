using OkEye.Services.Interfaces;
using System.Collections.Generic;

using System.Diagnostics;
using System.Linq;
using System.Management;

namespace OkEye.Services
{

    public class SystemInfoService : ISystemInfoService
    {
        public PerformanceCounter CpuOccupied;
        public PerformanceCounter RamOccupied;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "Only run in Windows")]
        public SystemInfoService()
        {
            CpuOccupied = new PerformanceCounter("Processor Information", "% Processor Utility", "_Total");
            RamOccupied = new PerformanceCounter("Memory", "% Committed Bytes In Use");

            
        }

        public string GetCupRate()
        {
            // 获取CPU占用率
            string cpurate = CpuOccupied.NextValue().ToString("F1") + "%";
            return cpurate;
        }

        public string GetDiskRate()
        {
            string diskrate = "0%";
            return diskrate;
        }

        public string GetRamRate()
        {
            string ramrate = RamOccupied.NextValue().ToString("F1") + "%";
            return ramrate;
        }
    }



}
