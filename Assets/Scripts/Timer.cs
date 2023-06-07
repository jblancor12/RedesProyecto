using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Mirror.Examples.Pong
{
    public class Timer : NetworkBehaviour
    {
        public float currentTime;
        public float toSpeedUp;

        public Ball ball_script;

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

            if(toSpeedUp.ToString("0") == "10")
            {
                toSpeedUp = 0;

                ball_script.speedUp();
            }
        }
    }
}
