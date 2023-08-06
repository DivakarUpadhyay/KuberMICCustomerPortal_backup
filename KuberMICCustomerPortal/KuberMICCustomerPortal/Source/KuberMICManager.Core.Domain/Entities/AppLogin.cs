using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class AppLogin
    {
        public string RecId { get; set; }
        public DateTime? Login { get; set; }
        public DateTime? Logout { get; set; }
        public string WinloginName { get; set; }
        public string TmologinName { get; set; }
        public string HostdomainName { get; set; }
        public string HostcomputerName { get; set; }
        public string HostphysicalAddress { get; set; }
        public string HostpublicIpaddress { get; set; }
        public string HostprivateIpaddress { get; set; }
        public bool? RemoteSession { get; set; }
        public string ClientDomainName { get; set; }
        public string ClientComputerName { get; set; }
        public string ClientIpaddress { get; set; }
        public string WtsloginName { get; set; }
        public string WtssessionName { get; set; }
        public int? DeviceId { get; set; }
        public string CpuId { get; set; }
        public string OsId { get; set; }
        public string VideoControllerId { get; set; }
        public string AppserialNumber { get; set; }
        public string AppversionNumber { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecSource { get; set; }
        public int? SysRecStatus { get; set; }
    }
}
