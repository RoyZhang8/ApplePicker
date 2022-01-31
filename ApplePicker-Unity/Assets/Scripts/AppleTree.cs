/****
 * Created by: Ruoyu Zhang
 * Data Created: Jan 31, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Jan 31, 2022
 * 
 * Description: Controls the movement of the Apple Tree
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    /**** VARIABLES ****/
    [Header("SET IN INSPECTOR")]
    public float speed = 1f; //tree speed
    public float leftAndRightEdge = 10f; //distance where the tree turns around
    public GameObject applePrefabs; //prefab for instantiating apples
    public float secondsBetweenAppleDrops = 1f; // time between apple drops
    public float chanceToChangeDirections = 0.1f; //chance that the tree will change directions



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Basic Movement
        Vector3 pos = transform.position; //records the current position
        pos.x += speed * Time.deltaTime; //adds speed to x position
        transform.position = pos; //apply the positiobn value

        //Change Direction
        if(pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); //set speed to positive
        }
        else if(pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); //set speed to negative value
        }//end Change Directions

    }//end update

    //FixedUpdated is called on fixed intervals (50 times per second)
    private void FixedUpdate()
    {
        if(Random.value < chanceToChangeDirections)
        {
            speed *= -1; //change directions
        }
    }
}
