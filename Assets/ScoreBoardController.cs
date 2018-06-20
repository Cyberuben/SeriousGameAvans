using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreBoardController : MonoBehaviour
{
    public GameObject rowPrefab;
    public GameObject header;
    public GameObject canvas;
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
        urlToApi = "https://seriousgame.rsrv.pw/api/users/10";
        User[] users;
        using (WWW www = new WWW(urlToApi))
        {
            //string jsonValue = www.text;
            yield return www;
            users = FromJson<User>(www.text);
        }
        //users = new User[] { new User("Test users", 100), new User("test user 2",200), new User("test user 3", 200), new User("test user 4", 200), new User("Test user", 100), new User("test user 2", 200), new User("test user 3", 200), new User("test user 4", 200), new User("Test user", 100), new User("test user 2", 200) };


        Camera camera = Camera.main;
        Canvas canvas = GetComponent<Canvas>();

        Vector3 startPosition = header.GetComponent<RectTransform>().anchoredPosition;

        for (int i = 0; i < users.Length; i++)
        {
            GameObject row = Instantiate(rowPrefab);
            ScoreboardRow instance = row.GetComponent<ScoreboardRow>();
            instance.transform.parent = canvas.transform;
            RectTransform instanceTransform = instance.GetComponent<RectTransform>();
            instanceTransform.anchoredPosition = startPosition + new Vector3(0, -40 * (i + 1), 0);
            instanceTransform.anchorMin = new Vector2(0.5f, 1);
            instanceTransform.anchorMax = new Vector2(0.5f, 1);
            instanceTransform.pivot = new Vector2(0.5f, 0.5f);
            instance.position.text = string.Format("#{0}", i + 1);
            instance.name.text = users[i].UserName;
            instance.department.text = users[i].Department;
            instance.score.text = users[i].HighScore.ToString("n0");
        }
    }

    public static T[] FromJson<T>(string json)
    {
        string newJson = "{ \"array\": " + json + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
        return wrapper.array;
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] array;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
