using UnityEngine;
using System.Collections;

public class GetScoreGlobal : MonoBehaviour {

	void Start () {
		this.GetComponent<UILabel>().text = "Your final score is : " + ScoreManager.giveScoreToAll;
	}

}
