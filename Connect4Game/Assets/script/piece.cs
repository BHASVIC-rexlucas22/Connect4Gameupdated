using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public Transform respawnPoint;
    public GameObject piece;
    public float respawnTimer;
    public bool interact;
    static public bool isLaunched;

    private void Start()
    {
        GetComponent<SpringJoint2D>().enabled = true;
        piece.transform.position = respawnPoint.transform.position;
        interact = true;
        isLaunched = false;
    }

    public void OnMouseDrag()
    {
        if (interact == true)
        {
            // Let's player move piece around
            Vector2 DragPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(DragPosition.x, DragPosition.y);
        }
    }

    public void OnMouseUp()
    {
        //this calls the routines once piece is released after being thrown
        StartCoroutine(releasePiece());
        
        StartCoroutine(respawnPiece());
    }

    public float releaseTime = 0.15f;

    IEnumerator releasePiece()
    {
        yield return new WaitForSeconds(releaseTime);
        GetComponent<SpringJoint2D>().enabled = false;
        interact = false;
        //makes it so the piece can't be moved after it's released
        isLaunched = true;
    }

    IEnumerator respawnPiece()
    {
        //temporary place holder for respawn until turn's are figured out
        yield return new WaitForSeconds(respawnTimer);
        Instantiate(piece, respawnPoint.position, Quaternion.identity);

    }
}

