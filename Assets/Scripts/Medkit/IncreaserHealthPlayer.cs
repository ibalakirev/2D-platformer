using UnityEngine;

public class IncreaserHealthPlayer : MonoBehaviour
{
    private HealthPlayer _healthPlayer;
    [SerializeField] private float _health = 20;

    private void Start()
    {
        _healthPlayer = FindObjectOfType<HealthPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(typeof(HealthPlayer), out Component component))
        {
            _healthPlayer.IncreaseHealth(_health);
        }
    }
}
