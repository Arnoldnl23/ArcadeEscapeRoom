using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isColliding = false;
    public Canvas mazeResult;

    private AudioSource audioSource;

    public Vector3 lastMoveDirection;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isColliding = true;
        }
        if (collision.gameObject.tag == "Goal")
        {
            //Spawn in gun and text saying to take the gun
            Instantiate(Resources.Load<GameObject>("Gun_Prefab"), new Vector3(8.80944157f, 2.00699997f, -7.03487587f), new Quaternion(0, 0.707106829f, 0, 0.707106829f));
            Instantiate(Resources.Load<GameObject>("Toy Flashlight"), new Vector3(27.5149994f, 0.986000001f, -12.7250004f), new Quaternion(0, 1, 0, 0));
            Instantiate(Resources.Load<GameObject>("CluePaperDuckHunt"), new Vector3(9.56799984f, 1.97099996f, -7.01200008f), new Quaternion(-0.5f, -0.5f, 0.5f, 0.5f));
            audioSource.Play();
            FindFirstObjectByType<GameManager>().updateTickets(10);

            mazeResult.GetComponent<CanvasGroup>().alpha = 1;
            GameManager.progressCount++;
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
