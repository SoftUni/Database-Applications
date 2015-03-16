namespace NativelikeMongoDBQueries
{
    using System;

    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Log
    {
        public Log(string text, DateTime logDate)
        {
            this.Id = ObjectId.GenerateNewId().ToString();
            this.Text = text;
            this.LogDate = logDate;
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Text { get; set; }

        public DateTime LogDate { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}] {1}", this.LogDate, this.Text);
        }
    }
}
