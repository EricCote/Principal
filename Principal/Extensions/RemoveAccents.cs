using System.Globalization;

namespace Principal.Extensions
{
    public static class RemoveAccentsExtension
    {
        public static string RemoveAccents(this string s) 
        {
            return new string(
                    s.Normalize(System.Text.NormalizationForm.FormD).
                    Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).
                    ToArray()
             );
        
        }
    }
}
