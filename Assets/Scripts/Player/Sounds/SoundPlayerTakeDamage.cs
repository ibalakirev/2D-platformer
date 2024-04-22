using UnityEngine;

public class SoundPlayerTakeDamage : MonoBehaviour
{
    [SerializeField] private AudioSource _soundTakeDamage;
    [SerializeField] private Health _player;

    private void OnEnable()
    {
        _player.CurrentValueReduce += PlaySoundTakeDamage;
    }

    private void OnDisable()
    {
        _player.CurrentValueReduce -= PlaySoundTakeDamage;
    }

    private void PlaySoundTakeDamage()
    {
        _soundTakeDamage.Play();
    }
}
