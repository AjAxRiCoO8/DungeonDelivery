using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private bool _DontShowIfFull;
    [SerializeField] private bool _HasTextComponent;
    [Space]

    [SerializeField] private Transform _HealthBar;
    [SerializeField] private Transform _HealthBarBackground;
    [SerializeField] private Text _HealthBarText;

    private float _HealthBarSize;

    private void Awake()
    {
        _HealthBarSize = _HealthBar.localScale.x;
    }

    public void UpdateHealthBar(int current, int maximum)
    {
        if (_DontShowIfFull)
        {
            for(int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(current != maximum);
            }
        }

        float healthScale = ((float)current / maximum) * _HealthBarSize;

        Debug.Log(current + ", " + maximum + ", " + _HealthBarSize + ", " + healthScale);

        _HealthBar.localScale = new Vector3(healthScale, _HealthBar.localScale.y, 1);
        _HealthBarBackground.localScale = new Vector3(_HealthBarSize - healthScale, _HealthBarBackground.localScale.y, 1);

        if (_HasTextComponent)
        {
            _HealthBarText.text = current.ToString() + " / " + maximum.ToString();
        }
    }
}
