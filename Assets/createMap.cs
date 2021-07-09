using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//learn how using works and C# and c++ poitner difference

public class createMap : MonoBehaviour
{

		System.Random rand = new System.Random();

	public int counter;

public	int randomGenerator()
	{
        int num = rand.Next(4);
		//string s = Convert.ToString(num);
		//string s1 = Convert.ToString(counter);
		string s2 = num + ", " + counter;
		counter++;
		//Debug.Log(s2);
		return num;
	}

	public class Pos
    {
		public int x;
		public int y;

		public Pos(int x, int y)
        {
<<<<<<< HEAD
            Vector3 scaleChange = new Vector3(10f, 10.0f, 0.0f);
            Vector3 scaleChange2 = new Vector3(0.0f, 10.0f, 10.0f);

            this.x = x;
            this.y = y;
            //create all the walls of the cube
=======
			this.x = x;
			this.y = y;
        }
    }
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
>>>>>>> 09ef295... created maze


		public Cell(int x, int y)
		{
			Vector3 scaleChange = new Vector3(10f, 2.0f, 0.0f);
			Vector3 scaleChange2 = new Vector3(0.0f, 2.0f, 10.0f);

			this.x = x;
			this.y = y;
			//create all the walls of the cube

			leftCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			leftCube.transform.position = new Vector3(-50f + 10 * x, 0f, -45f + 10 * y);
			leftCube.transform.localScale += scaleChange2;

			downCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			downCube.transform.position = new Vector3(-45f + 10 * x, 0f, -50 + 10 * y);
			downCube.transform.localScale += scaleChange;

			upCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			upCube.transform.position = new Vector3(-45f + 10 * x, 0f, -40 + 10 * y);
			upCube.transform.localScale += scaleChange;

			rightCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			rightCube.transform.position = new Vector3(-40f + 10 * x, 0f, -45f + 10 * y);
			rightCube.transform.localScale += scaleChange2;
		}

	}

	Cell[,] map = new Cell[10, 10];
	const int UP = 0;
	const int DOWN = 1;
	const int LEFT = 2;
	const int RIGHT = 3;

	bool validCell(Cell cell)
	{
		int x = cell.x;
		int y = cell.y;
		int size = 10;
		bool isValid = (((y + 1 < size) && !(map[x, y + 1].visited)) ||
						((y - 1 >= 0) && !(map[x, y - 1].visited)) ||
						((x + 1 < size) && !(map[x + 1, y].visited)) ||
						((x - 1 >= 0) && !(map[x - 1, y].visited)));
		return isValid;
	}

	void finalmap(int xStart, int yStart, int xEnd,int yEnd)
	{
		Stack visitedCells = new Stack(); //gonna hold position not pointer
		Cell selectedCell = (map[xStart, yStart]);
		Cell endCell = (map[xEnd, yEnd]);
		int size = 10;
		int counter = 0;
		while (selectedCell.x != xEnd || selectedCell.y != yEnd)
	{
		//check if valid move exists
			map[selectedCell.x, selectedCell.y].visited = true;
		if (validCell(selectedCell))
		{
			counter++;
			visitedCells.Push(new Pos(selectedCell.x, selectedCell.y));
			bool valid = false;
			while (!valid)
			{
				int direction = randomGenerator();
				if (direction == UP)
				{
					if ((selectedCell.y + 1 != size) && !(map[selectedCell.x, selectedCell.y+1].visited))
					{
						//cout<<"up";
						//remove wall
						Destroy(map[selectedCell.x, selectedCell.y].upCube);
							map[selectedCell.x, selectedCell.y].upCube = null;
						selectedCell = (map[selectedCell.x, selectedCell.y +1]);
							//remove wall
							Destroy(map[selectedCell.x, selectedCell.y].downCube);
							map[selectedCell.x, selectedCell.y].downCube = null; 
						valid = true;
					}
				}
				else if (direction == DOWN)
				{
					if ((selectedCell.y - 1 != -1) && !(map[selectedCell.x, selectedCell.y -1].visited))
					{
							//cout<<"down";
							Destroy(map[selectedCell.x, selectedCell.y].downCube);
							map[selectedCell.x, selectedCell.y].downCube = null;
						selectedCell = (map[selectedCell.x, selectedCell.y -1]);
						Destroy(map[selectedCell.x, selectedCell.y].upCube);

						valid = true;
					}
				}
				else if (direction == LEFT)
				{
					if (selectedCell.x - 1 != -1 && !(map[selectedCell.x -1, selectedCell.y]).visited)
					{
						//cout<<"left";
						Destroy(map[selectedCell.x, selectedCell.y].leftCube);
						selectedCell = (map[selectedCell.x -1, selectedCell.y]);
						Destroy(map[selectedCell.x, selectedCell.y].rightCube);
						valid = true;
					}
				}
				else if (direction == RIGHT)
				{
					if (selectedCell.x + 1 != size && !(map[selectedCell.x+1, selectedCell.y].visited))
					{
						//cout<<"right";
						Destroy(map[selectedCell.x, selectedCell.y].rightCube);
						selectedCell = (map[selectedCell.x + 1, selectedCell.y]);
						Destroy(map[selectedCell.x, selectedCell.y].leftCube);
						valid = true;
					}
				}
			}
		}
		else
		{ //
				Pos selectedPos = (Pos)visitedCells.Pop();
				selectedCell = map[selectedPos.x, selectedPos.y];
		}
			map[selectedCell.x, selectedCell.y].visited = true;
		selectedCell.visited = true;
	}
}



    void drawMap()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                map[x, y] = new Cell(x, y);
    }
	}

        Destroy(map[4, 4].leftCube);
        Destroy(map[3, 4].rightCube);
        Destroy(map[4, 4].rightCube);
        Destroy(map[4, 4].upCube);
	
        Destroy(map[4, 5].downCube);
        Destroy(map[4, 5].rightCube);
        Destroy(map[4, 5].upCube);
        Destroy(map[4, 6].downCube);

        Destroy(map[5, 4].leftCube);
        Destroy(map[5, 4].upCube);
        Destroy(map[5, 4].downCube);
        Destroy(map[5, 3].upCube);

        Destroy(map[5, 5].leftCube);
        Destroy(map[5, 5].rightCube);
        Destroy(map[6, 5].leftCube);
        Destroy(map[5, 5].downCube);

	//	finalmap(5, 5, 0, 0);

		//go through map again and remove 4 boxed walls

		//create center start
		for (int y = 0; y < 10; y++)
		{
			for (int x = 0; x < 10; x++)
			{
				if(!map[x, y].visited)
                {
				//	Destroy(map[x, y].upCube);	
				//	Destroy(map[x, y].downCube);
				//	Destroy(map[x, y].leftCube);
				//	Destroy(map[x, y].rightCube);
                }
			}
		}

    }


    // Update is called once per frame
    void Update()
    {
    }
}
