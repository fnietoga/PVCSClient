using System;

namespace PVCSClient.Libraries
{
    public class PVCSFileGroup
    {
        public string Environment { get; set; }

        public string Version { get; set; }

        public PVCSFileGroup() { }

        /// <summary>
        /// 
        /// </summary>
        /// <example>-> SIT1                 Rev : 1.9</example>
        /// <example>-> IPVPN                Rev : 1.0</example>
        /// <param name="input"></param>
        public PVCSFileGroup(string input) : this()
        {
            this.Environment = input.ExtractString(@"\s*(?:->)\s*(\w+)\b");

            this.Version = input.ExtractVersion();
        }
    }
}