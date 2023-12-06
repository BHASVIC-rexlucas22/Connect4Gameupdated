using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board : MonoBehaviour

{
    Vector3 newPos = new Vector3 (0,0.89f,0);
    int row = 0;
    int col = 0;

    public int[,] gameBoard = {{0,0,0,0,0,0,0},
                               {0,0,0,0,0,0,0},
                               {0,0,0,0,0,0,0},
                               {0,0,0,0,0,0,0},
                               {0,0,0,0,0,0,0},
                               {0,0,0,0,0,0,0}};
    //Each spot is (0.9,0.89) apart
    void getCollum()
    {
        float posX = gameObject.transform.position.x;
        for (int i = 0; i < 7; i++)
        {
            if (posX == (0.9 * i) + -3.209417)
                //uses equation to find position of Checker, uses -3.2 as that's the position of
                //starting checker and 0.9 as that's the difference between each checker
            {
                col = i;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //checks if Piece overlaps any checkers
        if (collision.gameObject.CompareTag("Red"))
        {
            //puts piece into array
            gameBoard[col, row] = 'R';

            //sets checker to new board position
            gameObject.transform.position += newPos;
            row++;

            //destroys after reaching top of board
            if (row > 5)
            {
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.CompareTag("Yellow"))
        {
            //puts piece into array
            gameBoard[col, row] = 'Y';

            //sets checker to new board position
            gameObject.transform.position += newPos;
            row++;

            //destroys after reaching top of board
            if (row > 5)
            {
                Destroy(gameObject);
            }
        }
    }
}