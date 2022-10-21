namespace S3Recipes
{
    public interface IStorageService
    {
        void SaveFile(byte[] bytes, string filePath, string bucketName, string roleName);

        byte[] GetFile(string filePath, string bucketName, string roleName);
    }
}
