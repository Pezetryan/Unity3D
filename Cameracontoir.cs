using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontoir : MonoBehaviour
{

    public Vector3 distance;
    public float lookUp;
    public float lerpAmaount;

    private GameObject ballObject;

    void Start()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;

        ballObject = GameObject.FindGameObjectWithTag("Player");
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, ballObject.transform.position + distance, lerpAmaount * Time.deltaTime);
        transform.LookAt(ballObject.transform.position);
        transform.Rotate(-lookUp, 0, 0);
    }

}
