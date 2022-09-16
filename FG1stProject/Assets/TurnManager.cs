using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
   private static TurnManager instance;
   private int currentPlayerIndex;
   

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
      }
      else if (currentPlayerIndex == 1)
      {
         currentPlayerIndex = 0;
      }
   }
}
