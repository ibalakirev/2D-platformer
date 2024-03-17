using UnityEngine;

public class PlayerSoundCoin : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSourse;

    public void PlaySound()
    {
        _audioSourse.Play();
    }
}
