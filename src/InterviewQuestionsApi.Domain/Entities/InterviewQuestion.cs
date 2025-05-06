using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace InterviewQuestionsApi.Domain.Entities;

public class InterviewQuestion
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    [BsonElement("title")]
    public string Title { get; set; } = string.Empty;

    [BsonElement("description")]
    public string Description { get; set; } = string.Empty;

    [BsonElement("tags")]
    public List<string> Tags { get; set; } = new();
}