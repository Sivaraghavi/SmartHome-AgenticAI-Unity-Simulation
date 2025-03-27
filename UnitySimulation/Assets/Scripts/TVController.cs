using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class TVController : SmartDevice
{
    public bool isOn = false;
    public int volume = 10;
    public int channel = 1;
    public string source = "HDMI1";
    
    [SerializeField] private string roomNumberPublic = "Living Room";

    [Header("UI References")]
    [SerializeField] private TMP_Text TVStatusText;
    [SerializeField] private TMP_Text TVVolumeText;
    [SerializeField] private TMP_Text TVChannelText;
    [SerializeField] private TMP_Text TVSourceText;
    [SerializeField] private Image tvImage;          // For the OFF state
    [SerializeField] private RawImage tvVideo;          // For the OFF state
    [SerializeField] private Sprite tvOffSprite;     // TV OFF image

    [Header("Video Player")]
    [SerializeField] private VideoPlayer tvVideoPlayer;

    private void Start()
    {
        InitializeVideoPlayer();
        UpdateTVUI();
    }
    
    protected override void Awake()
    {
        base.Awake();
        SetRoomNumber(roomNumberPublic); // Assign SmartDevice's room number from public variable
    }
   
    private void InitializeVideoPlayer()
    {
        if (tvVideoPlayer != null)
        {
            tvVideoPlayer.playOnAwake = false;
            tvVideoPlayer.audioOutputMode = VideoAudioOutputMode.Direct;
            tvVideoPlayer.SetDirectAudioVolume(0, volume / 100f);
        }
    }

    public void ToggleTV(bool state)
    {
        isOn = state;
        UpdateTVUI();
        Debug.Log($"TV is now {(isOn ? "ON" : "OFF")}");
    }

    public void SetVolume(int vol)
    {
        volume = Mathf.Clamp(vol, 0, 100);
        if (tvVideoPlayer != null)
        {
            tvVideoPlayer.SetDirectAudioVolume(0, volume / 100f);
        }
        UpdateTVUI();
        Debug.Log($"TV volume set to {volume}");
    }

    public void SetChannel(int ch)
    {
        channel = ch;
        UpdateTVUI();
        Debug.Log($"TV channel set to {channel}");
    }

    public void SetSource(string newSource)
    {
        if (newSource == "HDMI1" || newSource == "HDMI2")
        {
            source = newSource;
            UpdateTVUI();
            Debug.Log($"TV source set to {source}");
        }
        else
        {
            Debug.LogError("Invalid TV source! Choose HDMI1 or HDMI2.");
        }
    }

    private void UpdateTVUI()
    {
        // Update text displays
        if (TVStatusText != null)
            TVStatusText.text = $"TV: {(isOn ? "ON" : "OFF")}";
        if (TVVolumeText != null)
            TVVolumeText.text = $"Volume: {volume}";
        if (TVChannelText != null)
            TVChannelText.text = $"Channel: {channel}";
        if (TVSourceText != null)
            TVSourceText.text = $"Source: {source}";

        // Update visual state
        if (tvImage != null)
        {
            tvImage.gameObject.SetActive(!isOn);
            tvVideo.gameObject.SetActive(isOn);
            tvImage.sprite = tvOffSprite;
        }

        // Control video playback
        if (tvVideoPlayer != null)
        {
            if (isOn && !tvVideoPlayer.isPlaying)
            {
                tvVideoPlayer.Play();
            }
            else if (!isOn && tvVideoPlayer.isPlaying)
            {
                tvVideoPlayer.Pause();
            }
        }
    }
}
