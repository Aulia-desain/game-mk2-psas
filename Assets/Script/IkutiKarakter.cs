using UnityEngine;

public class IkutiKarakter : MonoBehaviour
{
    // Kotak tempat masukin si cewek biar diikutin kamera
    public Transform targetKarakter;

    // Kecepatan kamera pas ngejar karakter (biar gerakannya smooth/mulus)
    public float smoothSpeed = 0.125f;

    // Jarak aman kamera biar gak terlalu dekat (Z harus minus agar kamera gak tenggelam)
    public Vector3 offset = new Vector3(0f, 0f, -10f);

    void LateUpdate()
    {
        if (targetKarakter != null)
        {
            // Menghitung posisi tujuan kamera selanjutnya
            Vector3 posisiTujuan = targetKarakter.position + offset;

            // Menggerakkan kamera ke posisi tujuan secara perlahan/halus
            Vector3 posisiSmooth = Vector3.Lerp(transform.position, posisiTujuan, smoothSpeed);

            // Terapkan posisi baru ke kamera
            transform.position = posisiSmooth;
        }
    }
}