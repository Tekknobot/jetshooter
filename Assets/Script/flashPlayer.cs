using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashPlayer : MonoBehaviour {

	public Color flashColor;
	public float flashDuration;

	Material mat;

    private IEnumerator flashCoroutine;

	private void Awake() {
		mat = GetComponent<SpriteRenderer>().material;
	}

	private void Start() {
		mat.SetColor("_FlashColor", flashColor);
	}

    private void Update() {
		if(Input.GetKeyDown(KeyCode.Space))
			Flash();
	}

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "gundam") {
            Flash();
        }   

        if(other.tag == "A0" || other.tag == "A45" || other.tag == "A90" || other.tag == "A135" || other.tag == "A180" ||
            other.tag == "A225" || other.tag == "A270" || other.tag == "A360" ) {
            Flash();
        }
	}		

	private void Flash() {
		if (flashCoroutine != null)
		    	StopCoroutine(flashCoroutine);
		
		flashCoroutine = DoFlash();
        StartCoroutine(flashCoroutine);
    }

    private IEnumerator DoFlash() {
        float lerpTime = 0;

        while (lerpTime < flashDuration) {
            lerpTime += Time.deltaTime;
            float perc = lerpTime / flashDuration;

            SetFlashAmount(1f - perc);
            yield return null;
        }
        SetFlashAmount(0);
    }
	
    private void SetFlashAmount(float flashAmount) {
        mat.SetFloat("_FlashAmount", flashAmount);
    }
}