using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour {

    public string UserName { get; set; }
    public int HighScore { get; set; }

    public User(string userName, int highScore)
    {
        UserName = userName;
        HighScore = highScore;
    }

    public User() { }
}
