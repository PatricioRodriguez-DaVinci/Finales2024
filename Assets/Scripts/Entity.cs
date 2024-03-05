using UnityEngine;
public abstract class Entity : MonoBehaviour
{
    protected GameObject _go;
    protected DamageController myDamageController;
    protected Transform myPlayerTransform;
    public ScenesController myScenesController;

    [SerializeField] protected int life = default;
    [SerializeField] protected float speed = default;

    private void Awake()
    {
        _go = GameObject.FindGameObjectWithTag("Controllers");

        if (_go != null) myDamageController = _go.GetComponent<DamageController>();
        if (_go != null) myScenesController = _go.GetComponent<ScenesController>();

        _go = GameObject.FindGameObjectWithTag("Player");

        if (_go != null) myPlayerTransform = _go.GetComponent<Transform>();
    }
}
