using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public static int tickets = 0;

    //Add to this at certain points in puzzle
    public static int progressCount = 0;

    private void Awake()
    {
        // If an instance already exists and it's not this one, destroy this one.
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        // Set the static Instance to this instance.
        instance = this;
        // Ensure the GameManager persists across scene loads.
        DontDestroyOnLoad(this.gameObject);
    }
}
