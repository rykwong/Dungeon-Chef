using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    void Start()
    {
        float savedVol = PlayerPrefs.GetFloat("volume");
        GetComponent<Slider>().value = savedVol;
    }
}