using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
  public void loadDungeonScene() {
    SceneManager.LoadScene("Dungeon", LoadSceneMode.Single);
  }

  public void loadRecipeBookScene() {
    SceneManager.LoadScene("RecipeBook", LoadSceneMode.Single);
  }

  public void loadRestaurantScene() {
    SceneManager.LoadScene("Restaurant", LoadSceneMode.Single);
  }

  public static void loadGameOverScene() {
    SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
  }

  public static void loadGameWonScene() {
    SceneManager.LoadScene("GameWon", LoadSceneMode.Single);
  }

  public static void loadMainMenuScene() {
    SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
  }

  public void quitGame() {
    Application.Quit();
  }
}