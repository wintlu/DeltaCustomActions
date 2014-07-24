using Microsoft.SharePoint;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.WorkflowActions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Compiler;

namespace DeltaCustomActions
{
    public class CustomSubsSiteAction : Activity
    {
        public static DependencyProperty DepartMentsProperty = DependencyProperty.Register("DepartMents", typeof(string), typeof(CustomSubsSiteAction));

        [Description("DepartMents")]
        [Category("Cross-Site Actions")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string DepartMents
        {
            get
            {
                return ((string)(base.GetValue(CustomSubsSiteAction.DepartMentsProperty)));
            }
            set
            {
                base.SetValue(CustomSubsSiteAction.DepartMentsProperty, value);
            }
        }

        public static DependencyProperty __ContextProperty = DependencyProperty.Register("__Context", typeof(WorkflowContext), typeof(CustomSubsSiteAction));

        [Description("__Context")]
        [Category("User")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public WorkflowContext __Context
        {
            get
            {
                return ((WorkflowContext)(base.GetValue(CustomSubsSiteAction.__ContextProperty)));
            }
            set
            {
                base.SetValue(CustomSubsSiteAction.__ContextProperty, value);
            }
        }

        public static DependencyProperty __ListIdProperty = DependencyProperty.Register("__ListId", typeof(string), typeof(CustomSubsSiteAction));

        [Description("__ListId")]
        [Category("__ListId Category")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ValidationOption(ValidationOption.Required)]
        public string __ListId
        {
            get
            {
                return ((string)(base.GetValue(CustomSubsSiteAction.__ListIdProperty)));
            }
            set
            {
                base.SetValue(CustomSubsSiteAction.__ListIdProperty, value);
            }
        }

        public static DependencyProperty __ItemIDProperty = DependencyProperty.Register("__ItemID", typeof(int), typeof(CustomSubsSiteAction));

        [Description("__ItemID")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ValidationOption(ValidationOption.Required)]
        public int __ItemID
        {
            get
            {
                return ((int)(base.GetValue(CustomSubsSiteAction.__ItemIDProperty)));
            }
            set
            {
                base.SetValue(CustomSubsSiteAction.__ItemIDProperty, value);
            }
        }

        public static DependencyProperty __ActivationPropertiesProperty = DependencyProperty.Register("__ActivationProperties", typeof(SPWorkflowActivationProperties), typeof(CustomSubsSiteAction));

        [Description("__ActivationProperties")]
        [Category("__ActivationProperties Category")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public SPWorkflowActivationProperties __ActivationProperties
        {
            get
            {
                return ((SPWorkflowActivationProperties)(base.GetValue(CustomSubsSiteAction.__ActivationPropertiesProperty)));
            }
            set
            {
                base.SetValue(CustomSubsSiteAction.__ActivationPropertiesProperty, value);
            }
        }
        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                var spService = executionContext.GetService<ISharePointService>();
                SPWeb rootWeb = null;
                try
                {
                    SPWeb web = __Context.Web;
                    spService.LogToHistoryList(this.WorkflowInstanceId, SPWorkflowHistoryEventType.WorkflowComment, 0, TimeSpan.Zero, string.Empty, "In Corss Site Action: " + web.Url, string.Empty);
                    //rootWeb = __Context.Site.RootWeb;
                    //Guid listGuid = new Guid(__ListId);
                    //SPList list = rootWeb.Lists[listGuid];
                    //SPListItem item = list.GetItemById(__ItemID);
                }
                catch { }
            });

            return ActivityExecutionStatus.Closed;
            //return base.Execute(executionContext);
        }
    }
}
