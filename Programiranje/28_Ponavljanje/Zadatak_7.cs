using UnityEngine;

public class Zadatak_7 : MonoBehaviour
{
    public int prviInt;
    public int drugiInt;
    public float prviFloat;
    public float drugiFloat;

    private void Update()
    {
        if(prviInt * drugiInt + prviFloat - drugiFloat * prviInt >= prviInt * drugiInt * prviFloat / drugiFloat)
        {
            transform.localScale += Vector3.one * Time.deltaTime;
            transform.Rotate(new Vector3(2, 2, 2) * Time.deltaTime);
        }
        else
        {
            transform.localScale -= new Vector3(2, 2, 2) * Time.deltaTime;
            transform.Rotate(new Vector3(1, 1, 1) * Time.deltaTime);
        }
    }
}
