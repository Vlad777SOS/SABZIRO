using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
    // Mute Button and Icons
    public Button muteButton;
    public Sprite soundOnIcon;
    public Sprite soundOffIcon;
    public AudioMixer audioMixer;

    private bool isMuted = false;

    // Volume Slider
    public Slider volumeSlider;

    void Start()
    {
        // Set slider to maximum volume on start
        float currentVolume;
        audioMixer.GetFloat("MasterVolume", out currentVolume); // Get the current volume value from the AudioMixer

        if (currentVolume <= -80f)
        {
            // If volume is set to mute in the mixer, set slider to 0
            volumeSlider.value = 0f;
            isMuted = true;
        }
        else
        {
            // Otherwise, set slider to max
            volumeSlider.value = 1f; // Max value for slider
            isMuted = false;
        }

        // Add listeners for mute button and volume slider
        muteButton.onClick.AddListener(ToggleMute);
        volumeSlider.onValueChanged.AddListener(SetVolume);
        UpdateMuteIcon();
    }

    void ToggleMute()
    {
        isMuted = !isMuted;
        if (isMuted)
        {
            audioMixer.SetFloat("MasterVolume", -80); // Mute volume
            volumeSlider.value = 0f; // Reflect mute in the slider
        }
        else
        {
            audioMixer.SetFloat("MasterVolume", Mathf.Log10(volumeSlider.value) * 20); // Restore volume based on slider value
            volumeSlider.value = 1f; // Set slider back to maximum if unmuted
        }
        UpdateMuteIcon();
    }

    void UpdateMuteIcon()
    {
        if (isMuted)
        {
            muteButton.GetComponent<Image>().sprite = soundOffIcon;
        }
        else
        {
            muteButton.GetComponent<Image>().sprite = soundOnIcon;
        }
    }

    public void SetVolume(float volume)
    {
        if (!isMuted)
        {
            // Adjust volume based on slider
            audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20); // Adjust volume
        }
    }
}
