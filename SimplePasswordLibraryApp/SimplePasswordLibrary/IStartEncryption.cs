namespace SimplePasswordLibrary
{
    public interface IStartEncryption
    {
        string GetFinalPassword(PasswordModel passwordModel);
    }
}
