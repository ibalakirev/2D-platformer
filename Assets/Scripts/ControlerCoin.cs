using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(SpriteRenderer))]

public class ControlerCoin : MonoBehaviour
{
    private AudioSource _soudCoin;
    private SpriteRenderer _spriteRenderer;
    private bool _isActiveCoin = true;
    private float _waitToTime = 1f;

    private void Start()
    {
        _soudCoin = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (_isActiveCoin == false)
        {
            StartCoroutine(WaitDisableCoin(_waitToTime));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<ControlerPlayer>())
        {
            _isActiveCoin = false;
            _spriteRenderer.enabled = false;

            _soudCoin.Play();
        }
    }

    private IEnumerator WaitDisableCoin(float waitToTime)
    {
        WaitForSeconds wait = new WaitForSeconds(waitToTime);

        yield return wait;

        gameObject.SetActive(false);
    }
}
