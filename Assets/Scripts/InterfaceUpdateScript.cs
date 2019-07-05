using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceUpdateScript : MonoBehaviour
{
    public Text myScore;

    public Text myHealth;
    // Update is called once per frame
    void Update()
    {
        var player = GameObject.FindGameObjectWithTag("PlayerEntity").GetComponent<PlayerEntityBehaviour>();
        myScore.text = player.GetScore().ToString();
        myHealth.text = player.GetALife().ToString();
    }
}
