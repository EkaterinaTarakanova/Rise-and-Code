using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasButton : MonoBehaviour
{
    public GameObject SolidContainerPrefab;
    public GameObject GasContainerPrefab;

    public void OnGasButtonClick()
    {
        // ��������� ������� ������� SolidContainer �� �����
        GameObject existingSolidContainer = GameObject.FindGameObjectWithTag("SolidContainerTag");

        if (existingSolidContainer != null)
        {
            // �������� ������� � ������� ������� SolidContainer
            Vector3 position = existingSolidContainer.transform.position;
            Quaternion rotation = existingSolidContainer.transform.rotation;

            // ������� ������ SolidContainer
            Destroy(existingSolidContainer);

            // ������� ��������� ������� GasContainer �� ��� �����
            Instantiate(GasContainerPrefab, position, rotation);
        }
    }
}
