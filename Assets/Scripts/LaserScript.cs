using UnityEngine;

public class LaserScript : MonoBehaviour
{
    [Header("Settings")]
    public LayerMask layerMask;
    public float defaultLength = 50f;
    public int numOfReflections = 2;

    public LineRenderer lineRenderer;
    public Transform spawnPointTransform;
    private Camera _myCam;
    private RaycastHit _hit;

    private Ray _ray;

    void Start()
    {
        _myCam = Camera.main;
    }

    void Update()
    {
        ReflectLaser();
    }

    void ReflectLaser()
    {
        _ray = new Ray(spawnPointTransform.transform.position, spawnPointTransform.transform.forward);

        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, spawnPointTransform.transform.position);

        float remainLength = defaultLength;

        for (int i = 0; i < numOfReflections; i++)

            if (Physics.Raycast(_ray.origin, _ray.direction, out _hit, remainLength, layerMask))
            {
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, _hit.point);

                remainLength -= Vector3.Distance(_ray.origin, _hit.point);

                _ray = new Ray(_hit.point, Vector3.Reflect(_ray.direction, _hit.normal));
            }

            else
            {
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, _ray.origin + (spawnPointTransform.transform.forward * remainLength));
            }
    }

    void NormalLaser()
    {
        lineRenderer.SetPosition(1, spawnPointTransform.transform.position);

        if (Physics.Raycast(spawnPointTransform.transform.position, spawnPointTransform.transform.forward, out _hit, defaultLength, layerMask))
        {
            lineRenderer.SetPosition(1, _hit.point);
        }
    }
}