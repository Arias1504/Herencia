<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormUniversidad.aspx.cs" Inherits="appUniversidad.WebFormUniversidad" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 80%;
            border: 2px solid #000000;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            width: 100%;
        }
        .auto-style4 {
            text-align: center;
            height: 23px;
        }
        .auto-style5 {
            text-align: right;
        }
        .auto-style6 {
            width: 80%;
        }
        .auto-style7 {
            width: 40%;
            height: 23px;
        }
        .auto-style8 {
            height: 23px;
        }
        .auto-style9 {
            text-align: right;
            height: 23px;
        }
        .auto-style10 {
            font-weight: bold;
        }
        .auto-style11 {
            width: 40%;
            height: 26px;
        }
        .auto-style12 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table align="center" class="auto-style1">
                <tr>
                    <td class="auto-style2" colspan="2"><strong>UNIVERSIDAD X</strong></td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <table class="auto-style3">
                            <tr>
                                <td class="auto-style5" style="width: 35%">Nombre:</td>
                                <td>
                                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style5">No. Documento:</td>
                                <td>
                                    <asp:TextBox ID="txtDocumento" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style5">Dirección:</td>
                                <td>
                                    <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style5">Genero:</td>
                                <td>
                                    <asp:TextBox ID="txtGenero" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="auto-style2" style="width: 50%">
                        <table class="auto-style3">
                            <tr>
                                <td class="auto-style5" style="width: 35%">Apellido:</td>
                                <td>
                                    <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style5">Telefono:</td>
                                <td>
                                    <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style5">Salario:</td>
                                <td>
                                    <asp:TextBox ID="txtSalario" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style5">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9" colspan="2"></td>
                </tr>
                <tr>
                    <td class="auto-style4" colspan="2"><strong>BUSCAR</strong></td>
                </tr>
                <tr>
                    <td class="auto-style4" style="width: 40%"><strong>Buscar Por No. de Documento:</strong></td>
                    <td class="auto-style4">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4" style="width: 50%">
                        <asp:TextBox ID="txtBuscar" runat="server" Width="191px"></asp:TextBox>
                    </td>
                    <td class="auto-style4"><strong>
                        <asp:Button ID="btnBuscar" runat="server" CssClass="auto-style10" OnClick="btnBuscar_Click" Text="Buscar" />
                        </strong></td>
                </tr>
                <tr>
                    <td class="auto-style4" colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4" colspan="2"><strong>
                        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
                        </strong></td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2"><strong>REGISTRAR</strong></td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2"><strong>
                        <asp:RadioButtonList ID="rblPersona" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Selected="True" Value="opcAdmin">Administrativo</asp:ListItem>
                            <asp:ListItem Value="opcDocente">Docente</asp:ListItem>
                            <asp:ListItem Value="opcEstudiante">Estudiante</asp:ListItem>
                        </asp:RadioButtonList>
                        </strong></td>
                </tr>
                <tr>
                    <td class="auto-style4" colspan="2">
                        <asp:Panel ID="pnlAdmin" runat="server">
                            <table class="auto-style6">
                                <tr>
                                    <td class="auto-style7">Área:</td>
                                    <td class="auto-style8">
                                        <asp:TextBox ID="txtArea" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Cargo:</td>
                                    <td>
                                        <asp:TextBox ID="txtCargo" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Extensión:</td>
                                    <td>
                                        <asp:TextBox ID="txtExtension" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">
                        <asp:Panel ID="pnlDocente" runat="server" Visible="False">
                            <table class="auto-style6">
                                <tr>
                                    <td class="auto-style11">Tipo:</td>
                                    <td class="auto-style12">
                                        <asp:TextBox ID="txtTipo" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Categoria:</td>
                                    <td>
                                        <asp:TextBox ID="txtCategoria" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Horas:</td>
                                    <td>
                                        <asp:TextBox ID="txtHoras" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">
                        <asp:Panel ID="pnlEstudiante" runat="server" Visible="False">
                            <table class="auto-style6">
                                <tr>
                                    <td style="width: 40%">Carné:</td>
                                    <td>
                                        <asp:TextBox ID="txtCarne" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Programa:</td>
                                    <td>
                                        <asp:TextBox ID="txtPrograma" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">
                        <strong>
                        <asp:Button ID="btnGrabar" runat="server" OnClick="btnGrabar_Click" Text="Grabar" CssClass="auto-style10" />
                        </strong>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">
                        <strong>
                        <asp:Button ID="btnResumen" runat="server" OnClick="btnResumen_Click" Text="Resumen" CssClass="auto-style10" />
                        </strong>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
