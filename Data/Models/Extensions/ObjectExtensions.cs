using FlashCardTailzor.Data.Models.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardTailzor.Data.Models.Extensions
{
    public static class ObjectExtensions
    {
        public static T? Clone<T>(this T? item)
        {
            if (item == null)
            {
                return item;
            }

            var itemParsed = JsonConvert.SerializeObject(item, JsonConfiguration.DefaultSerializeSettings);

            return JsonConvert.DeserializeObject<T>(itemParsed, JsonConfiguration.DefaultSerializeSettings);
        }
    }
}