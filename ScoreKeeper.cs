using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int currentScore;

    static ScoreKeeper instance;

    private void Awake()
    {
        ManageSingleton();
    }

    public static ScoreKeeper GetInstance()
    {
        return instance;
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ModifyScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        currentScore = Mathf.Clamp(currentScore, 0, int.MaxValue);
        print(currentScore);
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

    public void ResetScore()
    {
        currentScore = 0;
    }
}