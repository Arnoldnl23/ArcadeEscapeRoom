using UnityEngine;
using UnityEngine.InputSystem;

public class DuckHuntScript : MonoBehaviour
{
    public Transform firePoint;
    public float range = 100f;

    public InputActionProperty triggerAction;

    private LineRenderer laserLine;

    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        laserLine.positionCount = 2;
    }

    void Update()
    {
        UpdateLaser();

        if (triggerAction.action.WasPressedThisFrame())
        {
            Fire();
            Debug.Log("Shot Fired");
            
        }
    }

    public void UpdateLaser()
    {
        RaycastHit hit;

        laserLine.SetPosition(0, firePoint.position);

        if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, range))
        {
            laserLine.SetPosition(1, hit.point);
        }
        else
        {
            laserLine.SetPosition(1, firePoint.position + firePoint.forward * range);
        }
    }

    public void Fire()
    {
        RaycastHit hit;

        if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, range))
        {
            if (hit.collider.CompareTag("Bird"))
            {
                Debug.Log("Bird Hit!");
                Destroy(hit.collider.gameObject);
            }
        }
    }
}