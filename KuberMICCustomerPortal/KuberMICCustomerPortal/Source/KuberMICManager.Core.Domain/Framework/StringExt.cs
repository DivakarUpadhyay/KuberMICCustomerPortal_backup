namespace KuberMICManager.Core.Domain.Framework
{
    public static class StringExt
    {
#nullable enable
        public static string? Truncate(this string? value, int maxLength, string truncationSuffix = "…")
        {
            return value?.Length > maxLength
                ? value.Substring(0, maxLength) + truncationSuffix
                : value;
        }
#nullable disable
    }
}
