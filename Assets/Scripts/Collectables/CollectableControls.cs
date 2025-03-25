 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectableControls : MonoBehaviour
{
   public static int candyCount;
   [SerializeField] private TextMeshProUGUI candyCountDisplay;
   [SerializeField] private TextMeshProUGUI candyEndDisplay;

   void Start() 
   {
      candyCount = 0;  // reinitialized counter
   }

   void Update() 
   {
      candyCountDisplay.text = candyCount.ToString();
      candyEndDisplay.text = candyCount.ToString();
   }
}
