using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xyz.BusinessAPI.Common.TransferTemplate;
using Xyz.HtmlPlatform;

namespace Xyz.Web.Platform.TransferTemplate.Export
{
    public abstract class BaseDataExporter<T>
        where T: class
    {
        protected string separator;
        protected Encoding encoding;

        public BaseDataExporter(DataExporterParams<T> dataExportParams)
         => throw new System.NotImplementedException();

        protected virtual void WriteModelToStream(StreamWriter streamWriter, object model, List<string> selectedColumns, HashSet<string> dateAndTimeColumns = null)
        {
            var propertyNameValueModel = model.ToKeyValueDictionary();
            var lastColumn = selectedColumns.Last();
            foreach (var column in selectedColumns)
            {
                if (!propertyNameValueModel.ContainsKey(column))
                {
                    continue;
                }

                var displayValue = GetPropertyDisplayValue(model, column, propertyNameValueModel[column], propertyNameValueModel, dateAndTimeColumns != null && dateAndTimeColumns.Count > 0 && dateAndTimeColumns.Contains(column));
                var includeComma = lastColumn != column;

                CsvDataExportHelper.WriteValue(streamWriter, displayValue, includeComma, separator);
            }
        }

        protected virtual string GetPropertyDisplayValue(object model, string propertyName, object propertyValue, Dictionary<string, object> propertyNameValueModel, bool parseDateAndTime = false)
         => throw new System.NotImplementedException();
    }
}