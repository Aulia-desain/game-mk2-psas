using UnityEngine;
using UnityEngine.SceneManagement;

public class PindahLevel3 : MonoBehaviour
{
    // Fungsi universal untuk pindah level tinggal ketik namanya di Unity
    public void BukaLevel(string namaLevelTujuan)
    {
        SceneManager.LoadScene(namaLevelTujuan);
    }
}