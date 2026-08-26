using UnityEngine;
using UnityEngine.UI;

public class AroVida : MonoBehaviour
{
    public Transform player;
    public Slider sliderVida;
    
    public void SetSlider(float amount)
    {
        sliderVida.value = amount;
    }

    public void SetSliderMax(float amount)
    {
        sliderVida.maxValue = amount;
        SetSlider(amount);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + Vector3.up * 2f;
    }
}