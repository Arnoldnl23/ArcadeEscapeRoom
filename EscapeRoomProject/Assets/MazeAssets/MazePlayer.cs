using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isColliding = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isColliding = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isColliding = false;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
