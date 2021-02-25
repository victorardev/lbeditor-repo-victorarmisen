using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Transform enemySpawn;
    public List<Vector3> pointList = new List<Vector3>();
    float time = 30.0f;
    public Text timeText, vida;
    public GameObject basePlayer;
    public static bool isPlaying = false;
    public static bool currentPlaying = false;
    private void Start()
    {
        //make a time.
    }
    private void Update()
    {
        timeText.text = "Time: " + time.ToString("F2");
        if (PathCreate.play)
        {
            time -= Time.deltaTime;
            if(time <= 0.0f)
            {
                string currentSceneName = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(currentSceneName);
                PathCreate.play = false;
                PathCreate.pathReady = false;
                pointList.Clear();
                isPlaying = true;
            }
            if (currentPlaying)
            {
                int live = GameObject.FindGameObjectWithTag("BasePlayer").GetComponent<BasePlayer>().live;
                vida.text = "Live: " + live.ToString();
            }

        }
    }
}
