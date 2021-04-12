/* * Logan Ross 
 * * ScoreManager.cs 
 * * Assignment 10
 * * Probably could have been done better but this is how the high score is being tracked
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int bestScore = 0;
    private void Start()
    {
        DontDestroyOnLoad(this);
    }
}
