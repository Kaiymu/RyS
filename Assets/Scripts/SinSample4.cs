using UnityEngine;
using System.Collections;

public class SinSample4: MonoBehaviour {

float[] data;	
GameObject[] cubes;
public float delta;
public int nbCube;
public Material mat;

	void Awake()
	{
		data = new float[1];
		cubes = new GameObject[(nbCube*2)+1];
		cubes[0] = GameObject.CreatePrimitive (PrimitiveType.Cube);
		float x = 0;
		cubes[0].transform.position = new Vector3(0, this.transform.position.y, 50);
		cubes[0].renderer.material = this.mat;
		for (int i=1; i<cubes.Length;i=i+2)
		{
			x++;
			cubes[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cubes[i].transform.position = new Vector3(x, this.transform.position.y, 50);
			cubes[i].renderer.material = this.mat;
			cubes[i+1]=GameObject.CreatePrimitive(PrimitiveType.Cube);
			cubes[i+1].transform.position = new Vector3(-x, this.transform.position.y, 50);
			cubes[i+1].renderer.material = this.mat;
		}
	}
	
	void Update()
	{
		AudioListener.GetOutputData(this.data, 0);
		Vector3 scale = new Vector3(1, this.data[0] * delta,1);
		cubes[0].transform.localScale = scale;
		
		for (int i=cubes.Length-1; i >= 2; i=i-1)
		{
			cubes[i].transform.localScale = cubes[i-2].transform.localScale;
			cubes[i-1].transform.localScale = cubes[i-2].transform.localScale;
		}
	}
}
		
//creer un cube puis 25 de chaque coté 3|1|0|2|4