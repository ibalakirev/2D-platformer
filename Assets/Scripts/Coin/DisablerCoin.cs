using UnityEngine;

public class DisablerCoin : MonoBehaviour
{
    private PlayerSoundCoin _soundCoin;

    private void Start()
    {
        _soundCoin = FindObjectOfType<PlayerSoundCoin>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(typeof(MovePlayer), out Component component))
        {
            Destroy(gameObject);

            _soundCoin.PlaySound();
        }
    }
}
