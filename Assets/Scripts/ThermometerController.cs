using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThermometerController : MonoBehaviour
{
    private Transform sliderTransform;
    private StartForce[] startForceScripts;

    private void Start()
    {
        // �������� ����������
        sliderTransform = transform.Find("Cylinder.002");
        startForceScripts = FindObjectsOfType<StartForce>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                float yOffset = touch.deltaPosition.y;

                // ������ scale.z ��������, ������ �� �������� ������
                sliderTransform.localScale += new Vector3(0f, 0f, yOffset * 0.01f);
                // �������� �������� scale �� ��� Z
                float intensity = sliderTransform.localScale.z;

                foreach (StartForce startForceScript in startForceScripts)
                {
                    // ������������� ����� ������������� � ������ ������� StartForce
                    startForceScript.startForce = new Vector3(intensity, intensity, intensity);
                }
            }
        }
    }
}
