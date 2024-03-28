using UnityEngine;

public class SoundPlayerAttack : MonoBehaviour
{
    [SerializeField] private AudioSource _soundAttack;
    
    public void PlaySoundAttack()
    {
        _soundAttack.Play();
    }
}
