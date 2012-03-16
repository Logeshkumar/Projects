using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;
using System.IO;
using System.Xml.Linq;
using System.ServiceModel.Activation;
using Final.Models;
using Final.Controllers;
using System.Web.Mvc;

namespace Final
{

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WcfService" in code, svc and config file together.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WcfService : IWcfService
    {
            
        FinalClassDataContext ent = new FinalClassDataContext();
       public bool Create(DataMembers obj)
        {

            StatusReport StatusTable = new StatusReport();
            StatusTable.StatusText = obj.Text;
            StatusTable.StatusTitle = obj.Title;
            StatusTable.WorkPacRefId = obj.WorkPacId;
            StatusTable.StatusDate = obj.Date;
            var _req = from req in ent.WorkPacRefs
            select req;
            foreach (WorkPacRef w in _req)
            {
                if (obj.WorkPacId == w.WorkPacRefId)
                {
                    ent.StatusReports.InsertOnSubmit(StatusTable);
                    ent.SubmitChanges();
                    return true;
                }
                else
                {
                   
                }
            }
            return false;
         }

        
        public bool IsUserValid(string UserName, string Password)   // pass this username and password from WPF (when WPF call this service method on WPF login button click)
            {
            IMembershipService MembershipService = new AccountMembershipService();
 
            if(MembershipService.ValidateUser(UserName, Password))
                {
              //user is authenticate
                    return true;
                }     
                    else
                    {
                    return false;
              // not authenticated
                }
            }

        public void CreateBug(DataMembers obj)
        {
            HttpContext context = HttpContext.Current;
            string virtPath = HttpContext.Current.Server.MapPath(".");
            string path = virtPath + "\\App_Data\\" + "XMLFile1.xml";

            XDocument xdoc = XDocument.Load(path);
            XElement BugElement = new XElement("Bug");
            XElement BugWorkPack = new XElement("BugWorkPack");
            BugWorkPack.Value = obj.Worpackage;
            XElement BugTitle = new XElement("BugTitle");
            BugTitle.Value = obj.Title;
            XElement BugDate = new XElement("BugDate");
            BugDate.Value = obj.Date.ToString();
            XElement BugIssue = new XElement("BugIssue");
            BugIssue.Value = obj.Text;
            XElement BugResolution = new XElement("BugResolution");
            BugResolution.Value = obj.Resolution;
            Guid Id = Guid.NewGuid();
            XElement BugId = new XElement("BugId");
            BugId.Value = Convert.ToString(Id);
            BugElement.Add(BugId);
            BugElement.Add(BugWorkPack);
            BugElement.Add(BugTitle);
            BugElement.Add(BugDate);
            BugElement.Add(BugIssue);
            BugElement.Add(BugResolution);
            xdoc.Element("BugReport").Add(BugElement);
            xdoc.Save(path);
        }


        public StatusDisp disp()
        {
            StatusDisp temp = new StatusDisp();
            var _req = from req in ent.StatusReports
                       select req;
            foreach (StatusReport p in _req)
            {
                DataMembers pp = new DataMembers();
                pp.Date = p.StatusDate;
                pp.Text = p.StatusText;
                pp.Title = p.StatusTitle;
                pp.WorkPacId = p.WorkPacRefId;
                pp.Id = p.StatusId;
                temp.report.Add(pp);
            }

            return temp;
        }


        public DataMembers Edit(int Id)
        {
            StatusReport StatusTable = new StatusReport();
            DataMembers data = new DataMembers();
            var _edit = from req in ent.StatusReports
                        where req.StatusId == Id
                        select req;

            data.Title = _edit.First().StatusTitle;
            data.Text = _edit.First().StatusText;
            data.Date = _edit.First().StatusDate;
            data.WorkPacId = _edit.First().WorkPacRefId;
            return data;

        }



       public void saveEdit(DataMembers obj)
        {
            var edit = ent.StatusReports.Single(c => c.StatusId == obj.Id);

            edit.StatusTitle = obj.Title;
            edit.StatusText = obj.Text;
            edit.StatusDate = obj.Date;
            edit.WorkPacRefId = obj.WorkPacId;
            ent.SubmitChanges();
        }



        public void Delete(int Id)
        {
            var _del = ent.StatusReports.SingleOrDefault(c => c.StatusId == Id);
            ent.StatusReports.DeleteOnSubmit(_del);
            ent.SubmitChanges();
        }


        public List<DataMembers> LoadStatusId()
        {

            List<DataMembers> list = new List<DataMembers>();
            var query = from row in ent.StatusReports
                        select new DataMembers
                        {
                            Id = row.StatusId

                        };
            foreach (var q in query)
            {
                DataMembers data = new DataMembers();
                data.Id = q.Id;
                list.Add(data);
            }
            return list;

        }


        public List<DataMembers> LoadWorkPackId()
        {

            List<DataMembers> list = new List<DataMembers>();
            var query = from row in ent.WorkPacRefs
                        select new DataMembers
                        {
                            Id = row.WorkPacRefId

                        };
            foreach (var q in query)
            {
                DataMembers data = new DataMembers();
                data.Id = q.Id;
                list.Add(data);
            }
            return list;
        }


        public List<string> LoadBugId()
        {
             BugReport bug = new BugReport();
            List<string> list = new List<string>();
            try
            {
                HttpContext context = HttpContext.Current;
                string Path = context.Server.MapPath("~\\App_Data\\XMLFile1.xml");

                XDocument doc = XDocument.Load(Path);
                var query = from row in doc.Elements("BugReport").Elements("Bug") select row;
                foreach (var elem in query)
                {
                    bug.BugId = elem.Element("BugId").Value;
                   list.Add(bug.BugId);
                }
                    
            }
            catch (Exception)
            {
                return null;
            }
            return list;
        }

        public DataMembers BugEditing(string id)
        {
            DataMembers bug = new DataMembers();
            try
            {

                HttpContext context = HttpContext.Current;
                string path = context.Server.MapPath("~\\App_Data\\XMLFile1.xml");

                XDocument doc = XDocument.Load(path);
                var query = from row in doc.Elements("BugReport").Elements("Bug") select row;
                foreach (var elem in query)
                {
                    string i = elem.Element("BugId").Value;
                    bug.bugid = i;
                    if (bug.bugid == id)
                    {

                        bug.Worpackage = elem.Element("BugWorkPack").Value;
                        bug.Title = elem.Element("BugTitle").Value;
                        bug.Date = Convert.ToDateTime(elem.Element("BugDate").Value);
                        bug.Text = elem.Element("BugIssue").Value;
                        bug.Resolution = elem.Element("BugResolution").Value;
                        }
                }

            }
            catch (Exception) 
            {
                return null;
            }
            return bug;
        }

        public void BugEditSave(DataMembers obj)
        {
             DataMembers bug = new DataMembers();
             try
             {
                 HttpContext context = HttpContext.Current;
                 string path = context.Server.MapPath("~\\App_Data\\XMLFile1.xml");

                 XDocument doc = XDocument.Load(path);
                 var query = from row in doc.Elements("BugReport").Elements("Bug") select row;
                 foreach (var q in query)
                 {
                     bug.bugid = q.Element("BugId").Value;
                     if (bug.bugid == obj.bugid)
                     {

                         q.SetElementValue("BugWorkPack", obj.Worpackage);
                         q.SetElementValue("BugTitle", obj.Title);
                         q.SetElementValue("BugDate", obj.Date);
                         q.SetElementValue("BugIssue", obj.Text);
                         q.SetElementValue("BugResolution", obj.Resolution);

                     }
                     doc.Save(path);
                 }
             }
            catch(Exception)
             {
                 
             }

        }
        
        public void Getxml()
        {
            // string file = Server.MapPath("..\\");
        }
    }

}
