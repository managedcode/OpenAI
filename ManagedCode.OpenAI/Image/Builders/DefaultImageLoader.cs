using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagedCode.OpenAI.Image.Builders
{
    internal class DefaultImageLoader : IImageLoader
    {
        public string FromBytes(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        public string FromBase64(string base64)
        {
            return base64;
        }
    }
}
