using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public GameObject whitepiecePrefab;
    public GameObject blackpiecePrefab;
    private bool firstClicked = false;
    public float[] xPos;
    public float[] yPos;

    private void OnMouseDown()
    {
        GameObject gameScript = GameObject.Find("Controller");
        if (gameScript != null)
        {
            NewBehaviourScript game = gameScript.GetComponent<NewBehaviourScript>();
            if (game != null || game.removemode == false)
            {
                bool phase2 = game.phase2;
                bool player = game.player;
                if (!phase2)
                {
                    if (firstClicked == false)
                    {
                        //firstClicked = true;

                        int numPieces = game.numPieces;
                        if (player)
                        {
                            Instantiate(whitepiecePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z - 4), Quaternion.identity);
                            checkFor3InARow(player, game);
                            game.setPlayer(false);
                            game.incrementNumPieces();
                        }
                        else
                        {
                            Instantiate(blackpiecePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z - 4), Quaternion.identity);
                            checkFor3InARow(player, game);
                            game.setPlayer(true);
                            game.incrementNumPieces();
                        }
                    }
                }
                else
                {
                    if (game.pieceSelected == true)
                    {
                        Instantiate(game.getActivePiece(), new Vector3(transform.position.x, transform.position.y, transform.position.z - 4), Quaternion.identity);
                        Destroy(game.getActivePiece());
                        checkFor3InARow(player, game);
                        if (game.player)
                        {
                            game.setPlayer(false);
                        }
                        else
                        {
                            game.setPlayer(true);
                        }
                        game.setPieceSelected(false);
                        game.setActivePiece(null);
                    }
                }
            }
        }
    }

    void checkFor3InARow(bool player, NewBehaviourScript game)
    {
        if (player == false)
        {
            GameObject[] blackObjects = GameObject.FindGameObjectsWithTag("Black");
            xPos = new float[blackObjects.Length];
            yPos = new float[blackObjects.Length];

            for (int i = 0; i < blackObjects.Length; i++)
            {
                //Debug.Log("Black object " + i + " is at " + blackObjects[i].transform.position.x);
                //Debug.Log("Black object " + i + " is at " + blackObjects[i].transform.position.y);
                xPos[i] = blackObjects[i].transform.position.x;
                yPos[i] = blackObjects[i].transform.position.y;
            }
        }
        if (player == true)
        {
            GameObject[] whiteObjects = GameObject.FindGameObjectsWithTag("White");
            xPos = new float[whiteObjects.Length];
            yPos = new float[whiteObjects.Length];

            for (int i = 0; i < whiteObjects.Length; i++)
            {
                //Debug.Log("White object " + i + " is at " + whiteObjects[i].transform.position.x);
                //Debug.Log("White object " + i + " is at " + whiteObjects[i].transform.position.y);
                xPos[i] = whiteObjects[i].transform.position.x;
                yPos[i] = whiteObjects[i].transform.position.y;

            }
        }
        float currentX = transform.position.x;
        float currentY = transform.position.y;
        int rowcount = 0;
        int colcount = 0;
        float space = 1.6f;
        float currentXFactor = currentX / space;
        float currentXFactorn2 = currentXFactor - 2;
        float currentXFactorn1 = currentXFactor - 1;
        float currentXFactor1 = currentXFactor + 1;
        float currentXFactor2 = currentXFactor + 2;
        bool currentXFactorn2bool = false;
        bool currentXFactorn1bool = false;
        bool currentXFactor1bool = false;
        bool currentXFactor2bool = false;
        float currentYFactor = currentY / space;
        float currentYFactorn2 = currentYFactor - 2;
        float currentYFactorn1 = currentYFactor - 1;
        float currentYFactor1 = currentYFactor + 1;
        float currentYFactor2 = currentYFactor + 2;
        bool currentYFactorn2bool = false;
        bool currentYFactorn1bool = false;
        bool currentYFactor1bool = false;
        bool currentYFactor2bool = false;
        float tolerance = 0.1f;

        if (currentY == 0)
        {
            currentXFactor = currentX / space;
            currentXFactorn2 = currentXFactor - 2;
            currentXFactorn1 = currentXFactor - 1;
            currentXFactor1 = currentXFactor + 1;
            currentXFactor2 = currentXFactor + 2;
            for (int i = 0; i < xPos.Length; i++)
            {
                if (yPos[i] == 0)
                {
                    if (Mathf.Abs(currentXFactorn2 * space - xPos[i]) <= tolerance)
                    {
                        currentXFactorn2bool = true;
                        //Debug.Log("currentXFactorn2bool is true");
                    }
                    if (Mathf.Abs(currentXFactorn1 * space - xPos[i]) <= tolerance)
                    {
                        currentXFactorn1bool = true;
                        //Debug.Log("currentXFactorn1bool is true");
                    }
                    if (Mathf.Abs(currentXFactor1 * space - xPos[i]) <= tolerance)
                    {
                        currentXFactor1bool = true;
                        //Debug.Log("currentXFactor1bool is true");
                    }
                    if (Mathf.Abs(currentXFactor2 * space - xPos[i]) <= tolerance)
                    {
                        currentXFactor2bool = true;
                        //Debug.Log("currentXFactor2bool is true");
                    }
                }
            }
            if (currentXFactorn2bool && currentXFactorn1bool)
            {
                Debug.Log("3 in a row! by 21x");
                game.setRemoveMode(true);
            }
            if (currentXFactorn1bool && currentXFactor1bool)
            {
                Debug.Log("3 in a row! by 11x");
                game.setRemoveMode(true);
            }
            if (currentXFactor1bool && currentXFactor2bool)
            {
                Debug.Log("3 in a row! by 12x");
                game.setRemoveMode(true);
            }
        }
        else
        {
            for (int i = 0; i < xPos.Length; i++)
            {
                if (currentX == xPos[i])
                {
                    rowcount++;
                    if (rowcount == 3)
                    {
                        Debug.Log("3 in a row! OGX");
                        game.setRemoveMode(true);
                    }
                }
            }
        }

        if (currentX == 0)
        {
            currentYFactor = currentY / space;
            currentYFactorn2 = currentYFactor - 2;
            currentYFactorn1 = currentYFactor - 1;
            currentYFactor1 = currentYFactor + 1;
            currentYFactor2 = currentYFactor + 2;
            for (int i = 0; i < yPos.Length; i++)
            {
                if (xPos[i] == 0)
                {
                    if (Mathf.Abs(currentYFactorn2 * space - yPos[i]) <= tolerance)
                    {
                        currentYFactorn2bool = true;
                        //Debug.Log("currentYFactorn2bool is true");
                    }
                    if (Mathf.Abs(currentYFactorn1 * space - yPos[i]) <= tolerance)
                    {
                        currentYFactorn1bool = true;
                        //Debug.Log("currentYFactorn1bool is true");
                    }
                    if (Mathf.Abs(currentYFactor1 * space - yPos[i]) <= tolerance)
                    {
                        currentYFactor1bool = true;
                        //Debug.Log("currentYFactor1bool is true");
                    }
                    if (Mathf.Abs(currentYFactor2 * space - yPos[i]) <= tolerance)
                    {
                        currentYFactor2bool = true;
                        //Debug.Log("currentYFactor2bool is true");
                    }
                }
            }
            if (currentYFactorn2bool && currentYFactorn1bool)
            {
                Debug.Log("3 in a row! by 21y");
                game.setRemoveMode(true);
            }
            if (currentYFactorn1bool && currentYFactor1bool)
            {
                Debug.Log("3 in a row! by 11y");
                game.setRemoveMode(true);
            }
            if (currentYFactor1bool && currentYFactor2bool)
            {
                Debug.Log("3 in a row! by 12y");
                game.setRemoveMode(true);
            }
        }
        else
        {
            for (int i = 0; i < yPos.Length; i++)
            {
                if (currentX != 0)
                {
                    if (currentY == yPos[i])
                    {
                        colcount++;
                        if (colcount == 3)
                        {
                            Debug.Log("3 in a row! OGY");
                            game.setRemoveMode(true);
                        }
                    }
                }
            }
        }
    }
}
