using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace CYT.Web.FileUpload
{

    public enum FileUploadStatus
    {
        Success = 1, Fail, InvalidContentType, InvalidContentSize, InvalidContentCount
    }

    public class FileUploadResult
    {
        public FileUploadStatus Status { get; set; }
        public String Messages { get; set; }
        public MultipartFormDataStreamProvider MultipartFormDataStreamProvider { get; set; }
        public FileUploadResult(FileUploadStatus status, MultipartFormDataStreamProvider multipartFormDataStreamProvider, string message = "")
        {
            Status = status;
            Messages = message;
            MultipartFormDataStreamProvider = multipartFormDataStreamProvider;
        }

        public FileUploadResult(FileUploadStatus status, string message = "")
        {
            Status = status;
            Messages = message;        
        }
    }

}