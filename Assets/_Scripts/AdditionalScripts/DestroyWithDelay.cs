using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithDelay : MonoBehaviour
{
    // for fadeing the dead enemy
    public float fadeDuration = 1.3f;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer> ();
        StartCoroutine (FadeAndDestroy());

                  
    }

    IEnumerator FadeAndDestroy()
    {
        float elapsed = 0f;
        Color startColor = sr.color;
        while (elapsed < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsed/ fadeDuration);
            sr.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            elapsed += Time.deltaTime;
            yield return null;
        }

    
       
        //Removes the object from our Scene
        Destroy(gameObject);
        
    }

}
