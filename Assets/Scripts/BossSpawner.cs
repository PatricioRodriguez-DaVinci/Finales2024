using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public TimeController myTimeController;
    public GameObject bossPrefab;
    void Update()
    {
        if(myTimeController.timeRemaining <= 0)
        {
            bossPrefab.SetActive(true);
//            Instantiate(bossPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
