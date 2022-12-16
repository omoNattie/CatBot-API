using MongoDB.Bson.Serialization.Attributes;

namespace ServerSide.Source.Models;

[BsonIgnoreExtraElements]
public class UserModel
{
    public ulong DiscordID { get; set; }
    public long PatAmount { get; set; }
    public int MaxPats { get; set; }
    public int MinPats { get; set; }

    public bool IsCooldown { get; set; }
    public int TimeLeft { get; set; }
}