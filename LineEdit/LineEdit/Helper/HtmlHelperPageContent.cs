using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using RazorEngine;

namespace LineEdit.LineEdit.Helper
{
    public static class HtmlHelperPageContent
    {

        public static MvcHtmlString MyHiddenFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression) where TModel : class
        {
            var value = expression.Compile().Invoke(html.ViewData.Model);

            TagBuilder input = new TagBuilder("input");
            input.Attributes["type"] = "text";
            input.Attributes["id"] = html.IdFor(expression).ToString();
            input.Attributes["name"] = html.NameFor(expression).ToString();

          

           input.Attributes["value"] = value == null ? "" : value.ToString();

            return new MvcHtmlString(input.ToString());
        }

        public static MvcHtmlString NewTextBox(this HtmlHelper htmlHelper, string name, string value)
        {
            var builder = new TagBuilder("input");
            builder.Attributes["type"] = "text";
            builder.Attributes["name"] = name;
            builder.Attributes["value"] = value;
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString NewTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression) where TModel : class
        {
            var value = expression.Compile().Invoke(htmlHelper.ViewData.Model);
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return NewTextBox(htmlHelper, name, metadata.Model as string);
        }


        public static IHtmlString LineEdit<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, string _Id, string _height = "250px") where TModel : class
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var name = metadata.PropertyName;
            var content = metadata.Model as string;
            string txt =String.Format(""+
                 "<script>$(function() {{$('#{1}').Editor(); $('#{1}').Editor(\"setText\",\"{3}\");}} );</script>" +
            "  <textarea id=\"{1}\" name=\"{0}\">{3}</textarea>",name, _Id,content ,HttpUtility.HtmlEncode(content));
            return new MvcHtmlString(txt);
        }

    }
}

