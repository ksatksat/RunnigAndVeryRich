using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDetector : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "BadPickup" || other.gameObject.tag == "GoodPickup"){
            StartCoroutine(HideAfterDelay(0.05f, other.collider.gameObject));
        }
    }
    IEnumerator HideAfterDelay(float delay, GameObject GOToHide){
        yield return new WaitForSeconds(delay);
        GOToHide.SetActive(false);
    }
}
