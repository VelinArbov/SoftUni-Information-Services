namespace SIS.MVCFramework
{
    public interface IView
    {
        string GetHtml(object model);
    }
}