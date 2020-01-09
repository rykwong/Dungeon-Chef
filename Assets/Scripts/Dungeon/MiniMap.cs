using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public GameObject minimap;
    private static bool mapOpen = false;
    void Update()
    {
        checkKey();
    }

    public void checkKey()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            if(mapOpen)
            {
                closemapPanel();
            }
            else
            {
                loadmapPanel();
            }
        }
    }

    public void loadmapPanel()
    {
        minimap.SetActive(true);
        Time.timeScale = 0f;
        mapOpen = true;
    }

    public void closemapPanel()
    {
        minimap.SetActive(false);
        Time.timeScale = 1f;
        mapOpen = false;
    }
}
