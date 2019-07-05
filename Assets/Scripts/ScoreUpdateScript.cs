using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using MoonSharp.Interpreter;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdateScript : MonoBehaviour
{
    public Text myScore;
    // Update is called once per frame
    void Update()
    {
        var player = GameObject.FindGameObjectWithTag("PlayerEntity").GetComponent<PlayerEntityBehaviour>();
        myScore.text = player.GetScore().ToString();
    }
}
