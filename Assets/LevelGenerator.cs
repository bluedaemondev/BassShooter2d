using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//watafac
public class LevelGenerator : MonoBehaviour
{
    public List<GameObject> templates;

    // desde el editor me cargo una lista de templates de chunk
    // cuando las instancie, existe una posibilidad de que dejen de aparecer alta.
    // considerando que no tengo mucho mas tiempo para hacer level design
    // despues de instanciar todas, van a haber desaparecido de la lista.
    // asi que ahi meto un template de fin de nivel, que va a ser una meta
    // puedo ver si hago un cronometro, para darle algo mas de enfacis a la mecanica esa de caida
    // que se yo, siempre hago el mismo tipo de juego cuando trabajo apurado y me quemo
    // pero este lo termino


    public float randChanceS = 0.41328907146723f; //estoy pensando como hacer gen aleatoria sencilla
    public float randChanceR = 0.07138917468182f; //estoy pensando como hacer gen aleatoria sencilla

    public bool run;

    public int countTotal;

    public float distanceBetweenTemplatesY = 20;

    GameObject[] copia;



    // Start is called before the first frame update
    void Start()
    {
        if (templates != null)
        {
            run = true;
            countTotal = templates.Count;
            templates.CopyTo(copia);
        }//cualquiera jajaxd
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!run)
            return;

        
        for(int iMainTemplate = 0; iMainTemplate < countTotal; iMainTemplate++)
        {
            int seed = Mathf.FloorToInt(randChanceS + randChanceR);
            
            for (int xChanceRemove = seed; xChanceRemove > 0; xChanceRemove--)
            {
                float randChanceToDelete = Random.Range(0, xChanceRemove);
                float punteroDeRuleta = Random.Range(0, 100f);
                
                if(punteroDeRuleta + 1 > randChanceToDelete - 1 && punteroDeRuleta - 1 < randChanceToDelete + 1) //wtf jajaja
                {
                    var pos = transform.position;
                    pos.y -= distanceBetweenTemplatesY;

                    if (templates.Contains(copia[iMainTemplate])) { 
                    
                        GameObject goTemp = Instantiate(copia[iMainTemplate], pos, Quaternion.identity, GameInfo.instance.layoutContainer);
                        templates.Remove(copia[iMainTemplate]);
                        //exactamente
                        //que verga todo igual

                        goTemp.GetComponent<DestroyAfterTime>().enabled = true;

                    }
                }
            }
        }

    }
}
