using System.Collections;
using UnityEngine;

public class SoundPlayerTakeDamage : MonoBehaviour
{
    [SerializeField] private AudioSource _soundTakeDamage;

    private Coroutine _coroutine;

    public void StartPlaySoundTakeDamage()
    {
        _coroutine = StartCoroutine(WaitaPlaySoundTakeDamage());
    }

    public void StopPlaySoundTakeDamage()
    {
        StopCoroutine(_coroutine);
    }

    private void PlaySoundTakeDamage()
    {
        _soundTakeDamage.Play();
    }

    private IEnumerator WaitaPlaySoundTakeDamage()
    {
        float delay = 2f;
        bool isWorkCoroutine = true;

        WaitForSeconds wait = new WaitForSeconds(delay);

        while (isWorkCoroutine)
        {
            PlaySoundTakeDamage();

            yield return wait;
        }
    }
}
