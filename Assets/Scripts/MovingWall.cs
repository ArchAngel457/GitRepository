using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    public float speed = 1.0f;

    private Transform target;

    void Awake()
    {
        transform.position = new Vector3(0.0f, 0.5f, 0.0f);

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Camera.main.transform.position = new Vector3(08f, 1.0f, -3.0f);

        target = cube.transform;
        target.transform.localScale = new Vector3(0.0f, 1.0f, 0.0f);

        target.transform.position = new Vector3(1f, .5f, 1f); //controls how far to travel bewteen points

        GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Plane);
        floor.transform.position = new Vector3(0.0f, -1.0f, 0.0f);
    }

    void Update()
    {
        // Move our position a step closer to the target.
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            // Swap the position of the cylinder.
            target.position *= -1.0f;
        }
    }
}
  