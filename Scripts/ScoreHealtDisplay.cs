using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHealtDisplay : MonoBehaviour
{
    [SerializeField] Text goldText;
    [SerializeField] Text healtText;
    WallProperties wallHealt;

    // Start is called before the first frame update
    void Start()
    {
        wallHealt = FindObjectOfType<WallProperties>();
        goldText.text = SaveGame.ReadGold().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        GoldDisplay();
        HealtDisplay();
    }

    private void HealtDisplay()
    {
        healtText.text = wallHealt.GetHealt().ToString();
    }

    private void GoldDisplay()
    {
        goldText.text = " X " + SaveGame.ReadGold().ToString();
    }
}
