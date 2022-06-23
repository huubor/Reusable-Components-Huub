using UnityEngine;

public class Damage2 : MonoBehaviour, IDamage
{
    [SerializeField] GameObject pPlayer;
    [SerializeField] GameObject checkpoint;

    private Values pValues;

    private void Awake()
    {
       pValues = pPlayer.GetComponent<Values>();
    }
    public void DamageThis()
    {
        pValues.playerHealt--;
        pPlayer.transform.position = checkpoint.transform.position;
    }
}
