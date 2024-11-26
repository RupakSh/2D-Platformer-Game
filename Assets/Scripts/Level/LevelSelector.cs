using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelSelector : MonoBehaviour
{
    private Button button;

    public int level;
    public TextMeshProUGUI levelNumber;
    public string levelName;

    // Start is called before the first frame update

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }
    void Start()
    {
        // setting up level numbers on the buttons at runtime
        levelNumber.text = level.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        // check level status
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(levelName);
        
        switch (levelStatus)
        {
            case LevelStatus.unlocked:
                SoundManager.Instance.Play(Sounds.ButtonClick);
                SceneManager.LoadScene(levelName);
                break;

            case LevelStatus.locked:
                Debug.Log("Clear the previous levels first!!");
                break;

            case LevelStatus.finished:
                SoundManager.Instance.Play(Sounds.ButtonClick);
                SceneManager.LoadScene(levelName);
                break;
        }
    }
}
