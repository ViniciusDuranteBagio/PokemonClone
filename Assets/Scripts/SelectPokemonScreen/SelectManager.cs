using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    private const int SQUIRTLE = 0;
    private const int BULBASAUR = 1;
    private const int CHARMANDER = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectInitialPokemon(int InitalPokemonNumber)
    {
        if (InitalPokemonNumber == SQUIRTLE)
        {
            Debug.Log("SQUIRTLE");
        }

        if (InitalPokemonNumber == BULBASAUR)
        {
            Debug.Log("BULBASAUR");
        }

        if (InitalPokemonNumber == CHARMANDER)
        {
            Debug.Log("CHARMANDER");
        }

    }
}
