<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="otpscreen.aspx.cs" Inherits="WillAssure.page.otpscreen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Verify OTP</title>

    <style type="text/css">
    .bs-example {
        margin: 20px;
    }
</style>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">

<!DOCTYPE html>
<html lang="en">
<!-- Mirrored from codervent.com/rukada/light-admin/authentication-signin.html by HTTrack Website Copier/3.x [XR&CO'2014], Wed, 28 Nov 2018 11:46:08 GMT -->
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Will Assure</title>

   
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <!--Sweet Alerts -->
    
    <script src="../assets/plugins/alerts-boxes/js/sweetalert.min.js"></script>
    <script src="../assets/plugins/alerts-boxes/js/sweet-alert-script.js"></script>
    <!--favicon-->
    <link rel="icon" href="../assets/images/favicon.ico" type="image/x-icon">
    <!-- simplebar CSS-->
    <link href="../assets/plugins/simplebar/css/simplebar.css" rel="stylesheet" />
    <!-- Bootstrap core CSS-->
    <link href="../assets/css/bootstrap.min.css" rel="stylesheet" />
    <!-- animate CSS-->
    <link href="../assets/css/animate.css" rel="stylesheet" type="text/css" />
    <!-- Icons CSS-->
    <link href="../assets/css/icons.css" rel="stylesheet" type="text/css" />
    <!-- Sidebar CSS-->
    <link href="../assets/css/sidebar-menu.css" rel="stylesheet" />
    <!-- Custom Style-->
    <link href="../assets/css/app-style.css" rel="stylesheet" />
    <!--Data Tables -->
    <link href="../assets/plugins/bootstrap-datatable/css/dataTables.bootstrap4.min.css" rel="stylesheet" type="text/css">
    <link href="../assets/plugins/bootstrap-datatable/css/buttons.bootstrap4.min.css" rel="stylesheet" type="text/css">
  
    <style>
        input[type="email"] {
            text-align: center;
        }
    </style>

    <style type="text/css">
        .bs-example {
            margin: 20px;
        }
    </style>
    <style type="text/css">

                        .contactform span.title-form {
                            color: #4d4d4d
                        }

                        input[type="text"] {
                            margin-bottom: 15px;
                        }

                        .form-group {
                            margin-bottom: 0px;
                        }

                        .radio-inline {
                            margin-right: 15px;
                        }

                        .wrap-formrequest {
                            border: 1px solid #ddd;
                            border-radius: 10px;
                            padding: 15px
                        }
                    </style>
</head>
<body class="bg-dark">
    <!-- Start wrapper-->
    <div id="wrapper">
        <div class="card card-authentication1 mx-auto my-5">
            <div class="card-body">
                <div class="card-content p-2">
                    <div class="text-center">
                        <img src="../assets/images/logo-icon.png" alt="logo icon">
                        <br />
                        <br />
                       




                    </div>
             
                    <br />
                    <br />
                 <div id="logincontent">
                                <div class="form-group">
                                    <CENTER>
                                        <h5>Please Enter Your OTP</h5>
                                    </CENTER>
                                    
                                    <div class="position-relative has-icon-right">
                                        <input type="text" name="name" id="txtotp"  placeholder="Enter Your OTP" onfocus="clearmsg()" onchange="checkotpentered(this.value)" class="form-control input-shadow" value="" />
                                      
                                        <center>
                                                <span style="color:red;display:none" id="lblfailed"> * Failed</span>
                            <span style="color:red;display:none" id="lblemptycheck">* Please Enter Your OTP</span>
                            <span style="color:red; white-space:nowrap;" id="lblerror"></span>
                                        </center>
                                        <br />
                        
                                        <div class="form-control-position">
                                            <i class="icon-user"></i>
                                        </div>
                                    </div>
                                </div>
                                
                   
                                <button type="button" id="btnverifyotp" style="color:white;" name="name"  class="btn btn-success shadow-primary btn-block waves-effect waves-light">Verify OTP</button>

                                <button type="button" id="btnloginSUCCESS" style="display:none;" class="btnpopup btn btn-primary shadow-primary px-5"><i class="icon-lock"></i></button>
                                <button type="button" id="btnloginFAILED" style="display:none;" class="btnpopup btn btn-primary shadow-primary px-5"><i class="icon-lock"></i></button>
                                <button id="btnchanged" style="display:none" type="button"></button>
                            </div>
               
                </div>
            </div>
        </div>











<script>

    function clearmsg() {
        $("#lblemptycheck").hide();
        $("#lblfailed").hide();
    }



    $("#btnverifyotp").click(function () {

        var x = $("#txtotp").val();



        $.ajax({

            type: "POST",
            url: "../VisitorData/checkOTP",
            data: { "send": "" + x + "" },
            success: function (data) {

                if (data == "true") {
                    $("#lblsuccess").show();
                    $("#lblfailed").hide();
                    $("#btnverifyotp").removeAttr("disabled");

                    var url = "/LoginPage/LoginPageIndex?Type=message";
                    window.location.href = url;
                }

                if (data == "false") {
                    $("#lblfailed").show();
                    $("#lblsuccess").hide();
                    $("#lblemptycheck").hide();

                }

                if (data == "Empty") {

                    $("#lblemptycheck").show();

                }





            }
        });



    });







</script>








       
    </div>
    </div>

    <!--Start Back To Top Button-->
    <a href="javaScript:void();" class="back-to-top"><i class="fa fa-angle-double-up"></i> </a>
    <!--End Back To Top Button-->
    </div><!--wrapper-->
  
    <!-- Bootstrap core JavaScript-->
    <script src="../assets/js/jquery.min.js" /></script>
    <script src="../assets/js/popper.min.js"></script>
    <script src="../assets/js/bootstrap.min.js"></script>
    <!-- simplebar js -->
    <script src="../assets/plugins/simplebar/js/simplebar.js"></script>
    <!-- waves effect js -->
    <script src="../assets/js/waves.js"></script>
    <!-- sidebar-menu js -->
    <script src="../assets/js/sidebar-menu.js"></script>
    <!-- Custom scripts -->
    <script src="../assets/js/app-script.js"></script>
    <!-- Chart js -->
    <script src="../assets/plugins/Chart.js/Chart.min.js"></script>
    <!--Peity Chart -->
    <script src="../assets/plugins/peity/jquery.peity.min.js"></script>
    <!-- Index js -->
    <script src="../assets/js/index3.js"></script>
    <!--Data Tables js-->
    <script src="../assets/plugins/bootstrap-datatable/js/jquery.dataTables.min.js"></script>
    <script src="../assets/plugins/bootstrap-datatable/js/dataTables.bootstrap4.min.js"></script>
    <script src="../assets/plugins/bootstrap-datatable/js/dataTables.buttons.min.js"></script>
    <script src="../assets/plugins/bootstrap-datatable/js/buttons.bootstrap4.min.js"></script>
    <script src="../assets/plugins/bootstrap-datatable/js/jszip.min.js"></script>
    <script src="../assets/plugins/bootstrap-datatable/js/pdfmake.min.js"></script>
    <script src="../assets/plugins/bootstrap-datatable/js/vfs_fonts.js"></script>
    <script src="../assets/plugins/bootstrap-datatable/js/buttons.html5.min.js"></script>
    <script src="../assets/plugins/bootstrap-datatable/js/buttons.print.min.js"></script>
    <script src="../assets/plugins/bootstrap-datatable/js/buttons.colVis.min.js"></script>
   



    <script>
        $(document).ready(function () {
            $("#VerificationForm").validationEngine();
        });
    </script>
   


</body>
<!-- Mirrored from codervent.com/rukada/light-admin/authentication-signin.html by HTTrack Website Copier/3.x [XR&CO'2014], Wed, 28 Nov 2018 11:46:08 GMT -->
</html>







    </form>




</body>
</html>
