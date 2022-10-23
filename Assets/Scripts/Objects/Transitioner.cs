using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transitioner : MonoBehaviour
{
    public static void enterObject(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
