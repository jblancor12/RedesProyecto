using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Mirror.Examples.Pong
{
    public class Timer : MonoBehaviour
    {
        public float currentTime;
        public float toSpeedUp;
        public GameObject ball;
        private Ball ball_script;

        public TextMeshProUGUI CountUpTimer;

        void Start()
        {
            currentTime = 0f;
            toSpeedUp = 0;
            
        }

        void Update()
        {
            currentTime += 1 * Time.deltaTime;
            toSpeedUp += 1 * Time.deltaTime;
            CountUpTimer.GetComponent<TextMeshProUGUI>().text = currentTime.ToString("0");
            if(toSpeedUp.ToString("0") == "30")
            {
                toSpeedUp = 0;
                Debug.Log("Speed up");
                //ball_script = ball.GetComponent<Ball>();
                //ball_script.speed +=5;
            }
        }
    }
}
