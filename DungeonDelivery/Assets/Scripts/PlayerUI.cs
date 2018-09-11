using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [Header("Health Bar")]
    [SerializeField] private Transform _HealthBar;
    [SerializeField] private Transform _HealthBarBackground;
    [SerializeField] private Text _HealthBarText;

    public bool IsDirty { get; set; }

    private void Update()
    {
        if (IsDirty)
        {
            //Update UI Stuff
            UpdateHealthBar();

            IsDirty = false;
        }
    }

    //TODO: Replace _Health & _MaxHealth by the actual variables.
    private void UpdateHealthBar()
    {
        float totalScale = _HealthBar.localScale.x;
        //float healthScale = (_Health / _MaxHealth) * totalScale;
        float healthScale = _HealthBar.localScale.x; //use this temporarily until real variables are added.
        
        _HealthBar.localScale = new Vector3(healthScale, _HealthBar.localScale.y, 1);
        _HealthBarBackground.localScale = new Vector3(totalScale - healthScale, _HealthBarBackground.localScale.y, 1);
        //_HealthBarText.text = (int) _Health.ToString() + " / " + (int) _MaxHealth.ToString();
    }
}
