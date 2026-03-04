using UnityEngine;

public class VerticalLever : MonoBehaviour
{
    public float minY;        // lowest position
    public float maxY;        // highest position
    public float triggerPoint; // where activation happens

    private bool activated = false;
    private Vector3 startPosition;
    [SerializeField] public GameObject Lights = null;
    [SerializeField] public bool LightsOn = false;

    void Start()
    {
        startPosition = transform.position;

        // Set limits based on start position
        maxY = startPosition.y;
        minY = startPosition.y - 0.31f; // lever travel distance (adjust)
    }

    void Update()
    {
        Vector3 pos = transform.position;

        // Lock X and Z
        pos.x = startPosition.x;
        pos.z = startPosition.z;

        // Clamp Y
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;

        // Check if pulled down far enough
        if (!activated && pos.y <= triggerPoint)
        {
            activated = true;
            Activate();
        }
    }

    void Activate()
    {
        LightsOn = true;
        Lights.SetActive(true);
    }
}