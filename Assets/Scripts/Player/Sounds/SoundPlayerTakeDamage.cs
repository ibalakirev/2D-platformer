using UnityEngine;

public class SoundPlayerTakeDamage : MonoBehaviour
{
    [SerializeField] private AudioSource _soundTakeDamage;
    [SerializeField] private Health _player;

    private void OnEnable()
    {
        _player.CurrentValueReduced += PlaySoundTakeDamage;
    }

    private void OnDisable()
    {
        _player.CurrentValueReduced -= PlaySoundTakeDamage;
    }

    private void PlaySoundTakeDamage()
    {
        _soundTakeDamage.Play();
    }
}
