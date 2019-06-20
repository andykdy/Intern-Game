﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject PlayerEntity;
    // Start is called before the first frame update
    public void loadTest()
    {
        SceneManager.LoadScene("Scenes/MainGame");
    }
    public void StartPlayer()
    {
        Instantiate(PlayerEntity);
    }

}
