using UnityEngine;
using Unity.Cinemachine;
using System.Collections.Generic;
using System.Collections;

public class VirtualCamaraManager : MonoBehaviour
{
    public CinemachineCamera[] virtualCamaraList;
    public int startCamaraId;

    public bool transitionOnStart;
    public int defaultStartCamaraTransition;
    public const float DEFAULT_TRANSITION_TIME = 3; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < virtualCamaraList.Length; i++)
        {
            virtualCamaraList[i].Priority = 1;
        }

        SwitchCamara(startCamaraId); 

        if (transitionOnStart)
        {
            StartCoroutine(SwitchCamaraDelay(defaultStartCamaraTransition)); 
        }
    }

    public void SwitchCamara(int camaraId)
    {
        int clampedIndex = Mathf.Clamp(camaraId, 0, virtualCamaraList.Length - 1); 

        for (int i = 0; i < virtualCamaraList.Length; i++)
        {
            if (virtualCamaraList[i].Priority == clampedIndex)
            {
                virtualCamaraList[i].gameObject.SetActive(true);
            }
            else
            {
                virtualCamaraList[i].gameObject.SetActive(false);
            }
        }
    }

    IEnumerator SwitchCamaraDelay(int camaraId)
    {
        yield return new WaitForSeconds(DEFAULT_TRANSITION_TIME);
        SwitchCamara(camaraId); 
    }
}
