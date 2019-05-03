using AngleSharp.Html;
using AngleSharp.Html.Parser;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IksmClientDotNet.ConsoleApp.Services
{
    public class RecentBattleResultHtmlEditor
    {
        readonly string htmlPath;
        List<(string text, string cssClass)> data = new List<(string text, string cssClass)>();

        public RecentBattleResultHtmlEditor(string htmlPath)
        {
            this.htmlPath = htmlPath;
        }

        public void AddText(string text, string cssClass)
        {
            data.Add((text, cssClass));
        }

        public void Flush()
        {
            var html = File.ReadAllText(htmlPath);
            var htmlParser = new HtmlParser();
            var htmlDocument = htmlParser.ParseDocument(html);

            var children = htmlDocument.Body.ChildNodes.ToArray();
            foreach (var child in children)
            {
                htmlDocument.Body.RemoveChild(child);
            }

            var header = htmlDocument.CreateElement("span");
            header.TextContent = "直近の戦績";
            htmlDocument.Body.AppendChild(header);
            htmlDocument.Body.AppendChild(htmlDocument.CreateElement("br"));

            var notifiy = htmlDocument.CreateElement("span");
            notifiy.TextContent = "(5分毎に自動更新)";
            notifiy.ClassList.Add("note");
            htmlDocument.Body.AppendChild(notifiy);
            htmlDocument.Body.AppendChild(htmlDocument.CreateElement("br"));

            foreach (var (text, cssClass) in data)
            {
                var item = htmlDocument.CreateElement("span");
                item.TextContent = text;
                item.ClassList.Add(cssClass);
                htmlDocument.Body.AppendChild(item);

                htmlDocument.Body.AppendChild(htmlDocument.CreateElement("br"));
            }

            using (var textWriter = new StringWriter())
            {
                var formatter = new PrettyMarkupFormatter();
                htmlDocument.ToHtml(textWriter, formatter);

                File.WriteAllText(htmlPath, textWriter.ToString());
            }
        }
    }
}
