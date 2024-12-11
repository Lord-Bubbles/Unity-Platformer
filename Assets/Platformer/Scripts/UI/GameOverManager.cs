using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject screen;
    public TextMeshProUGUI score;

    private HealthManager healthManager;

    private ScoreManager scoreManager;

    private bool isGameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthManager = HealthManager.instance;
        scoreManager = ScoreManager.instance;
        screen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (healthManager.currentState == PlayerState.Dead && !isGameOver)
        {
            isGameOver = true;

            healthManager.gameObject.SetActive(false);
            scoreManager.gameObject.SetActive(false);
            screen.SetActive(true);
            score.text = string.Format("Score: {0}", scoreManager.score);
        }

        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
            }
        }
    }
}
