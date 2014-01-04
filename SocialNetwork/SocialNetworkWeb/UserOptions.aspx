<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserOptions.aspx.cs" Inherits="SocialNetworkWeb.UserOptions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h4>Изменить личные данные:</h4>
	<asp:Label ID="ChangesSavedLabel" CssClass="label label-success" Visible="False" runat="server" Text=""></asp:Label>
	<br />
	<table>
		<tr>
			<td>Имя</td>
			<td>
				<asp:TextBox ID="NameTextBox" runat="server" Height="20px" Width="200px"></asp:TextBox><asp:RequiredFieldValidator
					ID="RequiredFieldValidator1" runat="server" ErrorMessage="" 
					ControlToValidate="NameTextBox">Укажите имя</asp:RequiredFieldValidator></td>
		</tr>
		<tr>
			<td>Фамилия:</td>
			<td>
				<asp:TextBox ID="SurnameTextBox" runat="server" Width="197px"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
					ControlToValidate="SurnameTextBox" ErrorMessage="">Укажите фамилию</asp:RequiredFieldValidator>
			</td>
		</tr>
		<tr>
			<td>О себе:</td>
			<td>
				<asp:TextBox ID="DescriptionTextBox" runat="server" Height="68px" 
					TextMode="MultiLine" Width="370px"></asp:TextBox></td>
		</tr>
		<tr>
			<td>Интересы:</td>
			<td>
				<asp:TextBox ID="ActivitiesTextBox" runat="server" Height="56px" 
					TextMode="MultiLine" Width="366px"></asp:TextBox></td>
		</tr>
		<tr>
			<td>Номера телефонов:</td>
			<td>
				<asp:TextBox ID="PhonesTextBox" runat="server" Width="359px"></asp:TextBox></td>
		</tr>
		<tr>
			<td>Дата Рождения</td>
			<td>
				<asp:Label ID="DateOfBirthLabel" runat="server" Text=""></asp:Label><br/>
				<asp:TextBox ID="DateOfBirthTextBox" runat="server" TextMode="Date"></asp:TextBox></td>
		</tr>
	</table>
	<div>
		<asp:Button ID="Button" CssClass="btn btn-primary" runat="server" 
			Text="Сохранить изменения" onclick="Button_Click" />
	</div>
</asp:Content>
