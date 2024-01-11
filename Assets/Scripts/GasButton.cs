using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasButton : MonoBehaviour
{
    public GameObject SolidContainerPrefab;
    public GameObject GasContainerPrefab;

    public void OnGasButtonClick()
    {
        // Проверяем наличие объекта SolidContainer на сцене
        GameObject existingSolidContainer = GameObject.FindGameObjectWithTag("SolidContainerTag");

        if (existingSolidContainer != null)
        {
            // Получаем позицию и поворот объекта SolidContainer
            Vector3 position = existingSolidContainer.transform.position;
            Quaternion rotation = existingSolidContainer.transform.rotation;

            // Удаляем объект SolidContainer
            Destroy(existingSolidContainer);

            // Создаем экземпляр префаба GasContainer на его месте
            Instantiate(GasContainerPrefab, position, rotation);
        }
    }
}
