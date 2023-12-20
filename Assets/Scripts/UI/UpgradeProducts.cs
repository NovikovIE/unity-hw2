using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeProducts : MonoBehaviour
{
    public string product;
    public Image[] emptyIcon;
    public Sprite fillIcon;
    public int UpgradeLimit;

  private int ups;

  public void Start()
  {
    IconsUpdate();
    if (PlayerPrefs.HasKey("ups") == false) {
      ups = 0;
    }
    else {
      ups = PlayerPrefs.GetInt("ups");
    }
  }

  public void ProductUpgrade()
  {
    Debug.Log("UP: " + ups);
    if (ups > 0) {
      --ups;
      int count = PlayerPrefs.GetInt(product);
      if (count < UpgradeLimit)
      {
        count++;
        PlayerPrefs.SetInt(product, count);

        emptyIcon[count - 1].overrideSprite = fillIcon;
      }
    }

    void IconsUpdate()
    {
        int count = PlayerPrefs.GetInt(product);
        for (int i = 0; i < count; i++)
        {
            emptyIcon[i].overrideSprite = fillIcon;
        }
    }
}