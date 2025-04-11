using Microsoft.Extensions.Options;
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

        public SftpClient(IOptions<SftpClientSettings> settings)
        {
            _settings = settings.Value;
        }

        SessionOptions GetSessionOptions()
        {
            SessionOptions sessionOptions = new SessionOptions
            {
                Protocol = Protocol.Sftp,
                HostName = _settings.HostName,
                UserName = _settings.UserName,
                Password = _settings.Password,
                SshHostKeyFingerprint = _settings.SshHostKeyFingerprint
            };

            return sessionOptions;
        }
        public void GetFiles(string fileSpecIncludingFolder, string destinationPath, bool removeAfterwards)
        {
            using (Session session = new Session())
            {
                // Connect
                session.Open(GetSessionOptions());

                // Download files
                TransferOptions transferOptions = new TransferOptions();
                transferOptions.TransferMode = TransferMode.Binary;

                TransferOperationResult transferResult;
                transferResult = session.GetFiles(fileSpecIncludingFolder, destinationPath, removeAfterwards, transferOptions);
                transferResult.Check();
            }

        }

        public void PutFile(string fileNameIncludingFolder, string destinationPath)
        {
            using (Session session = new Session())
            {
                // Connect
                session.Open(GetSessionOptions());

                // Download files
                TransferOptions transferOptions = new TransferOptions();
                transferOptions.TransferMode = TransferMode.Binary;

                TransferOperationResult transferResult;
                transferResult = session.PutFiles(fileNameIncludingFolder, destinationPath, false, transferOptions);
                transferResult.Check();
            }
        }

        public void PutFiles(string fileSpecIncludingFolder, string destinationPath)
        {
            throw new NotImplementedException();
        }
    }
}
