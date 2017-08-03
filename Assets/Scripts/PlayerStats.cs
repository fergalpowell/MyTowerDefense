using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static int Money;
    public int startMoney;
    public static int reward;
    public int startReward;
    public static int lives;
    public int startLives = 1;

    private void Start()
    {
        lives = startLives;
        Money = startMoney;
        reward = startReward;
    }
}
