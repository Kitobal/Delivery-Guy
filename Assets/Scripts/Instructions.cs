using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
  [SerializeField] GameObject howToPlay;

  public void showHowToPlay(){
    howToPlay.gameObject.SetActive(true);
  }

  public void hideHowToPlay(){
    howToPlay.gameObject.SetActive(false);
  }
}
