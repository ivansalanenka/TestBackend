using Owin.Server.Controllers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace Owin.Server.Controllers
{
    public class FileUploadController : ApiController
    {
        public string Post()
        {
            var contents = ParseContent(Request.Content);
            var file = (byte[])contents["file"]["File"];
            string filePath = string.Format("ui/files/{0}", contents["file"]["FileName"]);

            using (var fileStream = File.Create(filePath))
            {
                fileStream.Write(file, 0, file.Length);
            }

            return string.Format("files/{0}", contents["file"]["FileName"]);
        }

        public static Dictionary<string, Dictionary<string, object>> ParseContent(HttpContent content)
        {
            var provider = new MultipartMemoryStreamProvider();
            var httpContentList = content.ReadAsMultipartAsync(provider).
              ContinueWith(o => provider.Contents.ToList()).Result;

            if (httpContentList.Count == 0)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            var contents = new Dictionary<string, Dictionary<string, object>>();

            foreach (var httpContent in httpContentList)
            {
                var contentDispositionName = UnquoteToken(httpContent.Headers.ContentDisposition.Name);

                if (!string.IsNullOrWhiteSpace(httpContent.Headers.ContentDisposition.FileName))
                {
                    var bytes = GetBytes(httpContent);
                    contents.Add(contentDispositionName, new Dictionary<string, object>
            {
              {"File", bytes},
              {"FileName", UnquoteToken(httpContent.Headers.ContentDisposition.FileName)},
              {"MediaType", httpContent.Headers.ContentType.MediaType}
            });
                }
                else
                {
                    var text = Encoding.UTF8.GetString(GetBytes(httpContent));
                    contents.Add(contentDispositionName, new Dictionary<string, object>
            {
              {"Text", text}
            });
                }
            }

            return contents;
        }

        public static string UTF8ToUnicode(string input)
        {
            return Encoding.Unicode.GetString(Encoding.Convert(Encoding.UTF8, Encoding.Unicode, Encoding.UTF8.GetBytes(input)));
        }

        private static byte[] GetBytes(HttpContent content)
        {
            var inputStream = content.ReadAsStreamAsync().Result;
            var outputStream = new MemoryStream();

            inputStream.CopyTo(outputStream);
            return outputStream.ToArray();
        }

        private static string UnquoteToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return token;

            if (token.StartsWith("\"", StringComparison.Ordinal) && token.EndsWith("\"", StringComparison.Ordinal) && token.Length > 1)
                return token.Substring(1, token.Length - 2);

            return token;
        }
    }

}
