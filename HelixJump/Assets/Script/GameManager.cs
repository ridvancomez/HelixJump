using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum States
{
    Menu,
    Play
}
public class GameManager : MonoBehaviour
{
    private int score;
    GameObject generateLevel, generatePlayer;
    private bool calisti;
    private int levelIndex;
    private int hangiLeveldeyiz;
    [SerializeField]
    private GameObject levelText;

    [SerializeField]
    private GameObject button;

    [SerializeField]
    private GameObject scoreText;

    public States currentState;

    [SerializeField]
    private GameObject Player;
    [SerializeField]
    GameObject[] levels;
    // Start is called before the first frame update
    void Start()
    {
        currentState = States.Menu;
        hangiLeveldeyiz = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == States.Menu)
        {
            score = 0;
            calisti = false;
            hangiLeveldeyiz = 1;
            Destroy(Camera.main.gameObject.GetComponent<CameraFollow>());
            Destroy(generateLevel);
            Destroy(generatePlayer);

            levelIndex = 0;

            levelText.SetActive(false);
            button.SetActive(true);
            scoreText.SetActive(false);

        }
        else if (!calisti)
        {
            scoreText.GetComponent<Text>().text = "Score: " + score.ToString();
            levelText.GetComponent<Text>().text = "Level " + hangiLeveldeyiz.ToString();
            button.SetActive(false);
            calisti = true;

            generatePlayer = Instantiate(Player);
            generatePlayer.transform.position = new Vector3(0, 12, -3);

            generateLevel = Instantiate(levels[levelIndex]);
            generateLevel.transform.position = Vector3.zero;



            levelText.SetActive(true);
            scoreText.SetActive(true);
            Camera.main.gameObject.AddComponent<CameraFollow>();
        }
    }

    public void StateDegistir()
    {
        currentState = States.Play;
    }

    public void LevelDegistir()
    {
        Destroy(generateLevel);
        levelIndex++;
        hangiLeveldeyiz++;
        if (levelIndex == 3)
        {
            currentState = States.Menu;
        }
        else
        {
            generateLevel = Instantiate(levels[levelIndex]);
            generatePlayer.transform.position = new Vector3(0, 12, -3);
            levelText.GetComponent<Text>().text = "Level " + hangiLeveldeyiz.ToString();
        }
    }

    public void ScoreArtir()
    {
        score += 10;
        scoreText.GetComponent<Text>().text = "Score: " + score.ToString();
    }
}
