using UnityEngine;
using UnityEngine.UI;

public class ImageVisibility : MonoBehaviour
{
    // Image bile�enini referans olarak al�n
    public Image targetImage;
    public bool isVisible = false;
    // G�r�n�rl��� ayarlamak i�in bir metod
    public void SetImageVisibility()
    {
        Color color = targetImage.color;
        color.a = isVisible ? 1f : 0f;  // 1f g�r�n�r, 0f g�r�nmez
        targetImage.color = color;
    }
}
