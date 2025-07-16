using UnityEngine;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

public class RunNotebook : MonoBehaviour
{
    public string pythonScriptPath = "Assets\\\\test.py";
    public static RunNotebook I;

    void Awake()
    {
        if (I != null && I != this)
        {
            Destroy(this);
        }
        else
        {
            I = this;
        }
    }

    async void Start()
    {
        await RunPythonScriptAsync();
    }

    public async Task RunPythonScriptAsync()
    {
        ProcessStartInfo psi = new ProcessStartInfo();
        psi.FileName = "python.exe"; 
        psi.Arguments = pythonScriptPath;
        psi.UseShellExecute = false;
        psi.RedirectStandardOutput = true;
        psi.RedirectStandardError = true;
        psi.CreateNoWindow = true;

        using (Process process = new Process())
        {
            process.StartInfo = psi;
            process.OutputDataReceived += (sender, e) => { if (!string.IsNullOrEmpty(e.Data)) UnityEngine.Debug.Log("Output: " + e.Data);
                                                            if (e.Data.Contains("Offensive")) DataLoggerScript.I.isOffensive = true; };
            process.ErrorDataReceived += (sender, e) => { if (!string.IsNullOrEmpty(e.Data)) UnityEngine.Debug.LogError("Error: " + e.Data); };

            try
            {
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                await Task.Run(() => process.WaitForExit()); // Run WaitForExit in a separate thread

                if (process.ExitCode != 0)
                {
                    UnityEngine.Debug.LogError($"Python script failed with exit code: {process.ExitCode}");
                }
                else
                {
                    UnityEngine.Debug.Log("Python script execution complete.");
                }
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogError($"Error running Python script: {ex.Message}");
            }
        }
    }
}