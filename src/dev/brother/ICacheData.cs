namespace Dade.Dms.Dev.Brother
{
    public interface ICacheData
    {
        bool Exists(string value);

        void Add(string value);

        void Flush();
    }
}
