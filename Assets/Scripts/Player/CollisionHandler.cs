using UnityEngine;

[RequireComponent (typeof(Health))]

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private Medkit _medkit;
    [SerializeField] private Coin _coin;
    [SerializeField] private SoundPlayerTakeDamage _soundTakeDamage;

    private Health _health;

    private void Start()
    {
        _health = GetComponent<Health>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.TryGetComponent(out Medkit medkit))
        {
            _health.IncreaseCurrentValue(medkit.HealthEffect);

            medkit.Destroy();
        }

        if (other.gameObject.TryGetComponent(out Coin coin))
        {
            coin.Destroy();
        }
    }
}
