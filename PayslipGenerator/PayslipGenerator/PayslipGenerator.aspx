<%@ Page Title="Payslip Generator" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PayslipGenerator.aspx.cs" Inherits="PayslipGenerator._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h1>Payslip generator</h1>
        <p>Program to generate payslips based on given inputs</p>
    </div>

    <h2>Enter employee details</h2>
    <table>
        <tr>
            <td>
                <asp:Label ID="FirstNameLabel" runat="server" Text="First name" />
            </td>
            <td>
                <asp:TextBox ID="FirstNameField" runat="server"></asp:TextBox>
            </td>

        </tr>
        <tr>
            <td>
                <asp:Label ID="LastNameLabel" runat="server" Text="Last name" />
            </td>
            <td>
                <asp:TextBox ID="LastNameField" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="AnnualSalaryLabel" runat="server" Text="Annual salary (positive integer)" />
            </td>
            <td>
                <asp:TextBox ID="AnnualSalaryField" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="SuperRateLabel" runat="server" Text="Super rate (0% - 50%)" />
            </td>
            <td>
                <asp:TextBox ID="SuperRateField" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="PaymentStartDateLabel" runat="server" Text="Payment month" />
            </td>
            <td>
                <asp:DropDownList ID="PaymentStartDateList" runat="server">
                    <asp:ListItem Text="January" Value="January"></asp:ListItem>
                    <asp:ListItem Text="February" Value="February"></asp:ListItem>
                    <asp:ListItem Text="March" Value="March"></asp:ListItem>
                    <asp:ListItem Text="April" Value="April"></asp:ListItem>
                    <asp:ListItem Text="May" Value="May"></asp:ListItem>
                    <asp:ListItem Text="June" Value="June"></asp:ListItem>
                    <asp:ListItem Text="July" Value="July"></asp:ListItem>
                    <asp:ListItem Text="August" Value="August"></asp:ListItem>
                    <asp:ListItem Text="September" Value="September"></asp:ListItem>
                    <asp:ListItem Text="October" Value="October"></asp:ListItem>
                    <asp:ListItem Text="November" Value="November"></asp:ListItem>
                    <asp:ListItem Text="December" Value="December"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="GeneratePayslip" runat="server" Text="Generate payslip" OnClick="GeneratePayslipInformation" />
            </td>
            <td>
                <asp:Label ID="GeneratePayslipErrorLabel" runat="server" Text="Please check if all fields are valid!" Visible="false"></asp:Label>
            </td>
        </tr>
    </table>

    <div id="PayslipInfo" runat="server" visible="false">
        <h2>Employee payslip information</h2>
        <table>
            <tr>
                <th>Name</th>
                <th>Pay Period</th>
                <th>Gross Income ($)</th>
                <th>Income Tax ($)</th>
                <th>Net Income ($)</th>
                <th>Super ($)</th>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="NameDisplay" runat="server" />
                </td>
                <td>
                    <asp:Label ID="PayPeriodDisplay" runat="server" />

                </td>
                <td>
                    <asp:Label ID="GrossIncomeDisplay" runat="server" />

                </td>
                <td>
                    <asp:Label ID="IncomeTaxDisplay" runat="server" />

                </td>
                <td>
                    <asp:Label ID="NetIncomeDisplay" runat="server" />

                </td>
                <td>
                    <asp:Label ID="SuperDisplay" runat="server" />

                </td>
            </tr>
        </table>
    </div>
</asp:Content>
