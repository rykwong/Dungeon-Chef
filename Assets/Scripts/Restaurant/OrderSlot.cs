using UnityEngine;
using UnityEngine.UI;

public class OrderSlot : MonoBehaviour
{
  [SerializeField] string id;

  [SerializeField] Image order = null;
  [SerializeField] Text time = null;
  [SerializeField] Slider timer = null;

  [SerializeField] Image timerFill = null;

  [SerializeField] AudioSource sfxOrderCorrect = null;
  [SerializeField] AudioSource sfxOrderWrong = null;

  [SerializeField] Database database = null;

  private Recipe recipe = null;

  public ItemSlot itemSlot = null;

  private void Start()
  {
    if (PlayerPrefs.HasKey(id + "_recipe") && PlayerPrefs.HasKey(id + "_time"))
    {
      recipe = database.GetRecipeReference(PlayerPrefs.GetString(id + "_recipe"));
      order.sprite = recipe.Food.Sprite;
      order.color = Color.white;
      timer.maxValue = recipe.Reputation;
      timer.value = PlayerPrefs.GetFloat(id + "_time");
    }
  }

  private void OnDestroy()
  {
    PlayerPrefs.SetString(id + "_recipe", recipe.ID);
    PlayerPrefs.SetFloat(id + "_time", timer.value);
  }

  private void OnValidate()
  {
    id = this.name;
  }

  private void Update()
  {
    NewOrder();
    CheckOrder();
    Countdown();
  }

  private void NewOrder()
  {
    int level = PlayerPrefs.GetInt("level");

    if (recipe == null)
    {
      Recipe[] unlockedRecipes = database.GetRecipesUpToLevel(level);
      int random = Random.Range(0, unlockedRecipes.Length);
      recipe = unlockedRecipes[random];
      order.sprite = recipe.Food.Sprite;
      order.color = Color.white;
      timer.maxValue = recipe.Reputation;
      timer.value = recipe.Reputation;
    }
  }

  private void CheckOrder()
  {
    if (itemSlot.Item != null)
    {
      if (itemSlot.Item.ID == recipe.Food.ID)
      {
        sfxOrderCorrect.Play();
        Reputation.Increase(recipe.Reputation);
        PlayerPrefs.SetInt("correctOrders", PlayerPrefs.GetInt("correctOrders") + 1);
      }
      else
      {
        sfxOrderWrong.Play();
        Reputation.Decrease(recipe.Reputation / 2 * (PlayerPrefs.GetInt("level") + 1));
        PlayerPrefs.SetInt("wrongOrders", PlayerPrefs.GetInt("wrongOrders") + 1);
      }

      itemSlot.Item = null;
      recipe = null;
    }
  }

  private void Countdown()
  {
    try
    {
      if (timer.value > 0)
      {
        float speed = PlayerPrefs.GetFloat("difficulty");
        timer.value -= Time.deltaTime * speed;
        time.text = timer.value.ToString("f0") + " / " + recipe.Reputation;
        timerFill.color = Color.Lerp(Color.red, Color.green, timer.value / timer.maxValue);
      }
      else
      {
        sfxOrderWrong.Play();
        Reputation.Decrease(recipe.Reputation / 2 * (PlayerPrefs.GetInt("level") + 1));
        PlayerPrefs.SetInt("wrongOrders", PlayerPrefs.GetInt("wrongOrders") + 1);
        recipe = null;
      }
    }
    catch
    {
      
    }
  }
}