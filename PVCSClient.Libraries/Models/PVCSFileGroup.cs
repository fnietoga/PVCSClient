using System;

namespace PVCSClient.Libraries
{
    public class PVCSFileGroup
    {
        string Environment { get; set; }

        string Version { get; set; }

        public PVCSFileGroup() { }

        /// <summary>
        /// 
        /// </summary>
        /// <example>-> SIT1                 Rev : 1.9</example>
        /// <example>-> IPVPN                Rev : 1.0</example>
        /// <param name="input"></param>
        public PVCSFileGroup(string input) : this() {
            throw new NotImplementedException();
        }
    }
}