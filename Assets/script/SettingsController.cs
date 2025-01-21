using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    public Toggle windowModeToggle;
    public Toggle soundToggle;
    public Slider volumeSlider;

    private Resolution[] resolutions;

    void Start()
    {

    }

    public void ApplySettings()
    {
        var selectedResolution = resolutions[resolutionDropdown.value];
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, windowModeToggle.isOn);

        AudioListener.volume = soundToggle.isOn ? volumeSlider.value / 100f : 0;

        PlayerPrefs.SetInt("Resolution", resolutionDropdown.value);
        PlayerPrefs.SetInt("WindowMode", windowModeToggle.isOn ? 1 : 0);
        PlayerPrefs.SetInt("Sound", soundToggle.isOn ? 1 : 0);
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
    }

    public void CloseSettings()
    {
        gameObject.SetActive(false);
    }
}
