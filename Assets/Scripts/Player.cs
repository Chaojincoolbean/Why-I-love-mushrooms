using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour {

	public GameObject mainCamera;
	public AudioClip aoh;
	public AudioClip pick;
	public AudioClip nice;
	public AudioClip fart;
	public AudioClip freeze;
	public AudioClip cool;
	public GameObject mushroomnumber;
	public GameObject time;
	float x;
	float y;
	int m,m1,m2,m3,m4,m5,m6,m7,m8,m9,m10,m11;
	int c;
	float timer;
	AudioSource audiosrc;

	// Use this for initialization
	void Start () {
		x = this.gameObject.transform.position.x;
		y = this.gameObject.transform.position.y;
		m = m1 = m2 = m3 = m4 = m5 = m6 = m7 = m8 = m9 = m10 = m11= 0;
		c = 0;
		timer = 30f;
		audiosrc = this.gameObject.GetComponent<AudioSource> ();



	}

	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime;

		m = m1 + m2 + m3 + m4 + m5 + m6 + m7 + m8 + m9 + m10 + m11;

		if (c == 0) {
			Control0 ();
		}
		if (c == 1) {
			Control1 ();
		}
		if (c == 2) {
			Control2 ();
		}



		if (x < -8.33f) {
			x = -8.33f;
		}
		if (x > 8.23f) {
			x = 8.23f;
		}
		if (y < -4.28f) {
			y = -4.28f;
		}
		if (y > 4.22f) {
			y = 4.22f;
		}

		this.gameObject.transform.position = new Vector3 (x, y, 0);
		mushroomnumber.GetComponent<Text> ().text = "Mushrooms:" + m;
		time.GetComponent<Text> ().text = "Time:" + (int)timer;

		Debug.Log (m);

		if (timer < 0) {
			GameOver ();
		}
	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.name == "mushroom1(Clone)") {
			m1++;
			audiosrc.clip = aoh;
			audiosrc.Play ();
			CameraRotation();
			StartCoroutine (Wait1());
			Destroy (col.gameObject);
		}
		if (col.gameObject.name == "mushroom2(Clone)") {
			m2++;
			audiosrc.clip = pick;
			audiosrc.Play ();
			Destroy (col.gameObject);
		}
		if (col.gameObject.name == "mushroom3(Clone)") {
			m3++;
			audiosrc.clip = pick;
			audiosrc.Play ();
			Destroy (col.gameObject);
		}
		if (col.gameObject.name == "mushroom4(Clone)") {
			m4= m4+2;
			audiosrc.clip = pick;
			audiosrc.Play ();
			Destroy (col.gameObject);
		}
		if (col.gameObject.name == "mushroom5(Clone)") {
			m5++;
			audiosrc.clip = freeze;
			audiosrc.Play ();
			c = 2;
			this.gameObject.transform.GetChild(0).GetComponent<Animator> ().Play("player_freeze");
			StartCoroutine (Wait2());
			Destroy (col.gameObject);
		}
		if (col.gameObject.name == "mushroom6(Clone)") {
			m6++;
			audiosrc.clip = fart;
			audiosrc.Play ();
			c = 1;
			this.gameObject.transform.GetChild(0).GetComponent<Animator> ().Play("player_poison");
			col.GetComponent<AudioSource> ().Play ();
			StartCoroutine (Wait1());
			Destroy (col.gameObject);
		}
		if (col.gameObject.name == "mushroom7(Clone)") {
			m7++;
			audiosrc.clip = cool;
			audiosrc.Play ();
			timer = timer + 5f;
			Destroy (col.gameObject);
		}
		if (col.gameObject.name == "mushroom8(Clone)") {
			m8++;
			audiosrc.clip = freeze;
			audiosrc.Play ();
			c = 2;
			this.gameObject.transform.GetChild(0).GetComponent<Animator> ().Play("player_freeze");
			StartCoroutine (Wait2());
			Destroy (col.gameObject);

		}
		if (col.gameObject.name == "mushroom9(Clone)") {
			m9++;
			audiosrc.clip = fart;
			audiosrc.Play ();
			c = 1;
			this.gameObject.transform.GetChild(0).GetComponent<Animator> ().Play("player_poison");
			StartCoroutine (Wait1());
			Destroy (col.gameObject);
		}
		if (col.gameObject.name == "mushroom10(Clone)") {
			m10 = m10 + 5;
			audiosrc.clip = nice;
			audiosrc.Play ();
			Destroy (col.gameObject);
		}
		if (col.gameObject.name == "mushroom11(Clone)") {
			m11 = m11 + 4;
			audiosrc.clip = nice;
			audiosrc.Play ();
			Destroy (col.gameObject);
		}

		//Debug.Log ("m1:" + m1 + "m2:" + m2 + "m3:" + m3 + "m4:" + m4 + "m5:" + m5 
		//	+ "m6:" + m6 + "m7:" + m7 + "m8:" + m8 + "m9:" + m9 + "m10:" + m10 + "m11:" + m11);

	}

	void Control0(){
		
		if(Input.GetKey(KeyCode.W)){
			y = y + 0.2f;
		}
		if(Input.GetKey(KeyCode.S)){
			y = y - 0.2f;

		}
		if(Input.GetKey(KeyCode.A)){
			x = x - 0.2f;
		}
		if(Input.GetKey(KeyCode.D)){
			x = x + 0.2f;

		}
	}

	void Control1(){

		if(Input.GetKey(KeyCode.W)){
			y = y + 0.01f;
		}
		if(Input.GetKey(KeyCode.S)){
			y = y - 0.01f;

		}
		if(Input.GetKey(KeyCode.A)){
			x = x - 0.01f;
		}
		if(Input.GetKey(KeyCode.D)){
			x = x + 0.01f;

		}
	}

	void Control2(){
		
		if(Input.GetKey(KeyCode.W)){
			y = y + 0.000000001f;
		}
		if(Input.GetKey(KeyCode.S)){
			y = y - 0.000000001f;

		}
		if(Input.GetKey(KeyCode.A)){
			x = x - 0.000000001f;
		}
		if(Input.GetKey(KeyCode.D)){
			x = x + 0.000000001f;

		}

	}

	void GameOver(){

		if (m >= 50) {
			SceneManager.LoadScene (6);
		}
		if (m < 50) {
			SceneManager.LoadScene (7);
		}

	}

	void CameraRotation(){

		mainCamera.transform.rotation = Quaternion.Euler (0, 0, 180);

		
	}
		

	IEnumerator Wait1(){
		yield return new WaitForSeconds (5);
		c = 0;
		mainCamera.transform.rotation = Quaternion.Euler (0, 0, 0);
		this.gameObject.transform.GetChild(0).GetComponent<Animator> ().Play("player_animation");
	}

	IEnumerator Wait2(){
		yield return new WaitForSeconds (2);
		c = 0;
		this.gameObject.transform.GetChild(0).GetComponent<Animator> ().Play("player_animation");
	}
}
