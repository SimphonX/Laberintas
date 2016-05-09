using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class PlayerFiz : MonoBehaviour {

    public LayerMask collMask;

    private BoxCollider coll;
    private Vector3 s;
    private Vector3 c;

    private float skin = .005f;

    [HideInInspector]
    public bool grounded;

    Ray ray;
    RaycastHit hit;
    void Start()
    {
        coll = GetComponent<BoxCollider>();
        s = coll.size;
        c = coll.center;
    }

	public void Move(Vector3 move)
    {
        float cellZ = move.z;
        float cellX = move.x;
        float cellY = move.y;
        Vector3 p = transform.position;

        for(int i = 0; i <= 3; i++)
        {
            float dir = Mathf.Sign(cellZ);
            float x = (p.x + c.x + s.x / 2) + s.x * i;
            float z = p.z + c.z + s.z / 2 * dir;

            ray = new Ray(new Vector3(x, 0, z), new Vector3(0, 0, dir));

            if(Physics.Raycast(ray, out hit, Mathf.Abs(cellZ), collMask))
            {
                float dst = Vector3.Distance(ray.origin, hit.point);

                if(dst > skin)
                {
                    cellZ = dst * dir + skin;
                }
                else
                {
                    cellZ = 0;
                }
                grounded = true;
                break;
            }
        }

        Vector3 final = new Vector3(cellX, cellY, cellZ);
        transform.Translate(final);
    }
}
