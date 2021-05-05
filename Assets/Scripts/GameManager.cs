using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject astroid;
    public GameObject pausePanel;
    public Text coinText;
    public int coin;
    public List<GameObject> enemyList = new List<GameObject>();
    private float time = 0.0f;
    private float spawnTime = 2.0f;
    public float maxRight;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        coin = 0;
        coinText.text = coin.ToString();
        maxRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0)).x;
    }

    void Update()
    {
        time += Time.deltaTime;
        if(time > spawnTime)
        {
            time = 0;

            int check = Random.Range(0, 2);
            if(check == 0)
            {
                Instantiate(astroid, new Vector3(maxRight+2, Random.Range(-4.0f, 4.0f), 0), Quaternion.identity);
            }
            else
            {
                int type = Random.Range(0, 3);
                Instantiate(enemyList[type], new Vector3(maxRight+2, Random.Range(-4.0f, 4.0f), 0), Quaternion.identity);
            }
            
        }
    }

    public void PauseAction()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void ResumeAction()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void MainMenuAction()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        SceneManager.LoadScene("MenuScene");
    }
}
