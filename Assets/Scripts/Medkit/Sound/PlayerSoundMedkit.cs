using UnityEngine;

public class PlayerSoundMedkit : MonoBehaviour
{
    [SerializeField] private AudioSource _soundMedkit;
    
    public void PlaySoundMedit()
    {
        _soundMedkit.Play();
    }
}
