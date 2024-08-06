using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Sahneler : MonoBehaviour
{
    public ImageVisibility imageVisibility;

    public void Start()
    {
        imageVisibility.SetImageVisibility();
    }
    public void TutorialButton()
    {
        imageVisibility.isVisible = !imageVisibility.isVisible;
        imageVisibility.SetImageVisibility();
    }
}