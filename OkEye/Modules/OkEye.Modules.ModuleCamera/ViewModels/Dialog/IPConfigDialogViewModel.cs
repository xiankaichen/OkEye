using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace OkEye.Modules.ModuleCamera.ViewModels
{
    public class IPConfigDialogViewModel : BindableBase, IDialogAware
    {
        public string Title { get; }

        private string _cameraIP;
        public string CameraIP
        {
            get { return _cameraIP; }
            set { SetProperty(ref _cameraIP, value); }
        }

        private string _cameraMask;
        public string CameraMask
        {
            get { return _cameraMask; }
            set { SetProperty(ref _cameraMask, value); }
        }

        private string userIP;
        public string UserIP
        {
            get { return userIP; }
            set { SetProperty(ref userIP, value); }
        }

        private string userMask;
        public string UserMask
        {
            get { return userMask; }
            set { SetProperty(ref userMask, value); }
        }


        public event Action<IDialogResult> RequestClose;
        public DelegateCommand YesDialogCommand { get; private set; }
        public DelegateCommand NoDialogCommand { get; private set; }

        private Logger<IPConfigDialogViewModel> _logger;
        public IPConfigDialogViewModel(Logger<IPConfigDialogViewModel> logger)
        {
            _logger = logger;
            _logger.LogInformation("打开IP配置窗口");
            YesDialogCommand = new DelegateCommand(() =>
            {
                DialogParameters param = new DialogParameters();

                param.Add("CameraIP", CameraIP);
                param.Add("CameraMask", CameraMask);
                param.Add("UserIP", UserIP);
                param.Add("UserMask", UserMask);

                RequestClose?.Invoke(new DialogResult(ButtonResult.OK, param));
            });
            NoDialogCommand = new DelegateCommand(() =>
            {
                RequestClose?.Invoke(new DialogResult(ButtonResult.No));
            });
        }




        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            CameraIP = parameters.GetValue<string>("CameraIP");
            CameraMask = parameters.GetValue<string>("CameraMask");
            UserIP = parameters.GetValue<string>("UserIP");
            UserMask = parameters.GetValue<string>("UserMask");
        }
    }


public static class IPProvider
    {

        // 获取IP地址对应的网络接口
        public static NetworkInterface GetNetworkInterface(IPAddress ipAddress)
        {
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in interfaces)
            {
                IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                foreach (var address in adapterProperties.UnicastAddresses)
                {
                    if (address.Address.Equals(ipAddress))
                    {
                        return adapter;
                    }
                }
            }
            return null;
        }

        //获取IPv4地址
        public static string GetIpv4Adress(NetworkInterface networkInterface)
        {
            IPInterfaceProperties adapterProperties = networkInterface.GetIPProperties();
            foreach (var unicastAddress in adapterProperties.UnicastAddresses)
            {
                if (unicastAddress.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {

                    return unicastAddress.Address.ToString();
                }

            }
            return "未知";

        }

        // 获取子网掩码
        public static string GetSubnetMask(NetworkInterface networkInterface)
        {
            IPInterfaceProperties adapterProperties = networkInterface.GetIPProperties();
            foreach (var unicastAddress in adapterProperties.UnicastAddresses)
            {
                if (unicastAddress.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return unicastAddress.IPv4Mask.ToString();
                }
            }
            return "未知";
        }

        // 获取默认网关
        public static string GetDefaultGateway(NetworkInterface networkInterface)
        {
            IPInterfaceProperties adapterProperties = networkInterface.GetIPProperties();
            foreach (var gatewayAddress in adapterProperties.GatewayAddresses)
            {
                return gatewayAddress.Address.ToString();
            }
            return "未知";
        }

        // 获取MAC地址
        public static string GetMacAddress(NetworkInterface networkInterface)
        {
            return BitConverter.ToString(networkInterface.GetPhysicalAddress().GetAddressBytes());
        }

        //获取所有本地网络信息
        public static void GetAllNetworks(ref Dictionary<string, string> AllNetworks)
        {
            AllNetworks.Clear();
            // 获取所有网络适配器
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {
                // 如果适配器支持IPv4并且不是虚拟适配器
                if (adapter.Supports(NetworkInterfaceComponent.IPv4) && !adapter.Description.Contains("Virtual"))
                {
                    //适配器名称:  adapter.Name;
                    //描述:  adapter.Description;
                    //MAC 地址:  adapter.GetPhysicalAddress();
                    //类型:  adapter.NetworkInterfaceType;
                    //操作状态:  adapter.OperationalStatus;
                    // 获取IP属性
                    IPInterfaceProperties ipProperties = adapter.GetIPProperties();
                    // 获取IPv4地址集
                    UnicastIPAddressInformationCollection addresses = ipProperties.UnicastAddresses;
                    foreach (UnicastIPAddressInformation address in addresses)
                    {
                        //ip版本4的地址并且不是本地回环地址
                        if (address.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork && !IPAddress.IsLoopback(address.Address))
                        {
                            if (!AllNetworks.Keys.Contains(adapter.Name))
                                AllNetworks.Add(adapter.Name, address.Address.ToString() + ":" + address.IPv4Mask.ToString());
                            //IPv4 地址:  address.Address
                            //子网掩码:  address.IPv4Mask
                        }
                    }
                }
            }


        }

        /// <summary>
        /// 根据已知Ip，修改改网口的网络信息
        /// </summary>
        /// <param name="OriginalIP">目标网口IP</param>
        /// <param name="ipAddress">新的Ip</param>
        /// <param name="subnetMask">新的子网掩码</param>
        /// <param name="defaultGateway">新的默认网关</param>
        public static void ModifyIPAddress(string OriginalIP, string ipAddress, string subnetMask, string defaultGateway, string dns = null)
        {
            ManagementClass mgmtClass = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection mgmtObjects = mgmtClass.GetInstances();

            foreach (ManagementObject mgmtObject in mgmtObjects)
            {
                if ((bool)mgmtObject["IPEnabled"])
                {
                    string[] addresses = (string[])mgmtObject["IPAddress"];
                    if (addresses != null && addresses.Length > 0 && addresses[0] == OriginalIP)
                    {
                        // 设置新的IP地址信息
                        ManagementBaseObject newIP = mgmtObject.GetMethodParameters("EnableStatic");
                        newIP["IPAddress"] = new string[] { ipAddress };
                        newIP["SubnetMask"] = new string[] { subnetMask };
                        ManagementBaseObject setIP = mgmtObject.InvokeMethod("EnableStatic", newIP, null);

                        //设置网关地址 
                        if (String.IsNullOrEmpty(defaultGateway))
                        {
                            mgmtObject.InvokeMethod("SetGateways", null);
                        }
                        else
                        {
                            // 设置新的默认网关
                            ManagementBaseObject newGateway = mgmtObject.GetMethodParameters("SetGateways");
                            newGateway["DefaultIPGateway"] = new string[] { defaultGateway };
                            newGateway["GatewayCostMetric"] = new int[] { 1 };
                            ManagementBaseObject setGateway = mgmtObject.InvokeMethod("SetGateways", newGateway, null);
                        }

                        //设置DNS 
                        if (String.IsNullOrEmpty(dns))
                        {
                            mgmtObject.InvokeMethod("SetDNSServerSearchOrder", null);
                        }
                        else
                        {
                            ManagementBaseObject newDNS = mgmtObject.GetMethodParameters("SetDNSServerSearchOrder");
                            newDNS["DNSServerSearchOrder"] = new string[] { dns }; //newDNS["DNSServerSearchOrder"] = new string[] { "DNS服务器地址1", "DNS服务器地址2" };
                            ManagementBaseObject setDNS = mgmtObject.InvokeMethod("SetDNSServerSearchOrder", newDNS, null);
                        }

                    }
                }
            }
        }


        /// <summary>
        /// 根据已知Ip地址，获取IP地址,子网掩码,默认网关信息[通过Management类库]
        /// </summary>
        /// <param name="OriginalIP"></param>
        /// <returns></returns>
        public static string getIPfromOriginalIP(string OriginalIP)
        {

            try
            {
                string ret = null;
                ManagementClass wmi = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = wmi.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    //如果没有启用IP设置的网络设备则跳过
                    //if (!(bool)mo["IPEnabled"])
                    //{
                    //    continue;
                    //}
                    if (mo["IPAddress"] != null)
                    {
                        string CurIP = (mo["IPAddress"] as String[])[0];
                        if (OriginalIP == CurIP)
                        {

                            //string caption = mo["Caption"].ToString();
                            //string mac = mo["MacAddress"].ToString();//Mac地址                    
                            string IPAddress = (mo["IPAddress"] as String[])?[0];//IP地址
                            string IPSubnet = (mo["IPSubnet"] as String[])?[0];//子网掩码
                            string DefaultIPGateway = (mo["DefaultIPGateway"] as String[])?[0];//默认网关
                            ret = IPAddress + "," + IPSubnet + "," + DefaultIPGateway;
                        }
                    }
                    mo.Dispose();
                }
                return ret;
            }
            catch (Exception)
            {
                return null;
            }


        }


        /// <summary>
        /// 根据MAC地址获取对应的IP地址
        /// </summary>
        /// <param name="macAddress">MAC</param>
        /// <returns>返回IP地址</returns>
        public static string GetIPAddressByMacAddress(string macAddress)
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                //判断网口是否连接
                //if (nic.OperationalStatus == OperationalStatus.Up)
                //{                  
                //}

                // 遍历网口的物理地址，查找匹配的MAC地址
                if (nic.GetPhysicalAddress().ToString().ToUpper() == macAddress.Replace("-", "").ToUpper())
                {
                    foreach (UnicastIPAddressInformation ip in nic.GetIPProperties().UnicastAddresses)
                    {
                        // 返回找到的IP地址
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            return ip.Address.ToString();
                        }
                    }
                }
            }

            // 没有找到匹配的IP地址
            return null;
        }


        /// <summary>
        /// 获取所有已识别以太网接口的Ip地址
        /// </summary>
        /// <returns></returns>
        public static List<string> getLocalNetworks()
        {
            List<string> Networks = new List<string>();
            try
            {
                // 获取本地计算机的所有网络接口
                NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

                // 遍历每个网络接口
                foreach (NetworkInterface networkInterface in networkInterfaces)
                {
                    // 仅考虑以太网接口&&网口处于连接状态
                    if (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet && networkInterface.OperationalStatus == OperationalStatus.Up)// || networkInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                    {
                        // 获取网络接口的IP属性
                        IPInterfaceProperties ipProperties = networkInterface.GetIPProperties();

                        // 遍历每个IP地址信息
                        foreach (UnicastIPAddressInformation ipInfo in ipProperties.UnicastAddresses)
                        {
                            // 仅考虑IPv4地址
                            if (ipInfo.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            {
                                Networks.Add(ipInfo.Address.ToString());
                                // Console.WriteLine($"Interface: {networkInterface.Name}, IP Address: {ipInfo.Address}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

            return Networks;

        }


        /// <summary>
        /// 根据已知mac地址，获取IP地址
        /// </summary>
        /// <param name="mac">返回IP地址</param>
        /// <returns></returns>
        public static string GetIpv4FromMACAddress(string mac)
        {
            try
            {
                string IPAddress = null;
                ManagementClass wmi = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = wmi.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    //如果没有启用IP设置的网络设备则跳过
                    if (!(bool)mo["IPEnabled"])
                    {
                        continue;
                    }
                    if (mo["MACAddress"] != null)
                    {
                        string momac = mo["MacAddress"].ToString().Replace(":", "").Replace("-", "").ToUpper();
                        mac = mac.ToUpper();
                        if (momac == mac)
                        {
                            //string Caption = mo["Caption"].ToString();
                            //string MacAddress = mo["MacAddress"].ToString();//Mac地址   
                            //string IPSubnet = (mo["IPSubnet"] as String[])[0];//子网掩码
                            //string DefaultIPGateway = (mo["DefaultIPGateway"] as String[])[0];//默认网关                 
                            IPAddress = (mo["IPAddress"] as String[])[0];//IP地址

                        }

                    }

                    mo.Dispose();
                }
                return IPAddress;
            }
            catch (Exception)
            {
                return null;
            }

        }

        /// <summary>
        /// 根据已知mac地址，获取IP子网掩码
        /// </summary>
        /// <param name="mac">返回IP子网掩码</param>
        /// <returns></returns>
        public static string GetSubnetMaskFromMACAddress(string mac)
        {
            try
            {
                string SubnetMask = null;
                ManagementClass wmi = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = wmi.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    //如果没有启用IP设置的网络设备则跳过
                    if (!(bool)mo["IPEnabled"])
                    {
                        continue;
                    }
                    if (mo["MACAddress"] != null)
                    {
                        string momac = mo["MacAddress"].ToString().Replace(":", "").Replace("-", "").ToUpper();
                        mac = mac.ToUpper();
                        if (momac == mac)
                        {
                            //string Caption = mo["Caption"].ToString();
                            //string MacAddress = mo["MacAddress"].ToString();//Mac地址   
                            SubnetMask = (mo["IPSubnet"] as String[])[0];//子网掩码
                                                                         //string DefaultIPGateway = (mo["DefaultIPGateway"] as String[])[0];//默认网关                 
                                                                         //string IPAddress = (mo["IPAddress"] as String[])[0];//IP地址


                        }

                    }

                    mo.Dispose();
                }
                return SubnetMask;
            }
            catch (Exception)
            {
                return null;
            }

        }

        /// <summary>
        /// 根据已知mac地址，获取IP默认网关
        /// </summary>
        /// <param name="mac">返回IP默认网关</param>
        /// <returns></returns>
        public static string GetDefaultGatewayFromMACAddress(string mac)
        {
            try
            {
                string DefaultGateway = null;
                ManagementClass wmi = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = wmi.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    //如果没有启用IP设置的网络设备则跳过
                    if (!(bool)mo["IPEnabled"])
                    {
                        continue;
                    }
                    if (mo["MACAddress"] != null)
                    {
                        string momac = mo["MacAddress"].ToString().Replace(":", "").Replace("-", "").ToUpper();
                        mac = mac.ToUpper();
                        if (momac == mac)
                        {
                            //string Caption = mo["Caption"].ToString();
                            //string MacAddress = mo["MacAddress"].ToString();//Mac地址   
                            //string IPSubnet = (mo["IPSubnet"] as String[])[0];//子网掩码
                            DefaultGateway = (mo["DefaultIPGateway"] as String[])[0];//默认网关                 
                                                                                     //string IPAddress = (mo["IPAddress"] as String[])[0];//IP地址


                        }

                    }

                    mo.Dispose();
                }
                return DefaultGateway;
            }
            catch (Exception)
            {
                return null;
            }

        }


        /// <summary>
        /// 匹配IP地址是否合法
        /// </summary>
        /// <param name="ip">当前需要匹配的IP地址</param>
        /// <returns>true:表示合法</returns>
        public static bool MatchIP(string ip)
        {
            bool success = false;
            if (!string.IsNullOrEmpty(ip))
            {
                //判断是否为IP
                success = System.Text.RegularExpressions.Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
            }
            return success;
        }

        /// <summary>
        /// 匹配端口是否合法
        /// </summary>
        /// <param name="port">当前需要匹配的端口地址</param>
        /// <returns>true：表示合法</returns>
        public static bool MatchPort(int port)
        {
            bool success = false;
            if (port >= 0 && port <= 65535)
            {
                success = true;
            }
            return success;
        }


        /// <summary>
        /// 检查IP是否可ping通
        /// </summary>
        /// <param name="strIP">要检查的IP</param>
        /// <returns>是否可连通【true:表示可以连通】</returns>
        public static bool CheckIPIsPing(string strIP)
        {
            if (!string.IsNullOrEmpty(strIP))
            {
                if (!MatchIP(strIP))
                {
                    return false;
                }
                // Windows L2TP VPN和非Windows VPN使用ping VPN服务端的方式获取是否可以连通
                Ping pingSender = new Ping();
                PingOptions options = new PingOptions();

                // 使用默认的128位值
                options.DontFragment = true;

                //创建一个32字节的缓存数据发送进行ping
                string data = "testtesttesttesttesttesttesttest";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 120;
                PingReply reply = pingSender.Send(strIP, timeout, buffer, options);

                return (reply.Status == IPStatus.Success);
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 匹配子网掩码是否合法
        /// </summary>
        /// <param name="mask">当前需要匹配的子网掩码地址</param>
        /// <returns></returns>
        public static bool MatchMask(string mask)
        {
            string[] vList = mask.Split('.');
            if (vList.Length != 4) return false;

            bool vZero = false; // 出现0 
            for (int j = 0; j < vList.Length; j++)
            {
                int i;
                if (!int.TryParse(vList[j], out i)) return false;
                if ((i < 0) || (i > 255)) return false;
                if (vZero)
                {
                    if (i != 0) return false;
                }
                else
                {
                    for (int k = 7; k >= 0; k--)
                    {
                        if (((i >> k) & 1) == 0) // 出现0 
                        {
                            vZero = true;
                        }
                        else
                        {
                            if (vZero) return false; // 不为0 
                        }
                    }
                }
            }

            return true;
        }


    }
}
