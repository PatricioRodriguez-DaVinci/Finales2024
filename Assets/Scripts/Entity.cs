using UnityEngine;
public abstract class Entity : MonoBehaviour
{
    protected DamageController myDamageController;
    protected GameObject _go;

    [SerializeField] protected int life = default;
    [SerializeField] protected float speed = default;

    private void Awake()
    {
        _go = GameObject.FindGameObjectWithTag("Controllers");
        if (_go != null) myDamageController = _go.GetComponent<DamageController>();
    }
}
