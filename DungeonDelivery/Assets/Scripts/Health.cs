using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private HealthBar _HealthBar;
    [SerializeField] private int _Maximum;
    private int _Current;
    
	private void Start ()
    {
        _Current = _Maximum;
        _HealthBar.UpdateHealthBar(_Current, _Maximum);
	}

    private void Update()
    {
        if (_Current <= 0 && gameObject.tag != "Player")
            Destroy(gameObject);
    }

    public void TakeDamage(int amount)
    {
        _Current -= amount;

        if (_Current < 0)
            _Current = 0;

        _HealthBar.UpdateHealthBar(_Current, _Maximum);
    }
}
