using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public int[,] shopItems = new int[5,5];
    public Text GoldText;
    public int gold;
    int attackQuantity;
    int speedQuantity;
    int healtQuantity;
    int arrowQuantity;
    PlayerStats stats;
    [SerializeField] Text damageText;
    [SerializeField] Text speedText;
    [SerializeField] Text healtText;    
    [SerializeField] Text arrowText;
    [SerializeField] int attackDamagePlus = 50;
    [SerializeField] float movementSpeedPlus = 0.5f;
    [SerializeField] int healtPlus = 30;
    [SerializeField] int arrowPlus = 1;

    [SerializeField] GameObject damageVFX;
    [SerializeField] GameObject speedVFX;
    [SerializeField] GameObject healtVFX;
    [SerializeField] GameObject arrowVFX;
    [SerializeField] GameObject archerPosition;
    string Language;

    void Start()
    {        
        Language = SaveGame.ReadSelectedLanguage();
        stats = PlayerStats.instance;
        gold = SaveGame.ReadGold();
        GoldText.text = "X " + SaveGame.ReadGold().ToString();

        if(Language == "English")
        {
            if (SaveGame.ReadAttackDamage() == 1)
            {
                damageText.text = "Attack: " + SaveGame.ReadAttackDamage();
            }
            else
            {
                damageText.text = "Attack: " + stats.attackDamage.ToString();
            }
            if (SaveGame.ReadMovementSpeed() == 1)
            {
                speedText.text = "Speed: " + SaveGame.ReadMovementSpeed();
            }
            else
            {
                speedText.text = "Speed: " + stats.movementSpeed.ToString();
            }
            if (SaveGame.ReadHealt() == 1)
            {
                healtText.text = "Healt: " + SaveGame.ReadHealt();
            }
            else
            {
                healtText.text = "Healt: " + stats.maxHealt.ToString();
            }
            if (SaveGame.ReadNumberOfArrows() == 1)
            {
                arrowText.text = "Arrow: " + SaveGame.ReadNumberOfArrows();
            }
            else
            {
                arrowText.text = "Arrow: " + stats.maxArrow.ToString();
            }
        }
        else if (Language == "Turkish")
        {
            if (SaveGame.ReadAttackDamage() == 1)
            {
                damageText.text = "Hasar: " + SaveGame.ReadAttackDamage();
            }
            else
            {
                damageText.text = "Hasar: " + stats.attackDamage.ToString();
            }
            if (SaveGame.ReadMovementSpeed() == 1)
            {
                speedText.text = "Yurume Hızı: " + SaveGame.ReadMovementSpeed();
            }
            else
            {
                speedText.text = "Yurume Hızı: " + stats.movementSpeed.ToString();
            }
            if (SaveGame.ReadHealt() == 1)
            {
                healtText.text = "Saglık: " + SaveGame.ReadHealt();
            }
            else
            {
                healtText.text = "Saglık: " + stats.maxHealt.ToString();
            }
            if (SaveGame.ReadNumberOfArrows() == 1)
            {
                arrowText.text = "Ok Sayısı: " + SaveGame.ReadNumberOfArrows();
            }
            else
            {
                arrowText.text = "Ok Sayısı: " + stats.maxArrow.ToString();
            }
        }
        else if (Language == "Russian")
        {
            if (SaveGame.ReadAttackDamage() == 1)
            {
                damageText.text = "Повреждать: " + SaveGame.ReadAttackDamage();
            }
            else
            {
                damageText.text = "Повреждать: " + stats.attackDamage.ToString();
            }
            if (SaveGame.ReadMovementSpeed() == 1)
            {
                speedText.text = "Скорость: " + SaveGame.ReadMovementSpeed();
            }
            else
            {
                speedText.text = "Скорость: " + stats.movementSpeed.ToString();
            }
            if (SaveGame.ReadHealt() == 1)
            {
                healtText.text = "Здоровье: " + SaveGame.ReadHealt();
            }
            else
            {
                healtText.text = "Здоровье: " + stats.maxHealt.ToString();
            }
            if (SaveGame.ReadNumberOfArrows() == 1)
            {
                arrowText.text = "Стрела: " + SaveGame.ReadNumberOfArrows();
            }
            else
            {
                arrowText.text = "Стрела: " + stats.maxArrow.ToString();
            }
        }
        else if (Language == "Germany")
        {
            if (SaveGame.ReadAttackDamage() == 1)
            {
                damageText.text = "Beschädigung: " + SaveGame.ReadAttackDamage();
            }
            else
            {
                damageText.text = "Beschädigung: " + stats.attackDamage.ToString();
            }
            if (SaveGame.ReadMovementSpeed() == 1)
            {
                speedText.text = "Geschwindigkeit: " + SaveGame.ReadMovementSpeed();
            }
            else
            {
                speedText.text = "Geschwindigkeit: " + stats.movementSpeed.ToString();
            }
            if (SaveGame.ReadHealt() == 1)
            {
                healtText.text = "Gesundheit: " + SaveGame.ReadHealt();
            }
            else
            {
                healtText.text = "Gesundheit: " + stats.maxHealt.ToString();
            }
            if (SaveGame.ReadNumberOfArrows() == 1)
            {
                arrowText.text = "Pfeil: " + SaveGame.ReadNumberOfArrows();
            }
            else
            {
                arrowText.text = "Pfeil: " + stats.maxArrow.ToString();
            }
        }
        else
        {
            if (SaveGame.ReadAttackDamage() == 1)
            {
                damageText.text = "Attack: " + SaveGame.ReadAttackDamage();
            }
            else
            {
                damageText.text = "Attack: " + stats.attackDamage.ToString();
            }
            if (SaveGame.ReadMovementSpeed() == 1)
            {
                speedText.text = "Speed: " + SaveGame.ReadMovementSpeed();
            }
            else
            {
                speedText.text = "Speed: " + stats.movementSpeed.ToString();
            }
            if (SaveGame.ReadHealt() == 1)
            {
                healtText.text = "Healt: " + SaveGame.ReadHealt();
            }
            else
            {
                healtText.text = "Healt: " + stats.maxHealt.ToString();
            }
            if (SaveGame.ReadNumberOfArrows() == 1)
            {
                arrowText.text = "Arrow: " + SaveGame.ReadNumberOfArrows();
            }
            else
            {
                arrowText.text = "Arrow: " + stats.maxArrow.ToString();
            }
        }

        if (SaveGame.HaveASaveAttackQuantity() == true)
        {
            attackQuantity = SaveGame.ReadAttackQuantity();
        }
        else
        {
            attackQuantity = 0;
        }

        if (SaveGame.HaveASaveSpeedQuantity() == true)
        {
            speedQuantity = SaveGame.ReadSpeedQuantity();
        }
        else
        {
            speedQuantity = 0;
        }

        if (SaveGame.HaveASaveHealtQuantity() == true)
        {
            healtQuantity = SaveGame.ReadHealtQuantity();
        }
        else
        {
            healtQuantity = 0;
        }

        if (SaveGame.HaveASaveArrowQuantity() == true)
        {
            arrowQuantity = SaveGame.ReadArrowQuantity();
        }
        else
        {
            arrowQuantity = 0;
        }

        //ID
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;

        //Price
        shopItems[2, 1] = (int)(15 * Mathf.Pow(1.37f, attackQuantity));
        shopItems[2, 2] = (int)(50 * Mathf.Pow(1.4f, speedQuantity));
        shopItems[2, 3] = (int)(40 * Mathf.Pow(1.38f, healtQuantity));
        shopItems[2, 4] = (int)(2500 * (int)Mathf.Pow(4, arrowQuantity));

        //Quantity
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;
        shopItems[3, 4] = 0;      
    }

    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        Vector2 VFXposition = archerPosition.transform.position;
        VFXposition.x = archerPosition.transform.position.x - 0.2f;
        VFXposition.y = archerPosition.transform.position.y - 2.5f;

        if (SaveGame.ReadGold() >= shopItems[2, ButtonRef.GetComponent<Shop>().ItemID])
        {
            gold -= shopItems[2, ButtonRef.GetComponent<Shop>().ItemID];
            shopItems[3, ButtonRef.GetComponent<Shop>().ItemID]++;
            GoldText.text = "X " + gold.ToString();
            SaveGame.SaveGold(gold);
            ButtonRef.GetComponent<Shop>().QuantityText.text = shopItems[3, ButtonRef.GetComponent<Shop>().ItemID].ToString();
            if (ButtonRef.GetComponent<Shop>().ItemID == 1)
            {
                UpgradeAttackDamage();
                SaveGame.SaveAttackDamage(stats.attackDamage);
                attackQuantity++;
                SaveGame.SaveAttackQuantity(attackQuantity);
                GameObject VFX = Instantiate(damageVFX, VFXposition, Quaternion.Euler(270,0,0));
            }
            if (ButtonRef.GetComponent<Shop>().ItemID == 2)
            {
                UpgradeMovementSpeed();
                SaveGame.SaveMovementSpeed(stats.movementSpeed);
                speedQuantity++;
                SaveGame.SaveSpeedQuantity(speedQuantity);
                GameObject VFX = Instantiate(speedVFX, VFXposition, Quaternion.Euler(270, 0, 0));
            }
            if (ButtonRef.GetComponent<Shop>().ItemID == 3)
            {
                UpgradeHealt();
                SaveGame.SaveHealt(stats.maxHealt);
                healtQuantity++;
                SaveGame.SaveHealtQuantity(healtQuantity);
                GameObject VFX = Instantiate(healtVFX, VFXposition, Quaternion.Euler(270, 0, 0));
            }
            if (ButtonRef.GetComponent<Shop>().ItemID == 4)
            {
                UpgradeArrow();
                SaveGame.SaveNumberOfArrows(stats.maxArrow);
                arrowQuantity++;
                SaveGame.SaveArrowQuantity(arrowQuantity);
                GameObject VFX = Instantiate(arrowVFX, VFXposition, Quaternion.Euler(270, 0, 0));
            }

            shopItems[2, 1] = (int)(15 * Mathf.Pow(1.37f, attackQuantity));
            shopItems[2, 2] = (int)(50 * Mathf.Pow(1.4f, speedQuantity));
            shopItems[2, 3] = (int)(40 * Mathf.Pow(1.38f, healtQuantity));
            shopItems[2, 4] = (int)(2500 * (int)Mathf.Pow(4, arrowQuantity));
        }        
    }

    void UpdateValues()
    {        
        if (Language == "English")
        {
            damageText.text = "Attack: " + stats.attackDamage.ToString();
            speedText.text = "Speed: " + stats.movementSpeed.ToString();
            healtText.text = "Healt: " + stats.maxHealt.ToString();
            arrowText.text = "Arrow: " + stats.maxArrow.ToString();
        }
        else if (Language == "Turkish")
        {
            damageText.text = "Hasar: " + stats.attackDamage.ToString();
            speedText.text = "Yurume Hızı: " + stats.movementSpeed.ToString();
            healtText.text = "Saglık: " + stats.maxHealt.ToString();
            arrowText.text = "Ok Sayısı: " + stats.maxArrow.ToString();
        }
        else if (Language == "Russian")
        {
            damageText.text = "Повреждать: " + stats.attackDamage.ToString();
            speedText.text = "Скорость: " + stats.movementSpeed.ToString();
            healtText.text = "Здоровье: " + stats.maxHealt.ToString();
            arrowText.text = "Стрела: " + stats.maxArrow.ToString();
        }
        else if (Language == "Germany")
        {
            damageText.text = "Beschädigung: " + stats.attackDamage.ToString();
            speedText.text = "Geschwindigkeit: " + stats.movementSpeed.ToString();
            healtText.text = "Gesundheit: " + stats.maxHealt.ToString();
            arrowText.text = "Pfeil: " + stats.maxArrow.ToString();
        }
        else
        {
            damageText.text = "Attack: " + stats.attackDamage.ToString();
            speedText.text = "Speed: " + stats.movementSpeed.ToString();
            healtText.text = "Healt: " + stats.maxHealt.ToString();
            arrowText.text = "Arrow: " + stats.maxArrow.ToString();
        }
    }
    public void UpgradeAttackDamage()
    {
        stats.attackDamage += attackDamagePlus;        
        UpdateValues();
    }
    public void UpgradeMovementSpeed()
    {
        stats.movementSpeed += movementSpeedPlus;
        UpdateValues();
    }

    public void UpgradeHealt()
    {
        stats.maxHealt += healtPlus;
        UpdateValues();
    }
    public void UpgradeArrow()
    {
        stats.maxArrow += arrowPlus;
        UpdateValues();
    }
}
