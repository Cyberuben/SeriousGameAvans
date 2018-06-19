using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoardController : MonoBehaviour
{

    public Text rowExample;
    public GameObject obj;
    private string urlToApi;

    //private IEnumerator PostExample()
    //{
    //    urlToApi = "localhost:8000/api/users";
    //    Dictionary<string, string> headers = new Dictionary<string, string>();
    //    headers.Add("Content-Type", "application/json");
    //    for (int i = 0; i < 10; i++)
    //    {
    //        User usr = new User("user" + i * 21, 1 * 100, "department " + i);
    //        string json = JsonUtility.ToJson(usr);
    //        byte[] arr = System.Text.Encoding.UTF8.GetBytes(json);

    //        using (WWW www = new WWW(urlToApi, arr, headers))
    //        {
    //            yield return www;
    //        }
    //    }
    //}

    void Start()
    {
        StartCoroutine(StartGetUsers());
    }

    IEnumerator StartGetUsers()
    {
        urlToApi = "localhost:8000/api/users/10";
        User[] users;
        using (WWW www = new WWW(urlToApi))
        {
            //string jsonValue = www.text;
            yield return www;
            users = FromJson<User>(www.text);
            int i = 0;
        }
        //users = new User[] { new User("Test users", 100), new User("test user 2",200), new User("test user 3", 200), new User("test user 4", 200), new User("Test user", 100), new User("test user 2", 200), new User("test user 3", 200), new User("test user 4", 200), new User("Test user", 100), new User("test user 2", 200) };


        Camera camera = Camera.main;
        Canvas canvas = GetComponent<Canvas>();
        for (int i = 0; i < users.Length; i++)
        {
            Text text = rowExample;
            Text new_text = Instantiate(text, new Vector3(0, 0), Quaternion.identity);
            new_text.text = "Gebruiker:" + users[i].UserName;
            Text new_text2 = Instantiate(text, new Vector3(0, 0), Quaternion.identity);
            new_text2.text = "Highscore:" + users[i].HighScore;
            new_text.transform.SetParent(transform);
            new_text2.transform.SetParent(obj.transform);
        }
    }

    public static T[] FromJson<T>(string json)
    {
        string newJson = "{ \"array\": " + json + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
        return wrapper.array;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            StartCoroutine(GameController.Instance.BackToStart());
        }
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] array;
    }
}
