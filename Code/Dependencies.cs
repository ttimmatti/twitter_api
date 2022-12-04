



static class Dependencies
{
    public static DateTime currentTime;
    public static string currentSave;
    public static string previousSave;
    public static HttpClient httpClient;
    public static void ReInit()
    {
        Dependencies.currentTime = DateTime.Now;
        Dependencies.currentSave = $"{currentTime.ToString("MM_dd")}/{GetExecCount()}.json";
        Dependencies.previousSave = GetExecCount() - 1 < 1 ? "" : $"{currentTime.ToString("MM_dd")}/{GetExecCount()-1}.json";
    }

    public static int GetExecCount()
    {
        if (!Directory.Exists(currentTime.ToString("MM_dd")))
            return 1;

        return int.Parse(File.ReadAllText("executionNum.txt"));
    }

    public static bool TodayFolderExists()
    {
        if (Directory.Exists(currentTime.ToString("MM_dd")))
            return true;

        return false;
    }
}
