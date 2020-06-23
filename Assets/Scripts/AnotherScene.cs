using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnotherScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void Menú ()
    {
        SceneManager.LoadScene("Menu");
    }
}

