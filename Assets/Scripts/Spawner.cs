using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private ControlerCoin _prefabCoin;
    [SerializeField] private float _timeWait = 0.1f;

    private void Start()
    {
        StartCoroutine(WaitSpawnCreated(_prefabCoin, _timeWait));
    }

    private IEnumerator WaitSpawnCreated(ControlerCoin coin, float timeWait)
    {
        int indexPoints = 0;
        WaitForSeconds wait = new WaitForSeconds(timeWait);

        for (int i = indexPoints; i < _spawnPoints.Count; i++)
        {
            CreateCoin(coin, _spawnPoints[i]);

            yield return wait;
        }
    }

    private void CreateCoin(ControlerCoin coin, Transform position)
    {
        Instantiate(coin, position);
    }
}
