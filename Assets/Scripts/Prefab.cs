using UnityEngine;

public class Prefab : MonoBehaviour
{
    protected AudioSource Sound;

    public virtual void Destroy()
    {
        Destroy(gameObject);
        PlaySound();
    }

    public virtual void AcceptSound(AudioSource sound)
    {
        Sound = sound;
    }
    private void PlaySound()
    {
        Sound.Play();
    }
}
