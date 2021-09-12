using System;
using TMPro;
using UnityEngine;

public class ValueFetch : MonoBehaviour
{
    private CSVReader csvReader;
    [SerializeField] private TMP_InputField fetchDestination;

    public string column;

    private void Awake()
    {
        csvReader = FindObjectOfType<CSVReader>();
    }

    public void LoadEntry(string entry)
    {
        fetchDestination.text = csvReader.FetchValue(entry, column);
    }
}
