using System.Collections;
using UnityEngine;

public class Loading : MonoBehaviour
{
    void Start()
    {
        LoadTransition();
    }

    public void LoadTransition()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(2f);
        GetComponent<SceneTransitions>().LoadTransition("Restaurant");
    }
}