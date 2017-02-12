using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject player;
	private LevelManager levelManager;
	

	// Use this for initialization
	void Start () {
		levelManager = GetComponent<LevelManager>();
		levelManager.SpawnPlayer (player, new Vector3(5,50,10));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
