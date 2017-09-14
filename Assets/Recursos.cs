using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recursos : MonoBehaviour {
	[SerializeField]Text recursosTxt;
	[SerializeField]Text tasaTxt;
	[SerializeField]Canvas miniCanvas; 
	[SerializeField]Canvas miniCanvasBandas; 
	[SerializeField]Button Mejora;
	[SerializeField]Button Mejora2;
	[SerializeField]Button Mejora3;
	[SerializeField]Button Mejora4;
	[SerializeField]Button Acelerar;
	[SerializeField]Button Banda;
	[SerializeField]Button Banda2;
	[SerializeField]Button Banda3;
	[SerializeField]Button Banda4;
	AudioSource audioSource;
	[SerializeField]AudioClip fondo;
	[SerializeField]AudioClip ClipAceleracion3;
	[SerializeField]AudioClip ClipAceleracion6;
	[SerializeField]AudioClip ClipStrikeAnywhere;
	[SerializeField]AudioClip ClipFrenzalRhomb;
	[SerializeField]AudioClip ClipAntiFlag;
	[SerializeField]AudioClip ClipRancid;
	float recursos;
	float recursoAux;
	int tasa;
	int tasaAceleracion;
	int estTasa;
	int estTasa1;
	bool acelerado;
	bool BandaTocando;
	float tiempoAceleracion;
	float maxTiempoAceleracion=3f;
	float tiempoBanda;

	float barWidth;
	float barHeight;
	Vector2 posBarra;

	int incrementoBase;

	[SerializeField]Texture2D barraLlena;

	// Use this for initialization
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource> ();
		recursoAux = 0;
		recursos = 0;
		tasa = 1;
		acelerado = false;
		estTasa = 0;
		estTasa1 = 0;
		maxTiempoAceleracion = 3f;
		tiempoAceleracion = maxTiempoAceleracion;
		tiempoBanda = 4f;
		posBarra.x = Screen.width * 0.062f;
		posBarra.y = Screen.height * 0.25f;
		barWidth = Screen.width * 3.1f;
		barHeight = Screen.height * 0.040f;
		tasaAceleracion = 20;
		incrementoBase = 100;
	}

	void OnGUI(){
		if(acelerado){
			GUI.DrawTexture(new Rect(posBarra, new Vector2(barWidth/100*tiempoAceleracion,barHeight)),barraLlena);
		}
	}

	public void IncrementarTasa(){
		tasa++;
	}

	public void IncrementarTasaAceleracion(){
		if (recursos*incrementoBase >= 25500) {
			recursos -= 25500 / incrementoBase;
			tasaAceleracion = 90;
			Mejora2.interactable = true;
			Mejora.interactable = false;
		} else {
			Debug.Log ("No tienes los fondos");
		}
	}

	public void IncrementarBase(){
		if (recursos*incrementoBase >= 75000) {
			recursos -= 75000 / incrementoBase;
			recursoAux = recursos;
			Debug.Log (recursos);
			incrementoBase = 500;
			recursos = (recursoAux*100)/500;
			Mejora3.interactable = true;
			Mejora2.interactable = false;
		} else {
			Debug.Log ("No tienes los fondos");
		}
	}

	public void IncrementarTiempo(){
		if (recursos*incrementoBase >= 125500) {
			recursos -= 125500 / incrementoBase;
			maxTiempoAceleracion = 6f;
			tiempoAceleracion = 6f;
            Acelerar.GetComponentInChildren<Text>().text = "Festival!";
            //Acelerar.GetComponent<RectTransform>().sizeDelta = new Vector2(600, 200);
            Mejora4.interactable = true;
			Mejora3.interactable = false;
		} else {
			Debug.Log ("No tienes los fondos");
		}
	}

	public void IncrementarTasaNormal(){
		if (recursos*incrementoBase >= 650000) {
			recursos -= 650000 / incrementoBase;
			tasa = 5;
			Mejora4.interactable = false;
		} else {
			Debug.Log ("No tienes los fondos");
		}
	}

	public void AcelerarGenracion(){
		estTasa = tasa;
		tasa = tasaAceleracion;
		acelerado = true;
		Acelerar.interactable = false;
		DesactivarBandas ();
		if (maxTiempoAceleracion == 3) {
			audioSource.clip = ClipAceleracion3;
			audioSource.Play ();
		} else if (maxTiempoAceleracion == 6) {
			audioSource.clip = ClipAceleracion6;
			audioSource.Play ();
		}
	}

	public void StrikeAnywhere(){
		if(!BandaTocando){
			if (recursos * incrementoBase >= 10000) {
				recursos -= 10000 / incrementoBase;
				estTasa1 = tasa;
				tasa = tasa + 40;
				BandaTocando = true;
				audioSource.clip = ClipStrikeAnywhere;
				audioSource.Play ();
			}
		}
	}

	public void FrenzalRhomb(){
		if(!BandaTocando){
			if (recursos * incrementoBase >= 50000) {
				recursos -= 50000 / incrementoBase;
				estTasa1 = tasa;
				tasa = tasa + 150;
				BandaTocando = true;
				audioSource.clip = ClipFrenzalRhomb;
				audioSource.Play ();
			}
		}
	}

	public void AntiFlag(){
		if(!BandaTocando){
			if (recursos * incrementoBase >= 100000) {
				recursos -= 100000 / incrementoBase;
				estTasa1 = tasa;
				tasa = tasa + 260;
				BandaTocando = true;
				audioSource.clip = ClipAntiFlag;
				audioSource.Play ();
			}
		}
	}

	public void Rancid(){
		if(!BandaTocando){
			if (recursos * incrementoBase >= 250000) {
				recursos -= 250000 / incrementoBase;
				estTasa1 = tasa;
				tasa = tasa + 250;
				BandaTocando = true;
				audioSource.clip = ClipRancid;
				audioSource.Play ();
			}
		}
	}

	public void ActivarCanvas(){
		if (miniCanvas.isActiveAndEnabled) {
			miniCanvas.gameObject.SetActive (false);
		} else {
			miniCanvas.gameObject.SetActive (true);
		}
	}

	public void ActivarCanvasBandas(){
		if (miniCanvasBandas.isActiveAndEnabled) {
			miniCanvasBandas.gameObject.SetActive (false);
		} else {
			miniCanvasBandas.gameObject.SetActive (true);
		}
	}

	public void JaggerTime(){
		recursos += 100f/incrementoBase;
	}

	void DesactivarBandas(){
		Banda.interactable = false;
		Banda2.interactable = false;
		Banda3.interactable = false;
		Banda4.interactable = false;
		Acelerar.interactable = false;
	}

	void ReactivarBandas(){
		Banda.interactable = true;
		Banda2.interactable = true;
		Banda3.interactable = true;
		Banda4.interactable = true;
		Acelerar.interactable = true;
	}

	// Update is called once per frame
	void Update () {
		if(acelerado){
			tiempoAceleracion -= Time.deltaTime;
			if(tiempoAceleracion<=0){
				tiempoAceleracion = maxTiempoAceleracion;
				tasa = estTasa;
				acelerado = false;
				Acelerar.interactable = true;
				ReactivarBandas ();
				audioSource.clip = fondo;
				audioSource.Play ();
				audioSource.loop = true;
			}
		}
		if(BandaTocando){
			DesactivarBandas();
			tiempoBanda -= Time.deltaTime;
			if (tiempoBanda <= 0) {
				BandaTocando = false;
				tiempoBanda = 4f;
				tasa = estTasa1;
				ReactivarBandas ();
				audioSource.clip = fondo;
				audioSource.Play ();
				audioSource.loop = true;
			}
		}
		recursos += Time.deltaTime * tasa;
		recursosTxt.text = ((int)recursos*incrementoBase).ToString();
		tasaTxt.text = tasa.ToString()+"x";
	}
}
