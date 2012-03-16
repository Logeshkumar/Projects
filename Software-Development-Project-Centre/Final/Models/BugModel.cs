using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Final.Models
{
    public class Workpackstatus
    {
        public int StatusId { get; set; }
        public string StatusTitle { get; set; }
        public string StatusDate { get; set; }
        public string StatusText { get; set; }
        public string WorkPackTitle { get; set; }

    }

    public class BugReport
    {
        public string BugId { get; set; }
        public string BugWorkPacId { get; set; }
        public string BugTitle { get; set; }
        public string BugDate { get; set; }
        public string BugIssue { get; set; }
        public string BugResolution { get; set; }
    }
    public class BugModel
    {

        public List<BugReport> BugReports { get; set; }

        public BugModel()
        {
            BugReports = new List<BugReport>();
        }

        public IEnumerable<BugReport> Fill(string path)
        {
            try
            {
                XDocument doc = XDocument.Load(path);
                var query = from row in doc.Elements("BugReport").Elements("Bug") select row;
                foreach (var ent in query)
                {
                    BugReport bug = new BugReport();
                    bug.BugId = ent.Element("BugId").Value.ToString();
                    bug.BugWorkPacId = ent.Element("BugWorkPack").Value.ToString();
                    bug.BugTitle = ent.Element("BugTitle").Value.ToString();
                    bug.BugDate = ent.Element("BugDate").Value.ToString();
                    bug.BugIssue = ent.Element("BugIssue").Value.ToString();
                    bug.BugResolution = ent.Element("BugResolution").Value.ToString();
                    BugReports.Add(bug);
                }
            }
            catch { return null; }
            return BugReports;
        }

        public BugReport BugDetails(string id, string file)
        {
            BugReport bug = new BugReport();
            BugReport bug1 = new BugReport();
            try
            {

                XDocument doc = XDocument.Load(file);
                var query = from row in doc.Elements("BugReport").Elements("Bug") select row;
                foreach (var q in query)
                {
                    bug.BugId = q.Element("BugId").Value.ToString();
                    if (bug.BugId == id)
                    {

                        bug1.BugId = q.Element("BugId").Value.ToString();
                        bug1.BugWorkPacId = q.Element("BugWorkPack").Value.ToString();
                        bug1.BugTitle = q.Element("BugTitle").Value.ToString();
                        bug1.BugDate = q.Element("BugDate").Value.ToString();
                        bug1.BugIssue = q.Element("BugIssue").Value.ToString();
                        bug1.BugResolution = q.Element("BugResolution").Value.ToString();

                    }

                }

            }
            catch
            {
                return null;
            }
            return bug1;
        }
    }
}