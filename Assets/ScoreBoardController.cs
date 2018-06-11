using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoardController : MonoBehaviour {

    public Text rowExample;

    public User[] users;
	// Use this for initialization

	void Start () {
        users = new User[] { new User("Test user", 100), new User("test user 2",200), new User("test user 3", 200), new User("test user 4", 200), new User("Test user", 100), new User("test user 2", 200), new User("test user 3", 200), new User("test user 4", 200), new User("Test user", 100), new User("test user 2", 200) };
        //TODO: get top 10 rows	from api and deserialize

        Camera camera = Camera.main;
        //float heightOneRow = transform.
        Canvas canvas = GetComponent<Canvas>();
        for (int i = 0; i < users.Length; i++)
        {
            Text text = rowExample;
            Text new_text = Instantiate(text, new Vector3(0,  0), Quaternion.identity);
            new_text.text = "Gebruiker:" + users[i].UserName + "        Highscore:" + users[i].HighScore;
            new_text.transform.SetParent(transform);
            Debug.Log(canvas.pixelRect);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
