using UnityEngine;

public static class ScoreAndStage
{
    private static int _score = 0;
    private static int _stage = 1;

    public static int Score { get => _score; }
    public static int Stage { get => _stage; }

    public static void AddScore(int value)
    {
        _score += value;
    }

    public static void AddStage()
    {
        _stage += 1;
    }

    public static void Reset()
    {
        _score = 0;
        _stage = 1;
    }

    public static void CheckRecords()
    {
        if (PlayerPrefs.GetInt("highscore") < ScoreAndStage.Score) PlayerPrefs.SetInt("highscore", ScoreAndStage.Score);
        if (PlayerPrefs.GetInt("stage") < ScoreAndStage.Stage) PlayerPrefs.SetInt("stage", ScoreAndStage.Stage);
    }

    public static void ClearRecords()
    {
        PlayerPrefs.DeleteAll();
    }


}
