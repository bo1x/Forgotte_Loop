using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class cameraShake : MonoBehaviour
{

    private CinemachineVirtualCamera virtualCam;
    private CinemachineBasicMultiChannelPerlin cameranoise;
    // Start is called before the first frame update
    void Start()
    {
        virtualCam = GetComponent<CinemachineVirtualCamera>();
        cameranoise = virtualCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void Shake(float amplitude, float frequencyGain,float time)
    {
        cameranoise.m_AmplitudeGain = amplitude;
        cameranoise.m_FrequencyGain = frequencyGain;

        CancelInvoke();
        Invoke("StopShake", time);
    }

    private void StopShake()
    {

        //Poner Z rot camara en 0 
        cameranoise.m_AmplitudeGain = 0;
        cameranoise.m_FrequencyGain = 0;
    }
}
