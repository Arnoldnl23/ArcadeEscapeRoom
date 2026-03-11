using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isColliding = false;
    public Canvas mazeResult;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isColliding = true;
        }
        if (collision.gameObject.tag == "Goal")
        {
            //Spawn in gun and text saying to take the gun
            Instantiate(Resources.Load<GameObject>("Cosmic_Retro_Blaster_3_9"), new Vector3(8.80944157f, 2.00699997f, -7.03487587f), new Quaternion(0, 0.707106829f, 0, 0.707106829f));
            GameManager.tickets += 10;

            mazeResult.GetComponent<CanvasGroup>().alpha = 1;
            this.gameObject.SetActive(false);
            this.enabled = false;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isColliding = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isColliding = false;
        }
    }

}
