using UnityEngine;
using UnityEngine.SceneManagement; // Ini wajib buat pindah-pindah scene

public class TombolBack : MonoBehaviour
{
    public void KeHome()
    {
        // Pastikan nama di dalam tanda kutip PERSIS sama dengan nama scene menu kamu
        SceneManager.LoadScene("MenuLevel");
    }
}