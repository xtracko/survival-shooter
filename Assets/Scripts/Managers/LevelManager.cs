using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public static string currentLevel = "Default";

    private void Awake()
    {
        LevelManager.currentLevel = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
            Load("Default");

        if (Input.GetKeyDown(KeyCode.F2))
            Load("Bombs");

        if (Input.GetKeyDown(KeyCode.F3))
            Load("Portals");

        if (Input.GetKeyDown(KeyCode.F4))
            Load("Potions");
    }

    public static void Reload()
    {
        SceneManager.LoadScene(currentLevel);
    }

    private void Load(string name)
    {
        LevelManager.currentLevel = name;
        Reload();
    }

}
