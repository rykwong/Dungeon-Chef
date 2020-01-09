using UnityEngine;

public class VolumeSlider : MonoBehaviour
{
    public void ChangeVol(float newValue) {
        float newVol = AudioListener.volume;
        newVol = newValue;
        PlayerPrefs.SetFloat("volume", newVol);
        AudioListener.volume = newVol;
    }
}