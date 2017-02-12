using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	/// Control Variables
	// Strafe
	public float i_forward, i_side;

	// View
	public float i_pitch, i_yaw;

    //Action
    public bool i_primaryAction;
    public bool i_secondaryAction;

	// Misc
	public bool i_jump;
    public float i_scroll;
    public bool i_pause;

	void Update () {
		UpdateVars ();
	}

    private void UpdateVars() {
        i_forward = Input.GetAxis("Forward");
        i_side = Input.GetAxis("Horizontal");
        i_pitch = Input.GetAxis("Mouse Y");
        i_yaw = Input.GetAxis("Mouse X");
        i_scroll = Input.GetAxis("Mouse ScrollWheel");
        i_pause = Input.GetKey(KeyCode.Escape);

        i_jump = Input.GetAxis("Jump") > 0.05f ? true : false;
        i_primaryAction = Input.GetAxis("Primary") > 0.05f ? true : false;
        i_secondaryAction = Input.GetAxis("Secondary") > 0.05f ? true : false;
    }
}
