using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject whitepiece;
    public GameObject blackpiece;
    public GameObject slot;

    public bool player; // true is white, false is black
    public int numPieces;
    public bool phase2 = false;

    public float space = 1.6f;

    public bool pieceSelected = false;
    public GameObject activePiece;

    public bool removemode = false;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(slot, new Vector3(space*-3, space*3, 0), Quaternion.identity);
        Instantiate(slot, new Vector3(space*0, space*3, 0), Quaternion.identity);
        Instantiate(slot, new Vector3(space*3, space*3, 0), Quaternion.identity);
        Instantiate(slot, new Vector3(space*0, space*2, 0), Quaternion.identity);
        Instantiate(slot, new Vector3(space*2, space*2, 0), Quaternion.identity);
        Instantiate(slot, new Vector3(space*-1, space*1, 0), Quaternion.identity);
        Instantiate(slot, new Vector3(space*0, space*1, 0), Quaternion.identity);
        Instantiate(slot, new Vector3(space*1, space*1, 0), Quaternion.identity);
        Instantiate(slot, new Vector3(space*-3, space*0, 0), Quaternion.identity);
        Instantiate(slot, new Vector3(space*-2, space*0, 0), Quaternion.identity);
        Instantiate(slot, new Vector3(space*-1, space*0, 0), Quaternion.identity);
        Instantiate(slot, new Vector3(space*1, space*0, 0), Quaternion.identity);
        Instantiate(slot, new Vector3(space*2, space*0, 0), Quaternion.identity);
        Instantiate(slot, new Vector3(space*3, space*0, 0), Quaternion.identity);
        Instantiate(slot, new Vector3(space*-1, space*-1, 0), Quaternion.identity);
        Instantiate(slot, new Vector3(space*0, space*-1, 0), Quaternion.identity);
        Instantiate(slot, new Vector3(space*1, space*-1, 0), Quaternion.identity);
        Instantiate(slot, new Vector3(space*-2, space*-2, 0), Quaternion.identity);
        Instantiate(slot, new Vector3(space*0, space*-2, 0), Quaternion.identity);
        Instantiate(slot, new Vector3(space*2, space*-2, 0), Quaternion.identity);
        Instantiate(slot, new Vector3(space*-3, space*-3, 0), Quaternion.identity);
        Instantiate(slot, new Vector3(space*0, space*-3, 0), Quaternion.identity);
        Instantiate(slot, new Vector3(space*3, space*-3, 0), Quaternion.identity);

        Instantiate(slot, new Vector3(space*-2, space*2, 0), Quaternion.identity);
        Instantiate(slot, new Vector3(space*0, space*0, 0), Quaternion.identity);
        

        
    

        player = true; // true is white, false is black 
        numPieces = 0;

    }

    public void setPlayer(bool p)
    {
        player = p;
        //Debug.Log("Player set to " + player);
    }
    public void incrementNumPieces()
    {
        numPieces++;
        //Debug.Log("Number of pieces: " + numPieces);
    }

    public void setPieceSelected(bool p)
    {
        pieceSelected = p;
        //Debug.Log("Piece selected: " + pieceSelected);
    }

    public void setActivePiece(GameObject p)
    {
        activePiece = p;
        //Debug.Log("Selected piece: " + activePiece);
    }

    public GameObject getActivePiece()
    {
        return activePiece;
    }

    public void setRemoveMode(bool p)
    {
        removemode = p;
        Debug.Log("Remove mode: " + removemode);
    }

    public void destoryPiece(GameObject p)
    {
        Destroy(p);
    }


    // Update is called once per frame
    void Update()
    {
        if (numPieces == 24)
        {
            phase2 = true;
        }
    }
}
