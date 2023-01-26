<%@ Page Title="Registro" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="clientes-reg-title">
        <h2><%=Title%></h2>
    </div>

    <div class="clientes-form">
        <div class="row">
        <div class="form-group col-md-3">
            <label for="CPF">CPF *</label>
            <asp:TextBox ID="CPF" runat="server" CssClass="form-control" MaxLength="11"></asp:TextBox>
            <asp:RequiredFieldValidator ID="requiredValidatorCPF" ControlToValidate="CPF" ValidationGroup="cliente"
                ErrorMessage="O campo CPF é obrigatório." CssClass="text-danger" Display="Dynamic" runat="server"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="lengthValidatorCPF" runat="server" CssClass="text-danger"
                ValidationGroup="cliente"
                ControlToValidate="CPF"
                Display="Dynamic"
                ErrorMessage="O campo CPF precisa ter 11 dígitos."
                ValidationExpression=".{11}.*" />
        </div>

        <div class="form-group col-md-3">
            <label for="Nome">Nome *</label>
            <asp:TextBox ID="Nome" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="requiredValidatorNome" ControlToValidate="Nome" ValidationGroup="cliente"
                ErrorMessage="O campo Nome é obrigatório." CssClass="text-danger" Display="Dynamic" runat="server"></asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="row">
        <div class="form-group col-md-3">
            <label for="RG">RG</label>
            <asp:TextBox ID="RG" runat="server" CssClass="form-control" MaxLength="9"></asp:TextBox>
            <asp:RegularExpressionValidator ID="lengthValidatorRG" runat="server" CssClass="text-danger"
                ValidationGroup="cliente"
                ControlToValidate="RG"
                Display="Dynamic"
                ErrorMessage="O campo RG precisa ter 9 dígitos."
                ValidationExpression=".{9}.*" />
        </div>
        <div class="form-group col-md-3">
            <label for="DataExpedicao">Data de Expedição</label>
            <asp:TextBox ID="DataExpedicao" runat="server" CssClass="form-control" type="date"></asp:TextBox>
        </div>
        <div class="form-group col-md-3">
            <label for="ddOrgaos">Orgão de Expedição</label>
            <asp:DropDownList ID="ddOrgaos" DataValueField="Value" DataTextField="Text" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="form-group col-md-3">
            <label for="UFExpedicao">UF Expedição</label>
            <asp:DropDownList ID="ddUFExpedicao" DataValueField="Value" DataTextField="Text" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
    </div>

    <div class="row">
        <div class="form-group col-md-3">
            <label for="DataNascimento">Data de Nascimento *</label>
            <asp:TextBox ID="DataNascimento" runat="server" CssClass="form-control" type="date"></asp:TextBox>
            <asp:RequiredFieldValidator ID="requiredValidatorDataNascimento" ControlToValidate="DataNascimento" ValidationGroup="cliente"
                ErrorMessage="O campo Data de Nascimento é obrigatório." CssClass="text-danger" Display="Dynamic" runat="server"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group col-md-3">
            <label for="ddSexo">Sexo *</label>
            <asp:DropDownList ID="ddSexo" DataValueField="Value" DataTextField="Text" runat="server" CssClass="form-control"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="requiredValidatorSexo" ControlToValidate="ddSexo" ValidationGroup="cliente"
                ErrorMessage="O campo Sexo é obrigatório." CssClass="text-danger" Display="Dynamic" runat="server"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group col-md-3">
            <label for="ddEstadoCivil">Estado Civil *</label>
            <asp:DropDownList ID="ddEstadoCivil" DataValueField="Value" DataTextField="Text" runat="server" CssClass="form-control"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="requiredValidatorEstadoCivil" ControlToValidate="ddEstadoCivil" ValidationGroup="cliente"
                ErrorMessage="O campo Estado Civil é obrigatório." CssClass="text-danger" Display="Dynamic" runat="server"></asp:RequiredFieldValidator>
        </div>
    </div>

    <h3 class="clientes-reg-address">Endereço</h3>

    <div class="row">
        <div class="form-group col-md-2">
            <label for="CEP">CEP *</label>
            <asp:TextBox ID="CEP" runat="server" CssClass="form-control" MaxLength="8"></asp:TextBox>
            <asp:RequiredFieldValidator ID="requiredValidatorCEP" ControlToValidate="CEP" ValidationGroup="cliente"
                ErrorMessage="O campo CEP é obrigatório." CssClass="text-danger" Display="Dynamic" runat="server"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="lengthValidatorCEP" runat="server" CssClass="text-danger"
                ValidationGroup="cliente"
                Display="Dynamic"
                ControlToValidate="CEP"
                ErrorMessage="O campo CEP precisa ter 8 dígitos."
                ValidationExpression=".{8}.*" />
        </div>

        <div class="form-group col-md-3">
            <label for="Logradouro">Logradouro *</label>
            <asp:TextBox ID="Logradouro" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="requiredValidatorLogradouro" ControlToValidate="Logradouro" ValidationGroup="cliente"
                ErrorMessage="O campo Logradouro é obrigatório." CssClass="text-danger" Display="Dynamic" runat="server"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group col-md-1">
            <label for="Numero">Número *</label>
            <asp:TextBox ID="Numero" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="requiredValidatorNumero" ControlToValidate="Numero" ValidationGroup="cliente"
                ErrorMessage="O campo Número é obrigatório." CssClass="text-danger" Display="Dynamic" runat="server"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group col-md-3">
            <label for="Complemento">Complemento</label>
            <asp:TextBox ID="Complemento" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group col-md-3">
            <label for="Bairro">Bairro *</label>
            <asp:TextBox ID="Bairro" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="requiredValidatorBairro" ControlToValidate="Bairro" ValidationGroup="cliente"
                ErrorMessage="O campo Bairro é obrigatório." CssClass="text-danger" Display="Dynamic" runat="server"></asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="row">
        <div class="form-group col-md-3">
            <label for="Cidade">Cidade *</label>
            <asp:TextBox ID="Cidade" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="requiredValidatorCidade" ControlToValidate="Cidade" ValidationGroup="cliente"
                ErrorMessage="O campo Cidade é obrigatório." CssClass="text-danger" Display="Dynamic" runat="server"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group col-md-3">
            <label for="ddUF">UF *</label>
            <asp:DropDownList ID="ddUF" DataValueField="Value" DataTextField="Text" runat="server" CssClass="form-control"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="requiredValidatorUF" ControlToValidate="ddUF" ValidationGroup="cliente"
                ErrorMessage="O campo UF é obrigatório." CssClass="text-danger" Display="Dynamic" runat="server"></asp:RequiredFieldValidator>
        </div>
    </div>

    <asp:Button type="submit" ID="btnSubmit" class="btn btn-info" runat="server" CausesValidation="true" ValidationGroup="cliente" OnClick="btnSubmit_Click" Text="Pronto" />
    </div>

</asp:Content>

