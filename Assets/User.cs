using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class User
{
    public string UserName;
    public int HighScore;
    public string Department;
    public string _id;

    public User(string userName, int highScore, string department)
    {
        UserName = userName;
        HighScore = highScore;
        Department = department;
    }

    public User() { }

    public User(string userName, int highScore, string department, string _id)
    {
        UserName = userName;
        HighScore = highScore;
        Department = department;
        this._id = _id;
    }
}
