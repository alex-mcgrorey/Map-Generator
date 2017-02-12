using System.Collections;
using UnityEngine;

public class HillDynamic{
	private float[,] mask;
	private int width;
	private int height;
	private float slope;

	// Constructor
	public HillDynamic (int width, int height, float slope){
		this.width = width;
		this.height = height;
		this.slope = slope;
		this.mask = new float[width,height];

		generateMask ();
	}

	// Accessors
	public int getWidth(){
		return width;
	}

	public int getHeight(){
		return height;
	}

	/// <summary>
	/// Generates the mask.
	/// 1. Choose a point on each edge
	/// 2. Input a value of slope creating an outline
	/// 3. Fill in the outline
	/// 4. Bring the perimiters in and repeat fill
	/// </summary>
	private void generateMask(){
		int topPoint = Random.Range (width/4, width*3/4);
		int leftPoint = Random.Range (height/4, height*3/4);
		int rightPoint = Random.Range (height/4, height*3/4);
		int bottomPoint = Random.Range (width/4, width*3/4);

		// Input values for edge points
		mask[0,leftPoint] = slope;
		mask[width - 1, rightPoint] = slope;
		mask [topPoint, 0] = slope;
		mask [bottomPoint, height - 1] = slope;

		// Connect top and left
		int rise = (int)Mathf.Round(leftPoint/rightPoint);
		for (int i = 1; i < topPoint - 2; i++) {
			for (int j = 1; j <= rise; j++) {
				mask [i, j + i * rise] = slope;
			}
		}
	}
}