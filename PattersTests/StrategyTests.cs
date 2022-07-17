using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Patterns.Strategy.Dynamic.DynamicStrategy;
using static Patterns.Strategy.Static.StaticStrategy;

namespace PattersTests
{
    [TestFixture]
    public class StrategyTests
    {
        [Test]
        public void DynamicStrategyTest()
        {
            var tp = new TextProcessor();
            tp.SetOutputFormat(Patterns.Strategy.Dynamic.DynamicStrategy.OutputFormat.Markdown);
            tp.AppendList(new[] { "foo", "bar", "baz" });
            Assert.That(tp.ToString(), Is.EqualTo(" * foo\r\n * bar\r\n * baz\r\n"));

            tp.Clear();
            tp.SetOutputFormat(Patterns.Strategy.Dynamic.DynamicStrategy.OutputFormat.Html);
            tp.AppendList(new[] { "foo", "bar", "baz" });
            Assert.That(tp.ToString(), Is.EqualTo("<ul>\r\n  <li>foo</li>\r\n  <li>bar</li>\r\n  <li>baz</li>\r\n</ul>\r\n"));
        }

        [Test]
        public void StaticStrategyTest()
        {
            var tp = new TextProcessor<Patterns.Strategy.Static.StaticStrategy.MarkdownListStrategy>();
            tp.AppendList(new[] { "foo", "bar", "baz" });
            Assert.That(tp.ToString(), Is.EqualTo(" * foo\r\n * bar\r\n * baz\r\n"));

            var tp2 = new TextProcessor<Patterns.Strategy.Static.StaticStrategy.HtmlListStrategy>();
            tp2.AppendList(new[] { "foo", "bar", "baz" });
            Assert.That(tp.ToString(), Is.EqualTo(" * foo\r\n * bar\r\n * baz\r\n"));
        }
    }
}
