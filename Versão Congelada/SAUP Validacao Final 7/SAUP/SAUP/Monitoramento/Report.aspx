<%@ Page Title="" Language="C#" MasterPageFile="~/SAUP.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="SAUP.WebForm7" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Conteudo_Master" runat="server">
 <h3> Média de pontuação por Prioridade</h3>
    <asp:Chart ID="Relatorio_Media_Pontuacao" runat="server" 
        DataSourceID="RelatorioMediaPOntuacao" BackColor="LightGreen" 
        BackGradientStyle="DiagonalLeft" Palette="Bright" Width="450px">
        <Series>
            <asp:Series Name="Média de Pontuações" 
            ChartArea="Media_Pontuacao" XValueMember="PRIORIDADE" XValueType="String" YValueMembers="Media" 
                 Palette="Light" YValueType="Auto" IsValueShownAsLabel="true" 
                IsXValueIndexed="true"  IsVisibleInLegend="true" ShadowColor="#CCFF99" ShadowOffset="50">
                     
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea  AlignmentStyle="PlotPosition" Name="Media_Pontuacao" Area3DStyle-Enable3D="true"
             AlignmentOrientation="Horizontal" Area3DStyle-IsClustered="true" BackImageAlignment="Center">
            <Area3DStyle Enable3D="true" />
            
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
    <asp:ObjectDataSource ID="RelatorioMediaPOntuacao" runat="server" 
        SelectMethod="relatorio_media_pontuacao" 
        TypeName="SAUP.Control.MonitoramentoBC"></asp:ObjectDataSource>
</asp:Content>
