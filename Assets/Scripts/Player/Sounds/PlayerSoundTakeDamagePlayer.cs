using UnityEngine;

public class PlayerSoundTakeDamagePlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _soundTakeDamage;

    public void PlaySoundTakeDamage()
    {
        _soundTakeDamage.Play();
    }
}
