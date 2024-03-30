using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public PlayerControls Player;


    private void OnCollisionEnter(Collision collision)
    {
        if(Player.Standing)
        {
            Player.Fall();
        }
    }

}
