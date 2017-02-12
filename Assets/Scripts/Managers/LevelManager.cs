//  Author:     Alex McGrorey
//  Project:    City Builder
//
//  LevelManager is instantiated by GameManager.  It is responsible for rendering the level, lighting, atmospehic effects, etc.
//**********************************************


using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour{
	[Header("Tiles")]
    public GameObject plain;
    public GameObject shroom;
    public GameObject forest;
    public GameObject sand;
    public GameObject ironOre;

    [Header("Creation Variables")]
    public int levelWidth = 75;
	public int levelHeight = 75;
	public float tileVariance = 5.0f;
	public int tileWidth = 1;
    public GameObject waterObj;

    [Header("Misc")]
    public Light masterLight;

    // Master Levels
    private Tile[,] naturalLevel;

	// Factories
	private LevelFactory levelFactory = new LevelFactory();

	// Accessors
	public Tile[,] getNaturalLevel(){
		return naturalLevel;
	}
 
	void Start(){
        naturalLevel = new Tile[levelHeight, levelWidth];
        CreateLevel();
        InstantiateNaturalMap();
        ChooseLighting();
        BuildLevel();
    }

    private void InstantiateNaturalMap() {;
        for(int i = 0; i <= levelHeight-1; i++) {
            for(int j = 0; j <= levelWidth-1; j++) {
                naturalLevel[i, j] = new Tile(levelFactory.masterLevel[i, j], new Vector3(tileWidth*j, levelFactory.heightMap[i, j], tileWidth * i), Quaternion.identity);
            }
        }
    }

	public void CreateLevel(){
        Debug.Log("Generating Level...");
		levelFactory.GenerateLevel(levelWidth, levelHeight, tileVariance);
	}

    private void BuildLevel() {
        for (int i = 0; i <= levelHeight-1; i++) {
            for(int j = 0; j <= levelWidth-1; j++) {
                GameObject currentTile = null;
                int rand90angle = Random.Range(0, 5) * 90;
                switch (naturalLevel[i, j].getLevelType()) {
                    case LevelFactory.types.Shroom:
                        currentTile = (GameObject)Instantiate(shroom, naturalLevel[i, j].getPosition(), new Quaternion(0, rand90angle, 0,0));
                        break;
                    case LevelFactory.types.Iron:
                        currentTile = (GameObject)Instantiate(ironOre, naturalLevel[i, j].getPosition(), new Quaternion(0, rand90angle, 0, 0));
                        break;
                    case LevelFactory.types.Sand:
                        currentTile = (GameObject)Instantiate(sand, naturalLevel[i, j].getPosition(), new Quaternion(0, rand90angle, 0, 0));
                        break;
                    case LevelFactory.types.Forest:
                        currentTile = (GameObject)Instantiate(forest, naturalLevel[i, j].getPosition(), new Quaternion(0, rand90angle, 0, 0));
                        break;
                    default:
                        currentTile = (GameObject)Instantiate(plain, naturalLevel[i, j].getPosition(), naturalLevel[i, j].getRotation());
                        break;
                }
                naturalLevel[i, j].setObj_Self(currentTile);
            }
        }
        Instantiate(waterObj, new Vector3(levelWidth/2, levelFactory.getWaterLevel()+2f, levelHeight/2), Quaternion.identity);
    }

	public void SpawnPlayer(GameObject player, Vector3 spawnPoint){
		Instantiate (player, spawnPoint, Quaternion.identity);
	}

    private void ChooseLighting() {
        // Choose theme
        int theme = Random.Range(0, 4);
        switch (theme) {
            case 0:         //Midday
                masterLight.transform.rotation = Quaternion.Euler(90,0,0);
                masterLight.color = new Color(0.201f, 0.210f, 0.168f, 0.255f);
                masterLight.intensity = 1f;
                break;
            case 1:         //Twilight
                masterLight.transform.rotation = Quaternion.Euler(10, 0, 0);
                masterLight.color = new Color(0.206f, 0.162f, 0.47f, 0.255f);
                masterLight.intensity = 0.75f;
                break;
            case 2:         //Night
                masterLight.transform.rotation = Quaternion.Euler(45, 0, 0);
                masterLight.color = new Color(0.91f, 0.65f, 0.197f, 0.255f);
                masterLight.intensity = 0.30f;
                break;
            default:         //Foggy
                masterLight.transform.rotation = Quaternion.Euler(45, 0, 0);
                masterLight.color = new Color(0.128f, 0.128f, 0.128f, 0.255f);
                masterLight.intensity = 0.50f;
                break;
        }
        Debug.Log(theme);
    }
}
