using System;
using UnityEngine;
using UnityEngine.UI;


public class Counter
    {
    private Text lifeCounterText;
    private Text bulletCounterText;
    private Text gameOverText;

    public Counter()
    {
        lifeCounterText = GameObject.Find("CounterText").GetComponent<Text>();
        UpdateCountDisplay();
        bulletCounterText = GameObject.Find("BulletCounterText").GetComponent<Text>();
        UpdateBulletCountDisplay();
        gameOverText = GameObject.Find("GameOverText").GetComponent<Text>();
        gameOverText.gameObject.SetActive(false);
    }

    private static int INIT_COUNT = 10;
    private static int INIT_BULLET_COUNT = 25;
    private int count = INIT_COUNT;
    private int bulletCount = INIT_BULLET_COUNT;
        
        public int LifeCount()
        {
        return count;
        }


    public void Reset()
    {
        count = INIT_COUNT;
        bulletCount = INIT_BULLET_COUNT;
        UpdateBulletCountDisplay();
        UpdateCountDisplay();
        gameOverText.gameObject.SetActive(false);
    }

    public int BulletCount()
    {
        return bulletCount;
    }
        public void addCount()
        {
            count++;
        UpdateCountDisplay();
        }

        public void subtractCount()
        {
            count--;
        UpdateCountDisplay();
        }

    public void AddBulletCount(int addCount)
    {
        bulletCount += addCount;
        UpdateBulletCountDisplay();
    }

    public void SubtractBulletCount(int removeBulletCount)
    {
        bulletCount -= removeBulletCount;
        if (bulletCount < 0)
        {
            bulletCount = 0;
        }
        UpdateBulletCountDisplay();
    }

    private void UpdateCountDisplay()
        {
        if (count < 0)
        {
            lifeCounterText.text = "GAME OVER";
            gameOverText.gameObject.SetActive(true);
        }
        else
        {
            lifeCounterText.text = "LIFES: " + count;
        }
        }

    private void UpdateBulletCountDisplay()
    {
         bulletCounterText.text = "SHOOTS: " + bulletCount;
        
    }

    private static Counter _counter;
        public static Counter instance()
    {
        if(_counter == null)
        {
            _counter = new Counter();
        }
        return _counter;
    }

    public bool IsGameOver()
    {
        return count < 0;
    }
}



