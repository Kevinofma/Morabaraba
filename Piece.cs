using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public GameObject scriptParent;
    void Start()
    {
        // Set scriptParent to the GameObject that this script is attached to's parent
        scriptParent = gameObject;
    }
    private void OnMouseDown()
    {
        GameObject gameScript = GameObject.Find("Controller");
        if (gameScript != null)
        {
            NewBehaviourScript game = gameScript.GetComponent<NewBehaviourScript>();
            if (game.removemode)
            {
                game.setRemoveMode(false);
                game.destoryPiece(scriptParent);
            }
            if (game != null)
            {
                bool phase2 = game.phase2;
                // if phase 2 and !player and prefab is black
                if (phase2 && !game.player && gameObject.tag == "Black")
                {
                    game.setPieceSelected(true);
                    game.setActivePiece(scriptParent);
                }
                // if phase 2 and player and prefab is white
                if (phase2 && game.player && gameObject.tag == "White")
                {
                    game.setPieceSelected(true);
                    game.setActivePiece(scriptParent);
                }
            }
        }
    }
}
