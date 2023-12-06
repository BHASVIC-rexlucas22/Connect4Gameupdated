using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inBoard : MonoBehaviour
{
    public GameObject pieceBoard;



    public void OnTriggerEnter2D(Collider2D collision)
    {
        bool isLaunched = collision.GetComponent<Collider2D>();
        if ((collision.gameObject.CompareTag("Red")) && (isLaunched = true))
        {
            pieceBoard = collision.gameObject;
            //makes it so piece only deletes if it's been launched
            Destroy(pieceBoard, 5);
            //waits 5 seconds before deleting object
        }
        if ((collision.gameObject.CompareTag("Yellow")) && (isLaunched = true))
        {
            pieceBoard = collision.gameObject;
            Destroy(pieceBoard, 5);

        }
    }
  
}