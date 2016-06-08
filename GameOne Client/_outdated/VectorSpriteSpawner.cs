/*
using UnityEngine;
using System.Collections;

// Remember to set sprite pivot to the left!

public class VectorSpriteSpawner : MonoBehaviour {

    public Vector2 SourcePos;
    public Vector2 DestinationPos;

    public GameObject Sprite;
    public int PixWidth;
    public int PixPerUnit;

    private GameObject _instance;

	void Start () 
    {

        DrawSprite();
	}
	


	void DrawSprite()
    {
        // Instantiate in a right place with the right rotation
        var _position = new Vector3(SourcePos.x, SourcePos.y, 0f);
        var _rotation = Quaternion.Euler(0f, 0f, CalculateAngle(SourcePos, DestinationPos));
        _instance = Instantiate(Sprite, _position, _rotation) as GameObject;


        // Scale
        float scaleNumber = CalculateScale(SourcePos, DestinationPos, PixPerUnit, PixWidth);
        var _scale = new Vector3(scaleNumber, scaleNumber, 0);

        _instance.transform.localScale = _scale;
    }

    float CalculateAngle(Vector2 start, Vector2 end)
    {
        Vector2 difference = DestinationPos - SourcePos;
        difference.Normalize();
        float rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;

        return rotZ;
    }

    float CalculateScale(Vector2 start, Vector2 end, int pixPerUnit, int pixWidth)
    {
        var difference = SourcePos - DestinationPos;
        float vectorLength = difference.magnitude;

        float scaleNumber = vectorLength * PixPerUnit / PixWidth;

        return scaleNumber;
    }
}
*/