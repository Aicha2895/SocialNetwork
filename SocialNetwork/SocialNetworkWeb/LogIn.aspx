<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="SocialNetworkWeb.LogIn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Вход на сайт</title>
    <link href="~/Styles/bootstrap.css" rel="stylesheet" type="text/css" />
	<script type="text/javascript" src="Scripts/jquery-1.10.2.js"></script>
	<script type="text/javascript" src="Scripts/bootstrap.js"></script>
</head>
<body>
    <form id="form1" runat="server">
	<div class="container">
		<h3>Вход на сайт</h3>
		<p>Если вы еще не зарегистрированы - пройдите на <a href="Register.aspx">страницу регистрации</a>.</p>
		<div class="row">
			<div class="col-sm-1">Email:</div>
			<div class="col-sm-6"><asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
					ErrorMessage="Введите Email" ControlToValidate="EmailTextBox">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator
						ID="RegularExpressionValidator1" runat="server" 
					ErrorMessage="Введите корректный Email" ControlToValidate="EmailTextBox" 
					ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator></div>
		</div> 
		<div class="row">
			<div class="col-sm-1">
				Пароль:
			</div>
			<div class="col-sm-6">
				<asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator
					ID="RequiredFieldValidator2" runat="server" ErrorMessage="Введите пароль" 
					ControlToValidate="PasswordTextBox">*</asp:RequiredFieldValidator></div>
		</div>
		<div>
			<asp:ValidationSummary ID="ValidationSummary1" runat="server" />
		</div>
		<div>
			<asp:Label ID="NoUserLabel" CssClass="label label-default" runat="server" 
				Text="Пользователь с таким email-ом и паролем не найден" Visible="False"></asp:Label>
		</div>
		<div>
			<asp:Button ID="GoButton" CssClass="btn btn-success" runat="server" 
				Text="Войти" onclick="GoButton_Click" />
		</div>
	</div>
    </form>
</body>
</html>
