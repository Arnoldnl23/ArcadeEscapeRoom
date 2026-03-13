using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Transform head;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(head.position.x, head.position.y - 1.33f, head.position.z);
        this.transform.rotation = head.rotation;
    }
}
