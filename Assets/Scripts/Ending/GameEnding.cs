using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
  [SerializeField] Image background = null;

  [SerializeField] Sprite GameOverHealth = null;
  [SerializeField] Sprite GameOverReputation = null;

  [SerializeField] Text level = null;
  [SerializeField] Text reputation = null;
  [SerializeField] Text correctOrders = null;
  [SerializeField] Text wrongOrders = null;

  private void Start()
  {
    if (SceneManager.GetActiveScene().name.Equals("GameOver"))
    {
      if (PlayerPrefs.GetInt("health") <= 0)
      {
        background.sprite = GameOverHealth;
      }
      else if (PlayerPrefs.GetInt("reputation") <= 0)
      {
        background.sprite = GameOverReputation;
      }
    }
    
    level.text = PlayerPrefs.GetInt("level").ToString();
    reputation.text = PlayerPrefs.GetInt("reputation").ToString();
    correctOrders.text = PlayerPrefs.GetInt("correctOrders").ToString();
    wrongOrders.text = PlayerPrefs.GetInt("wrongOrders").ToString();
  }

  public void ResetGame()
  {
    float masterVolume = PlayerPrefs.GetFloat("volume");
    PlayerPrefs.DeleteAll();
    PlayerPrefs.SetFloat("volume", masterVolume);

    List<string> emptyList = new List<string>();
    SaveIO.saveData("Inventory", emptyList);
    SaveIO.saveData("Furnace", emptyList);

    LoadScenes.loadMainMenuScene();
  }
}