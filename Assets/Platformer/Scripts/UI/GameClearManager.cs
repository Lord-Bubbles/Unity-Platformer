using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearManager : MonoBehaviour
{
    public GameObject screen;
    public TextMeshProUGUI score;

    private HealthManager healthManager;

    private ScoreManager scoreManager;

    private bool isGameClear = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthManager = HealthManager.instance;
        scoreManager = ScoreManager.instance;
        screen.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isGameClear = true;

            healthManager.gameObject.SetActive(false);
            scoreManager.gameObject.SetActive(false);
            screen.SetActive(true);
            score.text = string.Format("Score: {0}", scoreManager.score);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameClear)
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
