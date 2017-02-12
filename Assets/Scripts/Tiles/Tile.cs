using UnityEngine;
using System.Collections;

public class Tile {
    private LevelFactory.types levelType;
    private Vector3 position;
    private Quaternion rotation;
	private bool locked;
    private GameObject obj_Self;

	// Accessors
    public LevelFactory.types getLevelType() {
        return levelType;
    }

    public Vector3 getPosition() {
        return position;
    }

    public Quaternion getRotation() {
        return rotation;
    }

	public bool getLocked(){
		return locked;
	}

    public GameObject getObj_Self() {
        return obj_Self;
    }

	// Mutators
    public void setType(LevelFactory.types type) {
        this.levelType = type;
    }

    public void setPosition(Vector3 pos) {
        this.position = pos;
    }

    public void setRotation(Quaternion rot) {
        this.rotation = rot;
    }

	public void setLocked(bool isLocked){
		this.locked = isLocked;
	}

    public void setObj_Self(GameObject obj_Self) {
        this.obj_Self = obj_Self;
    }

    // Constructor
    public Tile(LevelFactory.types levelType, Vector3 position, Quaternion rotation) {
        this.levelType = levelType;
        this.position = position;
        this.rotation = rotation;
    }
}
