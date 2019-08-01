using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempFile : MonoBehaviour
{
    public void changeScene() {
          SceneManager.LoadScene("MainMenu");
      }
}
