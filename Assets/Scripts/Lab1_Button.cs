using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lab1_Button : MonoBehaviour
{
    public int sceneNumber;

    public void Transition() 
    {
        SceneManager.LoadScene(sceneNumber);
    }

}
