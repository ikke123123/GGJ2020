using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCollision : MonoBehaviour
{
    public enum AttachedTo { table, thing };

    public AttachedTo attached;
    public ImageManager imageCabbage;
    public ButtonSmasherManager smasherManager;
    public PlayerType player;
    public Movement player1;
    public Movement player2;
    public EnableCollision otherPlayer;
    public bool table;
    public bool thing;

    private void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Table") && player1.seizure == false && player2.seizure == false)
        {
            imageCabbage.player = player;
        }
    }
}
