var attexamples = attexamples || {};

attexamples.CustomizeFieldRendering = function ()
{

    var fieldJsLinkOverride = {};
    fieldJsLinkOverride.Templates = {};
 
    fieldJsLinkOverride.Templates.Fields =
    {
        // Make sure the Priority field view gets hooked up to the GetPriorityFieldIcon method defined below
        'CustomPriority': { 'View': attexamples.GetPriorityFieldIcon }
    };
 
    // Register the rendering template
    SPClientTemplates.TemplateManager.RegisterTemplateOverrides(fieldJsLinkOverride);
};

attexamples.GetPriorityFieldIcon = function ()
{
    var priority = ctx.CurrentItem.CustomPriority;  

    // In the following section we simply determine what the rendered html output should be. In my case I'm setting an icon.

    if (priority.indexOf("High") != -1) {
        return "<div style='background-color: #FFB5B5; width: 100%; display: block; border: 2px solid #DE0000; padding-left: 2px;'>" + priority + "</div>";
    }

    if (priority.indexOf("Medium") != -1) {
        return "<div style='background-color: #FFFFB5; width: 100%; display: block; border: 2px solid #DEDE00; padding-left: 2px;'>" + priority + "</div>";
    }

    if (priority.indexOf("Low") != -1) {
        return "<div style='background-color: #B5BBFF; width: 100%; display: block; border: 2px solid #2500DE; padding-left: 2px;'>" + priority + "</div>";
    }

    return ctx.CurrentItem.Priority;
};

attexamples.CustomizeFieldRendering();