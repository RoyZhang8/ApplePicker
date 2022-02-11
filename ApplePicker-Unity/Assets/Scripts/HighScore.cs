/****
 * Created by: Ruoyu Zhang
 * Data Created: Jan 31, 2022
 * 
 * Last Edited by: Feb 10, 2022
 * Last Edited: Feb 10, 2022
 * 
 * Description: Controls the movement of the Apple Tree
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static public int score = 1000;

    void Awake()
    { // 1
      // If the ApplePickerHighScore already exists, read it
        if (PlayerPrefs.HasKey("HighScore"))
        { // 2
            score = PlayerPrefs.GetInt("HighScore");
        }
        // Assign the high score to ApplePickerHighScore
        PlayerPrefs.SetInt("HighScore", score); // 3
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "High Score: " + score;

        // Update ApplePickerHighScore in PlayerPrefs if necessary
        if (score > PlayerPrefs.GetInt("HighScore"))
        { // 4
            PlayerPrefs.SetInt("HighScore", score);
        }

    }
}
