using System;
using UnityEngine;

public class FootStepManage : MonoBehaviour
{

    [SerializeField] private GameObject FootStep;
    private AudioSource AudioStep;

    private void Awake()
    {
        AudioStep = FootStep.GetComponent<AudioSource>();
        //AudioStep.mute = true;
    }
    
    public void OnAudioWalk()
    {
        AudioStep.pitch = 1;
        FootStep.SetActive(true);
    }

    public void OnAudioRun()
    {
        AudioStep.pitch = 1.5f;
        FootStep.SetActive(true);
    }

    public void OffAudio()
    {
        FootStep.SetActive(false);
    }
    
}
