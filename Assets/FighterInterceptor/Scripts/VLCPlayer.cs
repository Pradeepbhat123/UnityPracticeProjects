using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.InteropServices;

public class VLCPlayer : MonoBehaviour
{
    public RawImage videoDisplay; // Assign this in the Inspector
    private IntPtr libVLC;
    private IntPtr mediaPlayer;
    private Texture2D videoTexture;
    private RenderTexture renderTexture;

    [DllImport("libvlc")]
    private static extern IntPtr libvlc_new(int argc, IntPtr argv);

    [DllImport("libvlc")]
    private static extern IntPtr libvlc_media_new_location(IntPtr instance, string path);

    [DllImport("libvlc")]
    private static extern IntPtr libvlc_media_player_new_from_media(IntPtr media);

    [DllImport("libvlc")]
    private static extern void libvlc_media_release(IntPtr media);

    [DllImport("libvlc")]
    private static extern void libvlc_media_player_play(IntPtr player);

    [DllImport("libvlc")]
    private static extern void libvlc_media_player_set_hwnd(IntPtr player, IntPtr hwnd);

    [DllImport("libvlc")]
    private static extern void libvlc_media_player_stop(IntPtr player);

    [DllImport("libvlc")]
    private static extern void libvlc_media_player_release(IntPtr player);

    void Start()
    {
        // Initialize VLC
        libVLC = libvlc_new(0, IntPtr.Zero);

        // Set the video source (Replace with your RTSP URL or local file path)
        string videoPath = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4";  // Change this to your video URL
        IntPtr media = libvlc_media_new_location(libVLC, videoPath);
        mediaPlayer = libvlc_media_player_new_from_media(media);
        libvlc_media_release(media);

        // Create a RenderTexture to display the video
        renderTexture = new RenderTexture(1920, 1080, 16, RenderTextureFormat.ARGB32);
        renderTexture.Create();

        // Assign it to the RawImage UI element
        videoDisplay.texture = renderTexture;

        // Play the video
        libvlc_media_player_play(mediaPlayer);
    }

    void OnDestroy()
    {
        libvlc_media_player_stop(mediaPlayer);
        libvlc_media_player_release(mediaPlayer);
    }
}
