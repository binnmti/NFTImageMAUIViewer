using System.Diagnostics;

namespace GethGUI
{
    internal static class GethExe
    {
        public static string Run(string folderName, string arguments)
        {
            using var ps = new Process();
            ps.StartInfo.FileName = Environment.GetEnvironmentVariable("ComSpec");
            ps.StartInfo.Arguments = $"/c geth {arguments}";
            ps.StartInfo.WorkingDirectory = folderName;
            ps.StartInfo.RedirectStandardOutput = true;
            ps.StartInfo.RedirectStandardError = true;
            ps.StartInfo.UseShellExecute = false;
            ps.StartInfo.CreateNoWindow = true;
            ps.Start();
            ps.WaitForExit();

            var log = ps.StandardError.ReadToEnd();
            log += ps.StandardOutput.ReadToEnd();
            return log;
        }
    }
}
