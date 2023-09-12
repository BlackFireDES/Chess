using UnityEngine;

public class Cell : MonoBehaviour
{
    public Figure Figure { get; private set; }
    public int Number { get; set; }
    public LetterNumbering Letter {get; set;}

    public void CellInit(int number, LetterNumbering letter)
    {
        Number = number;
        Letter = letter;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Figure figure))
        {
            Figure = figure;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Figure figure))
        {
            Figure = null; // ÏĞÈ ÓÄÀËÅÍÈÈ ÔÈÃÓĞÛ ÎÍÀ ÍÅ ÏÎÊÈÄÀÅÒ ÒĞÈÃÅĞ, ÏÎİÒÎÌÓ ÔÈÃÓĞÓ ÍÓÆÍÎ ÑÍÀ×ÀËÀ ÏÅĞÅÌÅÑÒÈÒÜ
        }
    }


}
