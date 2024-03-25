using UnityEngine;

public class PlayerSoundAttackPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _soundAttack;
    
    public void PlaySoundAttack()
    {
        _soundAttack.Play();
    }
}
