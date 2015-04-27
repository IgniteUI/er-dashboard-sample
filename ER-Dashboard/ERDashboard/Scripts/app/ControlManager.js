function ControlManager(options) {
    var selector = options.selector;
    var create = options.create;
    var updateData = options.updateData;

    var controlCreated = false;
    var data = null;

    this.hide = function () { $(selector).stop(true, true).hide(); }
    this.show = function () {
        if (!controlCreated) {
            create(data);
            controlCreated = true;
        }
        $(selector).stop(true, true).fadeIn(1000);
    }
    this.update = function (newData) {
        data = newData;
        if (controlCreated)
            updateData(data);
    }
}