using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public List<GameObject> screens;

    public int _selectedScreen;
    private Vector3 _destination;
    // Use this for initialization
    void Start()
    {
        _selectedScreen = 0;

        Camera camera = Camera.main;
        float height = 2f * camera.orthographicSize;
        float width = height * camera.aspect;
        float menuDistance = Mathf.Sqrt(width * width + height * height);

        if (screens != null)
        {
            _destination = transform.position;

            for (int i = 1; i < screens.Count; i++)
            {
                Vector3 direction = (screens[i].transform.position - screens[0].transform.position).normalized;
                screens[i].transform.position = direction * menuDistance;
            }
        }
    }

    public void MoveTo(int screen)
    {
        _selectedScreen = screen;
        _destination = screens[_selectedScreen].transform.position;
        _destination.z = -10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            MoveTo(0);
        }

        if (transform.position != _destination)
        {
            float delta = 8.0f * Time.deltaTime;
            Vector3 nextPosition = Vector3.MoveTowards(transform.position, _destination, delta);

            transform.position = nextPosition;
        }
    }
}
