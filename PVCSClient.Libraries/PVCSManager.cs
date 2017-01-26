using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;
using System.Configuration;

namespace PVCSClient.Libraries
{
    public class PVCSManager
    {

        internal string HostOrIp { get { return System.Configuration.ConfigurationManager.AppSettings["SshHost"]; } }
        internal int Port { get { return System.Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SshPort"]); } }
        internal string Username { get { return System.Configuration.ConfigurationManager.AppSettings["SshUsername"]; } }
        internal string Password { get { return System.Configuration.ConfigurationManager.AppSettings["SshPassword"]; } }
        public ConnectionInfo Connection
        {
            get
            {
                return new ConnectionInfo(this.HostOrIp, this.Port, this.Username,
                    new AuthenticationMethod[]{

                        // Pasword based Authentication
                        new PasswordAuthenticationMethod(this.Username,this.Password),

                        //// Key Based Authentication (using keys in OpenSSH Format)
                        //new PrivateKeyAuthenticationMethod("username",new PrivateKeyFile[]{ 
                        //    new PrivateKeyFile(@"..\openssh.key","passphrase")
                        //}),
                    }
                );

            }

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="packagePath">Ruta del fichero (case sensitive)</param>
        /// <returns></returns>
        public PVCSBasicFileInfoCollection GetListado(string packagePath)
        {
            string command = string.Format("pvcs_listado.sh {0}",packagePath);
            string pvcsReturn = ExecutePVCSCommand(command);
            return new PVCSBasicFileInfoCollection(pvcsReturn);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="packageName">Nombre del fichero (case sensitive)</param>
        /// <param name="packagePath">Ruta del fichero (case sensitive)</param>
        /// <returns></returns>
        public PVCSFileInfo GetInfo(string packageName, string packagePath)
        {
            string command = string.Format("pvcs_info.sh {0} {1}", packageName, packagePath);
            string pvcsReturn = ExecutePVCSCommand(command);
            return new PVCSFileInfo(pvcsReturn);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="packageName">Nombre del fichero (case sensitive)</param>
        /// <param name="packagePath">Ruta del fichero (case sensitive)</param>
        /// <param name="description">Descripcion del fichero a añadir. Formato: (CODPROYECTO) Descripción (Usuario).</param>
        public void Add(System.IO.Stream fileStream, string packageName, string packagePath, string description)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="packageName">Nombre del fichero (case sensitive)</param>
        /// <param name="packagePath">Ruta del fichero (case sensitive)</param>
        /// <param name="version">Versión del fichero a obtener. La última versión si no se especifica.</param>
        /// <returns></returns>
        public System.IO.Stream Get(string packageName, string packagePath, string version)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="packageName">Nombre del fichero (case sensitive)</param>
        /// <param name="packagePath">Ruta del fichero (case sensitive)</param>
        /// <returns></returns>
        public System.IO.Stream Get(string packageName, string packagePath)
        {
            return this.Get(packageName, packagePath, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="packageName">Nombre del fichero (case sensitive)</param>
        /// <param name="packagePath">Ruta del fichero (case sensitive)</param>
        /// <param name="description">Descripción para la acción. Formato: (CODPROYECTO) Descripción (Usuario).</param>
        /// <returns></returns>
        public System.IO.Stream Checkout(string packageName, string packagePath, string description)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="packageName">Nombre del fichero (case sensitive)</param>
        /// <param name="packagePath">Ruta del fichero (case sensitive)</param>
        /// <param name="description">Descripción para la acción. Formato: Descripción (Usuario).</param>
        public void Checkin(System.IO.Stream fileContent, string packageName, string packagePath, string description)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="packageName">Nombre del fichero (case sensitive)</param>
        /// <param name="packagePath">Ruta del fichero (case sensitive)</param>
        public bool Unlock(string packageName, string packagePath)
        {
            string command = string.Format("pvcs_unlock.sh {0} {1}", packageName, packagePath);
            string pvcsReturn = ExecutePVCSCommand(command);
            return true; //TODO: Analizar respuesta de PVCS 
        } 

        private string ExecutePVCSCommand(string command)
        {
            string retVal = null;
            using (var client = new Renci.SshNet.SshClient(this.Connection))
            {
                client.Connect();

                using (var cmd = client.CreateCommand(command))
                {
                    cmd.Execute();                   
                    var streamReader = new System.IO.StreamReader(cmd.OutputStream);
                    retVal = streamReader.ReadToEnd();
                }
                client.Disconnect();
               
            }

            return retVal;
        }
    }
}

