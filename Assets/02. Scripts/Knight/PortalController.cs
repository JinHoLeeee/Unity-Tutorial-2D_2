using System;
using System.Collections;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public FadeRoutine fade;
    
    public GameObject portalEffect;
    public GameObject loadingImage;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PortalRoutine());
        }
    }
    
    IEnumerator PortalRoutine() 
    {
        portalEffect.SetActive(true);
        yield return StartCoroutine(fade.Fade(3f, Color.white, true)); // 페이드 온

        loadingImage.SetActive(true);
        yield return StartCoroutine(fade.Fade(3f, Color.white, false)); // 페이드 오프
        

        // 씬 변경

        // 페이드 오프


    }
}