using System.Collections;
using UnityEngine;

public class CleanupBall : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 20f);
	}
}
