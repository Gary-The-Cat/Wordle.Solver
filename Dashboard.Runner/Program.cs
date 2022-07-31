using System;
using System.Diagnostics;

var currentPath = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Process);

const string DashboardLocation = @"C:\Program Files\Impulse Dashboard\Impulse.Dashboard.exe";

const string PluginDirectory = @"C:\GitHub\code\Wordle.Solver\Application\Debug\net6.0-windows";

Process.Start(DashboardLocation, $"--plugin {PluginDirectory}");