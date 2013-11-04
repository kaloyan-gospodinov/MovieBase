using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Movie_Base.Services
{
    public static class Map
    {
        public static T DeserializeObject<T>(string objString)
        {
            var settings = new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore};
            return (T)JsonConvert.DeserializeObject<T>(objString, settings);
        }


        private static string DecompressBytes(byte[] compressedBytes)
        {
            string uncompressedObj = string.Empty;
            using (System.IO.Compression.GZipStream stream = new System.IO.Compression.GZipStream(new MemoryStream(compressedBytes, 0, compressedBytes.Length), System.IO.Compression.CompressionMode.Decompress))
            {
                MemoryStream memory = new MemoryStream();
                byte[] writeData = new byte[4096];
                int resLen;
                while ((resLen = stream.Read(writeData, 0, writeData.Length)) > 0)
                {
                    memory.Write(writeData, 0, resLen);
                }
                var uncompressedBytes = memory.ToArray();
                uncompressedObj = Encoding.UTF8.GetString(uncompressedBytes, 0, uncompressedBytes.Length);
            }
            return uncompressedObj;
        }

        async public static Task<T> LoadObject<T>(string apiCall)
        {
            var ws = new HttpClient();
            var uriAPICall = new Uri(apiCall);
            var objString = await ws.GetStringAsync(uriAPICall);
            return (T)DeserializeObject<T>(objString);
        }

        async public static Task<T> LoadCompressedObject<T>(string apiCall)
        {
            var ws = new HttpClient();
            ws.DefaultRequestHeaders.AcceptEncoding.Add(StringWithQualityHeaderValue.Parse("DEFLATE"));
            var uriAPICall = new Uri(apiCall);
            var objArray = await ws.GetByteArrayAsync(uriAPICall);
            var uncompressedString = DecompressBytes(objArray);
            return (T)DeserializeObject<T>(uncompressedString);
        }
    }
}