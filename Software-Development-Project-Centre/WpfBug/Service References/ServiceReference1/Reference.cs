﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfBug.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DataMembers", Namespace="http://schemas.datacontract.org/2004/07/Final")]
    [System.SerializableAttribute()]
    public partial class DataMembers : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ReportedByField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ResolutionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TextField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int WorkPacIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WorpackageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string bugidField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Date {
            get {
                return this.DateField;
            }
            set {
                if ((this.DateField.Equals(value) != true)) {
                    this.DateField = value;
                    this.RaisePropertyChanged("Date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ReportedBy {
            get {
                return this.ReportedByField;
            }
            set {
                if ((this.ReportedByField.Equals(value) != true)) {
                    this.ReportedByField = value;
                    this.RaisePropertyChanged("ReportedBy");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Resolution {
            get {
                return this.ResolutionField;
            }
            set {
                if ((object.ReferenceEquals(this.ResolutionField, value) != true)) {
                    this.ResolutionField = value;
                    this.RaisePropertyChanged("Resolution");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Text {
            get {
                return this.TextField;
            }
            set {
                if ((object.ReferenceEquals(this.TextField, value) != true)) {
                    this.TextField = value;
                    this.RaisePropertyChanged("Text");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title {
            get {
                return this.TitleField;
            }
            set {
                if ((object.ReferenceEquals(this.TitleField, value) != true)) {
                    this.TitleField = value;
                    this.RaisePropertyChanged("Title");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int WorkPacId {
            get {
                return this.WorkPacIdField;
            }
            set {
                if ((this.WorkPacIdField.Equals(value) != true)) {
                    this.WorkPacIdField = value;
                    this.RaisePropertyChanged("WorkPacId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Worpackage {
            get {
                return this.WorpackageField;
            }
            set {
                if ((object.ReferenceEquals(this.WorpackageField, value) != true)) {
                    this.WorpackageField = value;
                    this.RaisePropertyChanged("Worpackage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string bugid {
            get {
                return this.bugidField;
            }
            set {
                if ((object.ReferenceEquals(this.bugidField, value) != true)) {
                    this.bugidField = value;
                    this.RaisePropertyChanged("bugid");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="StatusDisp", Namespace="http://schemas.datacontract.org/2004/07/Final")]
    [System.SerializableAttribute()]
    public partial class StatusDisp : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IWcfService")]
    public interface IWcfService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/IsUserValid", ReplyAction="http://tempuri.org/IWcfService/IsUserValidResponse")]
        bool IsUserValid(string UserName, string Password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Create", ReplyAction="http://tempuri.org/IWcfService/CreateResponse")]
        bool Create(WpfBug.ServiceReference1.DataMembers obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/CreateBug", ReplyAction="http://tempuri.org/IWcfService/CreateBugResponse")]
        void CreateBug(WpfBug.ServiceReference1.DataMembers obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Edit", ReplyAction="http://tempuri.org/IWcfService/EditResponse")]
        WpfBug.ServiceReference1.DataMembers Edit(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/saveEdit", ReplyAction="http://tempuri.org/IWcfService/saveEditResponse")]
        void saveEdit(WpfBug.ServiceReference1.DataMembers objec);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Delete", ReplyAction="http://tempuri.org/IWcfService/DeleteResponse")]
        void Delete(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/Getxml", ReplyAction="http://tempuri.org/IWcfService/GetxmlResponse")]
        void Getxml();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/disp", ReplyAction="http://tempuri.org/IWcfService/dispResponse")]
        WpfBug.ServiceReference1.StatusDisp disp();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/LoadStatusId", ReplyAction="http://tempuri.org/IWcfService/LoadStatusIdResponse")]
        WpfBug.ServiceReference1.DataMembers[] LoadStatusId();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/LoadWorkPackId", ReplyAction="http://tempuri.org/IWcfService/LoadWorkPackIdResponse")]
        WpfBug.ServiceReference1.DataMembers[] LoadWorkPackId();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/LoadBugId", ReplyAction="http://tempuri.org/IWcfService/LoadBugIdResponse")]
        string[] LoadBugId();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/BugEditing", ReplyAction="http://tempuri.org/IWcfService/BugEditingResponse")]
        WpfBug.ServiceReference1.DataMembers BugEditing(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/BugEditSave", ReplyAction="http://tempuri.org/IWcfService/BugEditSaveResponse")]
        void BugEditSave(WpfBug.ServiceReference1.DataMembers obj);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWcfServiceChannel : WpfBug.ServiceReference1.IWcfService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WcfServiceClient : System.ServiceModel.ClientBase<WpfBug.ServiceReference1.IWcfService>, WpfBug.ServiceReference1.IWcfService {
        
        public WcfServiceClient() {
        }
        
        public WcfServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WcfServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WcfServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WcfServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool IsUserValid(string UserName, string Password) {
            return base.Channel.IsUserValid(UserName, Password);
        }
        
        public bool Create(WpfBug.ServiceReference1.DataMembers obj) {
            return base.Channel.Create(obj);
        }
        
        public void CreateBug(WpfBug.ServiceReference1.DataMembers obj) {
            base.Channel.CreateBug(obj);
        }
        
        public WpfBug.ServiceReference1.DataMembers Edit(int Id) {
            return base.Channel.Edit(Id);
        }
        
        public void saveEdit(WpfBug.ServiceReference1.DataMembers objec) {
            base.Channel.saveEdit(objec);
        }
        
        public void Delete(int Id) {
            base.Channel.Delete(Id);
        }
        
        public void Getxml() {
            base.Channel.Getxml();
        }
        
        public WpfBug.ServiceReference1.StatusDisp disp() {
            return base.Channel.disp();
        }
        
        public WpfBug.ServiceReference1.DataMembers[] LoadStatusId() {
            return base.Channel.LoadStatusId();
        }
        
        public WpfBug.ServiceReference1.DataMembers[] LoadWorkPackId() {
            return base.Channel.LoadWorkPackId();
        }
        
        public string[] LoadBugId() {
            return base.Channel.LoadBugId();
        }
        
        public WpfBug.ServiceReference1.DataMembers BugEditing(string id) {
            return base.Channel.BugEditing(id);
        }
        
        public void BugEditSave(WpfBug.ServiceReference1.DataMembers obj) {
            base.Channel.BugEditSave(obj);
        }
    }
}
