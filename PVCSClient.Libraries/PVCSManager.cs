using System;
using Renci.SshNet;

namespace PVCSClient.Libraries
{
     
    public class PVCSManager : IDisposable
    {
        #region Multithreaded Singleton  

        internal static volatile PVCSManager _instance;
        private static object syncRoot = new Object();

        internal PVCSManager()
        {
            this.SessionId = Guid.NewGuid().ToString("N").ToUpper();
        }

        public static PVCSManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                    {
                        if (_instance == null)
                            _instance = new PVCSManager();
                    }
                }

                return _instance;
            }
        }

        #endregion

        public string SessionId { get; internal set; }
        public string HostOrIp { get; internal set; } = System.Configuration.ConfigurationManager.AppSettings["SshHost"]; 
        public int Port { get; internal set; } =  System.Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SshPort"]);
        public string Username { get; internal set; } =  System.Configuration.ConfigurationManager.AppSettings["SshUsername"];
        protected internal string Password { get; internal set; } =  System.Configuration.ConfigurationManager.AppSettings["SshPassword"];

        internal Renci.SshNet.ConnectionInfo ConnectionInfo
        {
            get
            {
                return new Renci.SshNet.ConnectionInfo(this.HostOrIp, this.Port, this.Username,
                    new Renci.SshNet.AuthenticationMethod[]{
                        // Pasword based Authentication
                        new Renci.SshNet.PasswordAuthenticationMethod(this.Username,this.Password),
                    }
                );

            }

        }

        private Renci.SshNet.SshClient _connection;
        internal Renci.SshNet.SshClient Connection
        {
            get
            {
                if (_connection == null)
                    _connection = new Renci.SshNet.SshClient(ConnectionInfo);

                if (!_connection.IsConnected) _connection.Connect();

                return _connection;
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="packagePath">Ruta del fichero (case sensitive)</param>
        /// <returns></returns>
        public PVCSBasicFileInfoCollection GetListado(string packagePath)
        {
            string command = string.Format("pvcs_listado.sh {0}", packagePath);
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
            using (var client = new Renci.SshNet.SshClient(this.ConnectionInfo))
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

        #region IDisposable
        /// <summary>
        /// Generic and public dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        /// <summary>
        /// Class finalizer
        /// </summary>
        ~PVCSManager()
        {
            // Finalizer calls Dispose(false)  
            Dispose(false);
        }

        /// <summary>
        /// Protected and conditional dispose.
        /// The bulk of the clean-up code is implemented in Dispose(bool)  
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources  
                if (_connection != null)
                {
                    if (_connection.IsConnected) _connection.Disconnect();
                    _connection.Dispose();
                    _connection = null;
                }
            }

            // free native resources if there are any.  

        }

        #endregion

    }
}

