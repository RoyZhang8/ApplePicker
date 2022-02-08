using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;


    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter"); //score game object
        scoreGT = scoreGO.GetComponent<Text>(); //the next component of the score GO
        scoreGT.text = "0"; // set the text property
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current screen position of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition; // 1
        // The Camera's z position sets the how far to push the mouse into 3D
        mousePos2D.z = -Camera.main.transform.position.z; // 2
        // Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D); // 3
        // Move the x position of this Basket to the x position of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;


    }
    void OnCollisionEnter(Collision coll)
    { // 2
      // Find out what hit this basket
        GameObject collidedWith = coll.gameObject; // 3
        if (collidedWith.tag == "Apple")
        { // 4
            Destroy(collidedWith);

            int score = int.Parse(scoreGT.text);
            score += 100;
            scoreGT.text = score.ToString();

            // Track the high score
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }

        }
    }
}
