using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public Text myText = null;
    // Start is called before the first frame update
    void Start()
    {
        myText.text = "Score: 0";
    }

}
