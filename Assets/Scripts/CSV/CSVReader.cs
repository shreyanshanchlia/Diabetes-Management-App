using UnityEngine;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class CSVReader : MonoBehaviour
{
    [SerializeField] private GameObject panelDisableOnLoadingComplete; 
    [SerializeField] TextAsset csvAsset;

    [SerializeField] private StringHolder fetchResult;
    
    [SerializeField] private List<string> header;
    [SerializeField] private List<List<string>> csvData;

    private List<string> searchNames;
    private Dictionary<string, int> mapTable;
    
    void Start()
    {
         LoadCSVData();
    }

    async void LoadCSVData()
    {
        csvData = new List<List<string>>();
        mapTable = new Dictionary<string, int>();
        searchNames = new List<string>();
        string[] comma = new[] { "," };
        string[] newLine = new[] { "\n" };
        string[] newLineWithComma = new[] { ",", "\n" };
        char[] trimRegexChars = new[] { ',', ' ', '\n', '\r' };
        List<string> rows = csvAsset.text.Split(newLine, StringSplitOptions.RemoveEmptyEntries).ToList();
        
        await Task.Run(() =>
        {
            int i = -1;
            foreach (string row in rows)
            {
                csvData.Add(row.Trim(trimRegexChars).Split(newLineWithComma, StringSplitOptions.None).ToList());
                mapTable.Add(row.Split(comma, StringSplitOptions.None)[0], i);
                searchNames.Add(row.Split(comma, StringSplitOptions.None)[0].ToUpper());
                i++;
            }
        });
        header = csvData[0];
        csvData.RemoveAt(0);
        panelDisableOnLoadingComplete.SetActive(false);
    }

    private int foundRowIndex = -1;
    public bool loadingLock = true;
    public async void FetchRow(string foodName)
    {
        loadingLock = true;
        foodName = foodName.ToUpper();
        foundRowIndex = -1;
        await Task.Run(() =>
        {
            string foundFood = searchNames.FirstOrDefault(t => t.StartsWith(foodName));
            foundRowIndex = searchNames.IndexOf(foundFood);
            //|| Regex.IsMatch(t, @$"{name}.*")
        });
        if (foundRowIndex != -1)
        {
            loadingLock = false;
            fetchResult.SetString(searchNames[foundRowIndex]);
        }
    }

    public string FetchValue(string column)
    {
        int columnIndex = header.IndexOf(column);

        if (columnIndex == -1)
        {
            Debug.LogError($"Column {column} Not found");
            return "";
        }

        if (foundRowIndex <= 0) return "";
        return csvData[foundRowIndex - 1][columnIndex];
    }
}
