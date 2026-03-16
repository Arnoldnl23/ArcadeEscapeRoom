using UnityEngine;

public class BeginningDoor : MonoBehaviour
{
    public Transform doorHinge;
    public float openAngle = 90f;
    public float openSpeed = 2f;

    private bool opening = false;

    void Update()
    {
        if (opening)
        {
            Quaternion target = Quaternion.Euler(0, openAngle, 0);
            doorHinge.localRotation = Quaternion.Slerp(
                doorHinge.localRotation,
                target,
                Time.deltaTime * openSpeed
            );
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            opening = true;
        }
    }
}