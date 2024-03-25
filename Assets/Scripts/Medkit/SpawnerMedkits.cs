using System.Collections.Generic;
using UnityEngine;


public class SpawnerMedkits : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private DisablerMedkit _prefabMedkit;

    private void Start()
    {
        CreateMedkit();
    }

    private void CreateMedkit()
    {
        int indexPoints = 0;

        for (int i = indexPoints; i < _spawnPoints.Count; i++)
        {
            Instantiate(_prefabMedkit, _spawnPoints[i]);
        }       
    }
}
