using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PitchHandler : MonoBehaviour {

    public AudioMixerSnapshot lowPitchSnapshot;
    public AudioMixerSnapshot normalPitchSnapshot;
    public AudioMixerSnapshot highPitchSnapshot;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setLowPitchVoice()
    {
        lowPitchSnapshot.TransitionTo(0.1f);
    }

    public void setNormalPitchVoice()
    {
        normalPitchSnapshot.TransitionTo(0.1f);
    }

    public void setHighPitchVoice()
    {
        highPitchSnapshot.TransitionTo(0.1f);
    }
}
