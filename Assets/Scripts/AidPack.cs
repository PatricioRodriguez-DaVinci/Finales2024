using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidPack : MonoBehaviour
{
    public Player myPlayer;
    public List<Transform> spawnPoints = new List<Transform>();

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            myPlayer.GainLife();
            Transform randomSpawnPoint = GetRandomSpawnPoint();
            transform.position = randomSpawnPoint.position;
        }
    }

    Transform GetRandomSpawnPoint()
    {
        // Get a random index within the range of the spawnPoints list
        int randomIndex = Random.Range(0, spawnPoints.Count);

        // Return the transform at the random index
        return spawnPoints[randomIndex];
    }
}
