using UnityEngine;
using UnityEngine.SceneManagement;

public class Difficulty : MonoBehaviour
{
  public void Easy()
  {
    PlayerPrefs.SetFloat("difficulty", 1.0f);
    SceneManager.LoadScene("Restaurant", LoadSceneMode.Single);
  }

  public void Normal()
  {
    PlayerPrefs.SetFloat("difficulty", 1.5f);
    SceneManager.LoadScene("Restaurant", LoadSceneMode.Single);
  }

  public void Hard()
  {
    PlayerPrefs.SetFloat("difficulty", 2.0f);
    SceneManager.LoadScene("Restaurant", LoadSceneMode.Single);
  }
}