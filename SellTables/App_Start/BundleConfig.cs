﻿using System.Web;
using System.Web.Optimization;

namespace SellTables
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.1.4.js",
                        "~/Scripts/scripts/jquery.tabslideout.v1.2.js",
                        "~/Scripts/scripts/jquery.tagcanvas.js",
                        "~/Scripts/scripts/counter.js",
                        "~/Scripts/scripts/jqmenu.js",
                        "~/Scripts/scripts/registerLoginMenu.js"

                ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/scroll").Include(
                       "~/Scripts/scripts/scroll.js"));



            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                          "~/Scripts/angular.js",
                          "~/Scripts/angular-route.js",
                          "~/Scripts/angular-cookies.js",
                          "~/Scripts/ng-inline-edit.js"
                          ));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/app/main.js",
              "~/app/controllers/admin.js",
             "~/app/controllers/widthChange.js",
                "~/app/controllers/creative.js",
                "~/app/controllers/user.js",
                "~/app/controllers/tag.js",
                 "~/app/controllers/chapter.js",
                "~/Scripts/scripts/clean-blog.js",
                "~/Scripts/scripts/star-rating.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/scripts/redipadding.js",
                      "~/Scripts/angular-ui/ui-bootstrap-tpls.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css",
                      "~/Content/loginRegister.css",
                      "~/Content/counter.css",
                      "~/Content/circlemenu.css",
                      "~/Content/font-awesome.min.css",
                       "~/Content/font-awesome-animation.css",
                      "~/Content/summernote.css",
                      "~/Content/clean-blog.css",
                      "~/Content/star-rating.css",
                      "~/Content/creatives.css"

                      ));

            bundles.Add(new StyleBundle("~/Content/somestyles").Include(
                      "~/Content/somestyles/userpage.css"

                      ));

            bundles.Add(new ScriptBundle("~/bundles/tags").Include(
                      "~/Scripts/scripts/TagsScript.js"

                      ));
            bundles.Add(new StyleBundle("~/Content/tags").Include(
                      "~/Content/somestyles/TagsStyles.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/dropzonescripts").Include(
                     "~/Scripts/scripts/dropzone.js"
                     ));

            bundles.Add(new StyleBundle("~/Content/dropzonescss").Include(
                     "~/Content/somestyles/dropzone.css"
                     ));

            bundles.Add(new ScriptBundle("~/bundles/popoverscript").Include(
                     "~/Scripts/pageScripts/popoverScript.js"
                     ));

            bundles.Add(new ScriptBundle("~/bundles/creativeCreateScript").Include(
                     "~/Scripts/pageScripts/creativeCreateScript.js"
                     ));

            bundles.Add(new ScriptBundle("~/bundles/swiper").Include(
                     "~/Scripts/scripts/swiper.js"
                     ));

            bundles.Add(new StyleBundle("~/Content/swiper").Include(
                     "~/Content/somestyles/swiper.css"
                     ));

            bundles.Add(new ScriptBundle("~/bundles/creativeDetailsScript").Include(
                     "~/Scripts/pageScripts/creativeDetailsScript.js"
                     ));

            bundles.Add(new StyleBundle("~/Content/creativeDetailsScript").Include(
                     "~/Content/pageStyles/creativeDetailsStyles.css"
                     ));

            bundles.Add(new ScriptBundle("~/bundles/pageScrollEvent").Include(
                     "~/Scripts/pageScripts/pageScrollEventScript.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/setCookies").Include(
                "~/Scripts/pageScripts/setCookiesScript.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/dropzoneForCreative").Include(
                "~/Scripts/scripts/dropzoneForCreative.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/userpage").Include(
                "~/Scripts/pageScripts/userPageScript.js"
            ));
        }
    }
}
