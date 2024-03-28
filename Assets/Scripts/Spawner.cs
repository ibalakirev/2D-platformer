using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] protected List<Transform> SpawnPoints;
    [SerializeField] protected AudioSource Sound;

    public void CreatePrefabs()
    {
        int indexPoints = 0;

        for (int i = indexPoints; i < SpawnPoints.Count; i++)
        {
            CreatePrefab(i);
        }
    }

    public abstract void CreatePrefab(int index);
}
