 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectableControls : MonoBehaviour
{
   public static int candyCount;
   public TextMeshProUGUI candyCountDisplay;

   void Update() 
   {
      candyCountDisplay.text = candyCount.ToString();
      //   candyCountDisplay.GetComponent<Text>().text = "" + candyCount;
   }
}
