public interface IHighlightable
{
    string StartHighlight(HighlightBehaviour highlighter);
    string StopHighlight(HighlightBehaviour highlighter);
}