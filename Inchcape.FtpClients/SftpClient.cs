using WinSCP;

namespace Inchcape.FtpClients
{
    public class SftpClient : ISftpClient
    {
        private readonly SftpClientSettings _settings;

        public SftpClient(SftpClientSettings settings)
        {
            _settings = settings;
        }

        public void GetFiles(string fileSpecIncludingFolder, string destinationPath)
        {
            SessionOptions sessionOptions = new SessionOptions
            {
                Protocol = Protocol.Sftp,
                HostName = _settings.HostName,
                UserName = _settings.UserName,
                Password = _settings.Password,
                SshHostKeyFingerprint = _settings.SshHostKeyFingerprint
            };

            using (Session session = new Session())
            {
                // Connect
                session.Open(sessionOptions);

                // Download files
                TransferOptions transferOptions = new TransferOptions();
                transferOptions.TransferMode = TransferMode.Binary;

                TransferOperationResult transferResult;
                transferResult = session.GetFiles(fileSpecIncludingFolder, destinationPath, false, transferOptions);
                transferResult.Check();
            }

        }
    }
}
