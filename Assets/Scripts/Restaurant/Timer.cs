using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
  private Slider slider = null;

  private void Awake()
  {
    slider = gameObject.GetComponent<Slider>();
  }

  private void Update()
  {
    if (slider.value < slider.maxValue)
    {
      slider.value += Time.deltaTime;
    }
  }

  public void Reset()
  {
    slider.maxValue = 0;
    slider.value = 0;
  }

  public void SetTimer(float targetTime)
  {
    slider.maxValue = targetTime;
  }
}