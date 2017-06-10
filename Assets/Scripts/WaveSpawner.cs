using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefeb;
    public Transform spawnPoint;
    public float timeBetweenWave = 5f;
    public Text waveCountDownText;
    private float countdown = 2f;
    private int waveNumber = 0;

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWave;
        }

        countdown -= Time.deltaTime;
        waveCountDownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefeb, spawnPoint.position, spawnPoint.rotation);

    }
}
