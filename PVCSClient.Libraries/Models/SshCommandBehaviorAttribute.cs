using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVCSClient.Libraries.Models
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class SshCommandBehaviorAttribute : System.Attribute
    {
        public string RegExExpression { get; set; }
        public string SshCommand { get; set; }

        public SshCommandBehaviorAttribute() { }

        public SshCommandBehaviorAttribute(string regExExpression)
        {
            RegExExpression = regExExpression;
        }
        public SshCommandBehaviorAttribute(string regExExpression, string sshCommand) : this(regExExpression)
        {
            SshCommand = sshCommand;
        }
    }
    }
