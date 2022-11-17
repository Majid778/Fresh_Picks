using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SettingsMenu : MonoBehaviour
{
    public GameObject panel;
    public GameObject confirmpanel;
    public InputField textBox;
    public AudioMixer audioMixer;
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void resetPlayerPrefs()
    {
        if (textBox.text == "RESET")
        {
            PlayerPrefs.DeleteAll();
            panel.SetActive(false);
            confirmpanel.SetActive(true);
        }
    }
    public void Openpanel()
    {
        panel.SetActive(true);
    }
}
