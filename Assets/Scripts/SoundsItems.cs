using UnityEngine;

public class SoundsItems : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;
    [SerializeField] private CollisionHandler _collisionHandler;

    protected CollisionHandler CollisionHandler => _collisionHandler;

    protected void PlaySound()
    {
        _sound.Play();
    }
}
