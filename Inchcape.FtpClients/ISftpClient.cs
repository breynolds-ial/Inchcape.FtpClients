namespace Inchcape.FtpClients
{
    public interface ISftpClient
    {
        void GetFiles(string fileSpecIncludingFolder, string destinationPath);
    }
}
