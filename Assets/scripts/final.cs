using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class final : MonoBehaviour
{
    void FixedUpdate(){
        if(Input.anyKeyDown)
        {
            SceneManager.LoadScene("menu");
        }
    }
}
