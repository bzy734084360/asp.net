﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace OA.WebFormApp.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserInfo", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class UserInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UPwdField;
        
        private System.Nullable<System.DateTime> SubTimeField;
        
        private System.Nullable<short> DelFlagField;
        
        private System.Nullable<System.DateTime> ModifiedOnField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RemarkField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SortField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string UName {
            get {
                return this.UNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UNameField, value) != true)) {
                    this.UNameField = value;
                    this.RaisePropertyChanged("UName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string UPwd {
            get {
                return this.UPwdField;
            }
            set {
                if ((object.ReferenceEquals(this.UPwdField, value) != true)) {
                    this.UPwdField = value;
                    this.RaisePropertyChanged("UPwd");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=3)]
        public System.Nullable<System.DateTime> SubTime {
            get {
                return this.SubTimeField;
            }
            set {
                if ((this.SubTimeField.Equals(value) != true)) {
                    this.SubTimeField = value;
                    this.RaisePropertyChanged("SubTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=4)]
        public System.Nullable<short> DelFlag {
            get {
                return this.DelFlagField;
            }
            set {
                if ((this.DelFlagField.Equals(value) != true)) {
                    this.DelFlagField = value;
                    this.RaisePropertyChanged("DelFlag");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=5)]
        public System.Nullable<System.DateTime> ModifiedOn {
            get {
                return this.ModifiedOnField;
            }
            set {
                if ((this.ModifiedOnField.Equals(value) != true)) {
                    this.ModifiedOnField = value;
                    this.RaisePropertyChanged("ModifiedOn");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string Remark {
            get {
                return this.RemarkField;
            }
            set {
                if ((object.ReferenceEquals(this.RemarkField, value) != true)) {
                    this.RemarkField = value;
                    this.RaisePropertyChanged("Remark");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public string Sort {
            get {
                return this.SortField;
            }
            set {
                if ((object.ReferenceEquals(this.SortField, value) != true)) {
                    this.SortField = value;
                    this.RaisePropertyChanged("Sort");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.WebService1Soap")]
    public interface WebService1Soap {
        
        // CODEGEN: 命名空间 http://tempuri.org/ 的元素名称 HelloWorldResult 以后生成的消息协定未标记为 nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        OA.WebFormApp.ServiceReference1.HelloWorldResponse HelloWorld(OA.WebFormApp.ServiceReference1.HelloWorldRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        System.Threading.Tasks.Task<OA.WebFormApp.ServiceReference1.HelloWorldResponse> HelloWorldAsync(OA.WebFormApp.ServiceReference1.HelloWorldRequest request);
        
        // CODEGEN: 命名空间 http://tempuri.org/ 的元素名称 AddResult 以后生成的消息协定未标记为 nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Add", ReplyAction="*")]
        OA.WebFormApp.ServiceReference1.AddResponse Add(OA.WebFormApp.ServiceReference1.AddRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Add", ReplyAction="*")]
        System.Threading.Tasks.Task<OA.WebFormApp.ServiceReference1.AddResponse> AddAsync(OA.WebFormApp.ServiceReference1.AddRequest request);
        
        // CODEGEN: 命名空间 http://tempuri.org/ 的元素名称 LoadUserInfoListResult 以后生成的消息协定未标记为 nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/LoadUserInfoList", ReplyAction="*")]
        OA.WebFormApp.ServiceReference1.LoadUserInfoListResponse LoadUserInfoList(OA.WebFormApp.ServiceReference1.LoadUserInfoListRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/LoadUserInfoList", ReplyAction="*")]
        System.Threading.Tasks.Task<OA.WebFormApp.ServiceReference1.LoadUserInfoListResponse> LoadUserInfoListAsync(OA.WebFormApp.ServiceReference1.LoadUserInfoListRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorld", Namespace="http://tempuri.org/", Order=0)]
        public OA.WebFormApp.ServiceReference1.HelloWorldRequestBody Body;
        
        public HelloWorldRequest() {
        }
        
        public HelloWorldRequest(OA.WebFormApp.ServiceReference1.HelloWorldRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class HelloWorldRequestBody {
        
        public HelloWorldRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorldResponse", Namespace="http://tempuri.org/", Order=0)]
        public OA.WebFormApp.ServiceReference1.HelloWorldResponseBody Body;
        
        public HelloWorldResponse() {
        }
        
        public HelloWorldResponse(OA.WebFormApp.ServiceReference1.HelloWorldResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class HelloWorldResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string HelloWorldResult;
        
        public HelloWorldResponseBody() {
        }
        
        public HelloWorldResponseBody(string HelloWorldResult) {
            this.HelloWorldResult = HelloWorldResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AddRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Add", Namespace="http://tempuri.org/", Order=0)]
        public OA.WebFormApp.ServiceReference1.AddRequestBody Body;
        
        public AddRequest() {
        }
        
        public AddRequest(OA.WebFormApp.ServiceReference1.AddRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class AddRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int a;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public int b;
        
        public AddRequestBody() {
        }
        
        public AddRequestBody(int a, int b) {
            this.a = a;
            this.b = b;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AddResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="AddResponse", Namespace="http://tempuri.org/", Order=0)]
        public OA.WebFormApp.ServiceReference1.AddResponseBody Body;
        
        public AddResponse() {
        }
        
        public AddResponse(OA.WebFormApp.ServiceReference1.AddResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class AddResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string AddResult;
        
        public AddResponseBody() {
        }
        
        public AddResponseBody(string AddResult) {
            this.AddResult = AddResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class LoadUserInfoListRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="LoadUserInfoList", Namespace="http://tempuri.org/", Order=0)]
        public OA.WebFormApp.ServiceReference1.LoadUserInfoListRequestBody Body;
        
        public LoadUserInfoListRequest() {
        }
        
        public LoadUserInfoListRequest(OA.WebFormApp.ServiceReference1.LoadUserInfoListRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class LoadUserInfoListRequestBody {
        
        public LoadUserInfoListRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class LoadUserInfoListResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="LoadUserInfoListResponse", Namespace="http://tempuri.org/", Order=0)]
        public OA.WebFormApp.ServiceReference1.LoadUserInfoListResponseBody Body;
        
        public LoadUserInfoListResponse() {
        }
        
        public LoadUserInfoListResponse(OA.WebFormApp.ServiceReference1.LoadUserInfoListResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class LoadUserInfoListResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public OA.WebFormApp.ServiceReference1.UserInfo[] LoadUserInfoListResult;
        
        public LoadUserInfoListResponseBody() {
        }
        
        public LoadUserInfoListResponseBody(OA.WebFormApp.ServiceReference1.UserInfo[] LoadUserInfoListResult) {
            this.LoadUserInfoListResult = LoadUserInfoListResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WebService1SoapChannel : OA.WebFormApp.ServiceReference1.WebService1Soap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebService1SoapClient : System.ServiceModel.ClientBase<OA.WebFormApp.ServiceReference1.WebService1Soap>, OA.WebFormApp.ServiceReference1.WebService1Soap {
        
        public WebService1SoapClient() {
        }
        
        public WebService1SoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebService1SoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebService1SoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebService1SoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        OA.WebFormApp.ServiceReference1.HelloWorldResponse OA.WebFormApp.ServiceReference1.WebService1Soap.HelloWorld(OA.WebFormApp.ServiceReference1.HelloWorldRequest request) {
            return base.Channel.HelloWorld(request);
        }
        
        public string HelloWorld() {
            OA.WebFormApp.ServiceReference1.HelloWorldRequest inValue = new OA.WebFormApp.ServiceReference1.HelloWorldRequest();
            inValue.Body = new OA.WebFormApp.ServiceReference1.HelloWorldRequestBody();
            OA.WebFormApp.ServiceReference1.HelloWorldResponse retVal = ((OA.WebFormApp.ServiceReference1.WebService1Soap)(this)).HelloWorld(inValue);
            return retVal.Body.HelloWorldResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<OA.WebFormApp.ServiceReference1.HelloWorldResponse> OA.WebFormApp.ServiceReference1.WebService1Soap.HelloWorldAsync(OA.WebFormApp.ServiceReference1.HelloWorldRequest request) {
            return base.Channel.HelloWorldAsync(request);
        }
        
        public System.Threading.Tasks.Task<OA.WebFormApp.ServiceReference1.HelloWorldResponse> HelloWorldAsync() {
            OA.WebFormApp.ServiceReference1.HelloWorldRequest inValue = new OA.WebFormApp.ServiceReference1.HelloWorldRequest();
            inValue.Body = new OA.WebFormApp.ServiceReference1.HelloWorldRequestBody();
            return ((OA.WebFormApp.ServiceReference1.WebService1Soap)(this)).HelloWorldAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        OA.WebFormApp.ServiceReference1.AddResponse OA.WebFormApp.ServiceReference1.WebService1Soap.Add(OA.WebFormApp.ServiceReference1.AddRequest request) {
            return base.Channel.Add(request);
        }
        
        public string Add(int a, int b) {
            OA.WebFormApp.ServiceReference1.AddRequest inValue = new OA.WebFormApp.ServiceReference1.AddRequest();
            inValue.Body = new OA.WebFormApp.ServiceReference1.AddRequestBody();
            inValue.Body.a = a;
            inValue.Body.b = b;
            OA.WebFormApp.ServiceReference1.AddResponse retVal = ((OA.WebFormApp.ServiceReference1.WebService1Soap)(this)).Add(inValue);
            return retVal.Body.AddResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<OA.WebFormApp.ServiceReference1.AddResponse> OA.WebFormApp.ServiceReference1.WebService1Soap.AddAsync(OA.WebFormApp.ServiceReference1.AddRequest request) {
            return base.Channel.AddAsync(request);
        }
        
        public System.Threading.Tasks.Task<OA.WebFormApp.ServiceReference1.AddResponse> AddAsync(int a, int b) {
            OA.WebFormApp.ServiceReference1.AddRequest inValue = new OA.WebFormApp.ServiceReference1.AddRequest();
            inValue.Body = new OA.WebFormApp.ServiceReference1.AddRequestBody();
            inValue.Body.a = a;
            inValue.Body.b = b;
            return ((OA.WebFormApp.ServiceReference1.WebService1Soap)(this)).AddAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        OA.WebFormApp.ServiceReference1.LoadUserInfoListResponse OA.WebFormApp.ServiceReference1.WebService1Soap.LoadUserInfoList(OA.WebFormApp.ServiceReference1.LoadUserInfoListRequest request) {
            return base.Channel.LoadUserInfoList(request);
        }
        
        public OA.WebFormApp.ServiceReference1.UserInfo[] LoadUserInfoList() {
            OA.WebFormApp.ServiceReference1.LoadUserInfoListRequest inValue = new OA.WebFormApp.ServiceReference1.LoadUserInfoListRequest();
            inValue.Body = new OA.WebFormApp.ServiceReference1.LoadUserInfoListRequestBody();
            OA.WebFormApp.ServiceReference1.LoadUserInfoListResponse retVal = ((OA.WebFormApp.ServiceReference1.WebService1Soap)(this)).LoadUserInfoList(inValue);
            return retVal.Body.LoadUserInfoListResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<OA.WebFormApp.ServiceReference1.LoadUserInfoListResponse> OA.WebFormApp.ServiceReference1.WebService1Soap.LoadUserInfoListAsync(OA.WebFormApp.ServiceReference1.LoadUserInfoListRequest request) {
            return base.Channel.LoadUserInfoListAsync(request);
        }
        
        public System.Threading.Tasks.Task<OA.WebFormApp.ServiceReference1.LoadUserInfoListResponse> LoadUserInfoListAsync() {
            OA.WebFormApp.ServiceReference1.LoadUserInfoListRequest inValue = new OA.WebFormApp.ServiceReference1.LoadUserInfoListRequest();
            inValue.Body = new OA.WebFormApp.ServiceReference1.LoadUserInfoListRequestBody();
            return ((OA.WebFormApp.ServiceReference1.WebService1Soap)(this)).LoadUserInfoListAsync(inValue);
        }
    }
}
