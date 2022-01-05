using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] private MyHealth _objectHealth;
    private Slider _healthSlider;

    private void Awake()
    {
        _healthSlider = gameObject.GetComponent<Slider>();
        _healthSlider.wholeNumbers = true;
        _healthSlider.maxValue = _objectHealth.MaxHP;
    }

    private void Update()
    {
        _healthSlider.value = _objectHealth.CurHP;
    }
}