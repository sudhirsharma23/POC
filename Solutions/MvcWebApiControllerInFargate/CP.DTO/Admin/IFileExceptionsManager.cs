

namespace CP.DTO.Admin
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

    public interface IFileExceptionsManager
    {
        bool SendToException(int consumerFileid);
        GetFileExceptionsResponse GetFileExceptions();
        GetFilesResponse GetConsumerFiles(int fastDataConsumerFileID, int spDataConsumerFileID);

        bool NotifyIdaass(GetFilesResponse files);

        bool UpdateSPUserFromManageException(GetFilesResponse files);
        List<int> GetExceptionFilePrincipalId();

    }
}

