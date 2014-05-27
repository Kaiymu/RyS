using UnityEngine;
using System.Collections;

public class shipMove : MonoBehaviour {

	public float moveSpeed;
	public GameObject playerBullet;
	public GameObject ammoBar;
	private int currentRail;
	public float rangeBetweenRails; 
	private int ammo;
	private int maxAmmo =200;
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
		this.ammo = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if(this.currentRail == levelSpawner.ActiveRailNum)
		{
			this.loadWeapon();
		}
		if(!PauseGame.pause)
		{
			if (Input.GetButton("verticalUp") && this.currentRail != 0 && this.movingDir == "")
			{
				this.objectiveRail -= 1;
				this.objectiveValueY = railArray[this.objectiveRail];
				this.movingDir = "TOP";
			}
			else if(Input.GetButton("verticalDown") && this.currentRail != 2 && this.movingDir == "")
			{
				this.objectiveRail += 1;
				this.objectiveValueY = railArray[this.objectiveRail];
				this.movingDir = "BOT";
			}
			else if(Input.GetButton("Shoot") && this.ammo == this.maxAmmo)
			{
				this.shoot();
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
	void loadWeapon(){
		if(this.ammo < this.maxAmmo)
		{
			this.ammo +=2;
			ammoBar.transform.localScale += new Vector3(0.2F, 0, 0);
			ammoBar.transform.Translate( new Vector3(0.1f,0,0));
		}


	}
	void shoot(){

		Instantiate(this.playerBullet,this.transform.position, this.transform.rotation);
		this.ammo = 0;
		ammoBar.transform.localScale -= new Vector3(20F, 0, 0);
		ammoBar.transform.Translate( new Vector3(-10f,0,0));
	}
}
