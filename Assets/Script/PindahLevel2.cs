using UnityEngine;
using UnityEngine.SceneManagement; // Ini wajib ada buat pindah level

public class PindahLevel2 : MonoBehaviour
{
    public void BukaLevel2()
    {
        SceneManager.LoadScene("Level_2");
    }
}