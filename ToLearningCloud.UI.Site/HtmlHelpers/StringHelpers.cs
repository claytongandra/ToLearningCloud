﻿using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ToLearningCloud.UI.Site.HtmlHelpers
{
    public static class StringHelpers
    {
        public static string ToSeoUrl(this string url)
        {
            // make the url lowercase
            string encodedUrl = (url ?? "").ToLower();

            // replace & with and
            encodedUrl = Regex.Replace(encodedUrl, @"\&+", "e");

            // remove characters
            encodedUrl = encodedUrl.Replace("'", "");

            // remove acentos
            encodedUrl = StringHelpers.RemoverAcentuacao(encodedUrl);

            // remove invalid characters
            encodedUrl = Regex.Replace(encodedUrl, @"[^a-z0-9]", "-");

            // remove duplicates
            encodedUrl = Regex.Replace(encodedUrl, @"-+", "-");

            // trim leading & trailing characters
            encodedUrl = encodedUrl.Trim('-');

            return encodedUrl;
        }

        public static string RemoverAcentuacao(this string text)
        {
            return new string(text
                .Normalize(NormalizationForm.FormD)
                .Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                .ToArray());
        }

        public static string UpperCaseFirst(this string title)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(title))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(title[0]) + title.Substring(1);
        }
    }
}