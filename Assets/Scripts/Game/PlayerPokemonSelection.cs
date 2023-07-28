using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPokemonSelection : MonoBehaviour
{
    private const string PLAYER_POKEMON_KEY = "PlayerPokemon";

    // Array para armazenar os Pok�mon do jogador
    private Pokemon[] playerPokemon;

    // M�todo para adicionar um novo Pok�mon � Pok�dex do jogador
    public void AddPokemon(string pokemonName, int level, int type, int weakness, Sprite image)
    {
        Pokemon newPokemon = new Pokemon
        {
            nickName = pokemonName,
            level = level,
            type = type,
            weakness = weakness,
            image = image
        };

        List<Pokemon> pokemonList = new List<Pokemon>(playerPokemon);
        pokemonList.Add(newPokemon);
        playerPokemon = pokemonList.ToArray();

        SavePlayerPokemon();
    }

    public void RemovePokemon(string pokemonName)
    {
        List<Pokemon> pokemonList = new List<Pokemon>(playerPokemon);
        Pokemon pokemonToRemove = pokemonList.Find(pokemon => pokemon.nickName == pokemonName);
        if (pokemonToRemove != null)
        {
            pokemonList.Remove(pokemonToRemove);
            playerPokemon = pokemonList.ToArray();

            SavePlayerPokemon();
        }
    }

    public Pokemon[] GetPlayerPokemon()
    {
        return playerPokemon;
    }

    private void LoadPlayerPokemon()
    {
        if (PlayerPrefs.HasKey(PLAYER_POKEMON_KEY))
        {
            string json = PlayerPrefs.GetString(PLAYER_POKEMON_KEY);
            playerPokemon = JsonUtility.FromJson<Pokemon[]>(json);
        }
        else
        {
            playerPokemon = new Pokemon[0]; // Se n�o houver nenhum array salvo, inicialize um array vazio.
        }
    }

    // M�todo para salvar o array de Pok�mon do jogador
    private void SavePlayerPokemon()
    {
        string json = JsonUtility.ToJson(playerPokemon);
        PlayerPrefs.SetString(PLAYER_POKEMON_KEY, json);
    }

    private void Awake()
    {
        LoadPlayerPokemon();
    }
}
