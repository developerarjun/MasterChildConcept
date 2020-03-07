


// Model for Doctor

function Doctor(data) {
    var current = this;
    current.DoctorId = ko.observable(data.DoctorId);
    current.Name = ko.observable(data.Name);
    current.Gender = ko.observable(data.Gender);
    current.DOB = ko.observable(data.DOB);
    current.Salary = ko.observable(data.Salary);
    current.IsActive = ko.observable(data.IsActive);
    current.Action = ko.observable(data.Action);
    current.Qualification = ko.observable(data.Qualification);


}

// Structure For Qualification List
function QualificationList(data) {
    var current = this;
    current.QualId = ko.observable(data.QualId);
    current.QualName = ko.observable(data.QualName);
    current.Action = ko.observable(data.Action);
}
//structure for Qualification
function Qualification(data) {
    var current = this;
    current.DoctorId = ko.observable(data.DoctorId);
    current.QualId = ko.observable(data.QualId);
    current.QualName = ko.observable(data.QualName);
    current.Marks = ko.observable(data.Marks);
    current.Action = ko.observable(data.Action);
}
//
//View Model of Doctor

    var DoctorViewModel = function () {
        var current = this;
        current.DoctorId = ko.observable();
        current.Name = ko.observable();
        current.Gender = ko.observable(2);
        current.DOB = ko.observable();
        current.Salary = ko.observable();
        current.IsActive = ko.observable();
        current.Qualification = ko.observable();
        current.Action = ko.observable();
        current.SelectedData = ko.observable();
        //For Qualification
        current.Marks = ko.observable();
        current.DoctorUpdate = ko.observable(true);

        //For Qualification List
        current.QualId = ko.observable();
        current.QualName = ko.observable();

        current.Doctors = ko.observableArray([]);
        current.SelectedDoctorId = ko.observable();
    
        current.QualificationLists = ko.observableArray([]);
        current.SelectedQualificationID = ko.observable();

        current.Qualifications = ko.observableArray([]);

        current.toggle = ko.observable();
        current.toggle(true);



                
        current.GetQualificationList = function () {
            //debugger;
            $.ajax({
                dataType: "json",
                cache: false,
                async: false,
                url: '../../Handler/HandlerOfDoctor.ashx',
                data: { 'method': 'GetQualificationList', 'QualId': null },
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var mappedTask = $.map(data.ResponseData, function (item) {
                        return new QualificationList(item)
                    });

                    current.QualificationLists(mappedTask);
                    //    console.log(current.QualificationLists());

                },
                error: function (err) {
                    alert(err.status + " - " + err.statusText, "FAILURE");
                }
            });
        }
        current.GetQualificationList();
        //current.    = function () {
        //    // alert();
        //}
   

        //For Add data in table by clicking add button
        current.AddDoctorQualification = function () {
            //if (current.ValidateQualification()) {
                var errMsg = "";
                var objFocus = null;
            var pro;
            var QualData = current.SelectedData();

            


            if (QualData == null && QualData == undefined) {

                for (let i = 0; i < current.Qualifications().length; i++) {
                    if (ko.toJS(current.Qualifications()[i].QualId) == ko.toJS(current.SelectedQualificationID).QualId) {
                        alert('Data already exists !!!');
                        return;
                    }
                }
                console.log(current.DOB());
                pro = {
                    QualId: current.SelectedQualificationID().QualId(),
                    QualName: current.SelectedQualificationID().QualName(),
                    Marks: current.Marks(),
                    Action: "A"
                    
                   

                };
                
                current.Qualifications.push(new Qualification(pro));
                current.Marks(null);
                //   current.SelectedQulaificationChange.push(new Qualification(pro));
            }
            else {
                QualData.DoctorId(current.DoctorId());
                QualData.QualId(current.SelectedQualificationID().QualId());
                QualData.QualName(current.SelectedQualificationID().QualName());
               
              //  QualData.Action("E")
                QualData.Action(current.Action());

                QualData.Marks(current.Marks());
                current.SelectedData(null);
                current.Marks(null);             
            }

            current.SelectedQualificationID(null);

          
            
            current.Marks(null)
            //} //current.ClearLocal();
        }




            current.ClearDoctorInfo = function () {
            current.DoctorId(null);
            current.Name(null);
            current.DOB(null);
            current.Salary(null);
            current.Gender(null);
            current.Salary(null);
            current.Marks(null);
            current.SelectedQualificationID(null);
        }
        //Save Doctor

        current.SaveDoctor = function () {
            //if (current.ValidateDoctor()) {
               //// alert();
              
            var doctorAction = "";
            if (current.SelectedDoctorId() == undefined) {
                doctorAction = "A";
            }
            else
                doctorAction = "E";

            //doctorAction = (ko.toJS(
            //    current.SelectedDoctorId()) != undefined &&
            //    ko.toJS(current.SelectedDoctorId()) != null) ? "E" : "A"; 

                //debugger
                var doctor = {
                    DoctorId: current.DoctorId(),
                    Name: current.Name(),
                    BirthDate: current.DOB(),
                    Gender: current.Gender(),
                    Salary: current.Salary(),
                    Qualification: current.Qualifications(),
                    Action: doctorAction
                }
                console.log(data);
                var url = "../../Handler/HandlerOfDoctor.ashx";
                var data = { 'method': 'SaveDoctor', 'args': JSON.stringify(ko.toJS(doctor)) };

                $.post(url, data, function (result) {
                    var obj = jQuery.parseJSON(result);
                    console.log(obj);
                    //alert(obj.Message);
                    if (obj.IsSuccess) {
                        alert("Doctor Data Save Sucessfully")
                        
                        current.Doctors();
                    //    console.log();
                      //  current.GetQualificationLists();

                        current.ClearDoctorInfo();
                        current.GetDoctors();
                    }

            });
            
            //}
        }
      //  current.SaveDoctor(false);

        current.GetDoctors = function () {
            $.ajax({
                dataType: "json",
                cache: false,
                url: '../../Handler/HandlerOfDoctor.ashx',
                data: { 'method': 'GetDoctor', 'doctorId': null },
                contentType: "application/json; charset=utf-8",

                success: function (result) {
                    var mappedTask = $.map(result.ResponseData, function (item) {
                        return new Doctor(item)

                    });

                    current.Doctors(mappedTask);
                },
                error: function (err) {
                    msg(err.status + " - " + err.statusText, "FAILURE");
                }
            });
        };
        current.GetDoctors();

        current.DoctorDetails = function (dddddd) {
            current.DoctorUpdate(false);
            current.SelectedDoctorId(dddddd.DoctorId);
            if (current.SelectedDoctorId() == null) {
               
            }
            else {
                             
                $.ajax({
                    dataType: "json",
                    cache: false,
                    url: "../../Handler/HandlerOfDoctor.ashx",
                    data: { 'method': 'GetDoctorDetails', 'DoctorId': current.SelectedDoctorId() },
                    contentType: "application/json; charset=utf-8",
                    success: function (result) {
                        var data = result.ResponseData[0];
                      //  debugger;
                        current.DoctorId(data.DoctorId);
                        current.Name(data.Name);
                        //current.DOB('/03/2019');
                        current.DOB(data.BirthDate);
                        current.Gender(data.Gender);
                        current.Salary(data.Salary);
                        var mappedTask = $.map(data.Qualification, function (item) {
                            return new Qualification(item)
                        });
                        current.Qualifications(mappedTask);

                        console.log(current.Qualifications());

                        current.GetQualificationList();
                     //  current.SaveDoctor(false);
                    },
                    error: function (err) {
                        console.log(err);
                        msg(err.status + " - " + err.statusText, "FAILURE");
                    }
                });

            }

        }
       

            //  for Add Qualification Details
            current.QualificationDetails = function () {               
                //waitMsg("Loading");
                //waitMsg.show();
                $.ajax({
                    dataType: "json",
                    cache: false,
                    url: "../../Handler/HandlerOfDoctor.ashx",
                    data: { 'method': 'GetQualificationDetails', 'DoctorId': current.SelectedDoctorId() },
                    contentType: "application/json; charset=utf-8",
                    success: function (result) {
                        
                        if (result.IsSucess) {
                            var mappedTask = $.map(result.ResponseData, function (item) {
                                return new Qualification(item)
                            });

                            current.Qualifications(mappedTask);
                        }
                        else {

                            msg(result.Message, "WARNING");
                        }
                    },
                    error: function (err) {
                       
                        alert(err.status + " - " + err.statusText, "FAILURE");
                    }
                });
            }
        //For Edit Qualification list
        current.EditQualification = function (data) {
            
            console.log(data);         
            current.Marks(data.Marks());
           
            for (var i = 0; i < current.QualificationLists().length; i++) {
                if (ko.toJS(current.QualificationLists()[i].QualName) === data.QualName()) {
                        current.SelectedQualificationID(current.QualificationLists()[i]);
                    }
                }
            current.SelectedData(data);    
          
        }

        
       



        //For Delete Qualification List 

        current.DeleteQualification = function (del) {
            if (confirm("Do you want to delete ")) {
                current.Qualifications.remove(del);
            }
        }

        //for Validation of marks
        current.ValidateQualification = function () {
            var errMsg = " ";

            if (Validate.empty(current.Marks())) {
                errMsg += "Enter Marks !\n";
            }
            if (current.Marks() < 40 || current.Marks() > 100) {
                errMsg += "Enter Marks Between 40 and 100 ! \n";
            }
            if (errMsg === "") {
                return true;
            }
            else {
                alert(errMsg);
                return false;
            }
            //return true;
        };
        //For Validation of Form
        current.ValidateDoctor = function () {
            var errMsg = "";
            if (Validate.empty(current.Name())) {
                //if (current.Name()== null || current.Name() == undefinded) {
                errMsg += "Enter Name! \n";
            }
            if (Validate.empty(current.DOB())) {
                errMsg += "Enter Date of Birth! \n";
            }
            if (Validate.empty(current.Salary())) {
                errMsg += "Enter Salary! \n";
            }
            //if (Validate.empty(current.Gender())) {
            //    errMsg += "Enter Gender! \n";
            //}
            if (errMsg === "") {
                return true;
            }
            else {
                alert(errMsg);
                return false;
            }

        };
    }

$(document).ready(function () {
    
    var doctorInfoModel = new DoctorViewModel();
    ko.applyBindings(doctorInfoModel);
   
});

