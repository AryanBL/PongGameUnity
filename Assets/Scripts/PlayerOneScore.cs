using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerOneScore : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshProUGUI textMeshProUGUI;
    public static PlayerOneScore instance;
    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
          //  DontDestroyOnLoad(gameObject); // Optional: Keeps the instance across scenes
        }
        else
        {
            //Destroy(gameObject);
        }
    }



    public void IncrementScore(String name)
    {
        
        //int score = Int32.Parse(textMeshProUGUI.text);
        //score++;
        //textMeshProUGUI.text = score.ToString();
        GameObject gameObject = GameObject.Find(name);
        if (gameObject != null) { 
            textMeshProUGUI = gameObject.GetComponent<TextMeshProUGUI>();

            int score = Int32.Parse(textMeshProUGUI.text);
            Debug.Log(score);
            score++;
            Debug.Log(score);
            textMeshProUGUI.text = score.ToString();
        }
    }

}
