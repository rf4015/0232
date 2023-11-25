namespace MarienProject.Web.Services.Contracts
{
    public interface IEncryptionService
    {
        string Encrypt(string data);
        string Decrypt(string encryptedData);
    }
}
