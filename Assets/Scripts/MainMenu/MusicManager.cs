using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
  [SerializeField] AudioSource musicMainMenu = null;
  [SerializeField] AudioSource musicRestaurant = null;
  [SerializeField] AudioSource musicDungeon = null;
  [SerializeField] AudioSource musicGameOver = null;
  
  public static MusicManager instance = null;

  private void Awake()
  {
    if (instance == null)
    {
      instance = this;
    }
    else if (instance != this)
    {
      Destroy(this.gameObject);
    }

    if (PlayerPrefs.HasKey("volume") == false)
    {
      PlayerPrefs.SetFloat("volume", 0.5f);
    }

    AudioListener.volume = PlayerPrefs.GetFloat("volume");

    DontDestroyOnLoad(this.gameObject);
  }

  private void Update()
  {
    if (!musicMainMenu.isPlaying && ActiveScene("MainMenu"))
    {
      musicMainMenu.Play();
    }
    else if (!musicRestaurant.isPlaying && ActiveScene("Restaurant"))
    {
      musicRestaurant.Play();
    }
    else if (!musicDungeon.isPlaying && ActiveScene("Dungeon"))
    {
      musicDungeon.Play();
    }
    else if (!musicGameOver.isPlaying && ActiveScene("GameOver"))
    {
      musicGameOver.Play();
    }

    if (musicMainMenu.isPlaying && !ActiveScene("MainMenu") && !ActiveScene("Difficulty") && !ActiveScene("Credits") && !ActiveScene("Options"))
    {
      musicMainMenu.Stop();
    }
    else if (musicRestaurant.isPlaying && !ActiveScene("Restaurant") && !ActiveScene("RecipeBook") && !ActiveScene("GameWon"))
    {
      musicRestaurant.Stop();
    }
    else if (musicDungeon.isPlaying && !ActiveScene("Dungeon"))
    {
      musicDungeon.Stop();
    }
    else if (musicGameOver.isPlaying && !ActiveScene("GameOver"))
    {
      musicGameOver.Stop();
    }
  }

  private bool ActiveScene(string sceneName)
  {
    return SceneManager.GetActiveScene().name.Equals(sceneName);
  }
}