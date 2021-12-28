using System;

namespace ArtSquare.Server.Services.ProductService
{
    public interface IStorageService
    {
        string StorageBaseUri { get; }
        Uri CreateUploadUri(string filename);
    }
   
}
