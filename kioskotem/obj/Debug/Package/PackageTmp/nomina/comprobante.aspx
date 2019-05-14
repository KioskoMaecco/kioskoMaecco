﻿<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="comprobante.aspx.cs" Inherits="kioskotem.nomina.comprobante" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
      <h1>
        <%--Comprobantes de pago de nomina--%>
        Transferencia bancaria
        <small><asp:Label ID="lblnombre" runat="server" Text=""></asp:Label></small>
      </h1>
      <ol class="breadcrumb">
        <li><a href="../inicio/inicio.aspx"><i class="fa fa-dashboard"></i> Inicio</a></li>
        <%--<li><a href="#">Bienvenido</a></li>--%>
        <li class="active">Comprobante nomina</li>
      </ol>
    </section>

    <!-- Main content -->
    <section class="content">
        <asp:ScriptManager ID="ScriptManager1" runat="server" ></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                
                Fecha Inicial:
                <telerik:RadDatePicker ID="dtpinicio" Runat="server">
                </telerik:RadDatePicker>
                <br/>
                Fecha Final:&nbsp;&nbsp;
                <telerik:RadDatePicker ID="dtpfinal" Runat="server">
                </telerik:RadDatePicker>
                <br/>
                <asp:Button ID="cmdbuscar" runat="server" Text="Buscar" 
                    onclick="cmdbuscar_Click"></asp:Button>
                <br/>
                <asp:Label ID="lblmensaje" runat="server" Text=""></asp:Label>
                <br/>
                <asp:GridView ID="dtgnominas" runat="server" AutoGenerateColumns="False" 
                    GridLines="None" CellPadding="4" ForeColor="#333333" AllowPaging="True" 
                        onrowcommand="dtgnominas_RowCommand" 
                        onpageindexchanging="dtgnominas_PageIndexChanging" 
                        onselectedindexchanged="dtgnominas_SelectedIndexChanged" >
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:Label ID="lblidfactura" runat="server" Text='<%# Bind("iIdPago") %>' Visible="false" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:Label ID="lbldpagosa" runat="server" Text='<%# Bind("dpagosa") %>' Visible="false" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:Label ID="lbldpagosin" runat="server" Text='<%# Bind("dpagosin") %>' Visible="false" ></asp:Label>
                                        
                                    </ItemTemplate>
                                </asp:TemplateField>

                                
                                <asp:TemplateField HeaderText="Fecha">
                                    <ItemTemplate>
                                        <asp:Label ID="lblfecha" runat="server" Text='<%# Bind("Fecha") %>' Width="60px"  ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Importe SA">
                                    <ItemTemplate>
                                        <asp:Label Width="80px" style=" text-align:right;" ID="lblimporte" runat="server" Text='<%# Bind("importe") %>'  Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Importe Sin">
                                    <ItemTemplate>
                                        <asp:Label Width="80px" style=" text-align:right;" ID="lblimportesin" runat="server" Text='<%# Bind("importesin") %>'  Visible="true" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField >
                                    <ItemTemplate>
                                        <asp:Label ID="lblb" runat="server" Text='<%# Bind("dsa") %>' Visible="false" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                
                                <asp:CommandField ButtonType="Image" HeaderText="SA" 
                                    SelectImageUrl="../imagenes/pdf2.png" 
                                    ShowSelectButton="True">
                                <HeaderStyle Width="40px" />
                                </asp:CommandField>
                                          
                                <asp:CommandField ButtonType="Image" HeaderText="Sin" 
                                     DeleteImageUrl = "../imagenes/pdf2.png" 
                                      ShowDeleteButton ="true"> 
                                <HeaderStyle Width="40px" />
                                </asp:CommandField>
                                
                                          
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="False" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        

    </section>
</asp:Content>
