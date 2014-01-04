<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewProfile.aspx.cs" Inherits="SocialNetworkWeb.ViewProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div class="ProfileInfo">
		<table class="table table-condensed">
			<tr>
				<td colspan="2">
					<h3>
						<asp:Label ID="NameLabel" runat="server" Text=""></asp:Label> <asp:Label ID="SurnameLabel" runat="server" Text=""></asp:Label>
					</h3>
				</td>
			</tr>
			<tr>
				<td>Номера телефонов</td> 
				<td>
					<asp:Label ID="PhonesLabel" runat="server" Text=""></asp:Label>
				</td>
			</tr>
			<tr>
				<td>
					О себе:</td> 
				<td>
					<asp:Label ID="DescriptionLabel" runat="server" Text=""></asp:Label>
				</td>
			</tr>
			<tr>
				<td>
					Увлечения:</td> 
				<td>
					<asp:Label ID="ActivitiesLabel" runat="server" Text=""></asp:Label>
				</td>
			</tr>
			<tr>
				<td>
					Дата рождения:</td> 
				<td>
					<asp:Label ID="BirthDayLabel" runat="server" Text=""></asp:Label>
				</td>
			</tr>
		</table>
	</div>
	<div>
		<div class="table-bordered" >
			<asp:HyperLink ID="UserPhotosHyperLink" runat="server">Photos</asp:HyperLink>
		</div>
		<div class="table-bordered">
			Photos
		</div>
	</div>
	<div class="Feed">
		<div>
			Лента<asp:HiddenField ID="FeedUserId" runat="server" />
		</div>
		<div>
			<asp:TextBox ID="NewPostTextBox" runat="server" Height="54px" TextMode="MultiLine" 
				Width="509px"></asp:TextBox>
			<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
				ErrorMessage="*" ControlToValidate="NewPostTextBox"></asp:RequiredFieldValidator>
				<div>
					<asp:Button CssClass="btn" ID="AddPostButton" runat="server" Text="Добавить" 
						onclick="AddPostButton_Click" /></div>
		</div>
		<br/>
		<div>
			<asp:Repeater ID="FeedPostsRepeated" runat="server">
				<ItemTemplate>
					<div>
					<div class="row">
						<div class="col-xs-2">
							<a href='ViewProfile.aspx?UserId=<%#Eval("FromUserId")%>'><%#Eval("FromUserName")%></a>
						</div>
						<div class="col-xs-10"><%#Eval("Text")%></div>
					</div>
					<div>
						<%#Eval("CreatedDate")%>
					</div>
					</div>
				</ItemTemplate>
			</asp:Repeater>
		</div>
	</div>
</asp:Content>
