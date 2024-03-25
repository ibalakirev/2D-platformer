using UnityEngine;

public class DisablerMedkit : MonoBehaviour
{
    private PlayerSoundMedkit _soundTakeDamage;

    private void Start()
    {
        _soundTakeDamage = FindObjectOfType<PlayerSoundMedkit>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(typeof(MovePlayer), out Component component))
        {
            Destroy(gameObject);

            _soundTakeDamage.PlaySoundMedit();
        }
    }
}
