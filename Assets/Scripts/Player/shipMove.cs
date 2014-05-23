using UnityEngine;
using System.Collections;

public class shipMove : MonoBehaviour {

	public float moveSpeed;
	private int currentRail;
	public float rangeBetweenRails; 

	public float[] railArray;
	private int objectiveRail;
	private float objectiveValueY;
	private string movingDir;
	// Use this for initialization
	void Awake (){

	}

	void Start () {
	
		this.objectiveRail = 1;
		this.currentRail = 1;
		this.movingDir ="";



	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("verticalUp") && this.currentRail != 0 && this.movingDir == "")
		{
			this.objectiveRail -= 1;
			this.objectiveValueY = railArray[this.objectiveRail];
			this.movingDir = "TOP";
		}
		else if(Input.GetButtonDown("verticalDown") && this.currentRail != 2 && this.movingDir == "")
		{
			this.objectiveRail += 1;
			this.objectiveValueY = railArray[this.objectiveRail];
			this.movingDir = "BOT";
		}

		if(this.objectiveRail != this.currentRail)// si l'objectif rail est différent du current rail, on déplace le vaisseau
		{
			if(this.objectiveRail > this.currentRail) // le vaisseaux va vers le bas
			{

				transform.Translate(Vector3.down *1/2, Space.World);

				if(this.transform.position.y == railArray[objectiveRail])
				{
					this.currentRail = this.objectiveRail;
					this.movingDir = "";
				}

			}
			if(this.objectiveRail < this.currentRail) // le vaisseau va vers le haut
			{
				transform.Translate(Vector3.up *1/2, Space.World);
				if(this.transform.position.y == railArray[objectiveRail])
				{
					this.currentRail = this.objectiveRail;
					this.movingDir = "";
				}
			}
		}
	}
}
