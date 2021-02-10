using UnityEngine;

public static class GameState 
{
    private static bool _isGameEnded = false;
    
    public static bool IsGameEnded { get => _isGameEnded; }

    public static void GameOver()
    {
        _isGameEnded = true;
    }

    public static void GameStart()
    {
        _isGameEnded = false;
    }

    public static void GameFreeze(bool value)
    {
        if (value) Time.timeScale = 0;
        else if (!value) Time.timeScale = 1;
    }
}
