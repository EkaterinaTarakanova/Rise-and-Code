using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidButton : MonoBehaviour
{
    public GameObject SolidContainerPrefab;
    public GameObject GasContainerPrefab;

    public void OnSolidButtonClick()
    {
        // ��������� ������� ������� GasContainer �� �����
        GameObject existingGasContainer = GameObject.FindGameObjectWithTag("GasContainerTag");

        if (existingGasContainer != null)
        {
            // �������� ������� � ������� ������� GasContainer
            Vector3 position = existingGasContainer.transform.position;
            Quaternion rotation = existingGasContainer.transform.rotation;

            // ������� ������ GasContainer
            Destroy(existingGasContainer);

            // ������� ��������� ������� SolidContainer �� ��� �����
            Instantiate(SolidContainerPrefab, position, rotation);
        }
    }
}

