using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public Vector2 range;
    public float speed;
	
	void Update () 
    {
        Vector3 position = transform.position;
        float direction = Input.GetAxis("Horizontal");
        position.x += speed * direction;
        position.x = Mathf.Clamp(position.x, range.x, range.y);
        transform.position = position;
	}

    void OnCollisionEnter(Collision col)
    {
        GameManager.Instance.Die();
        CleanScene.LoadBefore("Main");
    }
}
