using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    [SerializeField] GameObject panel = null;

    public void openPanel()
    {
        panel.SetActive(true);
    }

    public void closePanel()
    {
        panel.SetActive(false);
    }
}