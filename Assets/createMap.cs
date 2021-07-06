using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createMap : MonoBehaviour
{

    public class Cell
    {

       public int x;
        public int y;
        public bool visited = false;
        //whether the cell has wall surround corresponding side
        public GameObject leftCube;
        public GameObject rightCube;
        public GameObject upCube;
        public GameObject downCube;


public Cell(int x, int y)
        {
            Vector3 scaleChange = new Vector3(10f, 2.0f, 0.0f);
            Vector3 scaleChange2 = new Vector3(0.0f, 2.0f, 10.0f);

            this.x = x; 
            this.y = y; 
            //create all the walls of the cube

        leftCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        leftCube.transform.position = new Vector3(-50f + 10*x, 0f,-45f + 10*y);
            leftCube.transform.localScale += scaleChange2;

        downCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        downCube.transform.position = new Vector3(-45f + 10*x, 0f, -50 + 10*y);
            downCube.transform.localScale += scaleChange;

        upCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            upCube.transform.position = new Vector3(-45f + 10 * x, 0f, -40 + 10 * y);
            upCube.transform.localScale += scaleChange;

        rightCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            rightCube.transform.position = new Vector3(-40f + 10 * x, 0f, -45f + 10 * y);
            rightCube.transform.localScale += scaleChange2;
        }

}

    GameObject cube;
    GameObject cube2;
    GameObject cube3;
    Cell[,] map = new Cell[10, 10];

    void drawMap()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(0f, 0f, 10f);

        cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube2.transform.position = new Vector3(0f, 0f, 20f);

        cube3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube3.transform.position = new Vector3(0f, 0f, 30f);

        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                map[x, y] = new Cell(x, y);
    }
	}
    }


    // Update is called once per frame
    void Update()
    {
    }
}
