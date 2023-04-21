using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class cameraShake : MonoBehaviour
{

    private CinemachineVirtualCamera virtualCam;
    private GameObject cam;
    private CinemachineBasicMultiChannelPerlin cameranoise;
    float tiempo = 0;

    public float amplitude = 5f;
    public float freq = 5f;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        virtualCam = GetComponent<CinemachineVirtualCamera>();
        cameranoise = virtualCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void Update()
    {
        tiempo = tiempo + Time.deltaTime;
        
        if (tiempo>1f)
        {
            Debug.Log("A");
            Shake(amplitude, freq, 1f);
            tiempo = 0f;
        }
    }
    public void Shake(float amplitude, float frequencyGain,float time)
    {
        cameranoise.m_AmplitudeGain = amplitude;
        cameranoise.m_FrequencyGain = frequencyGain;

        //CancelInvoke();
        Invoke("StopShake", time);
    }

    private void StopShake()
    {

        //Poner Z rot camara en 0 
        //cam.transform.Rotate(0f, 0.0f, 0.0f, Space.Self);
        cameranoise.m_AmplitudeGain = 0;
        cameranoise.m_FrequencyGain = 0;

        //cam.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
