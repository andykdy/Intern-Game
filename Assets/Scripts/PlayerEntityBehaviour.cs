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
    
    public Text scoreText;

    private float playerScore;
    // Update is called once per frame
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Instance.scoreText = GameObject.Find("Canvas/score").GetComponent<Text>();
            Destroy(gameObject);
        } else {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            scoreText = GameObject.Find("Canvas/score").GetComponent<Text>();
            playerScore = 0;
        }
    }

    private void Update()
    {
        scoreText.text = "Score: " + playerScore.ToString();
    }

    public void AddScore(float scoreToAdd)
    {
        playerScore += scoreToAdd;
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
