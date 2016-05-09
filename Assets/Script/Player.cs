using UnityEngine;
using System.Collections;
[RequireComponent(typeof(PlayerFiz))]
public class Player : MonoBehaviour {
    public float speed = 8;
    public float accel = 12;
    public float gravity = 20;
    private float currentSpeedx;
    private float targetSpeedx;
    private float currentSpeedy;
    private float targetSpeedy;
    private Vector3 kiekisJud;
    private PlayerFiz fizikos;
	// Use this for initialization
	void Start () {
        fizikos = GetComponent < PlayerFiz >();
	}
	
	// Update is called once per frame
	void Update () {
        targetSpeedx = Input.GetAxisRaw("Horizontal") * speed;
        targetSpeedy = Input.GetAxisRaw("Vertical") * speed;
        currentSpeedx = IncrementTowards(currentSpeedx, targetSpeedx, accel);
        currentSpeedy = IncrementTowards(currentSpeedy, targetSpeedy, accel);

        kiekisJud.x = 0 - currentSpeedx;
        kiekisJud.y = currentSpeedy;
        kiekisJud.z = 0;
        fizikos.Move(kiekisJud * Time.deltaTime);
	}
    private float IncrementTowards(float n, float target, float speed)
    {
        if(n == target)
        {
            return n;
        }
        else
        {
            float dir = Mathf.Sign(target - n);
            n+= speed* Time.deltaTime * dir;
            return (dir == Mathf.Sign(target - n)) ? n : target;
        }
    }
}
