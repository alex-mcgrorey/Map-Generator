// Author:  Alex McGrorey
// Project: City Builder 
//
// LevelFactory is called by LevelManager when generating terrain.
//*********************************************************


using UnityEngine;
using System.Collections;

public class LevelFactory {
	private int width, height;
	private float variance;
	public PerlinHeightGenerator heightGenerator;
    public PerlinHeightGenerator shroomGenerator;
    public PerlinHeightGenerator forestGenerator;
    public PerlinHeightGenerator ironOreGenerator;
	public types[,] masterLevel;
	public float[,] heightMap;
    public float[,] shroomMap;
    public float[,] forestMap;
    public float[,] ironOreMap;
    private float waterLevel = 0;

	public enum types
	{
		Plain, Shroom, Sand, Fertile, Forest, Iron, Stone
	}

	// Accessors
	public types[,] getMasterLevel(){
		return masterLevel;
	}

    public float getWaterLevel() {
        return waterLevel;
    }
     
	public void GenerateLevel(int width, int height, float variance){	
		this.width = width;
		this.height = height;
		this.variance = variance;

		heightGenerator = new PerlinHeightGenerator (width, height, Random.Range(1.5f, 4f), Random.Range(10f, 35f));
		heightMap = heightGenerator.getNoiseMap ();
        waterLevel = heightGenerator.getMinHeight() + 1f;
		masterLevel = new types[height,width];

        // The do-while loops ensure that there are some of each resource spawned on each map
        do {
            shroomGenerator = new PerlinHeightGenerator(width, height, Random.Range(0.5f, 3f), Random.Range(10f, 35f));
        } while (shroomGenerator.getMaxHeight() < shroomGenerator.getPower() * 0.75f);
        shroomMap = shroomGenerator.getNoiseMap();

        do {
            forestGenerator = new PerlinHeightGenerator(width, height, Random.Range(0.5f, 3f), Random.Range(10f, 35f));
        } while (forestGenerator.getMaxHeight() < shroomGenerator.getPower() * 0.7f);
        forestMap = forestGenerator.getNoiseMap();

        do {
            ironOreGenerator = new PerlinHeightGenerator(width, height, Random.Range(0.5f, 3f), Random.Range(10f, 35f));
        } while (ironOreGenerator.getMaxHeight() < shroomGenerator.getPower() * 0.85f);

        ironOreMap = ironOreGenerator.getNoiseMap();

        InitializeLevel();  
		ApplyUneveness();
	}

	private void InitializeLevel(){
		for(int i = 0; i <= height-1; i++){
			for(int j = 0; j <= width-1; j++){
                if (heightMap[i, j] <= waterLevel) {
                    masterLevel[i,j] = types.Sand;
                }
                else if (ironOreMap[i,j] >= ironOreGenerator.getPower()*0.85f) {
                    masterLevel[i, j] = types.Iron;
                }
                else if (forestMap[i, j] >= forestGenerator.getPower()*0.7f) {
                    masterLevel[i, j] = types.Forest;
                }
                else if (shroomMap[i, j] >= shroomGenerator.getPower()*0.75f) {
                    masterLevel[i, j] = types.Shroom;
                }
                else {
                    masterLevel[i, j] = types.Plain;
                }
			}
		}
	}

	private void ApplyUneveness(){
		// Add unevenness
		for(int i = 0; i <= height-1; i++){
			for(int j = 0; j <= width-1; j++){
				float semiRandom = Random.Range(-variance,variance);
				if(semiRandom < 0){semiRandom = 0;}			        //if height(semiRandom) is negative, make it 0
				if(semiRandom > variance){semiRandom = variance;}	//if height is greater than variance, make it variance
				heightMap [i, j] += semiRandom;
			}
		}
	}
}
