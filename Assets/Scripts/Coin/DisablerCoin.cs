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
        if (other.GetComponent<MovePlayer>())
        {
            Destroy(gameObject);

            _soundCoin.PlaySound();
        }
    }
}
