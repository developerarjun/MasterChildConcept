<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="DoctorRegistration.aspx.cs" Inherits="DoctorPatientInfo.About" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     

    <div class="row">
        <div class="col-md-3">
        <h3 style="color:red">Doctor List </h3>
        </div>
        <div class="col-md-9">
       <h3 style="color:cornflowerblue"><u>Add Doctor Details</u> </h3>
        </div>
    </div><br />
        <div class="row">
       <div class="col-md-3">     
          
           <%-- <select id="lstDoctor"  class="form-control list-group-item" style="min-height:400px; width:100%;" multiple="multiple"
                         data-bind="
                            options: Doctors,
                            optionsText: 'Name',
                            optionsValue: 'DoctorId',
                            optionsCaption: '---Choose Doctor ---',
                            value: SelectedDoctorId ,
                           event: {change:DoctorDetails } ">
                            
            </select>--%>
           <table  style="min-height:40px; width:100%;" data-bind="visible:toggle" border="1" class="dataTable table table-bordered table-condensed  sort" id="showTable">
             
                <tr>
                    <th>Id</th>                 
                    <th>Doctor  Name</th> 
                    <th>Action</th>
                 </tr>
                    <tbody data-bind="foreach:Doctors " >
                        <!-- ko  if: Action()!='D' -->  
                            <tr data-bind="click: $root.DoctorDetails" style="cursor: pointer; 
                            text-align: center;">
                                
                            <td>
                                <span data-bind="text:DoctorId"></span>
                            </td>
                         
                            <td align="left">
                                <span data-bind="text:Name " style="width: 150px;" />
                            </td>
                           
                              <td>
                                  <span class="glyphicon glyphicon-remove" data-bind ="click: $root.DeleteDoctors"></span>
                                  
                              </td>
            </tr>
                       
                        <!-- /ko -->
                    </tbody>
                </table>
        </div>
            <div class="col-md-9">
                <div class="table-responsive">                      
                        <table class="table-form">

                            <div class="row">  
                                <div class="form-group margin-bottom-0">
                               <label class="col-md-3 control-label text-top" for="textinput">
                                    Doctor ID: <span class="mandatory">*</span></label>
                                <div class="col-md-5 ">
                                    <input type="text" class="form-control" id="Text1"  data-bind="value: DoctorId"  readonly />
                                       
                                </div> 
                               </div>
                              
                              </div>
                            
                            <div class="row">
                                  <div class="form-group margin-bottom-0">
                                     <label class="col-md-3 control-label text-top" for="textinput">
                                      Doctor Name: <span class="mandatory">*</span></label>
                                  <div class="col-md-5 ">
                                 <input type="text" id="doctorName"  class='required form-control' data-bind="value: Name"  /> 
                                   </div>
                                    </div>
                              </div>
                                                   
                            <div class="row">
                                <div class="form-group margin-bottom-0">
                                    <label class="col-md-3 control-label text-top" for="textinput"> DOB: </label>                                 
                                    <div class="col-md-5 ">
                                    <input type="text" id="txtDOB" placeholder="yyyy.mm.dd" maxlength="10" onkeypress='return (event.charCode >= 48 && event.charCode <= 57) || event.charCode == 46' class="form-control" name="Mobile" data-bind="value: DOB"/>
                                      
                                    </div>
                               </div>
                             </div>

                            <div class="row">
                               <div class="form-group margin-bottom-0">
                                    <label class="col-md-3 control-label text-top" for="textinput">Gender</label>                                   
                                    <%--<div class="col-md-5 ">
                                     <input type="text" id="txtGender"  class="form-control" name="Email" data-bind="value: Gender"/>
                                    </div>--%>
                                    <label class="radio-inline"  >
                                          <input type="radio" name="optradio" value="1"  data-bind="checked: Gender" checked>Male
                                     </label>
                                   <label class="radio-inline">
                                        <input type="radio" name="optradio" value="2" data-bind="checked: Gender">Female
                                    </label>
                              </div>
                            </div>

                            <div class="row">               
                              <div class="form-group margin-bottom-0">
                                <label class="col-md-3 control-label text-top" for="textinput"> Salary</label>                                   
                                <div class="col-md-5 ">
                                 <input type="text" id="txtSalary"  class="form-control" name="Salary" onkeypress='return (event.charCode >= 48 && event.charCode <= 57) || event.charCode == 46' data-bind="value: Salary"/>
                                </div>
                              </div>
                            </div>  
                            
                           <div class="row">    
                               <div class="form-group margin-bottom-0">
                                <label class="col-md-3 control-label text-top" for="textinput">Active: <span class="mandatory">*</span></label>                                   
                                    <div class="col-md-5 ">
                                      <input id="chkActive" type="checkbox" data-bind="checked: IsActive" style="float: left;" checked="checked" />
                                     </div>       
                                </div>
                           </div>
                                         

                          <h3>Qualification List</h3>
                            <div class="row">
                           <div class="form-group margin-bottom-0">
                                <label class="col-md-3 control-label text-top" for="textinput"> Qual Name:<span class="mandatory">*</span></label>                                   
                                <div class="col-md-5 dropdown">
                                    <%--<td><span data-bind="text: QualId" /> </td>--%>
                                 <select  class="dropdown-select" 
                                        data-bind="
                                           options:QualificationLists,
                                           optionsText: 'QualName',
                                           optionsValue: $data,
                                           value:SelectedQualificationID, 
                                           optionsCaption:'---choose---'
                                           ">
                                 </select>
                                </div>
                            </div>

                            </div>
                              
                            <div class="row">
                                <div class="form-group margin-bottom-0" id="DocIDNo">
                                 <label class="col-md-3 control-label text-top" for="textinput">
                                    Marks <span class="mandatory">*</span></label>
                                <div class="col-md-5 ">
                           <input type="text" id="TxtMarks"  class="form-control" name="Marks" onkeypress='return (event.charCode >= 48 && event.charCode <= 57) || event.charCode == 46' data-bind="value: Marks"/>
                                </div>
                                </div>
                           </div>
         <div class="form-group col-md-1 margin-bottom-0" id="addID">
            <button class="btn icon-add btn-primary margin-left-15" data-bind="click: AddDoctorQualification,text: ButtonQual"> </button>
          </div>                           
 </div>
      
       <div class="row" >
        <div class="col-lg-8">
            <div class="table-responsive">
              <table style="width: 100%;" data-bind="visible:toggle" border="1" class="dataTable table table-bordered table-condensed  sort" id="showTable">
             
                <tr>
                    <th>Id</th>
                  <%--  <th>QualId</th>--%>
                    <th>Qualification Name</th>
                    <th>Marks</th>
                    <th>Action</th>                    
                 </tr>
                    <tbody data-bind="foreach:Qualifications " >
                        <!-- ko  if: Action()!='D' -->  
                        <tr data-bind="visible: Action() !='D'">
                            <td>
                                <span data-bind="text: ($index() + 1)"></span>
                            </td>
                          <%--  <td align="left">
                                <span data-bind="text:QualId " style="width: 150px;" />
                            </td>--%>
                            <td align="left">
                                <span data-bind="text:QualName " style="width: 150px;" />
                            </td>
                            <td align="left">
                                <span data-bind="text:Marks " style="width: 150px;" />
                            </td>
                              <td align="left">
                                     <a data-bind="click:$root.EditQualification">                        
                                        <span class="glyphicon glyphicon-edit" title="Edit" rel="tooltip"></span>
                                        </a>
                                     <a data-bind="click:$root.DeleteQualification">
                                        <span class="glyphicon glyphicon-trash" title="Delete" rel="tooltip"></span>
                                        </a>
                               </td>
                        </tr>
                        <!-- /ko -->
                    </tbody>
                </table>
            </div>
        </div>
    </div>
                   
              <div class="row">
             
            <div class="col-md-4 margin-top-15 pull-right">
               <button class="btn btn-success" data-bind="click:SaveDoctor ">Submit</button>
              <%-- <button class="btn btn-info" data-bind="click:">Update</button>
               <button class="btn btn-danger">Delete</button>--%>
                <button class="btn btn-warning" data-bind="click: resetDoctors">Cancel</button>
            </div>
          </div>
          
            </div>
            <div class="clear"></div>           
        </div>

    

    <script src="Scripts/DoctorPatient/Doctor.js"></script>

</asp:Content>

