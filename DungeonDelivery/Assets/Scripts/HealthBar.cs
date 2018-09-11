using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private bool _DontShowIfFull;
    [Space]
    [SerializeField] private bool _HasTextComponent;
    [Space]

    [SerializeField] private Transform _HealthBar;
    [SerializeField] private Transform _HealthBarBackground;
    [SerializeField] private Text _HealthBarText;

    private void Update()
    {
        //if (damage is taken)
        //UpdateHealthBar(); 
        //kan natuurlijk ook ergens anders aangeroepen worden.

        UpdateHealthBar();
    }

    //TODO: Replace _Health & _MaxHealth by the actual variables.
    public void UpdateHealthBar()
    {
        if (_DontShowIfFull)
        {
            for(int i = 0; i < transform.childCount; i++)
            {
                //transform.GetChild(i).gameObject.SetActive(_Health != _MaxHealth);
            }
        }

        float totalScale = _HealthBar.localScale.x;
        //float healthScale = (_Health / _MaxHealth) * totalScale;
        float healthScale = _HealthBar.localScale.x; //use this temporarily until real variables are added.

        _HealthBar.localScale = new Vector3(healthScale, _HealthBar.localScale.y, 1);
        _HealthBarBackground.localScale = new Vector3(totalScale - healthScale, _HealthBarBackground.localScale.y, 1);

        if (_HasTextComponent)
        {
            //_HealthBarText.text = (int) _Health.ToString() + " / " + (int) _MaxHealth.ToString();
        }
    }
}
