<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SocialNetworkWeb.Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
	    Введите регистрационные данные:
    <div class="row">
		<div class="col-sm-3">Имя:</div>
		<div class="col-sm-9">
			<asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox><asp:RequiredFieldValidator
				ID="RequiredFieldValidator1" runat="server" ErrorMessage="Введите имя" 
				ControlToValidate="NameTextBox">*</asp:RequiredFieldValidator></div>
    </div>
	<div class="row">
		<div class="col-sm-3">Фамилия:</div>
		<div class="col-sm-9">
			<asp:TextBox ID="SurnameTextBox" runat="server"></asp:TextBox>
			<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
				ErrorMessage="Введитет фамилию" ControlToValidate="SurnameTextBox">*</asp:RequiredFieldValidator>
		</div>
    </div>
	 <div class="row">
		<div class="col-sm-3">Email:</div>
		<div class="col-sm-9">
			<asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
			<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
				ControlToValidate="EmailTextBox" ErrorMessage="Введите Email">*</asp:RequiredFieldValidator>
			<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
				ControlToValidate="EmailTextBox" ErrorMessage="Введите верные Email" 
				ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
			<asp:CustomValidator ID="CustomValidator1" runat="server" 
				ErrorMessage="Пользователь с таким Email уже существует" Font-Bold="True" 
				ForeColor="#006600" ControlToValidate="EmailTextBox" 
				onservervalidate="CustomValidator1_ServerValidate">**</asp:CustomValidator>
		 </div>
    </div>
	<div class="row">
		<div class="col-sm-3">Пароль</div>
		<div class="col-sm-9">
			<asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
			<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
				ControlToValidate="PasswordTextBox" ErrorMessage="Введите пароль">*</asp:RequiredFieldValidator>
		</div>
    </div>
	<div>
		<asp:ValidationSummary ID="ValidationSummary1" runat="server" />
	</div>
	<div>
		<asp:Button ID="RegisterButton" CssClass="btn btn-primary" runat="server" 
			Text="Зарегистрироваться" onclick="RegisterButton_Click" />
	</div>
	<div>
		<a href="~/LogIn.aspx">На страницу входа</a>
	</div>
    </form>
</body>
</html>
