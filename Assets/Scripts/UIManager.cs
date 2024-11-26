
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;

    // singleton class
    private static UIManager instance;
    public static UIManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Start()
    {
        StartingScore();
    }

    public void RefreshUI(int score)
    {
        scoreText.text = "Score:" + score;
    }

    public void StartingScore()
    {
        scoreText.text = "Score:" + ScoreManager.Instance.score;
    }
}
