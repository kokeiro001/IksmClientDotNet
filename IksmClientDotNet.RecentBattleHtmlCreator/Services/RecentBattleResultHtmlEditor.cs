using AngleSharp.Html;
using AngleSharp.Html.Parser;
using System.Collections.Generic;
using System.IO;

namespace IksmClientDotNet.ConsoleApp.Services
{
    public class RecentBattleResultHtmlEditor
    {
        private readonly string outputHtmlPath;
        private readonly string baseHtmlPath;

        private List<(string text, string cssClass)> data = new List<(string text, string cssClass)>();

        public RecentBattleResultHtmlEditor(string outputHtmlPath, string baseHtmlPath)
        {
            this.outputHtmlPath = outputHtmlPath;
            this.baseHtmlPath = baseHtmlPath;
        }

        public void AddText(string text, string cssClass)
        {
            data.Add((text, cssClass));
        }

        public void Flush()
        {
            var baseHtml = File.ReadAllText(baseHtmlPath);

            var htmlParser = new HtmlParser();
            var htmlDocument = htmlParser.ParseDocument(baseHtml);

            var div = htmlDocument.QuerySelector("div");

            foreach (var (text, cssClass) in data)
            {
                var item = htmlDocument.CreateElement("span");
                item.TextContent = text;
                item.ClassList.Add(cssClass);
                div.AppendChild(item);

                div.AppendChild(htmlDocument.CreateElement("br"));
            }

            using (var textWriter = new StringWriter())
            {
                var formatter = new PrettyMarkupFormatter();
                htmlDocument.ToHtml(textWriter, formatter);

                File.WriteAllText(outputHtmlPath, textWriter.ToString());
            }
        }
    }
}
