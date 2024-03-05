using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalllBehaviour : CanBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            return;
        }

        else if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            myDamageController.StartDamageEvent();
            Destroy(gameObject);
        }

        else Destroy(gameObject);
    }
}
