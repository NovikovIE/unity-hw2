using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeProducts : MonoBehaviour
{

  public string product;

  public void ProductUpgrade()
  {
    int count = PlayerPrefs.GetInt(product);

    PlayerPrefs.SetInt(product, count + 1);
    Debug.Log(count + 1);
  }
}
