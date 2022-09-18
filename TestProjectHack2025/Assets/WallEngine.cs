using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallEngine : MonoBehaviour
{

    ArrayList Walls = new ArrayList();
    public Texture texture;
    public Texture2D resized0;
    public Texture2D resized1;

    // Start is called before the first frame update
    void Start()
    {

        Parce();


    }

    public void Start2(LinkedList<Vector2Int[]> horizontals, LinkedList<Vector2Int[]> verticals, int floor)
    {
        foreach (var hor in horizontals)
        {
            Walls.Add(new Pair<Vector3>(new Vector3(hor[0].x, floor * 3, hor[0].y), new Vector3(hor[1].x, (floor + 1) * 3, hor[1].y)));
        }

        for (int i = 0; i < Walls.Count; i++)
        {

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);


            Pair<Vector3> wall = (Pair<Vector3>)Walls[i];
            cube.transform.localScale = new Vector3(0.01f, wall.object2.y, Mathf.Sqrt((wall.object1.x - wall.object2.x) * (wall.object1.x - wall.object2.x) + (wall.object1.z - wall.object2.z) * (wall.object1.z - wall.object2.z)));

            cube.transform.RotateAroundLocal(new Vector3(0, 1, 0), Mathf.Atan(((wall.object1.x - wall.object2.x) / 2) / ((wall.object1.z - wall.object2.z) / 2)));
            //cube.transform.Rota

            cube.transform.position = new Vector3((wall.object1.x + wall.object2.x) / 2, (wall.object1.y + wall.object2.y) / 2, (wall.object1.z + wall.object2.z) / 2);



            Renderer renderer = cube.GetComponent<Renderer>();

            renderer.material.SetTexture("_MainTex", texture);

        }


    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public Texture2D[] floorImage;

    void Parce()
    {
        int counter = -1;
        foreach (Texture2D floor in floorImage)
        {
            counter++;
            LinkedList<Vector2Int[]> horizontals = new LinkedList<Vector2Int[]>();
            LinkedList<Vector2Int[]> verticals = new LinkedList<Vector2Int[]>();
            //Texture2D resized = Resize(floor, floor.width / 20, floor.height / 20);
            Texture2D resized = floor;

            for (int i = 0; i < resized.height; i++)
            {
                for (int j = 0; j < resized.width; j++)
                {
                    if (resized.GetPixel(j, i).Equals(Color.black))
                    {
                        LinkedList<Vector2Int> horizontal = new LinkedList<Vector2Int>();
                        LinkedList<Vector2Int> vertical = new LinkedList<Vector2Int>();
                        int k = i;
                        int m = j;
                        while (resized.GetPixel(m + 1, k).Equals(Color.black) || resized.GetPixel(m + 1, k + 1).Equals(Color.black) || resized.GetPixel(m + 1, k - 1).Equals(Color.black))
                        {
                            if (resized.GetPixel(m + 1, k).Equals(Color.black))
                            {
                                m++;
                            }
                            else if (resized.GetPixel(m + 1, k + 1).Equals(Color.black))
                            {
                                m++;
                                k++;
                            }
                            else if (resized.GetPixel(m + 1, k - 1).Equals(Color.black))
                            {
                                m++;
                                k--;
                            }
                            horizontal.AddLast(new Vector2Int(m, k));
                        }

                        k = i;
                        m = j;
                        while (resized.GetPixel(m, k + 1).Equals(Color.black) || resized.GetPixel(m + 1, k + 1).Equals(Color.black) || resized.GetPixel(m - 1, k + 1).Equals(Color.black))
                        {
                            if (resized.GetPixel(m, k + 1).Equals(Color.black))
                            {
                                k++;
                            }
                            else if (resized.GetPixel(m + 1, k + 1).Equals(Color.black))
                            {
                                m++;
                                k++;
                            }
                            else if (resized.GetPixel(m - 1, k + 1).Equals(Color.black))
                            {
                                m--;
                                k++;
                            }
                            vertical.AddLast(new Vector2Int(m, k));
                        }
                        if (horizontal.Count > vertical.Count)
                        {
                            horizontals.AddLast(new Vector2Int[2] { horizontal.First.Value, horizontal.Last.Value });
                            foreach (var coordinate in horizontal)
                            {
                                resized.SetPixel(coordinate.x, coordinate.y, Color.white);
                            }
                        }
                        else if (horizontal.Count < vertical.Count)
                        {
                            verticals.AddLast(new Vector2Int[2] { vertical.First.Value, vertical.Last.Value });
                            foreach (var coordinate in vertical)
                            {
                                resized.SetPixel(coordinate.x, coordinate.y, Color.white);
                            }
                        } else
                        {
                            try
                            {

                                horizontals.AddLast(new Vector2Int[2] { horizontal.First.Value, horizontal.Last.Value });
                                foreach (var coordinate in horizontal)
                                {
                                    resized.SetPixel(coordinate.x, coordinate.y, Color.white);
                                }

                                verticals.AddLast(new Vector2Int[2] { vertical.First.Value, vertical.Last.Value });
                                foreach (var coordinate in vertical)
                                {
                                    resized.SetPixel(coordinate.x, coordinate.y, Color.white);
                                }
                            } catch (Exception ex)
                            {

                            }
                        }



                    }
                }
            }

            Start2(horizontals, verticals, counter);
        }
    }

    Texture2D Resize(Texture2D texture2D, int targetX, int targetY)
    {
        RenderTexture rt = new RenderTexture(targetX, targetY, 24);
        RenderTexture.active = rt;
        Graphics.Blit(texture2D, rt);
        Texture2D result = new Texture2D(targetX, targetY);
        result.ReadPixels(new Rect(0, 0, targetX, targetY), 0, 0);
        result.Apply();
        return result;
    }
}

public class Pair<T>
{
    public T object1 { get; set; }
    public T object2 { get; set; }
    public Pair(T object1, T object2)
    {
        this.object1 = object1;
        this.object2 = object2;
    }


}
