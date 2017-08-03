using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefeb;
    public Transform tankPrefeb;
    public Transform spawnPoint;
    public float timeBetweenWave = 5f;
    public Text waveCountDownText;
    public Text WaveCounter;
    private float countdown = 20f;
    public int waveNumber = 0;

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWave;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountDownText.text = "Next Wave: " + string.Format("{0:00.00}", countdown);
        WaveCounter.text = "Wave: " + waveNumber.ToString();
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;

        if (waveNumber == 1)
        {
            Enemy.min = 1;
            Enemy.max = 1;
        }

        if (waveNumber > 1)
        {
            Enemy.min = 1;
            Enemy.max = 3;
        }

        if (waveNumber > 2)
        {
            Enemy.min = 1;
            Enemy.max = 5;
        }

        if (waveNumber > 3)
        {
            Enemy.min = 2;
            Enemy.max = 5;
        }

        if (waveNumber > 5)
        {
            PlayerStats.reward = 25;
        }

        if (waveNumber > 7)
        {
            Enemy.min = 3;
            Enemy.max = 5;
        }

        if (waveNumber > 9)
        {
            Enemy.min = 4;
            Enemy.max = 4;
        }

        if (waveNumber > 20)
        {
            GameObject gameOver = GameObject.FindGameObjectWithTag("Canvas");
            gameOver.GetComponent<UIManager>().showGameOver();
        }
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefeb, spawnPoint.position, Quaternion.Euler(0, 90, 0));

    }

    public void NextWave()
    {
        countdown = 0;
    }
}
