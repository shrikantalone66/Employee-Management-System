<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type ="text/javascript">

    windowwindow.onload = window.history.forward(0);  
    
</script>  
    <table  class="login-tbl">
        <tr valign="top">
            <td class="style2" rowspan="8" align="center">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/web_img/lock.png" 
                                    Width="150px" />
            </td>
            <td class="style2">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Yellow" 
                                    Text="User Type"></asp:Label>
            </td>
            <td class="style1">
                <asp:DropDownList ID="ddltype" runat="server" Width="100px" CssClass="tbox">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>Employee</asp:ListItem>
                    <asp:ListItem>Admin</asp:ListItem>
                    <asp:ListItem>Teamleader</asp:ListItem>

                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Yellow" 
                                    Text="Username"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtuser" runat="server" Height="30px" Width="200px" 
                                    BackColor="White" CssClass="tbox" Font-Bold="True" Font-Size="Medium" 
                                    ForeColor="#003399"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="Yellow" 
                                    Text="Password"></asp:Label>
            </td>
            <td style="margin-left: 120px">
                <asp:TextBox ID="txtpwd" runat="server" Height="30px" Width="200px" 
                                    BackColor="White" CssClass="tbox" Font-Bold="True" Font-Size="Medium" 
                                    ForeColor="#003399" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3" colspan="2">
                                <hr color="Orange"  />
                                </td>
        </tr>
        <tr>
            <td class="style3">
                                &nbsp;</td>
            <td style="margin-left: 120px">
                <asp:ImageButton ID="ImageButton1" runat="server" Height="40px" 
                                    ImageUrl="~/web_img/login1.png" Width="130px" 
                                    onclick="ImageButton1_Click" />
            </td>
        </tr>
        <tr>
            <td class="style3" colspan="2">
                <asp:HyperLink ID="HyperLink3" runat="server" ForeColor="White" 
                    NavigateUrl="~/NewEmp.aspx" class="sub-link-a">New Employee Registration</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td class="style3" colspan="2">
                <asp:HyperLink ID="HyperLink2" runat="server" ForeColor="White" 
                    NavigateUrl="~/ForgetPwd.aspx" class="sub-link-a">Forgot Password</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td class="style3" colspan="2">
                <asp:Label ID="lblmsg" runat="server" Font-Bold="True" ForeColor="White"></asp:Label>
                <asp:HiddenField ID="hfUser" runat="server" />
                <asp:HiddenField ID="hfPwd" runat="server" />
                <asp:SqlDataSource ID="SqlDataLogin" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:EMPConnectionString %>" 
                                    
                    SelectCommand="SELECT [username], [pwd],status FROM [Registration] WHERE ([username] = @username) and pwd=@pwd">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hfUser" Name="username" PropertyName="Value" 
                                            Type="String" />
                        <asp:ControlParameter ControlID="hfPwd" Name="pwd" PropertyName="Value" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataLoginClient" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:EMPConnectionString %>" 
                                    
                    
                    SelectCommand="SELECT [username], [pwd],status FROM [ClientReg] WHERE ([username] = @username) and pwd=@pwd">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hfUser" Name="username" PropertyName="Value" 
                                            Type="String" />
                        <asp:ControlParameter ControlID="hfPwd" Name="pwd" PropertyName="Value" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>

