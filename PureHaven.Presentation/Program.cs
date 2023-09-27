using Microsoft.EntityFrameworkCore.Query;
using PureHaven.Presentation.UI;

namespace PureHaven.Presentation;
public class Program
{
    static void Main(string[] args)
    {
        var uI = new UIPresentation();
        uI.print();
    }
}