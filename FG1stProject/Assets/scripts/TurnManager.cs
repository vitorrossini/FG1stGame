using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
   private static TurnManager instance;
   [SerializeField] private PlayerTurn playerOne;
   [SerializeField] private PlayerTurn playerTwo;
   [SerializeField] private float timeBetweenTurns = 2f;
   [SerializeField] private Camera cam0;
   [SerializeField] private Camera cam1;

   private int currentPlayerIndex;
   private bool waitingForNextTurn;
   private float turnDelay;
   
   private void Awake()
   {
      if (instance == null)
      {
         instance = this;
         currentPlayerIndex = 0;
         playerOne.SetPlayerTurn(0);
         playerTwo.SetPlayerTurn(1);
      }
   }

   private void Update()
   {
      if (waitingForNextTurn)
      {
        turnDelay += Time.deltaTime;
         if (turnDelay >= timeBetweenTurns)
         {
            turnDelay = 0;
            waitingForNextTurn = false;
            Changeturn();
         }
      }
   }

   public bool IsItPlayerTurn(int index)
   {
      if (waitingForNextTurn)
      {
         return  false;
      }

      return index == currentPlayerIndex;
   }

   public static TurnManager GetInstance()
   {
      return instance;
   }

   public void TriggerChangeTurn()
   {
      waitingForNextTurn = true;
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
