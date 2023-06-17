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

        public NetworkManagerPong network_script;

        public TextMeshProUGUI CountUpTimer;
    

        public override void OnStartServer()
        {
            base.OnStartServer();
           
            currentTime = 0f;
            network_script = GameObject.FindGameObjectWithTag("Network").GetComponent<NetworkManagerPong>();
        }



        void Update()
        {
            if (network_script.getGameStart())
            {
                
                if(isServer){
                    Debug.Log("corriendo en server");
                }
                runTime();
            }
        }

        [ClientRpc]
        void runTime(){
            currentTime += 1 * Time.deltaTime;
            CountUpTimer.GetComponent<TextMeshProUGUI>().text = currentTime.ToString("0");
        }

    }
}
