using UnityEngine;
using System.Collections;

public class PerlinHeightGenerator {
	private float[,] noiseMap;
	private float scale = 1f;
	private float power = 3f;
    private float minHeight = 999f;
    private float maxHeight = 0f;

    // Accessors
    public float getScale() {
        return scale;
    }

    public float getPower() {
        return power;
    }

    public float getMinHeight() {
        return minHeight;
    }

    public float getMaxHeight() {
        return maxHeight;
    }

    public float[,] getNoiseMap() {
        return noiseMap;
    }

    //Constructor
    public PerlinHeightGenerator(int width, int height, float scale, float power){
		this.scale = scale;
		this.power = power;

		noiseMap = new float[height,width];
        GenerateNoise ();
	}

	private void GenerateNoise(){
        Vector2 randomShift = new Vector2(Random.Range(0, 100f), Random.Range(0,100f));
        for (int i = 0; i < noiseMap.GetLength(0); i++) {
			for (int j = 0; j < noiseMap.GetLength(1); j++) {
				float xCoord = ((float)j/ noiseMap.GetLength(1)) * scale;
				float yCoord = ((float)i/ noiseMap.GetLength(0)) * scale;
				float coordHeight = Mathf.PerlinNoise (xCoord+randomShift.x, yCoord+randomShift.y) * power;
                noiseMap[i,j] = coordHeight;
                if(coordHeight > maxHeight) {
                    maxHeight = coordHeight;
                }
                if(coordHeight < minHeight) {
                    minHeight = coordHeight;
                }
			}
		}
	}
}
