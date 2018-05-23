using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace CYT.Web.FileUpload
{
    public class FileUploader
    {
        public HttpRequestMessage Request { get; set; }
        public MultipartFormDataStreamProvider Provider { get; set; }
        public int MaxFiles { get; set; }

        public int MaxFileSize { get; set; }

        public IEnumerable<string> AllowedExtensions { get; set; }

        public FileUploader(HttpRequestMessage request, MultipartFormDataStreamProvider provider, ICollection<string> allowedExtensions, int maxFiles = 1, int maxFileSize = 5120)
        {
            Request = request;
            Provider = provider;
            MaxFiles = MaxFiles;
            MaxFileSize = maxFileSize;
            AllowedExtensions = allowedExtensions;
        }

        public async Task<FileUploadResult> Upload()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            MultipartFormDataStreamProvider result = await Request.Content.ReadAsMultipartAsync(Provider);

            return new FileUploadResult(FileUploadStatus.Success, result);
        }

        public FileInfo GetFileInfo()
        {
            string file = Provider.FileData.FirstOrDefault() == null ? null : Provider.FileData.FirstOrDefault().LocalFileName;
            return file == null ? null : new FileInfo(file);
        }

        public FileUploadResult Validate()
        {
            if (Provider.FileData.Count > MaxFiles)
            {
                return new FileUploadResult(FileUploadStatus.InvalidContentCount);
            }

            foreach (var file in Provider.FileData)
            {
                var fileinfo = new FileInfo(file.LocalFileName);
                if (fileinfo.Length > MaxFileSize)
                    return new FileUploadResult(FileUploadStatus.InvalidContentSize);

                if (!AllowedExtensions.Contains(fileinfo.Extension))
                    return new FileUploadResult(FileUploadStatus.InvalidContentType);
            }

            return new FileUploadResult(FileUploadStatus.Success);
        }
    }
}