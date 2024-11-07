using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inchcape.FtpClients
{
    public class SftpClientSettings
    {
        public string HostName { get; set; } = String.Empty;
        public string UserName { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string SshHostKeyFingerprint { get; set; } = String.Empty;
    }
}
