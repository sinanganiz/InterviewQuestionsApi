using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace InterviewQuestionsApi.Domain.Entities;

public class InterviewQuestion
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;

    [BsonElement("question")]
    public string Question { get; set; } = null!;

    [BsonElement("answer")]
    public string Answer { get; set; } = null!;

    [BsonElement("tags")]
    public List<string> Tags { get; set; } = new();

    [BsonElement("difficulty")]
    public string Difficulty { get; set; } = "medium";

    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}