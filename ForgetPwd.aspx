<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ForgetPwd.aspx.cs" Inherits="ForgetPwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table   class="login-tbl">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Enter Your Username" 
                    Font-Bold="True" ForeColor="White"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEmpid" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td> &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btnOtp" runat="server" onclick="btnOtp_Click" Text="Send OTP" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Enter OTP" 
                    Font-Bold="True" ForeColor="White"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtOtp" runat="server" Width="300px" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                </td>
            <td class="style1">
                </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btnpwd" runat="server" onclick="btnpwd_Click" 
                    Text="Get Password" class="hvr-wobble-vertical btn-style" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Label ID="lblmsg" runat="server" Font-Bold="True" ForeColor="Yellow"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <hr color="Orange" />
                </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:HyperLink ID="HyperLink3" runat="server" ForeColor="White" 
                    NavigateUrl="~/Login.aspx" class="sub-link-a">Login</asp:HyperLink>
            </td>
        </tr>
    </table>
</asp:Content>

