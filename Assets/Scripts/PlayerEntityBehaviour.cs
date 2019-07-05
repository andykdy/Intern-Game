using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerEntityBehaviour : MonoBehaviour
{
    private static PlayerEntityBehaviour _instance;
    public static PlayerEntityBehaviour Instance { get { return _instance; } }
    

    private float playerScore;
    private float playerLife;
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        } else {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            playerScore = 0;
            playerLife = 3;
        }
    }

    public void AddScore(float scoreToAdd)
    {
        playerScore += scoreToAdd;
    }

    public float GetScore()
    {
        return playerScore;
    }

    public void LoseLife()
    {
        playerLife -= 1;
    }

    public float GetALife()
    {
        return playerLife;
    }
    
//    void OnEnable()
//    {
//        SceneManager.sceneLoaded += OnSceneLoaded;
//    }
//    
//    void OnDisable()
//    {
//        Debug.Log("OnDisable");
//        SceneManager.sceneLoaded -= OnSceneLoaded;
//    }
//
//    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
//    {
//        Instance.scoreText = new Text();
//    }
    
}
