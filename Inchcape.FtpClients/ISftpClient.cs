namespace Inchcape.FtpClients
{
    public interface ISftpClient
    {
        void GetFiles(string fileSpecIncludingFolder, string destinationPath, bool removeAfterwards = false);
        void PutFile(string fileNameIncludingFolder, string destinationPath);
        //void PutFiles(string fileSpecIncludingFolder, string destinationPath);
    }
}
