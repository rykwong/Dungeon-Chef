using UnityEngine;
using UnityEngine.UI;

public class Reputation : MonoBehaviour
{
  [SerializeField] Image tier = null;

  [SerializeField] Sprite tier0 = null;
  [SerializeField] Sprite tier1 = null;
  [SerializeField] Sprite tier2 = null;
  [SerializeField] Sprite tier3 = null;

  [SerializeField] Text amount = null;
  
  public static Slider slider = null;

  private void Awake()
  {
    slider = gameObject.GetComponent<Slider>();
  }

  private void Start()
  {
    slider.maxValue = 1000 * (PlayerPrefs.GetInt("level") + 1);
    slider.value = PlayerPrefs.GetInt("reputation");
  }

  private void OnDestroy()
  {
    PlayerPrefs.SetInt("reputation", (int)slider.value);
  }

  private void Update()
  {
    if (slider.value <= 0)
    {
      LoadScenes.loadGameOverScene();
    }

    amount.text = slider.value + " / " + slider.maxValue;

    SetTier();
  }

  public static void Increase(int reputation)
  {
    if (slider.value + reputation > slider.maxValue)
    {
      slider.maxValue += 1000;
      PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
    }

    slider.value += reputation;
  }

  public static void Decrease(int reputation)
  {
    slider.value -= reputation;
  }

  private void SetTier()
  {
    int level = PlayerPrefs.GetInt("level");

    if (level == 0)
    {
      tier.sprite = tier0;
    }
    else if (level == 1)
    {
      tier.sprite = tier1;
    }
    else if (level == 2)
    {
      tier.sprite = tier2;
    }
    else if (level == 3)
    {
      tier.sprite = tier3;
    }
    else
    {
      LoadScenes.loadGameWonScene();
    }
  }
}