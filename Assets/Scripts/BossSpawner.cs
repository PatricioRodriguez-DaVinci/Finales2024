using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public TimeController myTimeController;
    public GameObject boss;
    void Update()
    {
        if(myTimeController.timeRemaining <= 0)
        {
            boss.SetActive(true);
//            Instantiate(bossPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
