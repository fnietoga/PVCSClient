using System;

namespace PVCSClient.Libraries
{ 
    public class PVCSBasicFileInfo  
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public string LockedBy { get; set; }

        public PVCSBasicFileInfo() { }

        /// <summary>
        /// 
        /// </summary>
        /// <example>CRM/BBDD/BTS/FUNCIONES/GIOR_OBTENERSINTOMAS.sql</example>
        /// <example>CRM/BBDD/BTS/FUNCIONES/SELECTUPDATEOLPOLLING_2.sql              Bloqueado por : amdo_d31</example>
        /// <param name="input"></param>
        public PVCSBasicFileInfo(string input) : this() {
            //TODO: Implement
            throw new NotImplementedException();           
        }
    }
}