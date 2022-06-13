using System.Diagnostics;

const string DashboardLocation =
    @"C:\GitHub\code\Impulse.Dashboard\Impulse.Framework\Impulse.Dashboard\bin\Debug\net6.0-windows\Impulse.Dashboard.exe";

const string PluginDirectory = @"C:\GitHub\code\Wordle.Solver\Application\Debug\net6.0-windows";

Process.Start(DashboardLocation, $"--plugin {PluginDirectory}");