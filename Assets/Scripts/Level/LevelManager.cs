using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // singleton class
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    public string level1;

    private void Awake()
    {
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
        if (GetLevelStatus(level1) == LevelStatus.locked)
        {
            SetLevelStatus(level1, LevelStatus.unlocked);
        }
    }

    public void MarkCurrentLevelComplete()
    {
        Scene scene = SceneManager.GetActiveScene();
        LevelManager.Instance.SetLevelStatus(scene.name, LevelStatus.unlocked);

        // unlock the next level
        int nextSceneIndex = scene.buildIndex + 1;
        Scene nextScene = SceneManager.GetSceneByBuildIndex(nextSceneIndex);

        // setting status of the next level to unlocked
        SetLevelStatus(nextScene.name, LevelStatus.unlocked);
        
    }

    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelstatus = (LevelStatus) PlayerPrefs.GetInt(level, 0);
        return levelstatus;
    }

    public void SetLevelStatus(string level, LevelStatus levelStatus) 
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
    }
}

