<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    

    <!DOCTYPE html>
<html>
<head>
    <title>IT Company Website</title>
    <style>
        body {
            margin: 0;
            padding: 0;
            font-family: Arial, sans-serif;
        }
        
        #header {
            background-color: #333;
            color: #fff;
            padding: 10px;
            text-align: center;
        }
        
        #menu {
            background-color: #444;
            color: #fff;
            padding: 10px;
            text-align: center;
        }
        
        #menu ul {
            list-style-type: none;
            margin: 0;
            padding: 0;
        }
        
        #menu li {
            display: inline;
            margin-right: 20px;
        }
        
        #content {
            padding: 20px;
        }
        
        #content img {
            display: block;
            margin: 0 auto;
            max-width: 100%;
            height: auto;
        }
        
        #footer {
            background-color: #333;
            color: #fff;
            padding: 10px;
            text-align: center;
        }
    </style>
</head>
<body>
    <div id="header">
        <h1>Employee Management System</h1>
    </div>

    <div id="menu">
        <ul>
            <li><a href="#">Home</a></li>
            <li><a href="./Login.aspx">Login</a></li>
            <li><a href="./NewEmp.aspx">Registration</a></li>
        </ul>
    </div>

    <div id="content">
        <h2>Our Team at Work</h2>
        <img src="https://img.freepik.com/free-photo/colleagues-working-project-discussing-details_114579-2817.jpg?w=740&t=st=1698592171~exp=1698592771~hmac=8a295d52a54dd08c2b324760f714c5f2fcfd8200a029cbb3d247338f0904a6e6" alt="IT Company Employees" />
    </div>

    <div id="footer">
        &copy; 2023 IT Company. All rights reserved.
    </div>
</body>
</html>


    </form>
</body>
</html>
