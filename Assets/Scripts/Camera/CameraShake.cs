using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Core.Singleton;
using Unity.Cinemachine;

public class CameraShake : Singleton<CameraShake>
{
   public CinemachineVirtualCamera camera;

   public float shakeTime;

   [Header("Shake Values")]
   public float amplitude = 3f;
   public float frequency = 3f;
   public float time = .2f;

   public void Shake()
    {
        Shake(amplitude, frequency, time);
    }

    public void Shake(float amplitude, float frequency, float time)
    {
        camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().AmplitudeGain = amplitude;
        camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().FrequencyGain = frequency;

        shakeTime = time;
    }

    public void Update()
    {
        if(shakeTime > 0)
        {
            shakeTime -= Time.deltaTime;
        }
        else
        {
        camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().AmplitudeGain = 0f;
        camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().FrequencyGain = 0f;

        }
    }
}
