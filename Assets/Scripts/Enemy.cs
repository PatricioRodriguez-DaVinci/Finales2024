using UnityEngine;

public class Enemy : Entity
{
    protected Transform playerTransform;
    private void Awake()
    {
        _go = GameObject.FindGameObjectWithTag("Player");
        if (_go != null) playerTransform = _go.GetComponent<Transform>();
    }

    private void Start()
    {
        myDamageController.DoDamage += TakeDamage;
    }
    void TakeDamage()
    {
        if (life <= 1) Destroy(gameObject);
        else
        {
            Debug.Log("Hacer daño a enemigo");
            life--;
        }
    }

    private void OnDisable()
    {
        myDamageController.DoDamage -= TakeDamage;
    }
}
