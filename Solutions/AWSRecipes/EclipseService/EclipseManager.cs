using System.Threading.Tasks;
using Eclipse.SDK;
using Eclipse.SDK.File;
using Eclipse.SDK.DTO;
namespace EclipseService
{
    public class EclipseManager
    {
        public async Task<FileDetail> GetFileDetailAsync(int fileID)
        {
            FileClient fileClient = EclipseFactory.CreateFileClient("", "", "");

            return await fileClient.FetchFileAsync(fileID);
        }
    }
}
