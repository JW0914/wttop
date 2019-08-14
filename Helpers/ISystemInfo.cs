using System;
using System.Collections.Generic;

namespace wttop.Helpers {
    
    public interface ISystemInfo
    {
        OSInfo GetOSInfo();

        int GetCPUsCount();

        IEnumerable<Cpu> GetCPUsUsage();

        Memory GetMemoryUsage();

        Network GetNetworkStatistics();

        Process GetProcessActivity();

        Disk GetDiskActivity();
    }
}