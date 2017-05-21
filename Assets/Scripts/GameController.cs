using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject columnPref;
    public bool gameOver;
    public Text gameOverText;
    public Text scoreText;
    public int score = 0;
    public GameObject[] columns;
    private Vector2 poolPosition = new Vector2(20f,0f);

    int columnsQt = 8;
    float deltaX = 10f;

    void Awake()
    {
        //If we don't currently have a game control...
        if (instance == null)
            //...set this one to be it...
            instance = this;
        //...otherwise...
        else if (instance != this)
            //...destroy this one because it is a duplicate.
            Destroy(gameObject);

        gameOverText = GameObject.Find("gameOverText").GetComponent<Text>();
        scoreText = GameObject.Find("scoreText").GetComponent<Text>();

        columns = new GameObject[columnsQt];
        for (int i = 0; i < columnsQt; i++)
            columns[i] = (GameObject)Instantiate(columnPref, new Vector2(poolPosition.x + i*Column.deltaX/columnsQt, Random.Range(-0.5f,3.16f)), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver && Input.GetMouseButtonDown(0))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    public void BirdDied()
    {
        gameOver = true;
        gameOverText.enabled = true;
    }

    public void scoreAdd()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

}