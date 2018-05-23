using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace CYT.Web.FileUpload
{
    public class GuidMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        public GuidMultipartFormDataStreamProvider(string path)
            : base(path)
        {
        }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            string[] split = headers.ContentDisposition.FileName.Split('.');
            string extension = split[split.Length - 1];

            string name = String.Format("{0}.{1}", Guid.NewGuid(), extension);
            name = name.Replace("\"", "");
            return name;
        }
    }
}