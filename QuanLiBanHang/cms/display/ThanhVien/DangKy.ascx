<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DangKy.ascx.cs" Inherits="cms_display_ThanhVien_DangKy" %>
<link href="css/dang-ky.css" rel="stylesheet" />
<div class="title-gioithieu">
    <h1>TẠO TÀI KHOẢN</h1>
</div>
<div class="userbox">

    <div id="create_customer">
        <input name="form_type" type="hidden" value="create_customer">
        <input name="utf8" type="hidden" value="✓">

        <div id="first_name" class="clearfix">
            <div class="label-fname"></div>
            <asp:TextBox ID="tbHoTen" runat="server" CssClass="text" placeholder="Họ tên"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" SetFocusOnError="True" Display="Dynamic" ControlToValidate="tbHoTen"></asp:RequiredFieldValidator>
        </div>
        <div id="last_name" class="clearfix">
            <div class="label-lname"></div>
            <asp:TextBox ID="tbSoDienThoai" runat="server" CssClass="text" placeholder="Số điện thoại"></asp:TextBox>
        </div>
        <div id="last_name" class="clearfix">
            <div class="label-lname"></div>
            <asp:TextBox ID="tbDiaChi" runat="server" CssClass="text" placeholder="Địa chỉ"></asp:TextBox>
        </div>

        <div id="email" class="clearfix">
            <div class="label-email"></div>
            <asp:TextBox ID="tbEmail" runat="server" CssClass="text" placeholder="Email"></asp:TextBox>
            <div style="clear:both"></div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" SetFocusOnError="True" Display="Dynamic" ControlToValidate="tbEmail"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="<div style='color:red;padding:3px 0'>Email sai định dạng</div>" SetFocusOnError="True" Display="Dynamic" ControlToValidate="tbEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </div>

        <div id="password" class="clearfix">
            <div class="label-pass"></div>
            <asp:TextBox ID="tbMatKhau" runat="server" CssClass="password text" placeholder="Mật khẩu" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" SetFocusOnError="True" Display="Dynamic" ControlToValidate="tbMatKhau"></asp:RequiredFieldValidator>
        </div>
        
        <div id="password" class="clearfix">
            <div class="label-pass"></div>
            <asp:TextBox ID="tbNhapLaiMatKhau" runat="server" CssClass="password text" placeholder="Nhập lại mật khẩu" TextMode="Password"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="<div style='color:red;padding:3px 0'>Nhập lại mật khẩu không trùng khớp</div>" SetFocusOnError="True" Display="Dynamic" ControlToValidate="tbNhapLaiMatKhau" ControlToCompare="tbMatKhau"></asp:CompareValidator>
        </div>

        <div class="action_bottom">
            <asp:LinkButton ID="lbtDangKy" CssClass="btn" runat="server" OnClick="lbtDangKy_Click">Đăng ký</asp:LinkButton>
        </div>
        <div class="req_pass">
            <a class="come-back" href="/">Quay về</a>
        </div>

    </div>
</div>