using UnityEngine;

public class SoundJumpPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private MoverPlayer _movePlayer;

    private void OnEnable()
    {
        _movePlayer.SoundJumpStarted += PlaySound;
    }

    private void OnDisable()
    {
        _movePlayer.SoundJumpStarted -= PlaySound;
    }

    public void PlaySound()
    {
        _audioSource.Play();
    }
}
