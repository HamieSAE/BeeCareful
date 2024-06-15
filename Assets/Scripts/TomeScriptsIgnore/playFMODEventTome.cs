using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playFMODEventTome : MonoBehaviour
{
    public FMODUnity.EventReference anfmodEvent;
   // public FMODUnity.StudioEventEmitter fmodEmitter;
    private FMOD.Studio.EventInstance tp_instance;

    // Start is called before the first frame update
    void Start()
    {
        tp_instance = FMODUnity.RuntimeManager.CreateInstance(anfmodEvent);
        tp_instance.start();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
