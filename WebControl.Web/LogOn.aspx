<%@ Page Language="C#" %>
<%@ Import Namespace="System.Web.Security" %>

<script runat="server">
  void Logon_Click(object sender, EventArgs e)
  {
    if ((UserID.Text == "admin") && (UserPass.Text == "16842"))
      {
          FormsAuthentication.RedirectFromLoginPage(UserID.Text, Persist.Checked);
      }
      else
      {
          Msg.Text = "Ошибка авторизации. Попробуйтей еще раз.";
      }
  }
</script>
<html>
<head id="Head1" runat="server">
  <title>Forms Authentication - Login</title>
    <style type="text/css">
        .auto-style1 {
            width: 37%;
        }
        .auto-style3 {
            width: 23px;
        }
        .auto-style4 {
            width: 24%;
        }
    </style>
</head>
    <body>
        <form id="form1" runat="server">
            <div align="center">
                <table border="1" cellspacing="0" width="371" id="AutoNumber1" height="265" style="border-collapse: collapse" bordercolor="#2945DE" cellpadding="0">
                    <td width="409" height="260">
                    <img border="0" src="Images/Banner.jpg" style="width: 100%; height: 80px;">
                        <div align="center"> 
                            <table>                            
                            <h3>Авторизация</h3>
                            <tr>
                                <td height="25" class="auto-style3"></td>
                                <td height="25" class="auto-style4"><font face="Arial" size="2">Пользователь:</font></td>
                                <td height="25" class="auto-style1"><asp:TextBox ID="UserID" runat="server" /></td>                                 
                                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="UserID" Display="Dynamic" ErrorMessage="Не может быть пустым." runat="server" ForeColor="Red" /> </td>
                            </tr>
                            <tr>
                                <td height="25" class="auto-style3"></td>
                                <td height="25" class="auto-style4"><font face="Arial" size="2">Пароль:</font></td>
                                <td height="25" class="auto-style1"><asp:TextBox ID="UserPass" TextMode="Password" runat="server" /></td>
                                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="UserPass" ErrorMessage="Не может быть пустым." runat="server" ForeColor="Red" /></td>
                            </tr>
                            <tr>
                                <td height="25" class="auto-style3"></td>
                                <td height="25" class="auto-style4"><font face="Arial" size="2">Запомнить?</font></td>
                                <td class="auto-style1"><asp:CheckBox ID="Persist" runat="server" /></td>
                            </tr>
                            </table><asp:Button ID="Submit1" OnClick="Logon_Click" Text="Вход" runat="server" Width="210px" />
                            <p><asp:Label ID="Msg" ForeColor="red" runat="server" /></p>
                            </table>
                        </div>
                    </div>
                </table>
            </div>
        </form>
    </body>
</html>