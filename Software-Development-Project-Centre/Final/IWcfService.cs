using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;
using System.IO;
using System.ServiceModel.Activation;
using Final.Models;


namespace Final
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWcfService" in both code and config file together.
    [ServiceContract]
    public interface IWcfService
    {
        
        [OperationContract]
        bool IsUserValid(string UserName, string Password);
        [OperationContract]
        bool Create(DataMembers obj);
        [OperationContract]
        void CreateBug(DataMembers obj);
        [OperationContract]
        DataMembers Edit(int Id);
        [OperationContract]
        void saveEdit(DataMembers objec);
        [OperationContract]
        void Delete(int Id);
        [OperationContract]
        void Getxml();
        [OperationContract]
        StatusDisp disp();
        [OperationContract]
        List<DataMembers> LoadStatusId();
        [OperationContract]
        List<DataMembers> LoadWorkPackId();
        [OperationContract]
        List<string> LoadBugId();
        [OperationContract]
        DataMembers BugEditing(string id);
        [OperationContract]
        void BugEditSave(DataMembers obj);
    }

    [DataContract]
    public class StatusDisp
    {
        List<DataMembers> records = new List<DataMembers>();
        public List<DataMembers> report
        {
            get { return records; }
            set { records.AddRange(value); }
        }
    }

    [DataContract]
    public class DataMembers
    {
        private string _Title;
        private string _Text;
        private DateTime _Date;
        private int _WorkPacId;
        private int _ReportedBy;
        private int _Id;
        private string _Solution;
        private string _bugid;
        private string _Worpackage;


        [DataMember]
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }

        }

        [DataMember]
        public string Resolution
        {
            get { return _Solution; }
            set { _Solution = value; }

        }

        [DataMember]
        public string Text
        {
            get { return _Text; }
            set { _Text = value; }

        }

        [DataMember]
        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }

        }

        [DataMember]
        public int ReportedBy
        {
            get { return _ReportedBy; }
            set { _ReportedBy = value; }

        }
        [DataMember]
        public int WorkPacId
        {
            get { return _WorkPacId; }
            set { _WorkPacId = value; }
        }

        [DataMember]
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        [DataMember]
        public string bugid
        {

        
        get{return _bugid;}
        set{_bugid = value;}
        }
        [DataMember]
        public string Worpackage
    {
        get{return _Worpackage;}
        set { _Worpackage = value; }
    }
    }

    }

