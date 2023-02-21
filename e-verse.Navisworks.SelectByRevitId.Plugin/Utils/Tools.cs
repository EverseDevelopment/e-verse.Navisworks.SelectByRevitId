using Autodesk.Navisworks.Api;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EVerse.Navisworks.SelectByRevitId.Plugin.Utils
{
    public class Tools
    {
        public static string SelectedIds;
        private static StringBuilder strBuilder;
        public static Document Doc { get; set; }
        public static ModelItemCollection CurrentSelection { get; set; }

        /// <summary>
        /// Convert input string to int
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static List<string> splitString(string s)
        {
            char delimit = ',';
            return s.Split(delimit).ToList();
        }

        internal static void GetIds(ModelItemCollection modelItemCollection)
        {
            foreach (var ModelItem in modelItemCollection)
            {
                if (ModelItem.HasGeometry | ModelItem.IsInsert)
                {
                    ModelItemCollection mic = new ModelItemCollection
                    {
                        ModelItem.Parent
                    };
                    Tools.GetIds(mic);
                    break;
                }
                if (ModelItem.IsCollection && ModelItem.IsLayer)
                {
                    ModelItemCollection mic = new ModelItemCollection();
                    mic.AddRange(ModelItem.Children);
                    Tools.GetIds(mic);
                }
                else
                {
                    var id = ModelItem.PropertyCategories.FindPropertyByName("LcRevitId", "LcOaNat64AttributeValue").Value.ToDisplayString();
                    strBuilder = new StringBuilder();
                    strBuilder.Append(SelectedIds);
                    strBuilder.Append(id);
                    strBuilder.Append(",");
                    SelectedIds = strBuilder.ToString();
                }
            }
        }

        /// <summary>
        /// Get selection from int Revit ID
        /// </summary>
        /// <param name="li"></param>
        /// <returns></returns>
        public static ModelItemCollection getElements(List<string> li)
        {
            Search search = new Search();

            search.Selection.SelectAll();
            foreach (var st in li)
            {
                search.SearchConditions.Add(SearchCondition.HasPropertyByName("LcRevitId", "LcOaNat64AttributeValue").EqualValue(VariantData.FromDisplayString(st)));
            }
            // Execute Search

            ModelItemCollection items = search.FindAll(Application.ActiveDocument, false);

            // highlight the items

            Application.ActiveDocument.CurrentSelection.

                CopyFrom(items);

            return items;
        }
        public static bool IsRevitModelLoaded()
        {
            var activeDoc = Autodesk.Navisworks.Api.Application.ActiveDocument;
            return activeDoc.ActiveSheet != null;
        }
    }
}