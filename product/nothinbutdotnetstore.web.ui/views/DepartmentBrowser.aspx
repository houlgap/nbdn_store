<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="C#" AutoEventWireup="true" Inherits="nothinbutdotnetstore.web.core.DefaultViewFor`1[[System.Collections.Generic.IEnumerable`1[[nothinbutdotnetstore.model.Department, nothinbutdotnetstore, Version=0.0.0.0]], mscorlib, Version=3.5.0.0]], nothinbutdotnetstore, Version=0.0.0.0" MasterPageFile="Store.master" %>
<%@ Import Namespace="nothinbutdotnetstore.web.application" %>
    <asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Department</p>

            <table>            
        	<%
        	    foreach (var department in model)
             {%>
            <tr class="ListItem">

               		 <td>                     
                        <a href="<%=(Url.For(department))%>"> <%=department.name%></a>
                	</td>
           	 </tr>      
             <%
                   
             }%>`
	    </table>            
</asp:Content>
