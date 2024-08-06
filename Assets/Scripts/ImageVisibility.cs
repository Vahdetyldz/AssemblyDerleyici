using UnityEngine;
using UnityEngine.UI;

public class ImageVisibility : MonoBehaviour
{
    // Image bileþenini referans olarak alýn
    public Image targetImage;
    public bool isVisible = false;
    // Görünürlüðü ayarlamak için bir metod
    public void SetImageVisibility()
    {
        Color color = targetImage.color;
        color.a = isVisible ? 1f : 0f;  // 1f görünür, 0f görünmez
        targetImage.color = color;
    }
}
