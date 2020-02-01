using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string EventPath;
    FMOD.Studio.EventInstance MusicInst;

    // Start is called before the first frame update
    void Start()
    {
        MusicInst = FMODUnity.RuntimeManager.CreateInstance(EventPath);
        MusicInst.start();
        MusicInst.release();
    }

    void OnDestroy()
    {
        MusicInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
