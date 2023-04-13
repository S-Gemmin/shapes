using UnityEngine;

public static class PlayerPreferences
{
    private const string HIGH_SCORE_KEY = "highScore";
    private const string VOLUME_KEY = "volume";

    public static int highScore
    {
        get => PlayerPrefs.GetInt(HIGH_SCORE_KEY);
        set => PlayerPrefs.SetInt(HIGH_SCORE_KEY, value);
    }

    public static float volume
    {
        get => PlayerPrefs.GetFloat(VOLUME_KEY);
        set => PlayerPrefs.SetFloat(VOLUME_KEY, value);
    }

    public static void Save() 
    {
        PlayerPrefs.Save();
    }
}
