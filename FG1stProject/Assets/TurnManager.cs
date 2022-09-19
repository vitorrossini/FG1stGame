using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
   private static TurnManager instance;
   private int currentPlayerIndex;
   [SerializeField] private Camera cam0;
   [SerializeField] private Camera cam1;
   

   private void Awake()
   {
      if (instance == null)
      {
         instance = this;
         currentPlayerIndex = 0;
      }
   }

   public bool IsItPlayerTurn(int index)
   {
      return index == currentPlayerIndex;
   }

   public static TurnManager GetInstance()
   {
      return instance;
   }

   public void Changeturn()
   {
      if (currentPlayerIndex == 0)
      {
         currentPlayerIndex = 1;
         cam0.gameObject.SetActive(false);
         cam1.gameObject.SetActive(true);
      }
      else if (currentPlayerIndex == 1)
      {
         currentPlayerIndex = 0;
         cam0.gameObject.SetActive(true);
         cam1.gameObject.SetActive(false);
      }
   }
}
