using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {
    [Header("Navigation Variables")]
	public float moveSpeed;
	public float jumpForce;
	public float JumpCooldown = 1;
	private float jumpCooldown;
	public float lookSensitivity = 1;

	private InputManager input;
	private Rigidbody rigidBody;
	public Camera camera;

    [Header("Inventory")]
    public double maxWood;
    public double maxMushroom;
    public double maxIron;
    private Inventory inventory;

    [Header("Usable Items")]
    public float reachableDistance;
    private GameObject equippedObj;
    public GameObject[] equippedItems = new GameObject[5];
    private int equippedIndex;

    [Header("Buildings")]
    public GameObject b_Tower;
    public GameObject b_Keep;
    public GameObject b_EyeTower;

    public enum equipped { hatchet, pickaxe };
    public bool isPaused = false;

    void Start () {
		input = GetComponent<InputManager> ();
		rigidBody = GetComponent <Rigidbody>();
        inventory = new Inventory(maxWood, maxMushroom, maxIron);
        jumpCooldown = JumpCooldown;
	}

	void Update () {
		Move (input.i_forward, input.i_side, input.i_yaw, input.i_jump);
		UpdateCamera (input.i_pitch);
        CheckPause(input.i_pause);
        UpdateEquipped(input.i_scroll);
        CheckAction(input.i_primaryAction, input.i_secondaryAction);
	}

	private void Move(float fwd, float side, float yaw, bool jump){
		transform.Translate (new Vector3(side*moveSpeed, 0, fwd*moveSpeed));
		if (jump && jumpCooldown <= 0) {
			rigidBody.AddForce (new Vector3 (0, jumpForce, 0));
			jumpCooldown = JumpCooldown;
		} else {
			jumpCooldown = jumpCooldown - Time.deltaTime;
		}
		transform.Rotate (new Vector3(0,yaw*lookSensitivity,0));
	}

	private void UpdateCamera(float pitch){
		camera.transform.Rotate (new Vector3 (-pitch*lookSensitivity, 0, 0));
	}

    private void UpdateEquipped(float wheel) { // TODO: this
        //Deal with index counting
        int lastIndex = equippedIndex;
        if (wheel > 0.05f) {
            equippedIndex++;
        }
        else if (wheel < -0.05f) {
            equippedIndex--;
        }
        equippedIndex = equippedIndex % equippedItems.Length;
        //Debug.Log("index: "+equippedIndex);

        //Set item active
        for(int i = 0; i < equippedItems.Length-1; i++) {
            if (i == equippedIndex) {
                equippedItems[i].gameObject.SetActive(true);
            }
            else {
                equippedItems[i].gameObject.SetActive(false);
            }
        }
    }

    private void CheckPause(bool pause) {
        if (pause) {
            Debug.Log("Paused");
            if (isPaused)
                Time.timeScale = 1f;
            else {
                Time.timeScale = 0f;
            }
            isPaused = !isPaused;
        }
    }

    private void CheckAction(bool primary, bool secondary) { // TODO: this
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit)) {
            if (hit.collider.tag == "Tile" && primary) {
                // Harvest
            }
            else if(hit.collider.tag == "Tile" && secondary) {
                // Clear and build
            }
        }
    }
}
