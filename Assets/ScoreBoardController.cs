using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoardController : MonoBehaviour {

    public Text rowExample;
    public GameObject obj;

    public User[] users;
	// Use this for initialization

	void Start () {
        users = new User[] { new User("Test users", 100), new User("test user 2",200), new User("test user 3", 200), new User("test user 4", 200), new User("Test user", 100), new User("test user 2", 200), new User("test user 3", 200), new User("test user 4", 200), new User("Test user", 100), new User("test user 2", 200) };
        //TODO: get top 10 rows	from api and deserialize

        Camera camera = Camera.main;
        Canvas canvas = GetComponent<Canvas>();
        for (int i = 0; i < users.Length; i++)
        {
            Text text = rowExample;
            Text new_text = Instantiate(text, new Vector3(0,  0), Quaternion.identity);
            new_text.text = "Gebruiker:" + users[i].UserName;
            Text new_text2 = Instantiate(text, new Vector3( 0,0), Quaternion.identity);
            new_text2.text = "Highscore:" + users[i].HighScore;
            new_text.transform.SetParent(transform);
            new_text2.transform.SetParent(obj.transform);
        }
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            StartCoroutine(GameController.Instance.BackToStart());
        }
    }
}
