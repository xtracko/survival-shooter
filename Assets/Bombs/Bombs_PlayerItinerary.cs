using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bombs_PlayerItinerary : MonoBehaviour
{
    public float decoyProbability = 0.1f;
    public float explosiveProbability = 0.2f;

    public Text decoyIndicator;
    public Text explossiveIndicator;
    public GameObject decoyBomb;
    public GameObject explossiveBomb;
    private enum Type
    {
        None, Decoy, Explossive
    }

    private Type bomb = Type.None;

    private void Awake()
    {
        UpdateIndicators();
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DropBomb();
        }
    }

    private void DropBomb()
    {
        Vector3 position = transform.TransformPoint(new Vector3(0, 0, 1));

        switch (bomb)
        {
            case Type.Decoy:
                Instantiate(decoyBomb, position, Quaternion.Euler(90, 0, 0));
                break;
            case Type.Explossive:
                Instantiate(explossiveBomb, position, Quaternion.Euler(90, 0, 0));
                break;
        }

        bomb = Type.None;
        UpdateIndicators();
    }

    private void UpdateIndicators()
    {
        Color gray = new Color(0.33f, 0.33f, 0.33f);
        Color yellow = new Color(1f, 0.69f, 0f);
        Color green = new Color(0.31f, 1f, 0f);

        decoyIndicator.color = (bomb == Type.Decoy) ? yellow : gray;
        explossiveIndicator.color = (bomb == Type.Explossive) ? green : gray;
    }

    public void GenerateBomb()
    {
        float sample = Random.value;

        bool decoy = (0 <= sample && sample <= decoyProbability);
        bool explossive = (decoyProbability <= sample && sample <= decoyProbability + explosiveProbability);

        if (decoy && !explossive)
        {
            bomb = Type.Decoy;
        }
        if (explossive && !decoy)
        {
            bomb = Type.Explossive;
        }

        UpdateIndicators();
    }

}
