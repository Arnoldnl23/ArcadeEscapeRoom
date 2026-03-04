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
        if (collision.gameObject.tag == "Goal")
        {
            //Spawn in gun and text saying to take the gun
            Instantiate(Resources.Load<GameObject>("Cosmic_Retro_Blaster_3_9"), new Vector3(9.04300022f, 1.83099997f, -6.62900019f), Quaternion.identity);
            GameManager.tickets += 10;

            this.gameObject.SetActive(false);
            this.enabled = false;
        }
    }

    private void OnCollisionStay(Collision collision)
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

}
