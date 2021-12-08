using System;
using System.Collections;
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

    public void LoadEntry()
    {
        StartCoroutine(WaitAndLoadEntry());
    }

    IEnumerator WaitAndLoadEntry()
    {
        float _timeOut = Time.time + 10f;
        while (csvReader.loadingLock)// && Time.time < _timeOut)
        {
            yield return null;
        }
        fetchDestination.text = csvReader.FetchValue(column);
    }
}
