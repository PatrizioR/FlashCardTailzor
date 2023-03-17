using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardTailzor.Data.Models.Configuration
{
    public static class JsonConfiguration
    {
        public static readonly JsonSerializerSettings DefaultSerializeSettings = new()
        {
            Formatting = Formatting.Indented,
        };
    }
}
