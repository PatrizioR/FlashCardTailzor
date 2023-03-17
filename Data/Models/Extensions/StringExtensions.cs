using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FlashCardTailzor.Data.Models.Extensions
{
    public static partial class StringExtensions
    {
        private static readonly Regex htmlRegex = HtmlRegex();

        public static bool IsNullOrEmpty([NotNullWhen(false)] this string? input)
        {
            return string.IsNullOrEmpty(input);
        }

        public static bool HasText([NotNullWhen(true)] this string? input)
        {
            return !input.IsNullOrEmpty();
        }

        public static string? ToKebabString(this string? input, string split = "-")
        {
            if (input.IsNullOrEmpty())
            {
                return input;
            }

            var builder = new StringBuilder();
            builder.Append(input[..1].ToLower());
            if (input.Length > 2)
            {
                var lastUpper = false;
                foreach (var c in input[1..^1])
                {
                    if (char.IsUpper(c))
                    {
                        if (!lastUpper)
                        {
                            builder.Append(split);
                        }
                        lastUpper = true;
                    }
                    else
                    {
                        lastUpper = false;
                    }
                    builder.Append(c.ToString().ToLower());
                }
            }
            if (input.Length > 1)
            {
                builder.Append(input.Substring(input.Length - 1, 1).ToLower());
            }

            return builder.ToString();
        }

        public static string? RemoveHtml(this string? input)
        {
            if (input.IsNullOrEmpty())
            {
                return input;
            }

            var result = htmlRegex.Replace(input, string.Empty);
            return result.Replace("&nbsp;", " ").Replace("&amp;", "&");
        }

        public static string? TemplateOrDefault(this string? input, string template, string? defaultValue = null)
        {
            if (input.IsNullOrEmpty())
            {
                return defaultValue;
            }

            return template.Replace("{0}", input);
        }

        public static string? Shorten(this string? input, int maxLength = 30, string suffix = "...")
        {
            if (input.IsNullOrEmpty())
            {
                return input;
            }

            if (maxLength <= 0)
            {
                return string.Empty;
            }

            if (input.Length > maxLength)
            {
                return input[..maxLength] + suffix;
            }

            return input;
        }

        [GeneratedRegex("<.*?>", RegexOptions.Compiled)]
        private static partial Regex HtmlRegex();
    }
}