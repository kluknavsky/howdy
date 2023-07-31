var evaluator = new GroupEvaluator("answer.json");
double groupScore = evaluator.EvaluateGroupScore(groupId: 1, month: 3, year: 2021);
Console.WriteLine($"The group score is: {groupScore}");