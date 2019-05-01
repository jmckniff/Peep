namespace Peep.Domain.ValueObjects
{
    public class MediaRelativeUrl
    {
        public string Value { get; }

        public MediaRelativeUrl(string relativeUrl)
        {
            Value = relativeUrl;
        }
    }
}
