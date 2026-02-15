using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TMP_Text clockText;
    public GameObject gameOverScreen;   // Drag GameOverscreen here
    public GameObject gameStats;
    private int currentHour = 12;
    private int currentMinute = 0;

    // 30 real seconds per in-game hour
    // That means 1 in-game minute = 0.5 real seconds
    private float realSecondsPerGameMinute = 0.2f;

    private float timer;
    private bool isGameOver = false;

    void Start()
    {
        timer = realSecondsPerGameMinute;
       // Hide both at start
        gameOverScreen.SetActive(false);
        gameStats.SetActive(false);
        UpdateClockDisplay();
    }

    void Update()
    {
        if (isGameOver)
            return;

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            timer += realSecondsPerGameMinute; // safer than resetting
            DecreaseTime();
        }
    }

    void DecreaseTime()
{
    int totalMinutes = currentHour * 60 + currentMinute;
    totalMinutes--;

    if (totalMinutes <= 0)
    {
        currentHour = 0;
        currentMinute = 0;
        UpdateClockDisplay();
        TriggerGameOver();
        return;
    }

    currentHour = totalMinutes / 60;
    currentMinute = totalMinutes % 60;

    UpdateClockDisplay();
}


    void UpdateClockDisplay()
    {
        // Format: 12     00 (spacing preserved)
        clockText.text = currentHour.ToString("00") + "     " + currentMinute.ToString("00");
    }

    void TriggerGameOver()
    {
        isGameOver = true;

        gameOverScreen.SetActive(true);
        gameStats.SetActive(true);

        Time.timeScale = 0f;
    }
}
