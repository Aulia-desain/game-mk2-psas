using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLevel : MonoBehaviour
{
    // Fungsi untuk tombol Level 1
    public void KeLevel1()
    {
        SceneManager.LoadScene("Level_1");
    }

    // Fungsi untuk tombol Level 2
    public void KeLevel2()
    {
        SceneManager.LoadScene("Level_2");
    }

    // Fungsi untuk balik ke menu utama (Home)
    public void KeHome()
    {
        SceneManager.LoadScene("Home");
    }
}