using System;

namespace NPCIL.Helper
{
    public class Parsing
    {
        public static int? ParseInt(string value)
        {
            return int.TryParse(value, out var result) ? (int?)result : null;
        }

        public static DateTime? ParseDateTime(string value)
        {
            return DateTime.TryParse(value, out var result) ? (DateTime?)result : null;
        }
    }
}
