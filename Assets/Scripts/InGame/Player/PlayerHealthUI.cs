using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private GameObject prefabHealth;

    private GameObject parent;

    public List<GameObject> objectsHealth = new List<GameObject>();

    private float shift = 140f;

    private void Start()
    {
        parent = GameObject.FindGameObjectWithTag("ui_HealthBar");
    }

    public void InitUI(int maxHealth, int currentHealth)
    {
        for(int i = 0; i < maxHealth; i++)
        {
            GameObject obj = Instantiate(prefabHealth, parent.transform, false);
            Vector3 pos = obj.transform.localPosition;
            obj.transform.localPosition = new Vector3(pos.x - i * shift, pos.y, pos.z);
            objectsHealth.Add(obj);
        }

        UpdateUI(currentHealth);
    }

    public void UpdateUI(int health)
    {
        for(int i = 0; i < objectsHealth.Count; i++)
        {
            objectsHealth[i].SetActive(i < health);
        }
    }
}
