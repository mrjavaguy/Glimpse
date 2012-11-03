﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Glimpse.AspNet.Model;
using Glimpse.Core.Extensibility;
using Glimpse.Core.Plugin.Assist;

namespace Glimpse.AspNet.SerializationConverter
{
    public class TraceModelConverter : SerializationConverter<IList<TraceModel>>
    {
        public override object Convert(IList<TraceModel> obj)
        {
            var root = new TabSection("Category", "Trace", "From First", "From Last");
            foreach (var item in obj)
            {
                root.AddRow().Column(item.Category == FormattingKeywordEnum.None ? string.Empty : item.Category.ToString()).Column(item.Message).Column(item.FromFirst.ToString("0.## ms")).Column(item.FromLast.ToString("0.## ms")).Style(item.Category);
            }

            return root.Build();
        } 
    }
}
