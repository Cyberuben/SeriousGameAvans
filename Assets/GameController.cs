using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : Singleton<GameController> {
    public GameObject GameControllerSingle;
    public Difficulty difficulty;
    public Vector3 cameraPosition = Vector3.zero;
    public GameState gameState = GameState.MENU;
    public List<HouseState> houses;
    public bool playAudio = false;
    public int enteredHouse;

    public bool helpShown = false;

    public enum Difficulty
    {
        EASY,
        MEDIUM,
        HARD
    }

    public enum GameState
    {
        MENU,
        PLAYING,
        PAUSED,
        ENDED
    }

    [System.Serializable]
    public class HouseState
    {
        public GameObject prefab;
        public string indicator;
        public bool indicatorFound = false;
    }

    public int Score = 0;
    public int TimeLeft = 0;
    public int IndicatorsFound = 0;
    public int IndicatorsTotal = 10;

    protected GameController() {
        
    }

    public bool IsPaused()
    {
        return gameState == GameState.PAUSED;
    }

    public void AddScore(int amount)
    {
        Score += amount;
    }

    public void StartGame()
    {
        GameControllerConfig gameControllerConfig = GameObject.FindGameObjectWithTag("GameControllerConfig").GetComponent<GameControllerConfig>();

        Score = 0;
        IndicatorsFound = 0;

        int amountHouses = 0;
        if (difficulty == Difficulty.EASY)
        {
            amountHouses = 15;
            TimeLeft = 300; // 5 minutes
        }
        else if (difficulty == Difficulty.MEDIUM)
        {
            amountHouses = 20;
            TimeLeft = 240; // 4 minutes
        }
        else if (difficulty == Difficulty.HARD)
        {
            amountHouses = 25;
            TimeLeft = 180; // 3 minutes
        }

        houses = new List<HouseState>();
        for (int i = 0; i < amountHouses; i++)
        {
            HouseState house = new HouseState();
            house.prefab = gameControllerConfig.housePrefabs[Mathf.FloorToInt(Random.Range(0, gameControllerConfig.housePrefabs.Count - 0.01f))];
            houses.Add(house);
        }

        int indicatorsGenerated = 0;
        while (indicatorsGenerated < IndicatorsTotal)
        {
            int index = Mathf.FloorToInt(Random.Range(0, amountHouses - 0.01f));
            if (houses[index].indicator == null)
            {
                IndicatorController controller = houses[index].prefab.GetComponent<IndicatorController>();
                int indicatorIndex = Mathf.FloorToInt(Random.Range(0, controller.indicators.Count - 0.01f));
                houses[index].indicator = controller.indicators[indicatorIndex].name;
                indicatorsGenerated++;
            }
        }

        enteredHouse = -1;

        gameState = GameState.PLAYING;

        StartCoroutine(DecrementTimer());
    }

    private IEnumerator DecrementTimer()
    {
        yield return new WaitForSeconds(1);

        if (gameState != GameState.PLAYING)
        {
            yield break;
        }

        TimeLeft--;

        if (TimeLeft == 0)
        {
            EndGame();
            yield break;
        }

        StartCoroutine(DecrementTimer());
    }

    public IEnumerator BackToStart()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Menu");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void PauseGame()
    {
        gameState = GameState.PAUSED;
    }

    public void ResumeGame()
    {
        gameState = GameState.PLAYING;

        StartCoroutine(DecrementTimer());
    }

    public void EndGame()
    {
        gameState = GameState.ENDED;

        if (TimeLeft > 0)
        {
            Score += TimeLeft * 10;
        }

        if (IndicatorsFound != IndicatorsTotal)
        {
            // Game over
            Debug.Log("Game over");
        }
        else
        {
            // Finished game
            Debug.Log("You got them all!");
        }
    }

    public bool FoundIndicator(int houseIndex)
    {
        if (!houses[houseIndex].indicatorFound)
        {
            houses[houseIndex].indicatorFound = true;
            Score += 100;

            if (difficulty == Difficulty.EASY)
            {
                Score += TimeLeft;
            }
            else if (difficulty == Difficulty.MEDIUM)
            {
                Score += TimeLeft + 60;
            }
            else if (difficulty == Difficulty.HARD)
            {
                Score += TimeLeft + 120;
            }

            IndicatorsFound++;

            if (IndicatorsFound == IndicatorsTotal)
            {
                EndGame();
            }

            return true;
        }

        return false;
    }
}
