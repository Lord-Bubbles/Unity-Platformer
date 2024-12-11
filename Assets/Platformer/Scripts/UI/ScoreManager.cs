using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public int score = 0;

    public static ScoreManager instance { get; private set; }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        instance = this;
    }

    void Start()
    {
        score = 0;
        scoreText.text = string.Format("{0}", score);
    }

    public void UpdateScore(int amount)
    {
        score += amount;
        scoreText.text = string.Format("{0}", score);
    }

}

