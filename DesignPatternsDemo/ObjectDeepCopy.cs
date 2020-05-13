using Newtonsoft.Json;

namespace DesignPatternsDemo
{
    public class PlayerData
    {
        public int PlayerNumber { get; set; }
        public string PlayerName { get; set; }

        public PlayPosition Position { get; set; }
    }

    public enum PlayPosition
    {
        ATTACK,
        MID,
        DEFENCE
    }

    internal interface IDeepCopy
    {
        public T DeepCopy<T>(T source);
    }

    public class PlayerDataCopier : IDeepCopy
    {
        public T DeepCopy<T>(T source)
        {
            var copiedObject = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source));
            return copiedObject;
        }
    }
}