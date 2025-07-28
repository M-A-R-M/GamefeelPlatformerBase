using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CamaraShaker : MonoBehaviour
{
    public int shakeAmplitude;
    public int shakeFrequency;
    public CinemachineBasicMultiChannelPerlin perlin; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        perlin.AmplitudeGain = 0;
        perlin.FrequencyGain = 0;
    }

    public void ShakeCamara(float shakeTime)
    {
        perlin.AmplitudeGain = shakeAmplitude; 
        perlin.FrequencyGain = shakeFrequency;
        StartCoroutine(StopShakeRoutine(shakeTime));    
    }

    IEnumerator StopShakeRoutine(float shakeTime)
    {
        yield return new WaitForSeconds(shakeTime);
        perlin.AmplitudeGain = 0;
        perlin.FrequencyGain = 0; 
    }
}
