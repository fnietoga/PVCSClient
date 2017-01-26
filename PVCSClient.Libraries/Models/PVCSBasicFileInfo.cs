using System;

namespace PVCSClient.Libraries
{
    public class PVCSBasicFileInfo
    {
        string Path { get; set; }
        string Name { get; set; }
        string LockedBy { get; set; }

        public PVCSBasicFileInfo() { }

        /// <summary>
        /// 
        /// </summary>
        /// <example>CRM/BBDD/BTS/FUNCIONES/GIOR_OBTENERSINTOMAS.sql</example>
        /// <example>CRM/BBDD/BTS/FUNCIONES/SELECTUPDATEOLPOLLING_2.sql              Bloqueado por : amdo_d31</example>
        /// <param name="input"></param>
        public PVCSBasicFileInfo(string input) : this() {
            throw new NotImplementedException();
        }
    }
}