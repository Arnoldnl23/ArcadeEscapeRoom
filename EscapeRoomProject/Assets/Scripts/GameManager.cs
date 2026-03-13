using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI scoreText;
    public static int tickets = 0;

    //Add to this at certain points in puzzle
    public static int progressCount = 0;


    //Timer variables
    private float countdownTime = 3600.0f;
    private float countdownSpeed = 1f;
    public TextMeshProUGUI timeText;

    private float remainingTime;

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

        StartTimer();
    }

    public void StartTimer()
    {
        remainingTime = countdownTime;
        timeText.text = formatTime(remainingTime);
        StartCoroutine(CountdownCoroutine());
    }

    IEnumerator CountdownCoroutine()
    {
        while (remainingTime > 0)
        {
            yield return new WaitForSeconds(countdownSpeed);
            timeText.text = formatTime(remainingTime);
            remainingTime--;
        }
        countdownFinished();
    }

    string formatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void countdownFinished() {
        SceneTransitionManager.singleton.GoToScene(2);
    }

    public void updateTickets(int points)
    {
        tickets += points;
        scoreText.text = tickets.ToString();
    }

}
