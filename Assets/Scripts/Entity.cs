using UnityEngine;
public class Entity : MonoBehaviour
{
    protected DamageController myDamageController;
    protected Transform myPlayerTransform;
    protected GameObject _go;

    [SerializeField] protected int life = default;
    [SerializeField] protected float speed = default;

    private void Awake()
    {
        _go = GameObject.FindGameObjectWithTag("Controllers");

        if (_go != null) myDamageController = _go.GetComponent<DamageController>();

        _go = GameObject.FindGameObjectWithTag("Player");

        if (_go != null) myPlayerTransform = _go.GetComponent<Transform>();
    }
}
