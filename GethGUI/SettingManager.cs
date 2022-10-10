using GethGUI.Model;
using System.Diagnostics;
using System.Text.Json;

namespace GethGUI;

/// <summary>
/// セーブ、ロードの責務を持つ
/// </summary>
public class SettingManager
{
    public static Genesis Load()
    {
        var filePath = GetFilePath();
        using var stream = File.Open(filePath, FileMode.Open);
        var data = JsonSerializer.Deserialize<Genesis>(stream);
        Trace.Assert(data != null);
        return data!;
    }

    public static void Save(Genesis setting)
    {
        var filePath = GetFilePath();
        // 例外はそのまま外に出す
        using var stream = File.Open(filePath, FileMode.Create);
        JsonSerializer.Serialize(stream, setting);
    }

    private static string GetFilePath()
    {
        var dirPath = AppContext.BaseDirectory;
        var fileName = "ConnpassAutomator.json";
        var filePath = Path.Join(dirPath, fileName);
        return filePath;
    }
}
