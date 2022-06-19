namespace UnityTools.Extentions
{
    public static class StringExtentions
    {
        public static string PrepareLevelName(this string levelName)
        {
            return levelName.Replace("(Clone)", "");
        }
    }
}