using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
  public void PlayAgain()
  {
    PlayerPrefs.SetInt("ups", 0); // пример значения
    PlayerPrefs.SetInt("energy", 0); // пример значения
    SceneManager.LoadScene("SampleScene");
  }
}
