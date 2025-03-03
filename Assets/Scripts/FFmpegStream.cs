using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using UnityEngine;

public class FFmpegSphereStream : MonoBehaviour
{
    public GameObject sphere; // Assign your sphere GameObject in Unity Inspector
    public string videoUrl = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4";

    private Texture2D videoTexture;
    private Process ffmpegProcess;
    private Thread ffmpegThread;
    private bool isRunning = false;
    private byte[] frameBytes;

    private int width = 640;
    private int height = 360;

    void Start()
    {
        StartFFmpegStream();
    }

    void StartFFmpegStream()
    {
        if (ffmpegProcess != null)
        {
            StopFFmpeg();
        }

        videoTexture = new Texture2D(width, height, TextureFormat.RGB24, false);
        sphere.GetComponent<Renderer>().material.mainTexture = videoTexture;

        ffmpegProcess = new Process();
        string ffmpegPath = "Assets/Plugins/x86_64/ffmpeg.exe";

        ffmpegProcess.StartInfo.FileName = ffmpegPath;
        ffmpegProcess.StartInfo.Arguments = $"-i \"{videoUrl}\" -f rawvideo -pix_fmt rgb24 -";
        ffmpegProcess.StartInfo.RedirectStandardOutput = true;
        ffmpegProcess.StartInfo.RedirectStandardError = true;
        ffmpegProcess.StartInfo.UseShellExecute = false;
        ffmpegProcess.StartInfo.CreateNoWindow = true;

        try
        {
            isRunning = true;
            ffmpegProcess.Start();
            UnityEngine.Debug.Log("✅ FFmpeg Process Started Successfully!");

            ffmpegThread = new Thread(ReadFFmpegOutput);
            ffmpegThread.Start();
        }
        catch (Exception e)
        {
            UnityEngine.Debug.LogError($"❌ Error starting FFmpeg: {e.Message}");
        }
    }

    void ReadFFmpegOutput()
    {
        int frameSize = width * height * 3;
        byte[] buffer = new byte[frameSize];

        try
        {
            using (BinaryReader reader = new BinaryReader(ffmpegProcess.StandardOutput.BaseStream))
            {
                while (isRunning)
                {
                    int bytesRead = reader.Read(buffer, 0, frameSize);
                    
                }
            }
        }
        catch (Exception e)
        {
            UnityEngine.Debug.LogError($"❌ Error reading FFmpeg output: {e.Message}");
        }
    }

    void UpdateTexture()
    {
        if (frameBytes != null)
        {
            videoTexture.LoadRawTextureData(frameBytes);
            videoTexture.Apply();
            sphere.GetComponent<Renderer>().material.mainTexture = videoTexture;
        }
    }

    void StopFFmpeg()
    {
        isRunning = false;

        if (ffmpegProcess != null && !ffmpegProcess.HasExited)
        {
            ffmpegProcess.Kill();
            ffmpegProcess.Dispose();
        }

        ffmpegThread?.Join();
    }

    void OnApplicationQuit()
    {
        StopFFmpeg();
    }
}
