using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReturn : MonoBehaviour
{
   private BallLauncher ballLauncher;

   private void Awake()
   {
      ballLauncher = FindObjectOfType<BallLauncher>();
   }

   private void OnCollisionEnter2D(Collision2D other)
   {
      ballLauncher.ReturnBall();
      other.collider.gameObject.SetActive(false);
   }
}
