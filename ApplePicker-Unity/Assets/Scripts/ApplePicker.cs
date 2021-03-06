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

public class ApplePicker : MonoBehaviour
{
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate(basketPrefab) as GameObject;
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AppleDestroyed()
    {
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGo in tAppleArray)
        {
            Destroy(tGo);
        }

        //// Destroy one of the Baskets
        // Get the index of the last Basket in basketList
        int basketIndex = basketList.Count - 1;
        // Get a reference to that Basket GameObject
        GameObject tBasketGO = basketList[basketIndex];
        // Remove the Basket from the List and destroy the GameObject
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);

        // Restart the game, which doesn't affect HighScore.Score
        if (basketList.Count == 0)
        {
            Application.LoadLevel("_Scene_1");
        }


    }
}
