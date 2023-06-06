using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Delivery : MonoBehaviour
{
     bool hasPackage = false;
     int points = 100;
     [Header("Driver Sprites")]
     [SerializeField] Sprite defaultColor;
     [SerializeField] Sprite orangeColor;
     [SerializeField] Sprite blueColor;
     [SerializeField] Sprite greenColor;
     [SerializeField] Sprite yellowColor;
     [Header("Pickups and Dropoff")]
     [SerializeField] List<GameObject> pickups;
     [SerializeField] List<GameObject> dropoffs;
     [Header("UI stuff")]
     [SerializeField] GameObject pickupMessage;
     [SerializeField] GameObject messageImg;
     [SerializeField] Color32 boxOrange;
     [SerializeField] Color32 boxBlue;
     [SerializeField] Color32 boxYellow;
     [SerializeField] Color32 boxGreen;
     [Header("SFX")]
     [SerializeField] AudioClip pickupSFX;
    [SerializeField] AudioClip dropoffSFX;
    [SerializeField] [Range(0,1)] float pickupSFXVol = 0.1f;
    [SerializeField] [Range(0, 1)] float dropoffSFXVol = 0.1f;
    [SerializeField] List<AudioClip> bonkSFX;
    [SerializeField] [Range(0, 1)] float bonkSFXVol = 0.1f;

     SpriteRenderer driverRenderer;
     GameSession gameSession;
     void Start() {
          driverRenderer = this.transform.Find("Driver").GetComponent<SpriteRenderer>();
          gameSession = FindObjectOfType<GameSession>();
          activateRandomPickup();
     }

     public void activateRandomPickup(){
          int randomnumber = Random.Range(0,4);
          pickups[randomnumber].gameObject.SetActive(true);
          messageImg.gameObject.SetActive(true);
          pickupMessage.gameObject.SetActive(true);
          if (randomnumber == 0){
            messageImg.gameObject.GetComponent<Image>().color = boxOrange;
          }
          else if (randomnumber == 1){
            messageImg.gameObject.GetComponent<Image>().color = boxBlue;
          }
          else if (randomnumber == 2){
            messageImg.gameObject.GetComponent<Image>().color = boxYellow;
          }
          else if (randomnumber == 3){
            messageImg.gameObject.GetComponent<Image>().color = boxGreen;
          }

     }
     public void activateRandomDropoff(){
          dropoffs[Random.Range(0,16)].gameObject.SetActive(true);
     }


   void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag == "OrangePickUp" && !hasPackage){
          hasPackage = true;
          other.gameObject.SetActive(false);
          driverRenderer.sprite = orangeColor;
          activateRandomDropoff();
          messageImg.gameObject.SetActive(false);
          pickupMessage.gameObject.SetActive(false);
          AudioSource.PlayClipAtPoint(pickupSFX, Camera.main.transform.position,pickupSFXVol);
        }
        else if(other.tag == "BluePickUp" && !hasPackage){
          hasPackage = true;
          other.gameObject.SetActive(false);
          driverRenderer.sprite = blueColor;
          activateRandomDropoff();
          messageImg.gameObject.SetActive(false);
          pickupMessage.gameObject.SetActive(false);
          AudioSource.PlayClipAtPoint(pickupSFX, Camera.main.transform.position,pickupSFXVol);
        }
        else if(other.tag == "GreenPickUp" && !hasPackage){
          hasPackage = true;
          other.gameObject.SetActive(false);
          driverRenderer.sprite = greenColor;
          activateRandomDropoff();
          messageImg.gameObject.SetActive(false);
          pickupMessage.gameObject.SetActive(false);
          AudioSource.PlayClipAtPoint(pickupSFX, Camera.main.transform.position,pickupSFXVol);
        }
        else if(other.tag == "YellowPickUp" && !hasPackage){
          hasPackage = true;
          other.gameObject.SetActive(false);
          driverRenderer.sprite = yellowColor;
          activateRandomDropoff();
          messageImg.gameObject.SetActive(false);
          pickupMessage.gameObject.SetActive(false);
          AudioSource.PlayClipAtPoint(pickupSFX, Camera.main.transform.position,pickupSFXVol);
        }
        else if (other.tag == "Dropoff" && hasPackage){
          hasPackage = false;
          other.gameObject.SetActive(false);
          FindObjectOfType<GameSession>().AddToScore(points);
          driverRenderer.sprite = defaultColor;
          activateRandomPickup();
          AudioSource.PlayClipAtPoint(dropoffSFX, Camera.main.transform.position,dropoffSFXVol);
          gameSession.addTime();

        }
   }

      private void OnCollisionEnter2D(Collision2D other) {
        AudioSource.PlayClipAtPoint(bonkSFX[Random.Range(0,5)], Camera.main.transform.position,bonkSFXVol);
      }
}
