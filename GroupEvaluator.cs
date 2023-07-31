using Newtonsoft.Json;

/// <summary>
/// Represents a group evaluator that reads and deserializes JSON data into a list of EvaluationData objects.
/// </summary>
public class GroupEvaluator
{
    private List<EvaluationData> _data;

    /// <summary>
    /// Initializes a new instance of the GroupEvaluator class with a JSON file path.
    /// </summary>
    /// <param name="jsonFilePath"></param>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="FileNotFoundException"></exception>
    /// <exception cref="Exception"></exception>
    public GroupEvaluator(string jsonFilePath)
    {
        if (string.IsNullOrEmpty(jsonFilePath))
        {
            throw new ArgumentException("JSON file path cannot be null or empty.");
        }

        if (!File.Exists(jsonFilePath))
        {
            throw new FileNotFoundException("JSON file not found.", jsonFilePath);
        }

        try
        {
            var jsonData = File.ReadAllText(jsonFilePath);
            this._data = JsonConvert.DeserializeObject<List<EvaluationData>>(jsonData) ?? throw new Exception("Failed to deserialize the JSON data.");
        }

        catch (JsonReaderException jrex)
        {
            throw new Exception("Error reading JSON file.", jrex);
        }
        catch (JsonSerializationException jsex)
        {
            throw new Exception("Error deserializing JSON file.", jsex);
        }
        catch (Exception ex)
        {
            throw new Exception("Error deserializing JSON file.", ex);
        }
    }

    /// <summary>
    /// Evaluates the total score for a group based on individual evaluation scores.
    /// </summary>
    /// <param name="groupId"></param>
    /// <param name="month"></param>
    /// <param name="year"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public double EvaluateGroupScore(int groupId, int month, int year)
    {
        var groupData = this._data
            .Where(d => d.GroupId == groupId && d.AnsweredOn.Month == month && d.AnsweredOn.Year == year)
            .ToList();

        if (!groupData.Any())
        {
            throw new Exception("No data available for the specified group and month.");
        }

        return groupData.Average(d => d.AverageScore);
    }
}

