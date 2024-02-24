using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerSpecialAttack : MonoBehaviour
{
    public InputController myInputs;
    public int bounceCounter;
    public float ballForce;

    public GameObject specialBallPrefab;
    public GameObject spawnPoint;

    private void Update()
    {
        if (myInputs.isSpecialttacking)
        {
            GameObject myInstance = GameObject.Instantiate(specialBallPrefab, spawnPoint.transform.position, Quaternion.identity) as GameObject;
            myInstance.GetComponent<SpecialBall>().bounceTimes = bounceCounter;
            myInstance.GetComponent<Rigidbody>().AddForce(spawnPoint.transform.forward * ballForce);

            bounceCounter = 5;
        }
    }
}