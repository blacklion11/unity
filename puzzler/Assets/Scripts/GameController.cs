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

	private ArrayList int_blocks;
	private ArrayList blocks;


	// Use this for initialization
	void Start () {
		S = this;
	
		// Construct the container bottom
		for(int i = 0; i < 10; i++)
		{
			GameObject go = Instantiate(container) as GameObject;
			go.transform.position = new Vector2(i, 0);
		}

		// Construct the container walls

		for(int i = 0; i < 20; i++)
		{
			for(int j = 0; j < 10; j+=9)
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

	public IEnumerator SelectBlock(BlockController block)
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
		}

		yield return new WaitForSeconds (0);

	}

	bool isNeighbor(Transform transA, Transform transB)
	{
		return Mathf.Abs(transA.position.x - transB.position.x) <= 1 && Mathf.Abs(transA.position.y - transB.position.y) <= 1; 

	}

	void GenerateBlocks()
	{
		//Randomly generate the blocks
		for(int i = 0; i < 19; i++)
		{
			int[] line = new int[8];
			for(int j = 0; j < 8; j++)
			{
				int rand = (int) Random.Range(0f, 4f);
				line[j] = rand;
			}
			int_blocks.Add(line);
		}
	}

	void SpawnBlocks()
	{
		//Spawn the blocks 
		for(int i = 1; i < 20; i++)
		{
			int[] int_line = (int[]) int_blocks[i - 1];
			GameObject[] ob_line = new GameObject[8];
			for(int j = 1; j < 9; j++)
			{
				int block_id = int_line[j - 1];
				GameObject go = null;
				switch(block_id)
				{
				case 0:
					go = Instantiate(blue) as GameObject;
					break;
				case 1:
					go =Instantiate(brown) as GameObject;
					break;
				case 2:
					go = Instantiate(green) as GameObject;
					break;
				case 3:
					go = Instantiate(light_blue) as GameObject;
					break;
				case 4:
					go = Instantiate(red) as GameObject;
					break;
				}

				if(go != null)
				{
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
