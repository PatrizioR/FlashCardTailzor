using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardTailzor.Data.Models.Extensions
{
    public static class GuidExtension
    {
        public static string? ToShortString(this Guid? guid, int length = 5)
        {
            return guid?.ToShortString(length);
        }

        public static string? ToShortString(this Guid guid, int length = 5)
        {
            return guid.ToString()[..length];
        }
    }
}