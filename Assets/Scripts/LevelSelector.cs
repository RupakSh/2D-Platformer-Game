using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSelector : MonoBehaviour
{

    public int level;
    public TextMeshProUGUI levelNumber;

    // Start is called before the first frame update
    void Start()
    {
        // setting up level numbers on the buttons at runtime
        levelNumber.text = level.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelSelection()
    {
        // loading numbered scenes for buttons
        SceneManager.LoadScene("Scene_" + level.ToString());
        print("Level " + level.ToString() + " loaded.");
    }
}
