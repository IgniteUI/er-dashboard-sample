//  Implements the localization logic for the application
//  Can be used for direct resource string fetching and
//  to update the view automatically where possible.
function Localizer(resources) {
    var dataAttrb = "data-localize";
    if (resources == null)
        throw "No resource object passed to Localizer!";

    var res = resources;
    //  Returns a resource with name localizationKey and
    this.get = function (localizationKey) {
        return res[localizationKey];
    };

    //  Date/Time formatting methods
    this.longDateFormat = function (dateItem) {
        if (res.longDateFormat) {
            return res.longDateFormat(dateItem);
        }
        else {
            return $.ig.formatter(dateItem, "date",
                $.ig.regional.defaults.dateLongPattern + ' ' +
                $.ig.regional.defaults.timeLongPattern);
        }
    }

    this.shortDateFormat = function (dateItem) {
        if (res.shortDateFormat) {
            return res.shortDateFormat(dateItem);
        }
        else {
            return $.ig.formatter(dateItem, "date", $.ig.regional.defaults.datePattern);
        }
    }
    //Returns date in format "dd MMM yyyy"
    this.mainViewDateFormat = function (dateItem) {
        //This parsing is needed for iPad issue when trying to format date string
        var item = new Date(Date.parse(dateItem));
        return $.ig.formatter(item, "date", "dd MMM yyyy");
    }

    //  Finds all DOM elements with attribute data-localize set and
    //  applies the corresponding localization item to the element
    this.localizeView = function (view) {
        var viewResources = res[view];
        // Get all HTML elements that have a resource key.
        $('[' + dataAttrb + ']').each(function () {
            // Get the resource key from the element.
            var resKey = $(this).attr(dataAttrb);
            if (resKey) {
                // Get all the resources that start with the key.
                var resValue = viewResources[resKey];
                if (resKey.indexOf('.') == -1) {
                    // No dot notation in resource key,
                    // assign the resource value to the element's
                    // innerHTML.
                    $(this).html(resValue);
                }
                else {
                    // Dot notation in resource key, assign the
                    // resource value to the element's property
                    // whose name corresponds to the substring
                    // after the dot.
                    var attrKey = resKey.substring(resKey.indexOf('.') + 1);
                    $(this).attr(attrKey) = resValue;
                }
            }
        });
    };
}