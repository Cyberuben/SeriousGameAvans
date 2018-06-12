using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController> {
    public GameObject GameControllerSingle;
    public Difficulty difficulty;
    public float cameraPosition;

    public enum Difficulty
    {
        EASY,
        MEDIUM,
        HARD
    }

    private int _score = 0;
    private List<int> _houseIndices;
    private int _timeLeft = 0;
    private bool _paused = true;
    private int _indicatorsFound = 0;
    private int _indicatorsCount = 10;

    protected GameController() {
        
    }

    public int TimeLeft()
    {
        return _timeLeft;
    }

    public bool IsPaused()
    {
        return _paused;
    }

    public List<int> HouseIndices()
    {
        return _houseIndices;
    }

    public int IndicatorCount()
    {
        return _indicatorsCount;
    }

    public int IndicatorsFound()
    {
        return _indicatorsFound;
    }

    public void StartGame()
    {
        GameControllerConfig gameControllerConfig = GameObject.FindGameObjectWithTag("GameControllerConfig").GetComponent<GameControllerConfig>();

        cameraPosition = 0.0f;

        _paused = false;
        _score = 0;
        _indicatorsFound = 0;

        int amountHouses = 0;
        if (difficulty == Difficulty.EASY)
        {
            amountHouses = 15;
            _timeLeft = 300; // 5 minutes
        }
        else if (difficulty == Difficulty.MEDIUM)
        {
            amountHouses = 20;
            _timeLeft = 240; // 4 minutes
        }
        else if (difficulty == Difficulty.HARD)
        {
            amountHouses = 25;
            _timeLeft = 180; // 3 minutes
        }

        _houseIndices = new List<int>();
        for (int i = 0; i < amountHouses; i++)
        {
            _houseIndices.Add(Mathf.FloorToInt(Random.Range(0, gameControllerConfig.housePrefabs.Count - 0.01f)));
        }

        StartCoroutine(DecrementTimer());
    }

    private IEnumerator DecrementTimer()
    {
        yield return new WaitForSeconds(1);
        _timeLeft--;

        if (_timeLeft == 0)
        {
            EndGame();
        }

        if (!_paused)
        {
            StartCoroutine(DecrementTimer());
        }
    }

    public void PauseGame()
    {
        _paused = true;
    }

    public void ResumeGame()
    {
        _paused = false;

        StartCoroutine(DecrementTimer());
    }

    public void EndGame()
    {
        _paused = true;

        if (_timeLeft > 0)
        {
            _score += _timeLeft * 10;
        }

        if (_indicatorsFound != _indicatorsCount)
        {
            // Game over
        }
        else
        {
            // Finished game
        }
    }
}
