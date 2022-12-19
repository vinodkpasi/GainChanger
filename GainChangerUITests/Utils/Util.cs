using Newtonsoft.Json;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GainChangerUITests.Utils
{
   public static class Util
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static log4net.ILog Log { get { return log; } }

        public static List<string> GetAllElementsText(IList<IWebElement> element)
        {
            List<string> text = new List<string>();
            foreach (var item in element)
                text.Add(item.Text);
            return text;
        }

        public static void ExportInJsonFile(object entity, string filePath)
        {
            string json = JsonConvert.SerializeObject(entity);
            File.WriteAllText(filePath, json);
        }
    }
}
