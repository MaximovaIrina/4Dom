using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Camera camera;

    public GameObject obj;

  


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void rotateUp()
    {

        camera.transform.RotateAround(new Vector3(1, 0, 0), 3.14f/30);
    }

    public void rotateDown() {
        camera.transform.RotateAround(new Vector3(1, 0, 0), -3.14f / 30);

    }

    public void rotateLeft() {
        camera.transform.RotateAround(new Vector3(0, 1, 0), -3.14f / 30);
    }

    public void rotateRight() {
        camera.transform.RotateAround(new Vector3(0, 1, 0), +3.14f / 30);

    }

    public void forward() {
        var dir = obj.transform.position - camera.transform.position;
        float step = 15f;

        float deltax = dir.x / Mathf.Sqrt(dir.x* dir.x+ dir.y * dir.y + dir.z * dir.z) * step;
        float deltay = dir.y / Mathf.Sqrt(dir.x * dir.x + dir.y * dir.y + dir.z * dir.z) * step;
        float deltaz = dir.z / Mathf.Sqrt(dir.x * dir.x + dir.y * dir.y + dir.z * dir.z) * step;
        camera.transform.position = new Vector3(camera.transform.localPosition.x+ deltax, camera.transform.localPosition.y + deltay, camera.transform.localPosition.z + deltaz);

    }

    public void back() { }


}
