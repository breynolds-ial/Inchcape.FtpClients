using Inchcape.FtpClients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

IConfiguration config = builder.Build();

var hostBuilder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddTransient<ISftpClient, SftpClient>();
        services.Configure<SftpClientSettings>(config.GetSection(""));
    });

var host = hostBuilder.Build();

var ftpSettings = new SftpClientSettings
{
    HostName = "ftp.s7.exacttarget.com",
    UserName = "7331167",
    Password = "8pG8uc!TuJ@2",
    SshHostKeyFingerprint = "ssh-rsa 2048 vkSTIEfKQCqAXu6zDQvyzAc9AMOIWekzs3IpY5vMtek"
};

var client = new SftpClient(ftpSettings);

client.PutFile("E:\\CertifiedUsed\\Downloads\\CertifiedUsedSFMCExtract.csv", "/Import/CUP/");
