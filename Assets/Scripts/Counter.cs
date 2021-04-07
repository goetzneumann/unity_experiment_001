using System;
using UnityEngine;
using UnityEngine.UI;


public class Counter
    {
    private Text text;
    public Counter()
    {
        text = GameObject.Find("CounterText").GetComponent<Text>();
    }

        private int count = 5;

        public void addCount()
        {
            count++;
            updateCountDisplay();
        }

        public void subtractCount()
        {
            count--;
        updateCountDisplay();
        }

        private void updateCountDisplay()
        {
        text.text = count + "";
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
    }

