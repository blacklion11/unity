using UnityEngine;
using System.Collections;


public class GameController : MonoBehaviour {
	public static GameController S;

	public GameObject container;

	public GameObject blue;
	public GameObject brown;
	public GameObject green;
	public GameObject light_blue;
	public GameObject red;

	public int width;
	public int height;

	private ArrayList int_blocks;
	private ArrayList blocks;


	// Use this for initialization
	void Start () {
		S = this;
	
		// Construct the container bottom
		for(int i = 0; i < width + 2; i++)
		{
			GameObject go = Instantiate(container) as GameObject;
			go.transform.position = new Vector2(i, 0);
		}

		// Construct the container walls

		for(int i = 0; i < height + 1; i++)
		{
			for(int j = 0; j < width + 2; j+= (width + 1))
			{
				GameObject go = Instantiate(container) as GameObject;
				go.transform.position = new Vector2(j, i);

			}

		}

		blocks = new ArrayList();
		int_blocks = new ArrayList();

		GenerateBlocks();
		SmoothBlocks();
		SpawnBlocks();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private BlockController blockA;
	private BlockController blockB;

	public IEnumerator SelectBlock(BlockController block, bool value)
	{
		if(!value)
		{
			blockA = null;
			yield return StartCoroutine(block.Select(false));
		}
		else
		{
			if(blockA == null)
			{
				blockA = block;

				yield return StartCoroutine(block.Select(true));
			}
			else if(blockB == null && isNeighbor(blockA.transform, block.transform))
			{
				blockB = block;


				yield return StartCoroutine(block.Select(true));

				yield return new WaitForSeconds(0.5f);
				
				Vector2 tempPos = blockA.transform.position;
				
				blockA.transform.position = blockB.transform.position;
				blockB.transform.position = tempPos;

				yield return StartCoroutine(blockA.Select(false));
				yield return StartCoroutine(blockB.Select(false));

				// Check for groups to remove
				removeGroup();


				// shift blocks after removing groups
				shiftBlocks();

				blockA = blockB = null;
			}
		}
		yield return new WaitForSeconds (0);

	}

	bool isNeighbor(Transform transA, Transform transB)
	{
		return Mathf.Abs(transA.position.x - transB.position.x) <= 1 && Mathf.Abs(transA.position.y - transB.position.y) <= 1; 
	}


	void shiftBlocks()
	{
		Vector2 startPos = new Vector2(1f,1f);


	}


	void removeGroup()
	{
		Vector2 startPos = blockA.transform.position;
		startPos.y++;

		RaycastHit2D rayhit = Physics2D.Raycast(startPos, Vector2.up);

		Debug.Log(rayhit.distance);
		Debug.Log(rayhit.transform.gameObject.GetComponent<BlockController>().Color_ID);
		if(rayhit.collider.gameObject.GetComponent<BlockController>().Color_ID == blockA.Color_ID) Destroy(rayhit.collider.gameObject);
	}


	/*
	bool walkBlocks(BlockController block, int counter)
	{
		int numLikeBlocks = 0;
		bool shouldDestroy = false;
		// walk through all touching blocks and see if they are the same color
		for(int i = -1; i < 2; i++)
		{
			for(int j = -1; j < 2; j++)
			{
				if(i == 0 && j == 0)continue;

				Debug.Log(block.transform.position);

				GameObject testBlock =  ( (GameObject[]) blocks[(int) (block.transform.position.y) + i])[((int) block.transform.position.x) + j];
				if(!testBlock.GetComponent<BlockController>().counted && testBlock.GetComponent<BlockController>().Color_ID == block.Color_ID)
				{
					// match found
					testBlock.GetComponent<BlockController>().counted = true;
					numLikeBlocks++;

					// test the test block for like colored blocks
					shouldDestroy = walkBlocks(testBlock.GetComponent<BlockController>(), counter + numLikeBlocks);
				}
			}
		}

		// if no blocks are the same color check counter for number of touching same-colored blocks
		if(counter + numLikeBlocks > 3)
		{
			shouldDestroy = true;
		}

		if(shouldDestroy)
		{
			Destroy(block.gameObject);
		}
		return shouldDestroy;
	}
	*/



	void GenerateBlocks()
	{
		//Randomly generate the blocks
		for(int i = 0; i < height; i++)
		{
			int[] line = new int[width];
			for(int j = 0; j < width; j++)
			{
				int rand = (int) Random.Range(0f, 80);
				line[j] = rand;
			}
			int_blocks.Add(line);
		}
	}

	void SpawnBlocks()
	{
		//Spawn the blocks 
		for(int i = 1; i < height; i++)
		{
			int[] int_line = (int[]) int_blocks[i - 1];
			GameObject[] ob_line = new GameObject[width];
			for(int j = 1; j < width + 1; j++)
			{
				int block_id = int_line[j - 1];
				GameObject go = null;
				if(block_id < 80)
				{
					go = Instantiate(blue) as GameObject;
					go.GetComponent<BlockController>().Color_ID = 0;
				}
				if(block_id < 60)
				{
					if(go != null) Destroy(go.gameObject);
					go =Instantiate(brown) as GameObject;
					go.GetComponent<BlockController>().Color_ID = 1;
				}
				if(block_id < 40)
				{
					if(go != null) Destroy(go.gameObject);
					go = Instantiate(green) as GameObject;
					go.GetComponent<BlockController>().Color_ID = 2;
				}
				if(block_id < 20)
				{
					if(go != null) Destroy(go.gameObject);
					go = Instantiate(light_blue) as GameObject;
					go.GetComponent<BlockController>().Color_ID = 3;
				}
				if (block_id < 10)
				{
					if(go != null) Destroy(go.gameObject);
					go = Instantiate(red) as GameObject;
					go.GetComponent<BlockController>().Color_ID = 4;
				}
		

				if(go != null)
				{
					//make sure the blocks dont rotate

					// set block position
					go.transform.position = new Vector2(j, i);

					// add block to the line array
					ob_line[j - 1] = go;
				}
			}
			// add block line to arraylist
			blocks.Add(ob_line);
		}
	}


	void SmoothBlocks()
	{

		for(int i = 0; i < int_blocks.Count; i++)
		{
			int[] line = (int[]) int_blocks[i];
			for(int j = 1; j < line.Length - 1; j++)
			{
				if(line[j] == line[j-1] && line[j] == line[j+1])
				{
					line[j] = (int) Random.Range(0f ,6f);
					int_blocks[i]= line;
				}

			}

		}
	}
















}
