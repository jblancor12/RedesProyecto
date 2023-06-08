using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Mirror
{
    public class Timer : NetworkBehaviour
    {
        [SyncVar]
        public float currentTime;
        public float toSpeedUp;

        public Ball ball_script;
        public NetworkManagerPong network_script;

        public TextMeshProUGUI CountUpTimer;
    

        public override void OnStartServer()
        {
            base.OnStartServer();
           
            currentTime = 0f;
            toSpeedUp = 0;
            network_script = GameObject.FindGameObjectWithTag("Network").GetComponent<NetworkManagerPong>();
        }



        void Update()
        {
            if (network_script.getGameStart())
            {
                toSpeedUp += 1 * Time.deltaTime;
                if(isServer){
                    Debug.Log("corriendo en server");
                }
                runTime();


                if (toSpeedUp.ToString("0") == "10")
                {
                    toSpeedUp = 0;

                    ball_script.speedUp();
                }
            }
        }

        [ClientRpc]
        void runTime(){
            currentTime += 1 * Time.deltaTime;
            CountUpTimer.GetComponent<TextMeshProUGUI>().text = currentTime.ToString("0");
        }

    }
}
