
using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public int score = 0;


    // singleton class
    private static ScoreManager instance;
    public static ScoreManager Instance { get { return instance; } }

    

    private void Awake()
    {
        //scoreText = GetComponent<TextMeshProUGUI>();

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


    }

    private void Start()
    {
        UIManager.Instance.RefreshUI(score);
        //RefreshUI();
    }

    public void updateScore(int increment)
    {
        score += increment;
        UIManager.Instance.RefreshUI(score);
        //RefreshUI();
    }

    

    //private void RefreshUI()
    //{
    //    scoreText.text = "Score:" + score;
    //}

    
}
