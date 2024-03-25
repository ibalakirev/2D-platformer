using UnityEngine;

public class PlayerSoundJumpPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private MovePlayer _movePlayer;

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
