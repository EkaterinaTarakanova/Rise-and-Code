using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidButton : MonoBehaviour
{
    public GameObject SolidContainerPrefab;
    public GameObject GasContainerPrefab;

    public void OnSolidButtonClick()
    {
        // Проверяем наличие объекта GasContainer на сцене
        GameObject existingGasContainer = GameObject.FindGameObjectWithTag("GasContainerTag");

        if (existingGasContainer != null)
        {
            // Получаем позицию и поворот объекта GasContainer
            Vector3 position = existingGasContainer.transform.position;
            Quaternion rotation = existingGasContainer.transform.rotation;

            // Удаляем объект GasContainer
            Destroy(existingGasContainer);

            // Создаем экземпляр префаба SolidContainer на его месте
            Instantiate(SolidContainerPrefab, position, rotation);
        }
    }
}

