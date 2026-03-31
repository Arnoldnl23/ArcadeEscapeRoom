using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Transform head;

    [SerializeField] private GameObject winText; 

    void Start()
    {
        
    }

    void Update()
    {
        this.transform.position = new Vector3(head.position.x, head.position.y - 1.33f, head.position.z);
        this.transform.rotation = head.rotation;
    }

    public void ShowWinText()
    {
        if (winText != null)
        {
            winText.SetActive(true);
        }
    }
}