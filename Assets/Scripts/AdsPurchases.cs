using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class AdsPurchases : MonoBehaviour
{
   public GameObject iapButton1;
    public GameObject iapButton2;
    //public GameObject checkMark;   Objeto que muestra que la compra se realizo 

    private void Awake()
    {
        iapButton1.SetActive(true);
        iapButton2.SetActive(true);
        //checkMark.SetActive(false);
    }
    public void OnPurchaseComplete(Product product)
    {
#if UNITY_EDITOR
        StartCoroutine(DisableIapButton());
#else
            iapButton1.SetActive(false);
            iapButton2.SetActive(false);
         // checkMark.SetActive(true);
#endif

        //SE le Da al usuario el producto
        PlayerPrefs.SetInt("ads", 1);
    }

    public void OnPurchaseFailure(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("Purchase failed due to" + reason);
    }

    private IEnumerator DisableIapButton()
    {
        yield return new WaitForEndOfFrame();
        iapButton1.SetActive(false);
        iapButton2.SetActive(false);
        // checkMark.SetActive(true);
    }
}
