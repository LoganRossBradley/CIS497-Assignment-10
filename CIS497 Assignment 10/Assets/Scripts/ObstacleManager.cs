/* * Logan Ross 
 * * ScoreManager.cs 
 * * Assignment 10
 * * Moves obstacles twords the player
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    private void FixedUpdate()
    {
        this.transform.Translate(0, 0, -0.25f);
    }
}
