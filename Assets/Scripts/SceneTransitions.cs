using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    public Animator anim;

    public void LoadTransition(string name)
    {
        StartCoroutine(LoadScene(name));
    }

    IEnumerator LoadScene(string sceneName)
    {
        Time.timeScale = 1f;
        anim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void PlayGame()
    {
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame()
    {
        Time.timeScale = 1f;
        anim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);

        if (PlayerPrefs.GetString("saved").Equals("true"))
        {
            SceneManager.LoadScene("Restaurant", LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene("Difficulty", LoadSceneMode.Single);
        }
    }
}