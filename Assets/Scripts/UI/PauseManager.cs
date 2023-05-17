using UnityEngine;

public static class PauseManager
{
    //Settings pause
    private static float previousTimeScale = 1f;
    public static void PauseGame()
    {
        previousTimeScale = Time.timeScale;
        Time.timeScale = 0f;
    }
    public static void ResumeGame()
    {
        Time.timeScale = previousTimeScale;
    }
}
