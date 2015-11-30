using UnityEngine;
using System.Collections;

public class CreateScrollingText : MonoBehaviour {
    public Transform creditTextObject;
    public string scrollText = "Developers:\nRyan Andersen\nSiddharth Shah\nMoon Chang\nWei Yang Quek\nDingfeng Shao\n\nLevel Design\nWei Yang Quek\n\nParticle Effects\nDingfeng Shao\nWei Yang Quek\n\nMenu\nRyan Andersen\n\nPlayer Controller\nWei Yang Quek\nMoon Chang\nSiddharth Shah\n\nCamera Controller\nMoon Chang\n\nNPCs\nSiddharth Shah\nDingfeng Shao\n\nIn game UI\nRyan Andersen\nSiddharth Shah\n\nMusic:\nSad Piano Music by Ross Bugden\n\nThird Party Resources:\nRAIN AI: \nhttps://www.assetstore.unity3d.com/en/#!/content/23569";

	// Use this for initialization
	void Start () {
        string[] splitText = scrollText.Split('\n');
        int i = 0;
        foreach (string txtLine in splitText)
        {
            GameObject obj = (GameObject)Instantiate(creditTextObject.gameObject, Vector3.zero , Quaternion.Euler(0, 15, 0));
            obj.GetComponent<TextMesh>().text = txtLine;
            obj.transform.parent = this.transform;
            obj.transform.localScale = new Vector3(1, 1, 1);
            obj.transform.localPosition = new Vector3(0, -i * .5f, 0);
            i++;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
