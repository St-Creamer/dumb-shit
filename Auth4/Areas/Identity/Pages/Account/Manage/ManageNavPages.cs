﻿using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BrightPathDev.Areas.Identity.Pages.Account.Manage
{
    public static class ManageNavPages
    {
        public static string Index => "Index";

        public static string ChangePassword => "ChangePassword";

        public static string ExternalLogins => "ExternalLogins";

        public static string PersonalData => "PersonalData";

        public static string TwoFactorAuthentication => "TwoFactorAuthentication";

        public static string AddAdmin => "AddAdmin";

        public static string ManageUser => "ManageUser";

        public static string ManageDeleteRequest => "ManageDeleteRequest";

        public static string Approvals => "Approvals";

        public static string ManageEditRequest => "ManageEditRequest";

        public static string ManageFlags => "ManageFlags";
        public static string MyArticles => "MyArticles";

        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);

        public static string ChangePasswordNavClass(ViewContext viewContext) => PageNavClass(viewContext, ChangePassword);

        public static string ExternalLoginsNavClass(ViewContext viewContext) => PageNavClass(viewContext, ExternalLogins);

        public static string PersonalDataNavClass(ViewContext viewContext) => PageNavClass(viewContext, PersonalData);

        public static string TwoFactorAuthenticationNavClass(ViewContext viewContext) => PageNavClass(viewContext, TwoFactorAuthentication);

        public static string AddAdminNavClass(ViewContext viewContext) => PageNavClass(viewContext, AddAdmin);

        public static string ManageUserNavClass(ViewContext viewContext) => PageNavClass(viewContext, ManageUser);

        public static string ManageDeleteRequestNavClass(ViewContext viewContext) => PageNavClass(viewContext, ManageDeleteRequest);

        public static string ApprovalsNavClass(ViewContext viewContext) => PageNavClass(viewContext, Approvals);

        public static string ManageEditRequestNavClass(ViewContext viewContext) => PageNavClass(viewContext, ManageEditRequest);

        public static string ManageFlagsNavClass(ViewContext viewContext) => PageNavClass(viewContext, ManageFlags);
        public static string MyArticlesNavClass(ViewContext viewContext) => PageNavClass(viewContext, MyArticles);
        

        private static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}