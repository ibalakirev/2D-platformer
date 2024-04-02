using UnityEngine;

public class TakeableItem : MonoBehaviour
{
    protected AudioSource Sound;

    public void Destroy()
    {
        Destroy(gameObject);
        PlaySound();
    }

    public void SetSound(AudioSource sound)
    {
        Sound = sound;
    }

    private void PlaySound()
    {
        Sound.Play();
    }
}
