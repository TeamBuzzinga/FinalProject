using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MapPlayerPosition : MonoBehaviour {
	
	public Image mapImage;
	public GameObject floor;
	public GameObject player; 
	
	public Image positionIndicator;
	
	private RectTransform rectTransform;
	private Vector2 mapRange;
	private Vector2 floorRange;
	private Vector2 floorPos;
	private Vector2 playerPos;
	
	// Use this for initialization
	void Start () {
		rectTransform = GetComponent<RectTransform> ();
		mapRange = new Vector2(rectTransform.rect.width, rectTransform.rect.height);
		floorRange = new Vector2 (floor.transform.localScale.x, floor.transform.localScale.z);
		floorPos = new Vector2 (floor.transform.position.x, floor.transform.position.z);

	}
	
	// Update is called once per frame
	void Update () {
		playerPos = new Vector2 (player.transform.position.x, player.transform.position.z);
		positionIndicator.rectTransform.anchoredPosition = new Vector2 (-mapRange.x / 2f + ((playerPos.x - (floorPos.x - floorRange.x / 2f)) / floorRange.x) * mapRange.x, -mapRange.y / 2f + ((playerPos.y - (floorPos.y - floorRange.y / 2f)) / floorRange.y) * mapRange.y);
	}
}