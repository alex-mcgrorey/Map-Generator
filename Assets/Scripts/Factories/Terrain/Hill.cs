using UnityEngine;
using System.Collections;

public class Hill {

	private float[,] template =
		{{	0,		0,		0,		0.5f,	0.5f,	0.5f,	0,		0,		0},
		{	0,		0,		0.5f,	1,		1,		1,		0.5f, 	0, 		0},
		{	0,		0,		0.5f,	1,		1.5f,	1,		0.5f,	0,		0},
		{	0,		0.5f,	1,		1.5f,	1.5f,	1.5f,	1,		0.5f,	0},
		{	0,		0.5f,	1,		1.5f,	2,		1.5f,	1,		0.5f,	0},
		{	0.5f,	1,		1.5f,	2,		2,		2,		1.5f,	1,		0.5f},
		{	0,		0.5f,	1,		1.5f,	2,		1.5f,	1,		0.5f,	0},
		{	0,		0.5f,	1,		1.5f,	1.5f,	1.5f,	1,		0.5f,	0},
		{	0,		0,		0.5f,	1,		1.5f,	1,		0.5f,	0,		0},
		{	0,		0,		0.5f,	1,		1,		1,		0.5f, 	0, 		0},
		{	0,		0,		0,		0.5f,	0.5f,	0.5f,	0,		0,		0}};

	private float scale = 1;


	public Hill(float scale){
		this.scale = scale;
		applyScale ();
		// TODO implement all of template scaling
	}

	public float[,] getTemplate(){
		return template;
	}

	// I feel dirty hardcoding all oif this
	public int getWidth(){
		return 9;
	}

	public int getHeight(){
		return 11;
	}

	private void applyScale(){
		for (int i = 0; i < getHeight () - 1; i++) {
			for (int j = 0; j < getWidth () - 1; j++) {
				template [i, j] *= scale;
			}
		}
	}
}
