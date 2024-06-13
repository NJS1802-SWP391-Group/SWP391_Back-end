using Business.Constants;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Firebase
{
    public interface IFirebaseService
    {
        Task<IServiceResult> UploadFileToFirebase(IFormFile file, string pathFileName);
        Task<IServiceResult> UploadFilesToFirebase(List<IFormFile> files, string basePath);
        public Task<string> GetUrlImageFromFirebase(string pathFileName);
        public Task<IServiceResult> DeleteFileFromFirebase(string pathFileName);
    }
}
