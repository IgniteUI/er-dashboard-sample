//  View mode state engine
function ViewMode(options) {
    this.viewMode = options.viewMode;
    this.modeHandlers = options.modeHandlers;
    this.viewModeChanged = options.viewModeChanged;

    this.toggleMode = function (newMode, dataSource) {
        if (newMode != this.viewMode) {
            if(this.modeHandlers[this.viewMode].hide)
                this.modeHandlers[this.viewMode].hide();

            this.viewMode = newMode;
            this.modeHandlers[this.viewMode].show(dataSource);

            if(this.viewModeChanged)
                this.viewModeChanged(this.viewMode);
        }
    };

    this.nextMode = function () {
        var next = this.modeHandlers[this.viewMode].nextMode;
        if ($.isFunction(next)) {
            var n = next();
            this.toggleMode(n);
        }
        else {
            this.toggleMode(next);
        }
    }

    this.UpdateCurrentView = function (dataSource) {
        this.modeHandlers[this.viewMode].show(dataSource);
    }
};
