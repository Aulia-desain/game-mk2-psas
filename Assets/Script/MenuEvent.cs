using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEvent : MonoBehaviour 
{
    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
    // Start is called once before the firs
    //void strart()
    //{
}
