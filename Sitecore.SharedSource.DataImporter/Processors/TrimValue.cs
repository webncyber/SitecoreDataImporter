﻿using Sitecore.Data.Items;
using Sitecore.SharedSource.DataImporter.HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.SharedSource.DataImporter.HtmlScraper;
using Sitecore.SharedSource.DataImporter.Mappings;
using Sitecore.SharedSource.DataImporter.Reporting;

namespace Sitecore.SharedSource.DataImporter.Processors
{
    public class TrimValue
    {
        public void Run(Item processor, Item itemToProcess, Item fieldMapping)
        {
            BaseMapping baseMap = new BaseMapping(fieldMapping);
            try
            {
                using (new SecurityModel.SecurityDisabler())
                {
                    itemToProcess.Editing.BeginEdit();
                    itemToProcess.Fields[baseMap.NewItemField].Value = itemToProcess.Fields[baseMap.NewItemField].Value.Trim();
                    itemToProcess.Editing.EndEdit();
                }
                ImportReporter.Write(itemToProcess, Level.Info,  "", baseMap.NewItemField, "Trim Value");
            }
            catch(Exception ex)
            {
                ImportReporter.Write(itemToProcess, Level.Error, ex.ToString(), baseMap.NewItemField, "Trim Value Field");
            }
        }
    }
}
